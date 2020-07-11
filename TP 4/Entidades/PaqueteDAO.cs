using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        static PaqueteDAO()
        {
            conexion = new SqlConnection(@"Data Source = DESKTOP-PGQ4HMM; Initial Catalog=correo-sp-2017; Integrated Security=True;");
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static bool Insertar(Paquete p)
        {
            try
            {
                comando.CommandText = $"INSERT INTO dbo.Paquetes " +
                    $"(direccionEntrega, trackingID, alumno ) " +
                    $"VALUES ('{p.DireccionEntrega}', '{p.TrackingID}', 'Dalairac Diego')";

                conexion.Open();
                int cant = comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw new InsertarEnDBExeption("Error al guardar en la base de datos", e);
            }
            finally
            {
                conexion.Close();
            }
        }

    }//
}//
