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

namespace CandFilRespySol
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        //***********************************************************************************************************
        private Engine.EngineSudoku Funcion = new Engine.EngineSudoku();
        private Engine.EngineData Valor = Engine.EngineData.Instance();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Engine.EngineData.Titulo;
            if (!Funcion.ExisteClaveRegWin()) { Funcion.AgregarClaveRegWin(); }
            Funcion.AsociarExtension();
        }
    }
}
