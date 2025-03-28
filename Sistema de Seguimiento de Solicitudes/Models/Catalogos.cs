namespace Sistema_de_Seguimiento_de_Solicitudes.Models
{
    public class Catalogos
    {
        public static readonly List<string> MesesAdmision = new()
            {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            };

        public static readonly List<string> Estatuses = new()
            {
                "En proceso", "Pendiente", "Terminado","Cancelado"
            };

        public static readonly List<string> Ciudades = new()
            {
                "Tijuana", "Mexicali", "Ensenada", "Rosarito", "Tecate"
            };

        public static readonly List<string> Cobros = new()
            {
                "Ninguno", "Si"
            };
    }
}
