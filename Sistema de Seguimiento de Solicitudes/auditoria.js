const puppeteer = require('puppeteer');
const fs = require('fs');
const path = require('path');

// Define las rutas a auditar
const rutas = [
    '/login',
    '/menu',
    '/menu/modulo-solicitudes',
    '/menu/modulo-solicitudes/inicio-solicitudes',
    '/menu/modulo-solicitudes/indice-expedientes',
    '/menu/modulo-solicitudes/indice-expedientes/detalles/{id:int}/{folio}',
    '/menu/modulo-solicitudes/historial-solicitudes',
    '/menu/modulo-solicitudes/Calendario',
    '/menu/modulo-solicitudes/CreacionUsuarios'
];

// URL base (ajústala a tu servidor)
const baseUrl = 'https://localhost:7125';

(async () => {
    const browser = await puppeteer.launch({ headless: true });

    // Crear carpeta si no existe
    const carpetaReportes = path.join(__dirname, 'Reportes Accesibilidad');
    if (!fs.existsSync(carpetaReportes)) {
        fs.mkdirSync(carpetaReportes, { recursive: true });
    }

    for (const ruta of rutas) {
        const page = await browser.newPage();
        const urlCompleta = `${baseUrl}${ruta}`;

        await page.goto(urlCompleta, { waitUntil: 'networkidle0' });

        // Inyectar axe
        const axeSource = fs.readFileSync(require.resolve('axe-core'), 'utf8');
        await page.evaluate(axeSource);

        const results = await page.evaluate(async () => {
            return await axe.run();
        });

        // Convertir ruta en nombre de archivo seguro
        const nombreArchivo = `reporte_${ruta.replace(/\//g, '-').replace(/^-/, '')}.json`;

        const filePath = path.join(carpetaReportes, nombreArchivo);
        fs.writeFileSync(filePath, JSON.stringify(results, null, 2));
        console.log(`✅ Auditoría completada: ${ruta} -> ${nombreArchivo}`);

        await page.close();
    }

    await browser.close();
})();
