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
    public partial class Form1 : Form
    {
        String nombre = "";
        String apellido = "";
        String edad = "";
        String peso = "";
        String telefono = "";
        String temperatura = "";
        String alergico = "";
        String medicamento = "";
        String direccion = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            nombre = txt_nom.Text;
            apellido = txt_ape.Text;
            edad = comboBox_edad.Text;
            peso = txt_peso.Text;
            temperatura = txt_temp.Text;
            telefono = txt_numero.Text;
            alergico = r_si.Text;
            alergico = r_no.Text;
            medicamento = txt_medi.Text;
            direccion = direc.Text;

            
            DialogResult xguardar = MessageBox.Show("¿Desea Guardar los Datos?", "PROGRAMACION II", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == xguardar)
            {

                ConexionDB StrConexionServer = new ConexionDB();
                string StrCnnString = StrConexionServer.cadenaconexion();
                SqlConnection conexion = new SqlConnection(StrCnnString);

                string insertarReg = "insert into DATOS (Nombre,Apellidos,Edad,peso,temperatura,Telefono,alergico,medicamento,direccion)" + "values ('" + nombre.ToString() + "' , '" + apellido.ToString() + "' , '" + edad.ToString() + "' , '" + peso.ToString() + "', '" + temperatura.ToString() + "' , '" + telefono.ToString() + "' , '" + alergico.ToString() + "' , '" + medicamento.ToString() + "' , '" + direccion.ToString() +  "')";
                SqlCommand Sql = new SqlCommand(insertarReg, conexion);


                try
                {
                    
                    if ((nombre == "" || apellido == "" || telefono == "" || direccion == "" || peso == "" || temperatura == ""))
                        
                    {
                        MessageBox.Show("Por favor llenar todos los campos Obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_nom.Focus();
                    }

                    

                    //else { MessageBox.Show("Datos almacenados Correctamente", "Almacenado", MessageBoxButtons.OK, MessageBoxIcon.Information); }


                    else {
                        conexion.Open();

                        Sql.ExecuteNonQuery();
                        
                        MessageBox.Show("LOS DATOS SE HAN ALACENADO CORRECTAMENTE", "Consultorio", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation); }


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    conexion.Dispose();
                }

            }

        }

        private void r_si_Click(object sender, EventArgs e)
        {
            if (r_si.Checked == true)
            {
                label10.Enabled = true;
                txt_medi.Enabled = true;
            }

           
        }

        private void r_no_Click(object sender, EventArgs e)
        {
            if (r_no.Checked == true)
            {
                label10.Enabled = false;
                txt_medi.Enabled = false;
            }

        }

       

        }


       
    }

