using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandRespySol.Engine
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
        public const string Extension = ".aglm";
        public const string ExtensionFile = "aglm";
        public const string FiltroFile = " | *.aglm";
        public const string ArchivoEjecutable = "CandRespySol.exe";
        public const string ProgramaId = "CandRespySol";
        public const string Comando = "open";
        public const string DescripcionPrograma = "CandRespySol File";

        public const string Titulo = "Candidatos Respuesta y Solución";

        public const string Español = "mIEspañol";
        public const string CulturaEspañol = "ES-VE";
        public const string Ingles = "mIIngles";
        public const string CulturaIngles = "EN-US";
        public const string Portugues = "mIPortugues";
        public const string CulturaPortugues = "PT-PT";
        public const string LenguajeEspañol = "Español";
        public const string LenguajeIngles = "Ingles";
        public const string LenguajePortugues = "Portugues";

        public const string Up = "Up";
        public const string Down = "Down";
        public const string Right = "Right";
        public const string Left = "Left";

        public const string TipoLetra = "Microsoft Sans Serif";


        public Color GetColorCeldaAct() { return Color.DarkGray; }

        private string nombreIdioma = string.Empty;

        public void SetNombreIdioma(string v) { nombreIdioma = v; }

        public string GetNombreIdioma() { return nombreIdioma; }

        public string NombreIdiomaCultura(string vCultura)
        {
            switch (vCultura)
            {
                case (CulturaEspañol):
                    nombreIdioma = LenguajeEspañol;
                    break;
                case (CulturaIngles):
                    nombreIdioma = LenguajeIngles;
                    break;
                case (CulturaPortugues):
                    nombreIdioma = LenguajePortugues;
                    break;
                default:
                    nombreIdioma = LenguajeEspañol;
                    break;
            }
            return nombreIdioma;
        }

        private string idioma = string.Empty;

        public void SetIdioma(string v) { idioma = v; }

        public string GetIdioma() { return idioma; }

        public string NombreAbrirJuego(string lenguaje)
        {
            string nombreJuego = string.Empty;
            switch (lenguaje)
            {
                case ("Español"):
                    nombreJuego = "Archivos de Texto" + FiltroFile;
                    break;
                case ("Ingles"):
                    nombreJuego = "Text Files" + FiltroFile;
                    break;
                case ("Portugues"):
                    nombreJuego = "Arquivos de Textos" + FiltroFile;
                    break;
                default:
                    nombreJuego = "Archivos de Texto" + FiltroFile;
                    break;
            }
            return nombreJuego;
        }

        public string TextoAbrirJuego(string lenguaje)
        {
            string nombreJuego = string.Empty;
            switch (lenguaje)
            {
                case ("Español"):
                    nombreJuego = "Abrir Juego";
                    break;
                case ("Ingles"):
                    nombreJuego = "Open Game";
                    break;
                case ("Portugues"):
                    nombreJuego = "Jogo Aberto";
                    break;
                default:
                    nombreJuego = "Abrir Juego";
                    break;
            }
            return nombreJuego;
        }

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
