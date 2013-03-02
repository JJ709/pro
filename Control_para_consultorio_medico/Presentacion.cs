using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control_para_consultorio_medico
{
    public partial class Presentacion : Form
    {

        public void entrada()
        {
            if (this.barra.Value == 100)
            {
                this.Opacity -= 0.3;
                if (this.Opacity == 0.0)
                {

                    ACCESO f1 = new ACCESO();
                    this.Hide();
                    f1.Show();
                    timint.Enabled = false;
                }
            }

            else
            {
                this.barra.Value += 10;
            }
      }

        public Presentacion()
        {
            InitializeComponent();
        }

        private void timint_Tick(object sender, EventArgs e)
        {
            entrada();
        }
    }
}
