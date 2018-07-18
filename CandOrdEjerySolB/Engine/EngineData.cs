using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandOrdEjerySol.Engine
{
    class EngineData
    {
        private static EngineData valor;

        public static EngineData Instance()
        {
            if ((valor == null))
            {
                valor = new EngineData();
            }
            return valor;
        }

        public static string Titulo = "Candidatos Ordenados Ejercicio y Solución";
        public const string Up = "Up";
        public const string Down = "Down";
        public const string Right = "Right";
        public const string Left = "Left";

        public Color GetColorCeldaAct() { return Color.DarkGray; }

        private string pathArchivo = string.Empty;

        public string GetPathArchivo()
        {
            return pathArchivo;
        }

        public void SetPathArchivo(string pArchivo)
        {
            pathArchivo = pArchivo;
        }
    }
}
