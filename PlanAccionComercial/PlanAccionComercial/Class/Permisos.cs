using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanAccionComercial.Class
{
    public class Permisos
    {
        public class Permiso
        {
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
            public bool Activo { get; set; }
        }

        private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;

        public DataTable ListarPermisos(bool activo)
        {
            string SQL = @"select
                                f01_cod,
	                            f01_descripcion,
                                f01_activo
                            from
                                t01_permisos";
            if (activo)
            {
                SQL += @" where
                            f01_activo=1";
            }

            DataTable dt = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQL, cadena_pac);
                dt = new DataTable();
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar permisos: " + ex.Message);
            }
            return dt;
        }

        public void GuardarPermiso(Permiso permiso)
        {
            string SQL = @"insert into
	                            t01_permisos
                            values
                            (
	                            @cod,
	                            @descripcion,
	                            @activo
                            )";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cod", permiso.Codigo);
                cmd.Parameters.AddWithValue("@descripcion", permiso.Descripcion);
                cmd.Parameters.AddWithValue("@activo", permiso.Activo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                //variable = (condicion) ? valorVerdadero : valorFalso;
                string mensaje = ex.Number == 2627 ? $"El permiso {permiso.Codigo} ya existe" : ex.Message;//primary key
                throw new Exception($"Error al guardar el permiso: {mensaje}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el permiso: {ex.Message}");
            }
        }

        public void EditarPermiso(Permiso permiso)
        {
            string SQL = @"update
	                            t01_permisos
                            set
	                            f01_descripcion=@descripcion,
                                f01_activo=@activo
                            where
	                            f01_cod=@cod";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@descripcion", permiso.Descripcion);
                cmd.Parameters.AddWithValue("@activo", permiso.Activo);
                cmd.Parameters.AddWithValue("@cod", permiso.Codigo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al guardar el permiso: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el permiso: {ex.Message}");
            }
        }
    }
}
