using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Serialization;
using static PlanAccionComercial.Class.Clusters;
using System.IO;
using System.Net.Mail;
using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace PlanAccionComercial.Class
{
    public class DescuentoRetroplanning
    {
        public class Descuento
        {
            public int Id { get; set; }
            public int ConsecutivoRetroplanning { get; set; }
            public string Periodicidad { get; set; }
            public List<int> TipoComunicacion { get; set; }

            public class Detalle
            {
                public int Id { get; set; }
                public int Tipo { get; set; }
                public string Item { get; set; }
                public string Referencia { get; set; }
                public string Descripcion { get; set; }
                public string MarcaItem { get; set; }
                public string UndMedida { get; set; }
                public decimal Precio { get; set; }
                public decimal PUM { get; set; }
                public decimal Existencia { get; set; }
                public string IdPlan { get; set; }
                public string Plan { get; set; }
                public string IdCriterio { get; set; }
                public string Criterio { get; set; }
                public char TipoDescuento { get; set; }
                public decimal Descuento { get; set; }
                public decimal AsumeProveedor { get; set; }
                public decimal AsumeMegatiendas { get; set; }
                public string FechaInicialDescuento { get; set; }
                public string FechaFinalDescuento { get; set; }
                public int Cluster { get; set; }
                public string IdCentroOperacion { get; set; }
                public string CentroOperacion { get; set; }
            }
        }

        private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;
        private string cadena_unoee = ConfigurationManager.ConnectionStrings["unoee"].ConnectionString;

        public string[] ObtenerDatosItem(string item_ref)
        {
            string SQL = @"select distinct
								f120_id, 
								f120_referencia,
								f120_descripcion,
								replace(f106_descripcion,'''','') collate SQL_Latin1_General_Cp1251_CS_AS marca,
								f120_id_unidad_inventario
							from 
								t120_mc_items
								inner join t121_mc_items_extensiones ie on ie.f121_id_cia = f120_id_cia and ie.f121_rowid_item = f120_rowid 
								inner join t126_mc_items_precios p on p.f126_id_cia = f120_id_cia and p.f126_rowid_item = f120_rowid 
								inner join t125_mc_items_criterios on f125_id_cia = f120_id_cia and f125_rowid_item = f120_rowid and f125_id_plan = '012' 
								inner join t106_mc_criterios_item_mayores on f106_id_cia = f125_id_cia and f106_id_plan = f125_id_plan and f106_id = f125_id_criterio_mayor 
							where
								f120_id_cia = 1
								and (convert(varchar(20),f120_id)=@item_ref
								or f120_referencia=@item_ref)";
            string[] res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_unoee);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@item_ref", item_ref);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new string[5];
                    while (dr.Read())
                    {
                        res[0] = dr.GetInt32(0).ToString();
                        res[1] = dr.GetString(1).ToString();
                        res[2] = dr.GetString(2).ToString();
                        res[3] = dr.GetString(3).ToString();
                        res[4] = dr.GetString(4).ToString();
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos del ítem: " + ex.Message);
            }
            return res;
        }

        public List<object[]> ObtenerDatosItemCo(string item_ref, string co)
        {
            string SQL = $@"select distinct
							f120_id, 
							dbo.F_GENERICO_HALLAR_PREC_VTA(1, p.f126_id_lista_precio, ie.f121_rowid, GETDATE(), p.f126_id_unidad_medida) precio,
							convert(decimal(18,2), round(dbo.F_GENERICO_HALLAR_PREC_VTA(1, p.f126_id_lista_precio, ie.f121_rowid, GETDATE(), p.f126_id_unidad_medida)/
							(case 
								when 
									len(rtrim(dbo.F_GENERICO_HALLAR_MOVTO_ENT(f120_id_cia, isnull(f120_rowid_movto_entidad, 0), '001', 'FACTOR', 3))) > 0 
								then 
									cast(dbo.F_GENERICO_HALLAR_MOVTO_ENT(f120_id_cia, isnull(f120_rowid_movto_entidad, 0), '001', 'FACTOR', 3) as decimal(18, 2)) 
								else 1 
							end),2,1)) pum,
							f132_cant_existencia_1 existencia,
							f157_id co,
							f157_descripcion
						from 
							t120_mc_items
							inner join t121_mc_items_extensiones ie on ie.f121_id_cia = f120_id_cia and ie.f121_rowid_item = f120_rowid 
							inner join t126_mc_items_precios p on p.f126_id_cia = f120_id_cia and p.f126_rowid_item = f120_rowid 
							inner join t132_mc_items_instalacion on f132_id_cia=f121_id_cia and f132_rowid_item_ext=f121_rowid 
							inner join t157_mc_instalaciones on f132_id_instalacion=f157_id
						where
							f120_id_cia=1
							and (convert(varchar(20),f120_id)=@item_ref
							or f120_referencia=@item_ref)
							and f126_id_lista_precio in({co})
							and f132_id_instalacion in({co})";
            List<object[]> res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_unoee);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddWithValue("@item_ref", item_ref);
                cmd.Parameters.AddWithValue("@lp", co);
                cmd.Parameters.AddWithValue("@co", co);

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new List<object[]>();
                    while (dr.Read())
                    {
                        object[] row = new object[6];
                        row[0] = dr.GetInt32(0);
                        row[1] = dr.GetDecimal(1);
                        row[2] = dr.GetDecimal(2);
                        row[3] = dr.GetDecimal(3);
                        row[4] = dr.GetString(4);
                        row[5] = dr.GetString(5);
                        res.Add(row);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos del ítem por Centro Operación: " + ex.Message);
            }
            return res;
        }

        public List<string> ObtenerCoCluster(string cod_cluster)
        {
            string SQL = @"select
								f06_id_co
							from
								t05_clusters
								inner join t06_co_clusters on f06_cod_cluster=f05_cod
							where
								f05_cod=@cod";
            List<string> res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cod", cod_cluster);

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new List<string>();
                    while (dr.Read())
                    {
                        res.Add(dr.GetString(0));
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener Centros de operación del Cluster: " + ex.Message);
            }
            return res;
        }

        public async Task<DataTable> ListarPlanes()
        {
            string SQL = @"select 
	                            f105_id,
	                            f105_id + '-' + f105_descripcion f105_descripcion
                            from 
	                            t105_mc_criterios_item_planes 
                            where 
	                            f105_id_cia='1'
                            order by 2";
            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_unoee);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                
                SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new DataTable();
                    res.Load(dr);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar planes: " + ex.Message);
            }
            return res;
        }

        public async Task<DataTable> ListarCriterios(string id_plan)
        {
            string SQL = @"select 
								f106_id,
								f106_id + '-' + f106_descripcion f106_descripcion
							from 
								t106_mc_criterios_item_mayores
								inner join t105_mc_criterios_item_planes on f105_id=f106_id_plan and f106_id_cia=f105_id_cia
							where
								f105_id_cia=1 
								and f105_id =@id_plan
                            order by 2";
            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_unoee);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_plan", id_plan);

                SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new DataTable();
                    res.Load(dr);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar criterios: " + ex.Message);
            }
            return res;
        }

        public void GuardarDescuento(Descuento descuento, List<Descuento.Detalle> detalles)
        {
            string SQL_DEL_DESCUENTO = @"delete
	                                        t14_descuento_retroplanning 
                                        where
	                                        f14_consecutivo_retro=@consecutivo_retro and
	                                        f14_id_usuario=@id_usuario";

            string SQL_DESCUENTO = @"insert into
										t14_descuento_retroplanning
									(
										f14_consecutivo_retro,
										f14_periodicidad,
										f14_id_usuario,
										f14_fecha
									)output INSERTED.f14_id
									values
									(
										@consecutivo_retro,
										@periodicidad,
										@id_usuario,
										GETDATE()
									)";

            string SQL_TIPO_COM = @"insert into
										t15_tipo_comunicacion_descuento_retroplanning
									(
										f15_id_descuento,
										f15_id_tipo_comunicacion
									)
									values
									(
										@id_descuento,
										@id_tipo_comunicacion
									)";

            string SQL_DET_DESCUENTO = @"insert into
											t16_detalle_descuento_retroplanning
										(
											f16_id_descuento,
											f16_tipo,
											f16_item,
											f16_referencia,
											f16_descripcion,
											f16_marca_item,
											f16_um,
											f16_precio,
											f16_pum,
											f16_existencia,
											f16_id_plan,
											f16_plan,
											f16_id_criterio,
											f16_criterio,
                                            f16_tipo_descuento,
											f16_descuento,
											f16_porc_proveedor,
											f16_porc_megatiendas,
                                            f16_fecha_ini_desc,
                                            f16_fecha_fin_desc,
											f16_cod_cluster,
											f16_id_co,
											f16_co
										)
										values
										(
											@id_descuento,
											@tipo,
											@item,
											@referencia,
											@descripcion,
											@marca_item,
											@um,
											@precio,
											@pum,
											@existencia,
											@id_plan,
											@plan,
											@id_criterio,
											@criterio,
                                            @tipo_descuento,
											@descuento,
											@porc_proveedor,
											@porc_megatiendas,
                                            @fecha_ini_desc,
                                            @fecha_fin_desc,
											@cod_cluster,
											@id_co,
											@co
										)";
            SqlTransaction trans = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand cmd_del_descuento = new SqlCommand(SQL_DEL_DESCUENTO, conn, trans);
                cmd_del_descuento.CommandType = CommandType.Text;
                cmd_del_descuento.Parameters.AddWithValue("@consecutivo_retro", descuento.ConsecutivoRetroplanning);
                cmd_del_descuento.Parameters.AddWithValue("@id_usuario", Usuarios.Id);
                cmd_del_descuento.ExecuteNonQuery();

                SqlCommand cmd_descuento = new SqlCommand(SQL_DESCUENTO, conn, trans);
                cmd_descuento.CommandType = CommandType.Text;
                cmd_descuento.Parameters.AddWithValue("@consecutivo_retro", descuento.ConsecutivoRetroplanning);
                cmd_descuento.Parameters.AddWithValue("@periodicidad", descuento.Periodicidad);
                cmd_descuento.Parameters.AddWithValue("@id_usuario", Usuarios.Id);
                int id = (int)cmd_descuento.ExecuteScalar();

                SqlCommand cmd_tipo_comunicacion = new SqlCommand(SQL_TIPO_COM, conn, trans);
                cmd_tipo_comunicacion.CommandType = CommandType.Text;
                foreach (int tipo_com in descuento.TipoComunicacion)
                {
                    cmd_tipo_comunicacion.Parameters.AddWithValue("@id_descuento", id);
                    cmd_tipo_comunicacion.Parameters.AddWithValue("@id_tipo_comunicacion", tipo_com);
                    cmd_tipo_comunicacion.ExecuteNonQuery();
                    cmd_tipo_comunicacion.Parameters.Clear();
                }

                SqlCommand cmd_detalle = new SqlCommand(SQL_DET_DESCUENTO, conn, trans);
                cmd_detalle.CommandType = CommandType.Text;
                foreach (Descuento.Detalle detalle in detalles)
                {
                    cmd_detalle.Parameters.AddWithValue("@id_descuento", id);
                    cmd_detalle.Parameters.AddWithValue("@tipo", detalle.Tipo);
                    cmd_detalle.Parameters.AddWithValue("@item", detalle.Item == "" ? (object)DBNull.Value : detalle.Item);
                    cmd_detalle.Parameters.AddWithValue("@referencia", detalle.Referencia == "" ? (object)DBNull.Value : detalle.Referencia);
                    cmd_detalle.Parameters.AddWithValue("@descripcion", detalle.Descripcion == "" ? (object)DBNull.Value : detalle.Descripcion);
                    cmd_detalle.Parameters.AddWithValue("@marca_item", detalle.MarcaItem == "" ? (object)DBNull.Value : detalle.MarcaItem);
                    cmd_detalle.Parameters.AddWithValue("@um", detalle.UndMedida == "" ? (object)DBNull.Value : detalle.UndMedida);
                    cmd_detalle.Parameters.AddWithValue("@precio", detalle.Precio == 0 ? (object)DBNull.Value : detalle.Precio);
                    cmd_detalle.Parameters.AddWithValue("@pum", detalle.PUM == 0 ? (object)DBNull.Value : detalle.PUM);
                    cmd_detalle.Parameters.AddWithValue("@existencia", detalle.Existencia == 0 ? (object)DBNull.Value : detalle.Existencia);
                    cmd_detalle.Parameters.AddWithValue("@id_plan", detalle.IdPlan == "" ? (object)DBNull.Value : detalle.IdPlan);
                    cmd_detalle.Parameters.AddWithValue("@plan", detalle.Plan == "" ? (object)DBNull.Value : detalle.Plan);
                    cmd_detalle.Parameters.AddWithValue("@id_criterio", detalle.IdCriterio == "" ? (object)DBNull.Value : detalle.IdCriterio);
                    cmd_detalle.Parameters.AddWithValue("@criterio", detalle.Criterio == "" ? (object)DBNull.Value : detalle.Criterio);
                    
                    cmd_detalle.Parameters.AddWithValue("@tipo_descuento", detalle.TipoDescuento);
                    cmd_detalle.Parameters.AddWithValue("@descuento", detalle.Descuento);
                    cmd_detalle.Parameters.AddWithValue("@porc_proveedor", detalle.AsumeProveedor);
                    cmd_detalle.Parameters.AddWithValue("@porc_megatiendas", detalle.AsumeMegatiendas);
                    cmd_detalle.Parameters.AddWithValue("@fecha_ini_desc", detalle.FechaInicialDescuento);
                    cmd_detalle.Parameters.AddWithValue("@fecha_fin_desc", detalle.FechaFinalDescuento);

                    cmd_detalle.Parameters.AddWithValue("@cod_cluster", detalle.Cluster == 0 ? (object)DBNull.Value : detalle.Cluster);
                    cmd_detalle.Parameters.AddWithValue("@id_co", detalle.IdCentroOperacion == "" ? (object)DBNull.Value : detalle.IdCentroOperacion);
                    cmd_detalle.Parameters.AddWithValue("@co", detalle.CentroOperacion == "" ? (object)DBNull.Value : detalle.CentroOperacion);

                    cmd_detalle.ExecuteNonQuery();
                    cmd_detalle.Parameters.Clear();
                }

                trans.Commit();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al guardar cluster: " + ex.Message);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception("Error al guardar cluster: " + ex.Message);
            }
        }

        public object[] ObtenerDatosDescuento(int consecutivo_retro)
        {
            string SQL = @"select 
	                            f14_id,
	                            f14_consecutivo_retro,
	                            f14_periodicidad
                            from 
	                            t14_descuento_retroplanning 
                            where
	                            f14_consecutivo_retro=@consecutivo_retro and
	                            f14_id_usuario=@id_usuario";
            object[] res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SQL;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@consecutivo_retro", consecutivo_retro);
                cmd.Parameters.AddWithValue("@id_usuario", Usuarios.Id);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    res = new object[2];
                    while (dr.Read())
                    {
                        res[0] = dr["f14_id"];
                        res[1] = dr["f14_periodicidad"];
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos descuento: " + ex.Message);
            }
            return res;
        }

        public List<int> ObtenerTiposComunicacionDescuento(int id_descuento)
        {
            string SQL = @"select
	                            f15_id_tipo_comunicacion
                            from
	                            t15_tipo_comunicacion_descuento_retroplanning
                            where
	                            f15_id_descuento=@id_descuento";
            List<int> res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SQL;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_descuento", id_descuento);
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
                throw new Exception("Error al obtener tipos comunicación descuento: " + ex.Message);
            }
            return res;
        }

        public DataTable ObtenerDetalleDescuento(int id_descuento)
        {
            string SQL = @"select 
	                            f16_id,
	                            f16_id_descuento,
	                            f16_tipo,
	                            f16_item,
	                            trim(f16_referencia) f16_referencia,
	                            trim(f16_descripcion) f16_descripcion,
	                            trim(f16_marca_item) f16_marca_item,
	                            f16_um,
	                            f16_precio,
	                            f16_pum,
	                            f16_existencia,
	                            f16_id_plan,
	                            f16_plan,
	                            f16_id_criterio,
	                            f16_criterio,
	                            f16_tipo_descuento,
	                            f16_descuento,
	                            f16_porc_proveedor,
	                            f16_porc_megatiendas,
	                            CONVERT(VARCHAR(10), f16_fecha_ini_desc, 103) f16_fecha_ini_desc,
	                            CONVERT(VARCHAR(10), f16_fecha_fin_desc, 103) f16_fecha_fin_desc,
	                            f05_cod,
	                            f05_descripcion,
	                            f16_id_co,
	                            f16_co
                            from
	                            t16_detalle_descuento_retroplanning
	                            left join t05_clusters on f16_cod_cluster=f05_cod
                            where
	                            f16_id_descuento=@id_descuento";
            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SQL;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_descuento", id_descuento);
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
                throw new Exception("Error al obtener detalle descuento: " + ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Obtiene el número de negociadores del retroplanning y el número de descuentos registrados para el retroplanning.
        /// </summary>
        /// <param name="consecutivo_retro">Consecutivo del retroplanning</param>
        public int[] VerificarDescuentosNegociadores(int consecutivo_retro)
        {
            string SQL = @"select 
	                        COUNT(f13_id_usuario)nro_negociadores,
	                        COUNT(f14_id_usuario)nro_descuentos
                        from 
	                        t12_retroplanning
	                        left join t13_negociadores_retroplanning on f13_consecutivo_retro=f12_consecutivo
	                        left join t14_descuento_retroplanning on f14_consecutivo_retro=f12_consecutivo and f14_id_usuario=f13_id_usuario
                        where
	                        f12_consecutivo=@consecutivo";
            int[] res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType=CommandType.Text;
                cmd.Parameters.AddWithValue("@consecutivo", consecutivo_retro);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows) 
                {
                    res = new int[2];
                    dr.Read();
                    res[0] = dr.GetInt32(0);
                    res[1] = dr.GetInt32(1);
                }   
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar los descuentos de negociadores: " + ex.Message);
            }
            return res;
        }

        public void EnviarCorreo(string to, string message, string subject)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe");
                AppSettingsSection section = config.AppSettings;

                string smtp = section.Settings["smtp"].Value;
                int puerto = Convert.ToInt32(section.Settings["puerto"].Value);

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
				string from = section.Settings["from"].Value;
				string pwd = section.Settings["pwd"].Value;
				mail.From = new MailAddress(from, "Notificación");

                mail.To.Add(to);

                mail.IsBodyHtml = true;
                mail.Subject = subject;
                mail.Body = message;
                mail.Priority = MailPriority.High;

                SmtpServer.Port = puerto;
                SmtpServer.Credentials = new System.Net.NetworkCredential(from,pwd);
                SmtpServer.EnableSsl = false;//para gmail true;

                ServicePointManager.ServerCertificateValidationCallback +=
                              delegate (
                              Object sender1,
                              X509Certificate certificate,
                              X509Chain chain,
                              SslPolicyErrors sslPolicyErrors)
                              {
                                  return true;
                              };

                SmtpServer.Send(mail);
            }
            catch (SmtpException ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception("SmtpException, Error al enviar correo: " + ex.InnerException.Message);
                }
                else
                {
                    throw new Exception("SmtpException, Error al enviar correo: " + ex.Message);
                }
            }
            catch (WebException ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception("WebException, Error al enviar correo: " + ex.InnerException.Message + Environment.NewLine);
                }
                else
                {
                    throw new Exception("WebException, Error al enviar correo: " + ex.Message + Environment.NewLine);
                }
            }
            catch (SocketException ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception("SocketException, Error al enviar: " + ex.InnerException.Message + Environment.NewLine);
                }
                else
                {
                    throw new Exception("SocketException, Error al enviar correo: " + ex.Message + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception("Exception, Error al enviar: " + ex.InnerException.Message + Environment.NewLine);
                }
                else
                {
                    throw new Exception("Exception, Error al enviar correo: " + ex.Message + Environment.NewLine);
                }
            }
        }
    }
}
