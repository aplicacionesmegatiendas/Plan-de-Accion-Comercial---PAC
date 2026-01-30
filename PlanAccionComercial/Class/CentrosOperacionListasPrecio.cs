using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlanAccionComercial.Class.CentrosOperacionListasPrecio;
using static PlanAccionComercial.Class.Permisos;

namespace PlanAccionComercial.Class
{
    public class CentrosOperacionListasPrecio
    {
        private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;
        private string cadena_unoee = ConfigurationManager.ConnectionStrings["unoee"].ConnectionString;
        public class CentroLista
        {
            public string IdCentroOperacion { get; set; }
            public string CentroOperacion { get; set; }
            public string ListaPrecio { get; set; }
        }

        public async Task<DataTable> ListarCentrosOperacion(string orden = "")
        {
            string SQL = @"select 
	                            f285_id f157_id,
	                            f285_descripcion f157_descripcion
                            from 
	                            t285_co_centro_op
                            where
	                            f285_id_cia=1
	                            and f285_id_portafolio is not null";
            if (!orden.Equals(""))
            {
                SQL += $@" order by
	                        case
		                        when f285_id in({orden}) then 1
                                else 2
                            end";
            }
            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_unoee);
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
                throw new Exception("Error al listar Centros de operación: " + ex.Message);
            }
            return res;
        }


        public void GuardarCentroLista(CentroLista centro_lista)
        {
            string SQL = @"insert into
	                            t23_centros_op_listas_precio
                            (
	                            f23_id_co,
	                            f23_co,
	                            f23_lp
                            )
                            values
                            (
	                            @id_co,
	                            @co,
	                            @lp
                            )";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_co", centro_lista.IdCentroOperacion);
                cmd.Parameters.AddWithValue("@co", centro_lista.CentroOperacion);
                cmd.Parameters.AddWithValue("@lp", centro_lista.ListaPrecio);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al guardar: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar: {ex.Message}");
            }
        }

        public void EliminarCentroLista(int id)
        {
            string SQL = @"delete
	                            t23_centros_op_listas_precio
                            where
                                f23_id=@id";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al eliminar: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar: {ex.Message}");
            }
        }

        public DataTable ListarCentroLista(string orden = "")
        {
            string SQL = @"select 
	                            f23_id,
                                f23_id_co,
	                            f23_co,
	                            f23_lp
                            from 
	                            t23_centros_op_listas_precio";
            if (!orden.Equals(""))
            {
                SQL += $@" order by
	                        case
		                        when f23_id_co in({orden}) then 1
                                else 2
                            end";
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
                throw new Exception("Error al listar: " + ex.Message);
            }
            return dt;
        }

		public DataTable ListarCentroListaDescuento()
		{
			string SQL = @"select 
	                            f23_id,
                                f23_id_co,
	                            f23_id_co + '-' + f23_co f23_co,
	                            f23_lp
                            from 
	                            t23_centros_op_listas_precio
			                order by
	                            f23_id_co asc";
			

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
				throw new Exception("Error al listar: " + ex.Message);
			}
			return dt;
		}
	}
}
