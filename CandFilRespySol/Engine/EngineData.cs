using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandFilRespySol.Engine
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

        public const string ClaveRegWin = "CandFilRespySol";
        public const string FechaDeCreacion = "FechaDeCreacion";
        public const string Clave = "Clave";
        public const string Extension = ".mflm";
        public const string ArchivoEjecutable = "CandFilRespySol.exe";
        public const string ProgramaId = "CandFilRespySol";
        public const string Comando = "open";
        public const string DescripcionPrograma = "CandFilRespySol File";

        public const string Titulo = "Candidatos Filtrados Respuesta y Solución";

    }
}
