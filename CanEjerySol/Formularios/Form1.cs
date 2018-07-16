using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanEjerySol
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        //***********************************************************************************************************
        private Engine.EngineSudoku Funcion = new Engine.EngineSudoku();
        private Engine.EngineData Valor = Engine.EngineData.Instance();
        private TextBox[,] txtSudoku = new TextBox[9, 9]; //ARRAY CONTENTIVO DE LOS TEXTBOX DEL GRAFICO DEL SUDOKU
        private Button[] btnPincel = new Button[9];// ARRAY CONTENTIVO DE LOS BOTONES DE PINCELES IZQUIERDO
        private string[,] valorIngresado = new string[9, 9];//ARRAY CONTENTIVO DE LOS VALORES INGRESADOS 
        private string[,] valorVacios = new string[9, 9];
        private bool pincelMarcador = false;
        private Color colorFondoAct;
        private Color colorCeldaAnt;
        private int[] position = new int[2];
        int row = -1;
        int col = -1;
        string pathArchivo = string.Empty;
        ListBox lista = new ListBox();
        bool borrado = false;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Date > Convert.ToDateTime("13/08/2018", System.Globalization.CultureInfo.GetCultureInfo("es-ES"))) { Application.Exit(); }
            this.Text = Engine.EngineData.Titulo;
            label1.Text = "EJERCICIO Y SOLUCION";
            txtSudoku = AsociarTxtMatriz(txtSudoku);
            btnPincel = AsociarBtnPincel(btnPincel);
            btnPincel = Funcion.ColoresPincel(btnPincel);
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

        private void ColorMarcador_Click(object sender, EventArgs e)
        {
            Button pincel = (Button)sender;
            if (pincel.BackColor == Color.Silver)
            {
                pincelMarcador = false;
                txtSudoku = Funcion.SetearTextColorInicio(txtSudoku);
                btnSelectColor.BackColor = Color.Silver;
                btnSelectColor.FlatAppearance.BorderColor = Color.Silver;
                btnSelectColor.FlatAppearance.BorderSize = 1;
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

        //***************************************************************************************
        private void txt00_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Select(0, 0);
            row = Int32.Parse(txt.Name.Substring(3, 1));
            col = Int32.Parse(txt.Name.Substring(4, 1));

            txt.ForeColor = Color.Blue;


            if (pincelMarcador)
            {
                if (txtSudoku[row, col].Text != string.Empty)
                    txtSudoku[row, col].BackColor = colorFondoAct;
                else
                    txtSudoku[row, col].BackColor = Valor.GetColorCeldaAct();
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
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;

            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
                if (txt.Text.Length > 8) { txt.Text = string.Empty; }
            }
        }

        private void txt00_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            row = Int32.Parse(txt.Name.Substring(3, 1));
            col = Int32.Parse(txt.Name.Substring(4, 1));
            try
            {
                if (txt.Text.Contains ( "0"))
                {
                    txt.Text = string.Empty;
                    valorIngresado[row, col] = string.Empty;
                }
                else
                {
                    if (txt.Text == string.Empty )
                    {
                        txt.BackColor = Color.WhiteSmoke;

                    }
                    else if (txt.Text != string.Empty )
                    {
                        txt.Text = Funcion.OrganizarCandidatos(txt.Text, lista);
                        txt.BackColor = colorFondoAct;
                    }
                    valorIngresado[row, col] = txt.Text;
                }
             
            }
            catch { }

            string sentido = e.KeyCode.ToString();
            if (sentido == Engine.EngineData.Up || sentido == Engine.EngineData.Down || sentido == Engine.EngineData.Right || sentido == Engine.EngineData.Left)
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
                txt.BackColor = colorFondoAct;
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
            lista.Items.Clear();
        }

        //************************************************************************************

        private string GuardarComoSaveDialog()
        {

            this.saveFileDialog1.FileName = string.Empty;
            this.saveFileDialog1.Filter = "Archivos de Texto" + " | *.aglm";
            this.saveFileDialog1.Title = "Abrir Juego";
            this.saveFileDialog1.DefaultExt = ".aglm";
            this.saveFileDialog1.ShowDialog();
            return saveFileDialog1.FileName;
        }

        private void GuardarJuego(string pathArchivo)
        {
            if (Funcion.ExiteArchivo(pathArchivo)) { Funcion.ReadWriteTxt(pathArchivo); }
            Funcion.GuardarValoresIngresados(pathArchivo, valorIngresado);
            Funcion.GuardarColoresIngresados(pathArchivo, txtSudoku);
            if (Funcion.ExiteArchivo(pathArchivo)) { Funcion.OnlyReadTxt(pathArchivo); }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool resultado = Funcion.ExisteValorIngresado(valorIngresado);
            if (!resultado) return;
            pathArchivo = Valor.GetPathArchivo();
            if (pathArchivo == string.Empty)
            {
                pathArchivo = GuardarComoSaveDialog();
                if (pathArchivo != string.Empty)
                {
                    Valor.SetPathArchivo(pathArchivo);
                    GuardarJuego(pathArchivo);
                }
                else
                {
                    return;
                }
            }
            else
            {
                GuardarJuego(pathArchivo);
            }
        }

        private void crearOtroJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSudoku = Funcion.SetearTextColorInicio(txtSudoku);
            Funcion.SetearTextBoxLimpio(txtSudoku);
            Valor.SetPathArchivo(string.Empty);
            pincelMarcador = false;
            btnSelectColor.BackColor = Color.Silver;
            btnSelectColor.FlatAppearance.BorderColor = Color.Silver;
            btnSelectColor.FlatAppearance.BorderSize = 1;
            valorIngresado = new string[9, 9];
            borrado = false;
        }

        //********************************************************************************
    }
}
