using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPrincipal : Form
    {
        Correo correo;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.rtbMostrar.Enabled = false;
        }

        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete p in this.correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(p);
                        break;
                }
            }
        }


        private void paq_InformaEstado(Object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            Paquete p = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            p.InformaEstado += paq_InformaEstado;
            try
            {
                this.correo += p;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message, "Paquete Repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error ", "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.ActualizarEstados();
        }


        private void CmsListas_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);

                if (elemento is Correo)
                {
                    try
                    {
                        this.rtbMostrar.Text.Guardar("salida.txt");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

         private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }


        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

       
    }
}
