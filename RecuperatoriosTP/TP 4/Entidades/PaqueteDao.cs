using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoMensaje(string msj);
    public static class PaqueteDAO
    {
        private static SqlConnection conecction;
        private static SqlCommand command;

        static PaqueteDAO()
        {
            string conexion = @"Data Source = DESKTOP-PGQ4HMM; Initial Catalog=correo-sp-2017; Integrated Security=True;";
            conecction = new SqlConnection(conexion);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conecction;
        }
  
        public static bool Insertar(Paquete p)
        {
            try
            {
                command.CommandText = $"INSERT INTO dbo.Paquetes " +  $"(direccionEntrega, trackingID, alumno ) " + $"VALUES ('{p.DireccionEntrega}', '{p.TrackingID}', 'MANUEL CLIFTON')";

                conecction.Open();
                int cantidad = command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw new InsertarEnDBExcepcion("Error al guardar",e);
            }
            finally
            {
                conecction.Close();
            }
        }
    }
}

