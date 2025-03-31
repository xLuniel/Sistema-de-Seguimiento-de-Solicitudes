namespace Sistema_de_Seguimiento_de_Solicitudes.Models
{
    public class Catalogos
    {
        //Etapa Inicial

        public static readonly List<string> MesesAdmision = new()
            {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            };

        public static readonly List<string> Estatuses = new()
            {
                "En proceso", "Pendiente", "Terminado", "Cancelado"
            };

        public static readonly List<string> TiposSolicitud = new()
            {
                "DAI", "ARCO"
            };

        public static readonly List<string> SolicitudARCO = new()
            {
                "ACCESO", "RECTIFICACION", "CANCELACION",
                "OPOSICION"
            };

        public static readonly List<string> Ampliacion = new()
            {
                "SI", "NO"
            };

        // Etapa final

        public static readonly List<string> Ciudades = new()
            {
                "Tijuana", "Mexicali", "Ensenada", "Rosarito", "Tecate"
            };

        public static readonly List<string> Cobros = new()
            {
                "Ninguno", "Si"
            };

        public static readonly List<string> SentidoRespuesta = new()
            {
                "AFIRMATIVA", "RESERVADA", "CONFIDENCIAL", "TOTAL INCOMPETENCIA",
                "PARCIAL INCOMPETENCIA", "NOTORIA INCOMPETENCIA", "IMPROCEDENCIA",
                "INEXISTENCIA", "DESECHADA", "OTRO"
            };

        public static readonly List<string> Materia = new()
            {
                "CIVIL", "FAMILIAR", "MERCANTIL", "LABORAL", "PENAL", "PENAL ORAL", "OTRO"
            };

        public static readonly List<string> Tematica = new()
            {
                "ACTIVIDADES DEL CJE", "ACTIVIDADES DEL TSJ",
                "ACTIVIDADES DE LOS ÓRGANOS JURISDICCIONALES DE PRIMERA INSTANCIA",
                "ADMINISTRACIÓN JUDICIAL", "DATOS PERSONALES", "DESECHADA",
                "IMPROCEDENCIA", "INCOMPETENCIA", "INFORMACIÓN ESTADÍSTICA",
                "MANEJO PRESUPUESTAL", "NOTORIA INCOMPETENCIA", "ORIENTACIÓN",
                "PRESTACIONES LABORALES", "USO DE RECURSOS PÚBLICOS"
            };
    }
}
