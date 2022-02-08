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

        public void Limpiar() //Método para limpiar los textbox
        {
            mskedCarnet.Clear();
            txtNombre.Clear();
            numSalario.Value = 0;
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

        Queue<Empleados> Trabajadores = new Queue<Empleados>();
        //Objeto de la clase cola, es de tipo de la clase empleado, almacena objetos(?

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            BorrarMensaje();
            DateTime pagoSalario = dateTimePicker1.Value;
            int validacion = System.DateTime.Now.Year - pagoSalario.Year;

            if (validacion <= 0) 
            {
                errorProvider1.SetError(dateTimePicker1, "Ingrese una fecha de empleado valido");
            }

            else if(ValidarCampos())
            {
                Empleados empleado = new Empleados(); //Instacia para la clase empleados
                //Campturando los datos del empleado
                empleado.Carnet = mskedCarnet.Text;
                empleado.Nombre = txtNombre.Text;
                empleado.Salario = numSalario.Value;
                empleado.Fecha = dateTimePicker1.Value;
                Trabajadores.Enqueue(empleado); //Enqueue se utiliza para encolar a los "integrantes" de la cola
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Trabajadores.ToArray();
                Limpiar();
                mskedCarnet.Focus();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if(Trabajadores.Count != 0) //Lo hará siempre y cuando hayan trabajadores en la cola
            {
                Empleados empleado = new Empleados();
                empleado = Trabajadores.Dequeue(); //En vez de estar creando un método aparte para eliminar al primero
                                                   //de la fila simplemente usamos en comando Dequeue
                mskedCarnet.Text = empleado.Carnet;
                txtNombre.Text = empleado.Nombre;
                numSalario.Value = empleado.Salario;
                dateTimePicker1.Value = empleado.Fecha;
                //Ahora la estructura que ha sido convertida en cola pasa al dtgv teniendo un trabajador menos
                dataGridView1.DataSource = Trabajadores.ToList();
                MessageBox.Show("Se ha retirado un registro de la cola", "AVISO");
                Limpiar();

            }

            else
            {
                MessageBox.Show("No hay empleados en la cola", "AVISO");
                Limpiar();
            }

            mskedCarnet.Focus();


        }
    }
}
