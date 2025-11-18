using System.Collections.Generic;

namespace ModeloMemoriaRam.Modelo
{
    public class MemoryModel
    {
        public Dictionary<string, string> Memory { get; private set; }

        public MemoryModel()
        {
            Memory = new Dictionary<string, string>();
            InicializarMemoria();
        }

        private void InicializarMemoria()
        {
            for (int i = 0x00; i <= 0xFF; i++)
            {
                string direccion = $"0x{i:X2}";
                Memory[direccion] = "00"; // Valor por defecto
            }
        }

        public string Leer(string direccion)
        {
            return Memory.ContainsKey(direccion) ? Memory[direccion] : null;
        }

        public bool Escribir(string direccion, string valor)
        {
            if (Memory.ContainsKey(direccion))
            {
                Memory[direccion] = valor;
                return true;
            }
            return false;
        }
    }
}
