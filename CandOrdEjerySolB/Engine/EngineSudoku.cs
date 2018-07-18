using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandOrdEjerySol.Engine
{
    class EngineSudoku
    {
        private int[] pos = new int[2];

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

        public bool ExisteValorIngresado(string[,] plantilla)
        {
            bool existeValor = false;
            for (int f = 0; f <= 8; f++)
            {
                for (int c = 0; c <= 8; c++)
                {
                    if (plantilla[f, c] != null && plantilla[f, c] != string.Empty)
                    {
                        existeValor = true;
                        return existeValor;
                    }
                }
            }
            return existeValor;
        }

        public void ReadWriteTxt(string pathArchivo)
        {
            FileAttributes atributosAnteriores = File.GetAttributes(pathArchivo);
            File.SetAttributes(pathArchivo, atributosAnteriores & ~FileAttributes.ReadOnly);
        }

        public void OnlyReadTxt(string pathArchivo)
        {
            FileAttributes atributosAnteriores = File.GetAttributes(pathArchivo);
            File.SetAttributes(pathArchivo, atributosAnteriores | FileAttributes.ReadOnly);
        }

        public bool StatusOnlyReadTxt(string pathArchivo)
        {
            bool r = false;
            FileAttributes atributos = File.GetAttributes(pathArchivo);
            if ((atributos & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                r = true;
            }
            return r;
        }

        public bool ExiteArchivo(string pathArchivo)
        {
            bool resultado = false;
            if (File.Exists(pathArchivo))
            {
                resultado = true;
            }
            return resultado;
        }

        public void GuardarValoresIngresados(string pathArchivo, string[,] valorIngresado)
        {
            if (pathArchivo != null && pathArchivo != "")
            {
                string[] partes = pathArchivo.Split('\\');
                string nombreArchivo = partes[partes.Length - 1];
                string vLinea = string.Empty;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathArchivo))
                {
                    string vIngresado = string.Empty;
                    for (int f = 0; f <= 8; f++)
                    {
                        for (int c = 0; c <= 8; c++)
                        {
                            if (valorIngresado[f, c] != null && valorIngresado[f, c] != string.Empty)
                            {
                                vIngresado = valorIngresado[f, c].Trim();
                            }
                            else
                            {
                                vIngresado = "0";
                            }
                            if (c == 0) vLinea = vIngresado + "-";
                            else if (c > 0 && c < 8) vLinea = vLinea + vIngresado + "-";
                            else if (c == 8) vLinea = vLinea + vIngresado;
                        }
                        file.WriteLine(vLinea);
                        vLinea = string.Empty;
                    }
                }
            }
        }

        public void GuardarColoresIngresados(string pathArchivo, TextBox[,] cajaTexto)
        {
            if (pathArchivo != null && pathArchivo != "")
            {
                string[] partes = pathArchivo.Split('\\');
                string nombreArchivo = partes[partes.Length - 1];
                string vLinea = string.Empty;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathArchivo, true))
                {
                    string color = string.Empty;
                    for (int f = 0; f <= 8; f++)
                    {
                        for (int c = 0; c <= 8; c++)
                        {
                            if (cajaTexto[f, c].BackColor == Color.SkyBlue)
                            {
                                color = "1";
                            }
                            else if (cajaTexto[f, c].BackColor == Color.CornflowerBlue)
                            {
                                color = "2";
                            }
                            else if (cajaTexto[f, c].BackColor == Color.LightCoral)
                            {
                                color = "3";
                            }
                            else if (cajaTexto[f, c].BackColor == Color.Crimson)
                            {
                                color = "4";
                            }
                            else if (cajaTexto[f, c].BackColor == Color.PaleGreen)
                            {
                                color = "5";
                            }
                            else if (cajaTexto[f, c].BackColor == Color.YellowGreen)
                            {
                                color = "6";
                            }
                            else if (cajaTexto[f, c].BackColor == Color.LightSalmon)
                            {
                                color = "7";
                            }
                            else if (cajaTexto[f, c].BackColor == Color.Orange)
                            {
                                color = "8";
                            }
                            else
                            {
                                color = "0";
                            }
                            if (c == 0) vLinea = color + "-";
                            else if (c > 0 && c < 8) vLinea = vLinea + color + "-";
                            else if (c == 8) vLinea = vLinea + color;
                        }
                        file.WriteLine(vLinea);
                        vLinea = string.Empty;
                    }

                }
            }
        }

        public TextBox[,] SetearTextBoxLimpio(TextBox[,] cajaTexto)
        {
            for (int f = 0; f <= 8; f++)
            {
                for (int c = 0; c <= 8; c++)
                {
                    cajaTexto[f, c].Text = string.Empty;
                }
            }
            return cajaTexto;
        }

    }
}
