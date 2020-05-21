using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        //Flags botonnes convertir a binario y decimal
        int flagPasarABinario = 0;
        int flagPadarADecimal = 0;
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo operar llama al metodo de clase Calcularora Operar y asgina valor a el retorno
        /// </summary>
        /// <param name="numero1">string</param>
        /// <param name="numero2">string</param>
        /// <param name="operador">string</param>
        /// <returns>string</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;
        }

        /// <summary>
        /// Evento del boton btnOperar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {

            double resultado;
            //valida que esten cargados los textBox y comboBox
            if (!(String.IsNullOrEmpty(cmbOperador.Text)))
            {
                if (!(String.IsNullOrEmpty(txtNumero1.Text))
                && !(String.IsNullOrEmpty(txtNumero2.Text)))
                {
                    //asigna valor a la variable double
                   resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

                    //se asigna valor al label de resultado
                    if (cmbOperador.Text == "/" && txtNumero2.Text == "0")
                    {
                        lblResultado.Text = double.MinValue.ToString();
                        lblResultado.BackColor = Color.DarkGray;
                        lblResultado.ForeColor = Color.Brown;
                    }
                    else
                    {
                        lblResultado.Text = Math.Round(resultado, 2).ToString();
                        lblResultado.BackColor = Color.Azure;
                        lblResultado.ForeColor = Color.Black;
                        flagPasarABinario = 0;
                    }

                }
                else
                {
                    lblResultado.Text = "Faltan Operandos";
                    lblResultado.BackColor = Color.DarkGray;
                    lblResultado.ForeColor = Color.Brown;
                }
            }
            else
            {
                lblResultado.Text = "Faltan Operandor";
                lblResultado.BackColor = Color.DarkGray;
                lblResultado.ForeColor = Color.Brown;
            }
            
        }


        /// <summary>
        /// Metodo limpiar, borra los valores de los textBox, comboBox y lavbel de resultado
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            lblResultado.Text = string.Empty;
            flagPadarADecimal = 0;
            flagPasarABinario = 0;
        }

        /// <summary>
        /// Evento que llama al metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Evento que Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            
           if( MessageBox.Show("Estas seguro?", "Cierre", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        /// <summary>
        /// Evento para covertir un decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
           
            Numero binario = new Numero(lblResultado.Text);
            double num;
            if (double.TryParse(lblResultado.Text, out num) && flagPasarABinario == 0)
            {
                lblResultado.Text = binario.DecimalBinario(((int)Math.Abs(num)));
                flagPasarABinario = 1;
                flagPadarADecimal = 0;
            }

        }


        /// <summary>
        /// Evento que convierte un binario en decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvervirADecimal_Click(object sender, EventArgs e)
        {
            Numero numDecimal = new Numero(lblResultado.Text);
            double num;
            if (double.TryParse(lblResultado.Text, out num) && flagPadarADecimal == 0)
            {
                lblResultado.Text = numDecimal.BinarioDecimal(num.ToString());
                flagPasarABinario = 0;
                flagPadarADecimal = 1;
            }
        }


    }//
}//
