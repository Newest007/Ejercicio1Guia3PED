using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1_Guía3_PED
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ValidarCampos()
        {
            bool validado = true;

            if(mskedCarnet.Text == "" || mskedCarnet.Text.Contains(" "))
            {
                validado = false;
                errorProvider1.SetError(mskedCarnet, "Llenar campos!");
            }

            if(txtNombre.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtNombre, "Llenar campos!");
            }

            if(numSalario.Value <= 0)
            {
                validado = false;
                errorProvider1.SetError(numSalario, "Escriba un salario valido");
            }

            return validado;
        }

        private void BorrarMensaje()
        {
            errorProvider1.SetError(txtNombre,"");
            errorProvider1.SetError(numSalario, "");
            errorProvider1.SetError(mskedCarnet, "");
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            BorrarMensaje();
            DateTime pagoSalario = dateTimePicker1.Value;
            int validacion = System.DateTime.Now.Year - pagoSalario.Year;

            if (validacion >= 0) 
            {
                errorProvider1.SetError(dateTimePicker1, "Ingrese una fecha de salario valido");
            }

            if(ValidarCampos())
            {
                




            }

        }

        private void numSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Condición solo para letras
            if(char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            //Condición de aceptar tecla backspace
            else if(char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //Condición de aceptar tecla de espacio
            else if(char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                errorProvider1.SetError(txtNombre, "No se aceptan NickNames");
            }


        }
    }
}
