using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Sql;


namespace Control_para_consultorio_medico
{
    public partial class ACCESO : Form
    {
        public ACCESO()
        {
            InitializeComponent();
        }    

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ACCESO_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Usuario = txtusuario.Text.Trim();
            string Password = txtpassword.Text.Trim();
            string usu = "u";
            string pass = "c";


            ConexionDB StrConexionServer = new ConexionDB();
            String strCnnString = StrConexionServer.cadenaconexion();
            SqlConnection conexion1 = new SqlConnection(strCnnString);
            SqlConnection conexion2 = new SqlConnection(strCnnString);


            try
            {

                string consulta = "SELECT * FROM Acceso WHERE Usuario ='" + Usuario + "'";


                conexion1.Open();
                SqlCommand sql = new SqlCommand(consulta, conexion1);

                SqlDataReader buscar_registro = sql.ExecuteReader();
                Int32 filas = Convert.ToInt32(buscar_registro.HasRows);
                buscar_registro.Dispose();

                if (filas > 0)
                {
                    //MessageBox.Show("Usuario Corecto, Encontrado", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion1);
                    DataTable tb1 = new DataTable();
                    adaptador.Fill(tb1);
                    txtusuario.Text = usu.ToString();


                }

                else
                {

                    MessageBox.Show("Usuario Incorrecto, NO ENCONTRADO", "SOFTWARE MEDICO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtpassword.Text = "";
                    txtusuario.Text = "";
                    txtusuario.Focus();
                }


                string consulta1 = "SELECT * FROM Acceso WHERE Password ='" + Password + "'";

                conexion2.Open();
                SqlCommand sql1 = new SqlCommand(consulta1, conexion2);

                SqlDataReader buscar_registro1 = sql1.ExecuteReader();
                Int32 filas1 = Convert.ToInt32(buscar_registro1.HasRows);
                buscar_registro1.Dispose();

                if (filas1 > 0)
                {

                    //MessageBox.Show("Password Correcto, Encontrado", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta1, conexion2);
                    DataTable tb2 = new DataTable();
                    adaptador.Fill(tb2);
                    txtpassword.Text = pass.ToString();

                }

                else
                {

                    MessageBox.Show("Password Incorrecto, NO ENCONTRADO", "SOFTWARE MEDICO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtpassword.Text = "";
                    txtusuario.Text = "";
                    txtusuario.Focus();

                }

                if ((usu == txtusuario.Text) && (pass == txtpassword.Text))
                {
                    MessageBox.Show("Bienvenido " + Usuario, " Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();



                }
            }
            catch
            {
                MessageBox.Show("ERROR DE CONEXION \n\n DIGITE SU USUARIO Y CONTRASEÑA CORRECTA", "SOFTWARE MEDICO", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
        }


    }