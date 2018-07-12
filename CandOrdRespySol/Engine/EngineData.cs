﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandOrdRespySol.Engine
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
        public const string Extension = ".mvlm";
        public const string ExtensionFile = "mvlm";
        public const string FiltroFile = " | *.mvlm";
        public const string ArchivoEjecutable = "CandOrdRespySol.exe";
        public const string ProgramaId = "CandOrdRespySol";
        public const string Comando = "open";
        public const string DescripcionPrograma = "CandOrdRespySol File";

        public const string Titulo = "Candidatos Ordenados Respuesta y Solución";

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
