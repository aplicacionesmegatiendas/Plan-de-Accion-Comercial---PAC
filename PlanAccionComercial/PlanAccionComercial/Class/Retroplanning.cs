using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PlanAccionComercial.Class
{
    public class Retroplanning
    {
        public class Planning
        {
            public int Consecutivo { get; set; }
            public string Descripcion { get; set; }
            public int Dinamica { get; set; }
            public DateTime FechaInicialVigencia { get; set; }
            public DateTime FechaFinalVigencia { get; set; }
            public DateTime FechaEntregaMercadeo { get; set; }
            public DateTime FechaEntregaComercial { get; set; }
            public int Estado { get; set; }
            public List<int> Negociadores { get; set; }
        }

        private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;

        public object ObtenerValorConfiguracion(int id)
        {
            string SQL = @"select
                                f00_valor
                            from
                                t00_configuracion
                            where
                                f00_id = @id";
            object res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                res = cmd.ExecuteScalar();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener valor configuración: " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Lista los usuarios que estan marcados como negociadores
        /// </summary>
        /// <returns>Retorna un DataTable</returns>
        public DataTable ListarNegociadoresDescuentoRetroplanning()
        {
            string SQL = @"select distinct
                                f04_id,
	                            f04_nombre as f04_usuario
                            from
                                t04_usuarios
                                inner join t02_roles on f04_id_rol = f02_id
                                inner join t03_permisos_roles on f03_id_rol = f02_id
	                            inner join t01_permisos a on f03_cod_permiso = a.f01_cod
                            where
                                f04_activo = 1 and
                                f02_activo = 1 and
                                f04_negociador = 1 and
                                a.f01_activo = 1";
            //f04_id <> 1 and
            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new DataTable();
                    res.Load(dr);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener negociadores descuento por retroplanning: " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Lista los negociadores que estan vinculados a un retroplanning
        /// </summary>
        /// <param name="consecutivo">Consecutivo del retroplanning</param>
        /// <returns>Retorna un List<int></returns>
        public List<int> ListarNegociadoresRetroplanning(int consecutivo)
        {
            string SQL = @"select 
                                f13_id_usuario
                            from
                                t13_negociadores_retroplanning
                            where
                                f13_consecutivo_retro=@consecutivo";
            List<int> res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new List<int>();
                    while (dr.Read())
                    {
                        res.Add(dr.GetInt32(0));
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener negociadores del retroplanning: " + ex.Message);
            }
            return res;
        }

        public Byte[] ObtenerImagenRetroplanning(int consecutivo)
        {
            string SQL = @"select 
                                f12_imagen
                            from
                                t12_retroplanning
                            where
                                f12_consecutivo=@consecutivo";
            Byte[] res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
                object r = cmd.ExecuteScalar();
                if (!Convert.IsDBNull(r))
                {
                    res = new Byte[0];
                    res = (Byte[])r;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener imagen retroplanning: " + ex.Message);
            }
            return res;
        }

        public DataTable ListarRetroplanning()
        {
            string SQL = @"select 
                                f12_consecutivo,
	                            f12_descripcion,
	                            f08_id,
	                            f08_descripcion,
	                            f12_fecha_ini_vig,
	                            f12_fecha_fin_vig,
	                            f12_fecha_entrega_mercadeo,
	                            f12_fecha_entrega_comercial,
                                f11_id,
	                            f11_descripcion
                            from
                                t12_retroplanning
                                inner join t08_tipo_dinamica on f12_id_tipo_dinamica = f08_id
                                inner join t11_estados on f12_id_estado=f11_id 
                            where
                                f12_id_estado in('1','2')";

            DataTable res = null;

            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new DataTable();
                    res.Load(dr);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar retroplanning: " + ex.Message);
            }
            return res;
        }

        public DataTable ListarRetroplanning(string fecha_ini, string fecha_fin)
        {
            string SQL = @"select distinct
                                f12_consecutivo,
	                            f12_descripcion,
	                            f08_id,
	                            f08_descripcion,
	                            FORMAT(f12_fecha_ini_vig, 'dd/MM/yyyy') f12_fecha_ini_vig,
	                            FORMAT(f12_fecha_fin_vig, 'dd/MM/yyyy') f12_fecha_fin_vig,
                                FORMAT(f12_fecha_entrega_mercadeo, 'dd/MM/yyyy') f12_fecha_entrega_mercadeo,
	                            FORMAT(f12_fecha_entrega_comercial, 'dd/MM/yyyy') f12_fecha_entrega_comercial
                            from
                                t12_retroplanning
                                inner join t08_tipo_dinamica on f12_id_tipo_dinamica = f08_id
                                inner join t11_estados on f12_id_estado=f11_id
	                            inner join t13_negociadores_retroplanning on f13_consecutivo_retro=f12_consecutivo
                            where
	                            f12_id_estado in(1,2) and
	                            CONVERT(date,f12_fecha_creacion) between @fecha_ini and @fecha_fin and
	                            f13_id_usuario = @id_usuario";

            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@fecha_ini", fecha_ini);
                cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                cmd.Parameters.AddWithValue("@id_usuario", Usuarios.Id);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new DataTable();
                    res.Load(dr);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar retroplanning: " + ex.Message);
            }
            return res;
        }

        public void GuardarRetroplanning(Planning planning)
        {
            string SQL_PLANNING = @"insert into
                                t12_retroplanning
                            (
                                f12_consecutivo,
                                f12_descripcion,
                                f12_id_tipo_dinamica,
                                f12_fecha_ini_vig,
                                f12_fecha_fin_vig,
                                f12_fecha_entrega_mercadeo,
                                f12_fecha_entrega_comercial,
                                f12_id_estado,
                                f12_usuario_creacion,
                                f12_fecha_creacion
                            )
                            values
                            (
                                @consecutivo,
                                @descripcion,
                                @id_tipo_dinamica,
                                @fecha_ini_vig,
                                @fecha_fin_vig,
                                @fecha_entrega_mercadeo,
                                @fecha_entrega_comercial,
                                1,
                                @usuario_creacion,
                                GETDATE()
                            )";

            String SQL_NEGOCIADORES = @"insert into
                                            t13_negociadores_retroplanning
                                        (
                                            f13_consecutivo_retro,
                                            f13_id_usuario
                                        )
                                        values
                                        (
                                            @consecutivo,
                                            @id_usuario
                                        )";

            String SQL_CONSECUTIVO = @"update
	                                        t00_configuracion
                                        set
	                                        f00_valor=CONVERT(int,f00_valor)+1
                                        where
	                                        f00_id=1";

            SqlTransaction trans = null;
            try
            {
                int consecutivo = Convert.ToInt32(ObtenerValorConfiguracion(1));
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd_planning = new SqlCommand(SQL_PLANNING, conn, trans);
                cmd_planning.CommandType = CommandType.Text;
                cmd_planning.Parameters.AddWithValue("@consecutivo", consecutivo);
                cmd_planning.Parameters.AddWithValue("@descripcion", planning.Descripcion);
                cmd_planning.Parameters.AddWithValue("@id_tipo_dinamica", planning.Dinamica);
                cmd_planning.Parameters.AddWithValue("@fecha_ini_vig", planning.FechaInicialVigencia);
                cmd_planning.Parameters.AddWithValue("@fecha_fin_vig", planning.FechaFinalVigencia);
                cmd_planning.Parameters.AddWithValue("@fecha_entrega_mercadeo", planning.FechaEntregaMercadeo);
                cmd_planning.Parameters.AddWithValue("@fecha_entrega_comercial", planning.FechaEntregaComercial);
                
                cmd_planning.Parameters.AddWithValue("@usuario_creacion", Usuarios.NombreUsuario);
                cmd_planning.ExecuteNonQuery();

                SqlCommand cmd_negociadores = new SqlCommand(SQL_NEGOCIADORES, conn, trans);
                cmd_negociadores.CommandType = CommandType.Text;
                foreach (int n in planning.Negociadores)
                {
                    cmd_negociadores.Parameters.AddWithValue("@consecutivo", consecutivo);
                    cmd_negociadores.Parameters.AddWithValue("@id_usuario", n);
                    cmd_negociadores.ExecuteNonQuery();
                    cmd_negociadores.Parameters.Clear();
                }

                SqlCommand cmd_consecutivo = new SqlCommand(SQL_CONSECUTIVO, conn, trans);
                cmd_consecutivo.CommandType = CommandType.Text;
                cmd_consecutivo.ExecuteNonQuery();

                trans.Commit();
                conn.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception("Error al guardar retroplanning: " + ex.Message);
            }
        }

        public void EditarRetroplanning(Planning planning)
        {
            string SQL_PLANNING = @"update
                                        t12_retroplanning
                                    set
                                        f12_descripcion=@descripcion,
                                        f12_id_tipo_dinamica=@id_tipo_dinamica,
                                        f12_fecha_ini_vig=@fecha_ini_vig,
                                        f12_fecha_fin_vig=@fecha_fin_vig,
                                        f12_fecha_entrega_mercadeo=@fecha_entrega_mercadeo,
                                        f12_fecha_entrega_comercial=@fecha_entrega_comercial,
                                        f12_usuario_edicion=@usuario_edicion,
                                        f12_fecha_edicion=GETDATE()
                                    where
	                                    f12_consecutivo=@consecutivo";

            string SQL_DEL_NEGOCIADORES = @"delete
	                                            t13_negociadores_retroplanning
                                            where
	                                            f13_consecutivo_retro=@consecutivo";

            String SQL_NEGOCIADORES = @"insert into
                                            t13_negociadores_retroplanning
                                        (
                                            f13_consecutivo_retro,
                                            f13_id_usuario
                                        )
                                        values
                                        (
                                            @consecutivo,
                                            @id_usuario
                                        )";

            SqlTransaction trans = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd_planning = new SqlCommand(SQL_PLANNING, conn, trans);
                cmd_planning.CommandType = CommandType.Text;
                cmd_planning.Parameters.AddWithValue("@descripcion", planning.Descripcion);
                cmd_planning.Parameters.AddWithValue("@id_tipo_dinamica", planning.Dinamica);
                cmd_planning.Parameters.AddWithValue("@fecha_ini_vig", planning.FechaInicialVigencia);
                cmd_planning.Parameters.AddWithValue("@fecha_fin_vig", planning.FechaFinalVigencia);
                cmd_planning.Parameters.AddWithValue("@fecha_entrega_mercadeo", planning.FechaEntregaMercadeo);
                cmd_planning.Parameters.AddWithValue("@fecha_entrega_comercial", planning.FechaEntregaComercial);
                
                cmd_planning.Parameters.AddWithValue("@usuario_edicion", Usuarios.NombreUsuario);
                cmd_planning.Parameters.AddWithValue("@consecutivo", planning.Consecutivo);
                cmd_planning.ExecuteNonQuery();

                SqlCommand cmd_del_negociadores = new SqlCommand(SQL_DEL_NEGOCIADORES, conn, trans);
                cmd_del_negociadores.CommandType = CommandType.Text;
                cmd_del_negociadores.Parameters.AddWithValue("@consecutivo", planning.Consecutivo);
                cmd_del_negociadores.ExecuteNonQuery();

                SqlCommand cmd_negociadores = new SqlCommand(SQL_NEGOCIADORES, conn, trans);
                cmd_negociadores.CommandType = CommandType.Text;
                foreach (int n in planning.Negociadores)
                {
                    cmd_negociadores.Parameters.AddWithValue("@consecutivo", planning.Consecutivo);
                    cmd_negociadores.Parameters.AddWithValue("@id_usuario", n);
                    cmd_negociadores.ExecuteNonQuery();
                    cmd_negociadores.Parameters.Clear();
                }

                trans.Commit();
                conn.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception("Error al guardar retroplanning: " + ex.Message);
            }
        }

        public void CambiarEstadoRetroplanning(int estado, int consecutivo)
        {
            string SQL = @"update
	                            t12_retroplanning
                            set
	                            f12_id_estado=@id_estado
                            where
	                            f12_consecutivo=@consecutivo";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd=new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("id_estado", estado);
                cmd.Parameters.AddWithValue("consecutivo", consecutivo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado del retroplanning: " + ex.Message);
            }
        }

        public void CerrarRetroplanning()
        {
            string SQL = @"update
	                            t12_retroplanning
                            set
	                            f12_id_estado=4
                            where
	                           convert(date, GETDATE()) > f12_fecha_entrega_mercadeo
	                           and f12_id_estado in(1,2,3)";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar el retroplanning: " + ex.Message);
            }
        }

        public string ObtenerDescuentoAsociadoRetroplanning(int id_usuario, int consecutivo_retroplanning)
        {
            string SQL = @"select distinct
		                        f17_consecutivo
	                        from 
		                        t17_descuento_directo
		                        inner join t19_detalle_descuento_directo on f19_cons_descuento=f17_consecutivo
	                        where
		                        f17_id_usuario=@id_usuario
		                        and f17_consecutivo_retro=@consecutivo_retro";
            string res;
            try
            {
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = new SqlCommand(SQL, conn);
				cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@consecutivo_retro", consecutivo_retroplanning);
				res=Convert.ToString(cmd.ExecuteScalar());
                if (!res.Equals(""))
                {
                    res = res.PadLeft(4, '0');
				}
				conn.Close();
			}
            catch (Exception ex)
            {
				throw new Exception("Error al cerrar el retroplanning: " + ex.Message);
			}
            return res;
        }
    }
}
