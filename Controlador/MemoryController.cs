using ModeloMemoriaRam.Modelo;
using System.Collections.Generic;

namespace ModeloMemoriaRam.Controlador
{
    public class MemoryController
    {
        private MemoryModel modelo;

        public MemoryController()
        {
            modelo = new MemoryModel();
        }

        public string ObtenerValor(string direccion)
        {
            return modelo.Leer(direccion);
        }

        public bool AsignarValor(string direccion, string valor)
        {
            return modelo.Escribir(direccion, valor);
        }

        public Dictionary<string, string> ObtenerTodaLaMemoria()
        {
            return modelo.Memory;
        }
    }
}