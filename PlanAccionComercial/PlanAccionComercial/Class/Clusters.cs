using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace PlanAccionComercial.Class
{
    public class Clusters
    {
        private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;
        private string cadena_unoee = ConfigurationManager.ConnectionStrings["unoee"].ConnectionString;
        public class Cluster
        {
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
			public bool Principal { get; set; }
			public bool Activo { get; set; }
            public List<string[]> CentrosOperacion { get; set; }
        }
                
        public DataTable ObtenerListasPrecio(string co)
        {
            string SQL = @"select 
                            f112_id 
                            ,f112_id + ' - ' + f112_descripcion f112_descripcion 
                        from 
                            t285_co_centro_op 
                        inner join 
                            t1121_mc_listas_precios_co
                            on 
                            f1121_id_co=f285_id and f1121_id_cia=f285_id_cia 
                        inner join 
                            t112_mc_listas_precios
                            on f112_id=f1121_id_lista_precio and f112_id_cia=f1121_id_cia 
                        where 
                            f112_ind_estado=1 and  f112_ind_tipo_lista=1 and f285_id_cia=1 and f285_id=@CO 
                        order by 1";
            DataTable dt = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQL, ConfigurationManager.ConnectionStrings["unoee"].ConnectionString);
                da.SelectCommand.Parameters.AddWithValue("@CO", co);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las listas de precio: " + ex.Message);
            }
            return dt;
        }

        public async Task<DataTable> ListarClusters(bool activo)
        {
            string SQL = @"select
                            f05_cod,
	                        f05_descripcion,
                            f05_principal,
                            f05_activo
                        from
                            t05_clusters";
            if (activo)
            {
                SQL += @" where
                            f05_activo=1";
            }
            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader  dr = await cmd.ExecuteReaderAsync();
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
                throw new Exception("Error al listar clusters: " + ex.Message);
            }
            return res;
        }

        public List<string> ListarCentrosOperacionCluster(string cod_cluster)
        {
            string SQL = @"select 
                                f06_id_co
                            from
                                t06_co_clusters
                            where
                                f06_cod_cluster = @cod_cluster";
            List<string> res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cod_cluster", cod_cluster);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    res = new List<string>();
                    while ( dr.Read())
                    {
                        res.Add(dr.GetString(0));
                    }
                }
                dr.Close();
                conn.Close();
            }
            
            catch (Exception ex)
            {
                throw new Exception("Error al listar centros de operación del cluster: " + ex.Message);
            }
            return res;
        }

        public string ObtenerClusterCentrosOperacion(string id_co)
        {
            string SQL = @"select 
	                        f05_descripcion
                        from
	                        t06_co_clusters
	                        inner join t05_clusters on f05_cod=f06_cod_cluster
                        where
	                        f06_id_co=@id_co
                            and f05_principal=1";
            string res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_co", id_co);
                res = Convert.ToString(cmd.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cluster del centro de operación: " + ex.Message);
            }
            return res;
        }

        public void GuardarCluster(Cluster cluster)
        {
            string SQL_CLUSTER = @"insert into
                                        t05_clusters
                                    (
                                        f05_cod,
                                        f05_descripcion,
                                        f05_usuario_creacion,
                                        f05_fecha_creacion,
                                        f05_activo,
                                        f05_principal
                                    )output INSERTED.f05_cod
                                    values
                                    (
                                        @cod,
                                        @descripcion,
                                        @usuario,
                                        GETDATE(),
                                        @activo,
                                        @principal
                                    )";

            string SQL_CO_CLUSTER = @"insert into
	                                    t06_co_clusters 
                                    (
	                                    f06_cod_cluster,
	                                    f06_id_co,
	                                    f06_desc_co
                                    )
                                    values
                                    (
	                                    @cod_cluster,
	                                    @id_co,
	                                    @desc_co
                                    )";

            SqlTransaction trans = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd_cluster = new SqlCommand(SQL_CLUSTER, conn, trans);
                cmd_cluster.CommandType = CommandType.Text;
                cmd_cluster.Parameters.AddWithValue("@cod",cluster.Codigo);
                cmd_cluster.Parameters.AddWithValue("@descripcion",cluster.Descripcion);
                cmd_cluster.Parameters.AddWithValue("@activo",cluster.Activo);
				cmd_cluster.Parameters.AddWithValue("@principal", cluster.Principal);
				cmd_cluster.Parameters.AddWithValue("@usuario",Usuarios.NombreUsuario);
                string id = (string)cmd_cluster.ExecuteScalar();

                SqlCommand cmd_co = new SqlCommand(SQL_CO_CLUSTER, conn, trans);
                cmd_co.CommandType = CommandType.Text;
                foreach (string[] co in cluster.CentrosOperacion)
                {
                    cmd_co.Parameters.AddWithValue("@cod_cluster", id);
                    cmd_co.Parameters.AddWithValue("@id_co", co[0]);
                    cmd_co.Parameters.AddWithValue("@desc_co", co[1]);
                    cmd_co.ExecuteNonQuery();
                    cmd_co.Parameters.Clear();
                }
                trans.Commit();
                conn.Close();
            }
            catch(SqlException ex)
            {
				trans.Rollback();
				throw new Exception("Error al guardar cluster: " + ex.Message);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception("Error al guardar cluster: " + ex.Message);
            }
        }

        public void EditarCluster(Cluster cluster)
        {
            string SQL_CLUSTER = @"update
	                                    t05_clusters
                                    set
	                                    f05_descripcion=@descripcion,
                                        f05_activo=@activo,
                                        f05_principal=@principal,
	                                    f05_usuario_edicion=@usuario,
	                                    f05_fecha_edicion=GETDATE()
                                    where
	                                    f05_cod=@cod";

            string SQL_DEL_CO_CLUSTER = @"delete
                                            t06_co_clusters
                                        where
                                            f06_cod_cluster = @cod_cluster";

            string SQL_CO_CLUSTER = @"insert into
	                                    t06_co_clusters 
                                    (
	                                    f06_cod_cluster,
	                                    f06_id_co,
	                                    f06_desc_co
                                    )
                                    values
                                    (
	                                    @cod_cluster,
	                                    @id_co,
	                                    @desc_co
                                    )";

            SqlTransaction trans = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd_cluster = new SqlCommand(SQL_CLUSTER, conn, trans);
                cmd_cluster.CommandType = CommandType.Text;
                cmd_cluster.Parameters.AddWithValue("@descripcion", cluster.Descripcion);
                cmd_cluster.Parameters.AddWithValue("@activo", cluster.Activo);
				cmd_cluster.Parameters.AddWithValue("@principal", cluster.Principal);
				cmd_cluster.Parameters.AddWithValue("@usuario", Usuarios.NombreUsuario);
                cmd_cluster.Parameters.AddWithValue("@cod", cluster.Codigo);
                cmd_cluster.ExecuteNonQuery();

                SqlCommand cmd_del_co = new SqlCommand(SQL_DEL_CO_CLUSTER, conn, trans);
                cmd_del_co.CommandType = CommandType.Text;
                cmd_del_co.Parameters.AddWithValue("@cod_cluster", cluster.Codigo);
                cmd_del_co.ExecuteNonQuery();

                SqlCommand cmd_co = new SqlCommand(SQL_CO_CLUSTER, conn, trans);
                cmd_co.CommandType = CommandType.Text;
                foreach (string[] co in cluster.CentrosOperacion)
                {
                    cmd_co.Parameters.AddWithValue("@cod_cluster", cluster.Codigo);
                    cmd_co.Parameters.AddWithValue("@id_co", co[0]);
                    cmd_co.Parameters.AddWithValue("@desc_co", co[1]);
                    cmd_co.ExecuteNonQuery();
                    cmd_co.Parameters.Clear();
                }
                trans.Commit();
                conn.Close();
            }
            catch (SqlException ex)
            {
				trans.Rollback();
				throw new Exception("Error al guardar cluster: " + ex.Message);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception("Error al guardar cluster: " + ex.Message);
            }
        }

		public void EliminarCluster(string codigo)
		{
			string SQL_SELECT = @"select 
	                                    COUNT(*) nro
                                    from 
	                                    t19_detalle_descuento_directo
	                                    inner join t05_clusters on f05_cod=f19_cod_cluster
                                    where
	                                    f05_cod=@cod";

			string SQL_DELETE = @"delete
		                                t05_clusters
	                                where
		                                f05_cod=@cod";

			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();

				SqlCommand cmd_select = new SqlCommand(SQL_SELECT, conn);
				cmd_select.CommandType = CommandType.Text;
				cmd_select.Parameters.AddWithValue("@cod", codigo);
				int nro = Convert.ToInt32(cmd_select.ExecuteScalar());
				if (nro == 0)
				{
					SqlCommand cmd_del = new SqlCommand(SQL_DELETE, conn);
					cmd_del.CommandType = CommandType.Text;
					cmd_del.Parameters.AddWithValue("@cod", codigo);
					cmd_del.ExecuteNonQuery();
				}
				else
				{
					conn.Close();
					throw new Exception($"Este Cluster no se puede eliminar porque ya esta siendo usada en los descuentos");
				}
				conn.Close();
			}
			catch (SqlException ex)
			{
				throw new Exception($"Error al eliminar Cluster: {ex.Message}");
			}
			catch (Exception ex)
			{
				throw new Exception($"Error al eliminar Cluster: {ex.Message}");
			}
		}
	}
}
