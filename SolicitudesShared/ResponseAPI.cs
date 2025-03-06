using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesShared
{
    internal class ResponseAPI<T>
    {
        public bool Exito { get; set; }
        public string? Mensaje { get; set; }
        public T? Data { get; set; }
    }
}
