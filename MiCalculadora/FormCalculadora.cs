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

        int flagBinario = 0;
        int flagPadarADecimal = 0;
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {

            double resultado;
            if (!(String.IsNullOrEmpty(cmbOperador.Text)))
            {
                if (!(String.IsNullOrEmpty(txtNumero1.Text))
                && !(String.IsNullOrEmpty(txtNumero2.Text)))
                {
                   resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

                    if (resultado == double.MinValue)
                    {
                        lblResultado.Text = "No es posible dividir por 0";
                        lblResultado.BackColor = Color.DarkGray;
                        lblResultado.ForeColor = Color.Brown;
                    }
                    else
                    {
                        lblResultado.Text = Math.Round(resultado, 2).ToString();
                        lblResultado.BackColor = Color.Azure;
                        lblResultado.ForeColor = Color.Black;
                        flagBinario = 0;
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

        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            lblResultado.Text = string.Empty;
            flagPadarADecimal = 0;
            flagBinario = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            
           if( MessageBox.Show("Estas seguro?", "Cierre", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
           
            Numero binario = new Numero(lblResultado.Text);
            double num;
            if (double.TryParse(lblResultado.Text, out num) && flagBinario == 0)
            {
                lblResultado.Text = binario.DecimalBinario(((int)Math.Abs(num)));
                flagBinario = 1;
                flagPadarADecimal = 0;
            }

        }

        private void btnConvervirADecimal_Click(object sender, EventArgs e)
        {
            Numero numDecimal = new Numero(lblResultado.Text);
            double num;
            if (double.TryParse(lblResultado.Text, out num) && flagPadarADecimal == 0)
            {
                lblResultado.Text = numDecimal.BinarioDecimal(num.ToString());
                flagBinario = 0;
                flagPadarADecimal = 1;
            }
        }


    }//
}//
