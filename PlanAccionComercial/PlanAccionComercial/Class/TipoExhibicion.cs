using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanAccionComercial.Class
{
    public class TipoExhibicion
    {
        private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;
        public class Tipo
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public bool Activo { get; set; }
        }
        public void GuardarTipoExhibicion(Tipo tipo)
        {
            string SQL = @"insert into
	                            t21_tipo_exhibicion
                            (
	                            f21_descripcion,
	                            f21_activo,
	                            f21_usuario_creacion,
	                            f21_fecha_creacion
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
                string mensaje = ex.Number == 2601 ? $"El tipo de exhibición {tipo.Descripcion} ya existe" : ex.Message;
                throw new Exception($"Error al guardar tipo de exhibición: {mensaje}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar tipo de exhibición: " + ex.Message);
            }
        }

        public void EditatTipoExhibicion(Tipo tipo)
        {
            string SQL = @"update
	                            t21_tipo_exhibicion
                            set
	                            f21_descripcion=@descripcion,
	                            f21_activo=@activo,
	                            f21_usuario_edicion=@usuario,
	                            f21_fecha_edicion=GETDATE()
                            where
	                            f21_id=@id";
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
                string mensaje = ex.Number == 2601 ? $"El tipo de exhibición {tipo.Descripcion} ya existe" : ex.Message;
                throw new Exception($"Error al guardar tipo de exhibición: {mensaje}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar tipo de exhibición: " + ex.Message);
            }
        }

		public void EliminarTipoExhibicion(int id)
		{
			string SQL_SELECT = @"select 
	                                    COUNT(*) nro
                                    from 
	                                    t20_tipo_exhibicion_descuento_directo
	                                    inner join t21_tipo_exhibicion on f21_id=f20_id_tipo_exhibicion
                                    where
	                                    f21_id=@id";

			string SQL_DEL = @"delete
	                                t21_tipo_exhibicion
                                where
	                                f21_id=@id";
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();

				SqlCommand cmd_select = new SqlCommand(SQL_SELECT, conn);
				cmd_select.CommandType = CommandType.Text;
				cmd_select.Parameters.AddWithValue("@id", id);
				int nro = Convert.ToInt32(cmd_select.ExecuteScalar());
				if (nro == 0)
				{
					SqlCommand cmd_del = new SqlCommand(SQL_DEL, conn);
					cmd_del.CommandType = CommandType.Text;
					cmd_del.Parameters.AddWithValue("@id", id);
					cmd_del.ExecuteNonQuery();
				}
				else
				{
					conn.Close();
					throw new Exception($"Este Tipo de exhibición no se puede eliminar porque ya esta siendo usado en los descuentos");
				}
				conn.Close();
			}
			catch (SqlException ex)
			{
				throw new Exception($"Error al eliminar tipo de dinámica: {ex.Message}");
			}
			catch (Exception ex)
			{
				throw new Exception($"Error al eliminar tipo de dinámica: {ex.Message}");
			}
		}

		public async Task<DataTable> ListarTiposExhibicion(bool activo = false)
        {
            string SQL = @"select
	                            f21_id,
	                            f21_descripcion,
	                            f21_activo
                            from
	                            t21_tipo_exhibicion";
            if (activo)
            {
                SQL += @" where
                            f21_activo=1";
            }
            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                if (dr.HasRows)
                {
                    res = new DataTable();
                    res.Load(dr);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar tipos de exhibición: " + ex.Message);
            }
            return res;
        }
    }
}
