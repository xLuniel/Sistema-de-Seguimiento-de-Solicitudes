window.excelFunctions = {
    descargarExcel: function (nombreArchivo, base64Archivo) {
        console.log("Iniciando descarga de Excel...");
        const link = document.createElement("a");
        link.download = nombreArchivo;
        link.href = "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64," + base64Archivo;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        console.log("Descarga completada");
    }
};