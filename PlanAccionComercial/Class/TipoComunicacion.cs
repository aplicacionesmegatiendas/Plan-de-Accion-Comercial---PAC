using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PlanAccionComercial.Class
{
    public class TipoComunicacion
    {
        private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;
        public class Tipo
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public string Correo { get; set; }
            public bool Activo { get; set; }
        }
        public void GuardarTipoComunicacion(Tipo tipo)
        {
            string SQL = @"insert into
	                            t07_tipo_comunicacion
                            (
	                            f07_descripcion,
	                            f07_activo,
	                            f07_usuario_creacion,
	                            f07_fecha_creacion,
                                f07_email
                            )
                            values
                            (
	                            @descripcion,
	                            @activo,
	                            @usuario,
	                            GETDATE(),
                                @email
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
                cmd.Parameters.AddWithValue("@email", tipo.Correo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                string mensaje = ex.Number == 2601 ? $"El tipo de comunicación {tipo.Descripcion} ya existe" : ex.Message;
                throw new Exception($"Error al guardar tipo de comunicación: {mensaje}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar tipo de comunicación: " + ex.Message);
            }
        }

        public void EditatTipoComunicacion(Tipo tipo)
        {
            string SQL = @"update
	                            t07_tipo_comunicacion
                            set
	                            f07_descripcion=@descripcion,
	                            f07_activo=@activo,
	                            f07_usuario_edicion=@usuario,
	                            f07_fecha_edicion=GETDATE(),
                                f07_email=@email
                            where
	                            f07_id=@id";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@descripcion", tipo.Descripcion);
                cmd.Parameters.AddWithValue("@activo", tipo.Activo);
                cmd.Parameters.AddWithValue("@usuario", Usuarios.NombreUsuario);
                cmd.Parameters.AddWithValue("@email", tipo.Correo);
                cmd.Parameters.AddWithValue("@id", tipo.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                string mensaje = ex.Number == 2601 ? $"El tipo de comunicación {tipo.Descripcion} ya existe" : ex.Message;
                throw new Exception($"Error al guardar tipo de comunicación: {mensaje}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar tipo de comunicación: " + ex.Message);
            }
        }

		public void EliminarTipoComunicacion(int id)
		{
			string SQL_SELECT = @"select
	                                count(*) nro
                                from 
	                                t18_tipo_comunicacion_descuento_directo
	                                inner join t07_tipo_comunicacion on f07_id=f18_id_tipo_comunicacion
                                where
	                                f07_id=@id";

			string SQL_DEL = @"delete
		                            t07_tipo_comunicacion
	                            where
		                            f07_id=@id";
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
					throw new Exception($"Este tipo de comunicación no se puede eliminar porque ya esta siendo usado en los descuentos");
				}
				conn.Close();
			}
			catch (SqlException ex)
			{
				throw new Exception($"Error al eliminar tipo de comunicación: {ex.Message}");
			}
			catch (Exception ex)
			{
				throw new Exception($"Error al eliminar tipo de comunicación: {ex.Message}");
			}
		}


		public async Task<DataTable> ListarTiposComunicacion(bool activo = false)
        {
            string SQL = @"select
	                            f07_id,
	                            f07_descripcion,
	                            f07_activo,
                                f07_email
                            from
	                            t07_tipo_comunicacion";
            if (activo)
            {
                SQL += @" where
                            f07_activo=1";
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
                throw new Exception("Error al listar tipos de comunicación: " + ex.Message);
            }
            return res;
        }

        public string BuscarCorreoTipoComunicacion(int id)
        {
            string SQL = @"select 
	                        f07_email
                        from 
	                        t07_tipo_comunicacion
                        where
	                        f07_id=@id";
            string res = "";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                res = Convert.ToString(cmd.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar correo: " + ex.Message);
            }
            return res;
        }

        public string BuscarCorreoTipoComunicacionDescuento(int consecutivo)
        {
            string SQL = @"select 
	                            f07_email
                            from 
	                            t17_descuento_directo
	                            inner join t18_tipo_comunicacion_descuento_directo on f18_cons_descuento = f17_consecutivo
	                            inner join t07_tipo_comunicacion on f18_id_tipo_comunicacion = f07_id
                            where 
                                f17_consecutivo=@consecutivo";
            string res = "";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
                res = Convert.ToString(cmd.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar correo: " + ex.Message);
            }
            return res;
        }
    }
}
