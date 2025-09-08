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
	public class TipoDinamica
	{
		private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;
		public class Tipo
		{
			public int Id { get; set; }
			public string Descripcion { get; set; }
			public bool Activo { get; set; }
		}

		public void GuardarTipoDinamica(Tipo tipo)
		{
			string SQL = @"insert into
	                            t08_tipo_dinamica
                            (
	                            f08_descripcion,
	                            f08_activo,
	                            f08_usuario_creacion,
	                            f08_fecha_creacion
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
				string mensaje = ex.Number == 2601 ? $"El tipo de dinámica {tipo.Descripcion} ya existe" : ex.Message;
				throw new Exception($"Error al guardar tipo de dinámica: {mensaje}");
			}
			catch (Exception ex)
			{
				throw new Exception("Error al guardar tipo de dinámica: " + ex.Message);
			}
		}

		public void EditarTipoDinamica(Tipo tipo)
		{
			string SQL = @"update
	                            t08_tipo_dinamica
                            set
	                            f08_descripcion=@descripcion,
	                            f08_activo=@activo,
	                            f08_usuario_edicion=@usuario,
	                            f08_fecha_edicion=GETDATE()
                            where
	                            f08_id=@id";
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
				string mensaje = ex.Number == 2601 ? $"El tipo de dinámica {tipo.Descripcion} ya existe" : ex.Message;
				throw new Exception($"Error al guardar tipo de dinámica: {mensaje}");
			}
			catch (Exception ex)
			{
				throw new Exception("Error al guardar tipo de dinámica: " + ex.Message);
			}
		}

		public void EliminarTipoDinamica(int id)
		{
			string SQL_SELECT = @"select
	                                count(*) nro
                                from 
	                                t17_descuento_directo
	                                inner join t08_tipo_dinamica on f08_id=f17_id_tipo_dinamica
                                where
	                                f08_id=@id";

			string SQL_DEL = @"delete
                                t08_tipo_dinamica
                            where
                                f08_id=@id";
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
					throw new Exception($"Este tipo de dinámica no se puede eliminar porque ya esta siendo usada en los descuentos");
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

		public async Task<DataTable> ListarTiposDinamica(bool activo = false)
		{
			string SQL = @"select
	                            f08_id,
	                            f08_descripcion,
	                            f08_activo
                            from
	                            t08_tipo_dinamica ";
			if (activo)
			{
				SQL += @"where 
                            f08_activo=1 ";

			}
			SQL += "order by 2";
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
				throw new Exception("Error al listar tipos de dinámica: " + ex.Message);
			}
			return res;
		}
	}
}
