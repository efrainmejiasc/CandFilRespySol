﻿using CandFilRespySol.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandFilRespySol
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        //***********************************************************************************************************
        private EngineSudoku Funcion = new EngineSudoku();
        private EngineData Valor = EngineData.Instance();


        private TextBox[,] txtSudoku = new TextBox[9, 9]; //ARRAY CONTENTIVO DE LOS TEXTBOX DEL GRAFICO DEL SUDOKU
        private TextBox[,] txtSudoku2 = new TextBox[9, 9]; //ARRAY CONTENTIVO DE LOS TEXTBOX DEL GRAFICO DE CANDIDATOS
        private Button[] btnPincel = new Button[9];// ARRAY CONTENTIVO DE LOS BOTONES DE PINCELES IZQUIERDO
        private string[,] valorNumeros = new string[9, 9];
        private string[,] valorSolucion = new string[9, 9];
        private string[,] valorRespuesta = new string[9, 9];
        private string pathArchivo = string.Empty;
        private bool pincelMarcador = false;
        private Color colorFondoAct;
        private Color colorCeldaAnt;
        bool borrado = false;
        bool comparacion = false;


        private int[] position = new int[2];
        int row = -1;
        int col = -1;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Engine.EngineData.Titulo;
            if (!Funcion.ExisteClaveRegWin()) { Funcion.AgregarClaveRegWin(); }
            Funcion.AsociarExtension();
            AsociarTxtMatriz(txtSudoku);
            AsociarTxtMatriz2(txtSudoku2);
            AsociarBtnPincel(btnPincel);
            Funcion.ColoresPincel(btnPincel);
            if (Valor.GetPathArchivo() != null && Valor.GetPathArchivo() != string.Empty)
            {
                AbrirJuego(Valor.GetPathArchivo());
            }
        }

        private TextBox[,] AsociarTxtMatriz(TextBox[,] txtSudoku)
        {
            /////////////////////////////////////////////////////////////////////////////
            txtSudoku[0, 0] = txt00; txtSudoku[0, 1] = txt01; txtSudoku[0, 2] = txt02;
            txtSudoku[1, 0] = txt10; txtSudoku[1, 1] = txt11; txtSudoku[1, 2] = txt12;
            txtSudoku[2, 0] = txt20; txtSudoku[2, 1] = txt21; txtSudoku[2, 2] = txt22;

            txtSudoku[0, 3] = txt03; txtSudoku[0, 4] = txt04; txtSudoku[0, 5] = txt05;
            txtSudoku[1, 3] = txt13; txtSudoku[1, 4] = txt14; txtSudoku[1, 5] = txt15;
            txtSudoku[2, 3] = txt23; txtSudoku[2, 4] = txt24; txtSudoku[2, 5] = txt25;

            txtSudoku[0, 6] = txt06; txtSudoku[0, 7] = txt07; txtSudoku[0, 8] = txt08;
            txtSudoku[1, 6] = txt16; txtSudoku[1, 7] = txt17; txtSudoku[1, 8] = txt18;
            txtSudoku[2, 6] = txt26; txtSudoku[2, 7] = txt27; txtSudoku[2, 8] = txt28;
            ////////////////////////////////////////////////////////////////////////////
            txtSudoku[3, 0] = txt30; txtSudoku[3, 1] = txt31; txtSudoku[3, 2] = txt32;
            txtSudoku[4, 0] = txt40; txtSudoku[4, 1] = txt41; txtSudoku[4, 2] = txt42;
            txtSudoku[5, 0] = txt50; txtSudoku[5, 1] = txt51; txtSudoku[5, 2] = txt52;

            txtSudoku[3, 3] = txt33; txtSudoku[3, 4] = txt34; txtSudoku[3, 5] = txt35;
            txtSudoku[4, 3] = txt43; txtSudoku[4, 4] = txt44; txtSudoku[4, 5] = txt45;
            txtSudoku[5, 3] = txt53; txtSudoku[5, 4] = txt54; txtSudoku[5, 5] = txt55;

            txtSudoku[3, 6] = txt36; txtSudoku[3, 7] = txt37; txtSudoku[3, 8] = txt38;
            txtSudoku[4, 6] = txt46; txtSudoku[4, 7] = txt47; txtSudoku[4, 8] = txt48;
            txtSudoku[5, 6] = txt56; txtSudoku[5, 7] = txt57; txtSudoku[5, 8] = txt58;
            ////////////////////////////////////////////////////////////////////////////
            txtSudoku[6, 0] = txt60; txtSudoku[6, 1] = txt61; txtSudoku[6, 2] = txt62;
            txtSudoku[7, 0] = txt70; txtSudoku[7, 1] = txt71; txtSudoku[7, 2] = txt72;
            txtSudoku[8, 0] = txt80; txtSudoku[8, 1] = txt81; txtSudoku[8, 2] = txt82;

            txtSudoku[6, 3] = txt63; txtSudoku[6, 4] = txt64; txtSudoku[6, 5] = txt65;
            txtSudoku[7, 3] = txt73; txtSudoku[7, 4] = txt74; txtSudoku[7, 5] = txt75;
            txtSudoku[8, 3] = txt83; txtSudoku[8, 4] = txt84; txtSudoku[8, 5] = txt85;

            txtSudoku[6, 6] = txt66; txtSudoku[6, 7] = txt67; txtSudoku[6, 8] = txt68;
            txtSudoku[7, 6] = txt76; txtSudoku[7, 7] = txt77; txtSudoku[7, 8] = txt78;
            txtSudoku[8, 6] = txt86; txtSudoku[8, 7] = txt87; txtSudoku[8, 8] = txt88;
            ////////////////////////////////////////////////////////////////////////////
            foreach (TextBox item in txtSudoku)
            {
                item.GotFocus += delegate { HideCaret(item.Handle); };
                //item.ReadOnly = EngineData.Verdadero;
            }
            return txtSudoku;
        }

        private TextBox[,] AsociarTxtMatriz2(TextBox[,] txtSudoku2)
        {
            /////////////////////////////////////////////////////////////////////////////
            txtSudoku2[0, 0] = t00; txtSudoku2[0, 1] = t01; txtSudoku2[0, 2] = t02;
            txtSudoku2[1, 0] = t10; txtSudoku2[1, 1] = t11; txtSudoku2[1, 2] = t12;
            txtSudoku2[2, 0] = t20; txtSudoku2[2, 1] = t21; txtSudoku2[2, 2] = t22;

            txtSudoku2[0, 3] = t03; txtSudoku2[0, 4] = t04; txtSudoku2[0, 5] = t05;
            txtSudoku2[1, 3] = t13; txtSudoku2[1, 4] = t14; txtSudoku2[1, 5] = t15;
            txtSudoku2[2, 3] = t23; txtSudoku2[2, 4] = t24; txtSudoku2[2, 5] = t25;

            txtSudoku2[0, 6] = t06; txtSudoku2[0, 7] = t07; txtSudoku2[0, 8] = t08;
            txtSudoku2[1, 6] = t16; txtSudoku2[1, 7] = t17; txtSudoku2[1, 8] = t18;
            txtSudoku2[2, 6] = t26; txtSudoku2[2, 7] = t27; txtSudoku2[2, 8] = t28;
            ////////////////////////////////////////////////////////////////////////////
            txtSudoku2[3, 0] = t30; txtSudoku2[3, 1] = t31; txtSudoku2[3, 2] = t32;
            txtSudoku2[4, 0] = t40; txtSudoku2[4, 1] = t41; txtSudoku2[4, 2] = t42;
            txtSudoku2[5, 0] = t50; txtSudoku2[5, 1] = t51; txtSudoku2[5, 2] = t52;

            txtSudoku2[3, 3] = t33; txtSudoku2[3, 4] = t34; txtSudoku2[3, 5] = t35;
            txtSudoku2[4, 3] = t43; txtSudoku2[4, 4] = t44; txtSudoku2[4, 5] = t45;
            txtSudoku2[5, 3] = t53; txtSudoku2[5, 4] = t54; txtSudoku2[5, 5] = t55;

            txtSudoku2[3, 6] = t36; txtSudoku2[3, 7] = t37; txtSudoku2[3, 8] = t38;
            txtSudoku2[4, 6] = t46; txtSudoku2[4, 7] = t47; txtSudoku2[4, 8] = t48;
            txtSudoku2[5, 6] = t56; txtSudoku2[5, 7] = t57; txtSudoku2[5, 8] = t58;
            ////////////////////////////////////////////////////////////////////////////
            txtSudoku2[6, 0] = t60; txtSudoku2[6, 1] = t61; txtSudoku2[6, 2] = t62;
            txtSudoku2[7, 0] = t70; txtSudoku2[7, 1] = t71; txtSudoku2[7, 2] = t72;
            txtSudoku2[8, 0] = t80; txtSudoku2[8, 1] = t81; txtSudoku2[8, 2] = t82;

            txtSudoku2[6, 3] = t63; txtSudoku2[6, 4] = t64; txtSudoku2[6, 5] = t65;
            txtSudoku2[7, 3] = t73; txtSudoku2[7, 4] = t74; txtSudoku2[7, 5] = t75;
            txtSudoku2[8, 3] = t83; txtSudoku2[8, 4] = t84; txtSudoku2[8, 5] = t85;

            txtSudoku2[6, 6] = t66; txtSudoku2[6, 7] = t67; txtSudoku2[6, 8] = t68;
            txtSudoku2[7, 6] = t76; txtSudoku2[7, 7] = t77; txtSudoku2[7, 8] = t78;
            txtSudoku2[8, 6] = t86; txtSudoku2[8, 7] = t87; txtSudoku2[8, 8] = t88;
            ////////////////////////////////////////////////////////////////////////////
            foreach (TextBox item in txtSudoku2)
            {
                item.GotFocus += delegate { HideCaret(item.Handle); };
                //item.ReadOnly = true;
            }
            return txtSudoku2;
        }

        private Button[] AsociarBtnPincel(Button[] btnPincel)
        {
            btnPincel[0] = pincelA; btnPincel[1] = pincelB;
            btnPincel[2] = pincelC; btnPincel[3] = pincelD;
            btnPincel[4] = pincelE;

            btnPincel[5] = pincelG;
            btnPincel[6] = pincelH; btnPincel[7] = pincelI;
            btnPincel[8] = pincelJ;

            return btnPincel;
        }

        private void Lenguaje_Click(object sender, EventArgs e)
        {
            EngineData Valor = EngineData.Instance();
            ToolStripMenuItem toolStrip = sender as ToolStripMenuItem;
            switch (toolStrip.Name)
            {
                case (EngineData.Español):
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(EngineData.CulturaEspañol);
                    Valor.SetIdioma(EngineData.CulturaEspañol);
                    Valor.SetNombreIdioma(EngineData.LenguajeEspañol);
                    break;
                case (EngineData.Ingles):
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(EngineData.CulturaIngles);
                    Valor.SetIdioma(EngineData.CulturaIngles);
                    Valor.SetNombreIdioma(EngineData.LenguajeIngles);
                    break;
                case (EngineData.Portugues):
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(EngineData.CulturaPortugues);
                    Valor.SetIdioma(EngineData.CulturaPortugues);
                    Valor.SetNombreIdioma(EngineData.LenguajePortugues);
                    break;
            }
            AplicarIdioma();
        }

        private void AplicarIdioma()
        {
            this.MaximumSize = new Size(1161, 680);
            this.Size = new Size(1161, 680);
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            if (pathArchivo == string.Empty)
            {
                this.Text = CandFilRespySol1.RecursosLocalizables.StringResources.thisText;
            }
            else
            {
                this.Text = CandFilRespySol1.RecursosLocalizables.StringResources.thisText + " : " + Funcion.NombreJuego(pathArchivo);
            }
            mIdiomas.Text = CandFilRespySol1.RecursosLocalizables.StringResources.mIdiomas;
            mIEspañol.Text = CandFilRespySol1.RecursosLocalizables.StringResources.mIEspañol;
            mIIngles.Text = CandFilRespySol1.RecursosLocalizables.StringResources.mIIngles;
            mIPortugues.Text = CandFilRespySol1.RecursosLocalizables.StringResources.mIPortugues;
            mRS.Text = CandFilRespySol1.RecursosLocalizables.StringResources.mRS;
            mIAbrir.Text = CandFilRespySol1.RecursosLocalizables.StringResources.mIAbrir;
            mIComparar.Text = CandFilRespySol1.RecursosLocalizables.StringResources.mIComparar;
            label1.Text = CandFilRespySol1.RecursosLocalizables.StringResources.label1;
            label2.Text = CandFilRespySol1.RecursosLocalizables.StringResources.label2;
        }

        private void ColorMarcador_Click(object sender, EventArgs e)
        {
            Button pincel = (Button)sender;
            if (pincel.BackColor == Color.Silver)
            {
                pincelMarcador = false;
                txtSudoku = Funcion.SetearTextColorInicio(txtSudoku);
                //txtSudoku2 = Funcion.SetearTextColorInicio(txtSudoku2);
                btnSelectColor.BackColor = Color.Silver;
                btnSelectColor.FlatAppearance.BorderColor = Color.Silver;
                btnSelectColor.FlatAppearance.BorderSize = 2;
            }
            else
            {
                pincelMarcador = true;
                colorFondoAct = pincel.BackColor;
                btnSelectColor.BackColor = colorFondoAct;
                btnSelectColor.FlatAppearance.BorderColor = Color.Black;
                btnSelectColor.FlatAppearance.BorderSize = 2;
            }
        }

        //****************************************************************************************
        private void txt00_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Select(0, 0);
            row = Int32.Parse(txt.Name.Substring(3, 1));
            col = Int32.Parse(txt.Name.Substring(4, 1));

            if (pincelMarcador)
            {
                txtSudoku[row, col].BackColor = colorFondoAct;
            }
            else
            {
                colorCeldaAnt = txt.BackColor;
                txt.BackColor = Valor.GetColorCeldaAct();
            }
        }

        private void txt00_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            row = Int32.Parse(txt.Name.Substring(3, 1));
            col = Int32.Parse(txt.Name.Substring(4, 1));

            txt.ForeColor = Color.Blue;

            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
                if (txt.Text.Length > 0) { txt.Text = string.Empty; }
            }
        }

        private void txt00_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            row = Int32.Parse(txt.Name.Substring(3, 1));
            col = Int32.Parse(txt.Name.Substring(4, 1));
            
            txt.Text = valorNumeros[row, col];
 

            string sentido = e.KeyCode.ToString();
            if (sentido == EngineData.Up || sentido == EngineData.Down || sentido == EngineData.Right || sentido == EngineData.Left)
            {
                try
                {
                    position = Funcion.Position(sentido, row, col);
                    txtSudoku[position[0], position[1]].Focus();
                }
                catch { txtSudoku[row, col].Focus(); }
                return;
            }
        }

        private void txt00_DoubleClick(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Select(0, 0);
            txt.BackColor = Color.WhiteSmoke;
            borrado = true;
        }

        private void txt00_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            row = Int32.Parse(txt.Name.Substring(3, 1));
            col = Int32.Parse(txt.Name.Substring(4, 1));
            if (!pincelMarcador)
            {
                txt.BackColor = colorCeldaAnt;
            }
            else
            {
                if (txt.Text == string.Empty || borrado == true)
                {
                    txt.BackColor = Color.WhiteSmoke;
                    borrado = false;
                }
                else if (txt.Text != string.Empty && borrado == false)
                {
                    txt.BackColor = colorFondoAct;
                }
            }
        }

        //****************************************************************************************

        private void t00_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Select(0, 0);
            row = Int32.Parse(txt.Name.Substring(1, 1));
            col = Int32.Parse(txt.Name.Substring(2, 1));

            colorCeldaAnt = txt.BackColor;
            txt.BackColor = Valor.GetColorCeldaAct();
        }

        private void t00_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Select(0, 0);

            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
                if (txt.Text.Length > 0) { txt.Text = string.Empty; }
            }
            txt.Text = string.Empty;
        }

        private void t00_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Select(0, 0);
            row = Int32.Parse(txt.Name.Substring(1, 1));
            col = Int32.Parse(txt.Name.Substring(2, 1));

            if (comparacion)
            {
                txtSudoku2 = Funcion.SetearTextBoxJuego(txtSudoku2, valorNumeros);
                txtSudoku2 = Funcion.SetearTextColor(txtSudoku2, valorSolucion);
            }
            else
            {
                txt.BackColor = Color.WhiteSmoke;
            }

            string sentido = e.KeyCode.ToString();
            if (sentido == EngineData.Up || sentido == EngineData.Down || sentido == EngineData.Right || sentido == EngineData.Left)
            {
                try
                {
                    position = Funcion.Position(sentido, row, col);
                    txtSudoku2[position[0], position[1]].Focus();
                }
                catch { txtSudoku2[row, col].Focus(); }
                return;
            }
        }

        private void t00_DoubleClick(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Select(0, 0);
            txt.BackColor = colorCeldaAnt;
        }

        private void t00_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            row = Int32.Parse(txt.Name.Substring(1, 1));
            col = Int32.Parse(txt.Name.Substring(2, 1));
            if (comparacion)
            {
                txtSudoku2 = Funcion.SetearTextBoxJuego(txtSudoku2, valorNumeros);
                txtSudoku2 = Funcion.SetearTextColor(txtSudoku2, valorSolucion);
            }
            else
            {
                txt.BackColor = Color.WhiteSmoke;
            }
        }

        // *****************************************************************************************************

        private void abrirEjercicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pathArchivo = null;
            string nombreIdioma = Valor.GetNombreIdioma();
            this.openFileDialog1.FileName = string.Empty;
            this.openFileDialog1.Filter = Valor.NombreAbrirJuego(nombreIdioma);
            this.openFileDialog1.Title = Valor.TextoAbrirJuego(nombreIdioma);
            this.openFileDialog1.DefaultExt = EngineData.ExtensionFile;
            this.openFileDialog1.ShowDialog();
            pathArchivo = openFileDialog1.FileName;

            if (pathArchivo == string.Empty)
            {
                return;
            }
            AbrirJuego(pathArchivo);
            this.Text = CandFilRespySol1.RecursosLocalizables.StringResources.thisText + " : " + Funcion.NombreJuego(pathArchivo);
        }

        private void AbrirJuego(string pathArchivo)
        {
            Valor.SetPathArchivo(pathArchivo);
            txtSudoku = Funcion.SetearTextBoxLimpio(txtSudoku);
            txtSudoku2 = Funcion.SetearTextBoxLimpio(txtSudoku2);
            ArrayList arrText = Funcion.AbrirValoresArchivo(pathArchivo);
            valorNumeros = Funcion.SetValorNumeros(arrText, valorNumeros);
            valorSolucion = Funcion.SetValorSolucion(arrText, valorSolucion);
            //valorRespuesta = Funcion.SetValorRespuesta(arrText, valorRespuesta);
            txtSudoku = Funcion.SetearTextBoxJuego(txtSudoku, valorNumeros);
            btnSelectColor.BackColor = Color.Silver;
            btnSelectColor.FlatAppearance.BorderColor = Color.Silver;
            btnSelectColor.FlatAppearance.BorderSize = 1;
            comparacion = false;
        }

        private void mIComparar_Click(object sender, EventArgs e)
        {
            txtSudoku2 = Funcion.SetearTextBoxLimpio(txtSudoku2);
            txtSudoku2 = Funcion.SetearTextBoxJuego(txtSudoku2, valorNumeros);
            txtSudoku2 = Funcion.SetearTextColor(txtSudoku2, valorSolucion);
            comparacion = true;
            //txtSudoku2 = Funcion.SetearTextColor(txtSudoku2, valorRespuesta);
        }

        //***************************************************************************************
    }
}
