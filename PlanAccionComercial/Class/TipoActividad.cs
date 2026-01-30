using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PlanAcuerdoComercial.Class
{
   public class TipoActividad
    {
        private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;
        public class Tipo
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public bool Activo { get; set; }
        }

        public async Task<DataTable> ListarTiposActividad(bool activo=false)
        {
            string SQL = @"select
                                f10_id,
	                            f10_descripcion,
	                            f10_activo
                            from
                                t10_tipo_actividad";
            if (activo)
            {
                SQL += @" where 
                            f10_activo=1";
            }
            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new DataTable();
                    res.Load(dr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar tipos actividad: " + ex.Message);
            }
            return res;
        }

        public void GuardarTipoActividad(Tipo tipo)
        {
            string SQL = @"insert into
	                            t10_tipo_actividad
                            (
	                            f10_descripcion,
	                            f10_activo,
	                            f10_usuario_creacion,
	                            f10_fecha_creacion
                            )
                            values
                            (
	                            @descripcion,
	                            @activo,
	                            @usuario,
	                            GETDATE()
                            )";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@descripcion", tipo.Descripcion);
                cmd.Parameters.AddWithValue("@activo", tipo.Activo);
                cmd.Parameters.AddWithValue("@usuario", Usuarios.NombreUsuario);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                string mensaje = ex.Number == 2601 ? $"El tipo de actividad {tipo.Descripcion} ya existe" : ex.Message;
                throw new Exception($"Error al guardar tipo de actividad: {mensaje}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar tipo de actividad: " + ex.Message);
            }
        }

        public void EditarTipoActividad(Tipo tipo)
        {
            string SQL = @"update
	                            t10_tipo_actividad
                            set
	                            f10_descripcion=@descripcion,
	                            f10_activo=@activo,
	                            f10_usuario_edicion=@usuario,
	                            f10_fecha_edicion=GETDATE()
                            where
	                            f10_id=@id";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@descripcion", tipo.Descripcion);
                cmd.Parameters.AddWithValue("@activo", tipo.Activo);
                cmd.Parameters.AddWithValue("@usuario", Usuarios.NombreUsuario);
                cmd.Parameters.AddWithValue("@id", tipo.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                string mensaje = ex.Number == 2601 ? $"El tipo de actividad {tipo.Descripcion} ya existe" : ex.Message;
                throw new Exception($"Error al guardar tipo de actividad: {mensaje}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar tipo de actividad: " + ex.Message);
            }
        }
    }
}
