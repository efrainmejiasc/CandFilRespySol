using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandOrdRespySol.Engine
{
    class EngineSudoku
    {
        private int[] pos = new int[2];
        private EngineData Valor = EngineData.Instance();

        private RegistryKey key = Registry.CurrentUser;

        public bool ExisteClaveRegWin()
        {
            bool respuesta = false;
            string[] subKeys = key.GetSubKeyNames();
            for (int i = 0; i <= subKeys.Length - 1; i++)
            {
                if (subKeys[i].ToString() == EngineData.ClaveRegWin) respuesta = true;
            }
            return respuesta;
        }

        public void AgregarClaveRegWin()
        {
            key = Registry.CurrentUser.CreateSubKey(EngineData.ClaveRegWin);
            key.SetValue(EngineData.FechaDeCreacion, DateTime.Now.ToShortDateString(), RegistryValueKind.String);
            key.SetValue(EngineData.Clave, EngineData.ClaveRegWin, RegistryValueKind.String);
            key.Close();
        }

        public void AsociarExtension()
        {
            if (GetProgIdFromExtension(EngineData.Extension) == null && GetProgIdFromExtension(EngineData.Extension) == string.Empty)
            {
                LinkExtension(EngineData.Extension, EngineData.ArchivoEjecutable, EngineData.ProgramaId, EngineData.Comando, EngineData.DescripcionPrograma);
            }
        }

        private string GetProgIdFromExtension(string extension)
        {
            string strProgramID = string.Empty;
            using (RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(extension))
            {
                if (registryKey?.GetValue(string.Empty) != null)
                {
                    strProgramID = registryKey.GetValue(string.Empty).ToString();
                    registryKey.Close();
                }
            }
            return strProgramID;
        }

        public void LinkExtension(string extension, string executableFileName, string programId, string command, string description)
        {
            string linkedProgramID;
            RegistryKey registryKey = null;
            RegistryKey registryKeyShell = null;

            if (string.IsNullOrEmpty(command))
                command = EngineData.Comando;
            if (string.IsNullOrEmpty(description))
                description = $"{extension} Descripción de {programId}";
            if (!extension.StartsWith("."))
                extension = "." + extension;

            linkedProgramID = GetProgIdFromExtension(extension);
            if (string.IsNullOrEmpty(linkedProgramID) || linkedProgramID.Length == 0)
            {
                registryKey = Registry.ClassesRoot.CreateSubKey(extension);
                registryKey?.SetValue(string.Empty, programId);
                registryKey = Registry.ClassesRoot.CreateSubKey(programId);
                registryKey?.SetValue(string.Empty, description);
                registryKeyShell = registryKey?.CreateSubKey($"shell\\{command}\\command");
            }
            else
            {
                registryKey = Registry.ClassesRoot.OpenSubKey(linkedProgramID, true);
                registryKeyShell = registryKey?.OpenSubKey($"shell\\{command}\\command", true);
                if (registryKeyShell == null)
                    registryKeyShell = registryKey?.CreateSubKey(programId);

            }
            if (registryKeyShell != null)
            {
                registryKeyShell.SetValue(string.Empty, $"\"{executableFileName}\" \"%1\"");
                registryKeyShell.Close();
            }
        }

        public TextBox[,] SetearTextColorInicio(TextBox[,] cajaTexto)
        {
            for (int f = 0; f <= 8; f++)
            {
                for (int c = 0; c <= 8; c++)
                {
                    cajaTexto[f, c].BackColor = Color.WhiteSmoke;
                }
            }
            return cajaTexto;
        }

        public Button[] ColoresPincel(Button[] v)
        {
            v[0].BackColor = Color.Silver;
            v[1].BackColor = Color.SkyBlue;
            v[2].BackColor = Color.CornflowerBlue;
            v[3].BackColor = Color.LightCoral;
            v[4].BackColor = Color.Crimson;

            v[5].BackColor = Color.PaleGreen;
            v[6].BackColor = Color.YellowGreen;
            v[7].BackColor = Color.LightSalmon;
            v[8].BackColor = Color.Orange;
            return v;
        }

        public TextBox[,] SetearTextBoxLimpio(TextBox[,] cajaTexto)
        {
            for (int f = 0; f <= 8; f++)
            {
                for (int c = 0; c <= 8; c++)
                {
                    cajaTexto[f, c].Text = string.Empty;
                    cajaTexto[f, c].BackColor = Color.WhiteSmoke;
                }
            }
            return cajaTexto;
        }

        public ArrayList AbrirValoresArchivo(string pathArchivo)
        {
            ArrayList arrText = new ArrayList();
            String sLine = string.Empty;
            try
            {
                System.IO.StreamReader objReader = new System.IO.StreamReader(pathArchivo);
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null) arrText.Add(sLine);
                }
                objReader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            return arrText;
        }

        public string[,] SetValorNumeros(ArrayList arrText, string[,] valorNumeros)
        {
            valorNumeros = new string[9, 9];
            for (int f = 0; f <= 8; f++)
            {
                string[] lineaVector = arrText[f].ToString().Split('-');

                if (f >= 0 && f <= 8)
                {
                    if (lineaVector.Length != 9) return valorNumeros;
                    for (int columna = 0; columna <= 8; columna++)
                    {
                        if (lineaVector[columna] != "0")
                        {
                            valorNumeros[f, columna] = lineaVector[columna];
                        }
                    }
                }

            }
            return valorNumeros;
        }

        public string[,] SetValorSolucion(ArrayList arrText, string[,] valorSolucion)
        {
            valorSolucion = new string[9, 9];
            for (int f = 0; f <= 17; f++)
            {
                string[] lineaVector = arrText[f].ToString().Split('-');

                if (f >= 9 && f <= 17)
                {
                    if (lineaVector.Length != 9) return valorSolucion;
                    for (int columna = 0; columna <= 8; columna++)
                    {
                        if (lineaVector[columna] != "0")
                        {
                            valorSolucion[f - 9, columna] = lineaVector[columna];
                        }
                    }
                }

            }
            return valorSolucion;
        }

        public string[,] SetValorRespuesta(ArrayList arrText, string[,] valorRespuesta)
        {
            valorRespuesta = new string[9, 9];
            int fila = 0;
            for (int f = 0; f <= 26; f++)
            {
                if (f >= 18 && f <= 26)
                {
                    string[] lineaVector = arrText[f].ToString().Split('-');
                    if (lineaVector.Length != 9) return valorRespuesta;
                    for (int columna = 0; columna <= 8; columna++)
                    {
                        if (lineaVector[columna] != "0")
                        {
                            valorRespuesta[fila, columna] = lineaVector[columna];
                        }
                    }
                    fila++;
                }
            }
            return valorRespuesta;
        }

        public TextBox[,] SetearTextBoxJuego(TextBox[,] cajaTexto, string[,] vIngresado)
        {
            for (int f = 0; f <= 8; f++)
            {
                for (int c = 0; c <= 8; c++)
                {
                    if (vIngresado[f, c] != null && vIngresado[f, c] != string.Empty)
                    {
                        cajaTexto[f, c].Text = vIngresado[f, c];
                        cajaTexto[f, c].Font = new Font(EngineData.TipoLetra, 20);
                        cajaTexto[f, c].ForeColor = Color.Blue;

                    }
                    cajaTexto[f, c].TextAlign = HorizontalAlignment.Center;
                }
            }
            return cajaTexto;
        }

        public TextBox[,] SetearTextColor(TextBox[,] cajaTexto, string[,] vColor)
        {
            for (int f = 0; f <= 8; f++)
            {
                for (int c = 0; c <= 8; c++)
                {
                    if (vColor[f, c] == "1")
                    {
                        cajaTexto[f, c].BackColor = Color.SkyBlue;
                    }
                    else if (vColor[f, c] == "2")
                    {
                        cajaTexto[f, c].BackColor = Color.CornflowerBlue;
                    }
                    else if (vColor[f, c] == "3")
                    {
                        cajaTexto[f, c].BackColor = Color.LightCoral;
                    }
                    else if (vColor[f, c] == "4")
                    {
                        cajaTexto[f, c].BackColor = Color.Crimson;
                    }
                    else if (vColor[f, c] == "5")
                    {
                        cajaTexto[f, c].BackColor = Color.PaleGreen;
                    }
                    else if (vColor[f, c] == "6")
                    {
                        cajaTexto[f, c].BackColor = Color.YellowGreen;
                    }
                    else if (vColor[f, c] == "7")
                    {
                        cajaTexto[f, c].BackColor = Color.LightSalmon;
                    }
                    else if (vColor[f, c] == "8")
                    {
                        cajaTexto[f, c].BackColor = Color.Orange;
                    }
                    else
                    {
                        cajaTexto[f, c].BackColor = Color.WhiteSmoke;
                    }
                }
            }

            return cajaTexto;
        }

        public int[] Position(string sentido, int f, int c)
        {
            switch (sentido)
            {
                case "Up":
                    pos[0] = f - 1; pos[1] = c;
                    break;
                case "Down":
                    pos[0] = f + 1; pos[1] = c;
                    break;
                case "Right":
                    pos[0] = f; pos[1] = c + 1;
                    break;
                case "Left":
                    pos[0] = f; pos[1] = c - 1;
                    break;
            }
            return pos;
        }

        public string NombreJuego(string pathArchivo)
        {
            string[] partes = pathArchivo.Split('\\');
            string nombreArchivo = partes[partes.Length - 1];
            string[] nombreJuego = nombreArchivo.Split('.');
            return nombreJuego[0];
        }

    }
}
