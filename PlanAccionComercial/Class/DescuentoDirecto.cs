using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;

namespace PlanAccionComercial.Class
{
	public class DescuentoDirecto
	{
		public class Descuento
		{
			public int Consecutivo { get; set; }
			public int ConsecutivoRetroplanning { get; set; }
			public int TipoDinamica { get; set; }
			public List<int> TipoComunicacion { get; set; }
			public List<int> TipoExhibicion { get; set; }
			public int Estado { get; set; }

			public class Detalle
			{
				public int Id { get; set; }
				public int Tipo { get; set; }
				public string Item { get; set; }
				public string Referencia { get; set; }
				public string Descripcion { get; set; }
				public string Nit { get; set; }
				public string Proveedor { get; set; }
				public string IdCasaProveedor { get; set; }
				public string CasaProveedor { get; set; }
				public string MarcaItem { get; set; }
				public string UndMedida { get; set; }
				public decimal PrecioInicial { get; set; }
				public decimal Factor { get; set; }
				public decimal PumInicial { get; set; }
				public decimal Existencia { get; set; }
				public string IdPlan { get; set; }
				public string Plan { get; set; }
				public string IdCriterio { get; set; }
				public string Criterio { get; set; }
				public string IdPlan2 { get; set; }
				public string Plan2 { get; set; }
				public string IdCriterio2 { get; set; }
				public string Criterio2 { get; set; }
				public string IdPlan3 { get; set; }
				public string Plan3 { get; set; }
				public string IdCriterio3 { get; set; }
				public string Criterio3 { get; set; }
				public string TipoDescuento { get; set; }
				public decimal Descuento { get; set; }
				public decimal AsumeProveedor { get; set; }
				public decimal AsumeMegatiendas { get; set; }
				public decimal PrecioFinal { get; set; }
				public decimal PumFinal { get; set; }
				public string FechaInicialDescuento { get; set; }
				public string FechaFinalDescuento { get; set; }
				public string ModoCobro { get; set; }
				public string IdCentroOperacion { get; set; }
				public string CentroOperacion { get; set; }
				public string RegionalCluster { get; set; }
				public bool IndRegionalCluster { get; set; }
				public string CodCluster { get; set; }
				public string Observacion { get; set; }
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
	                            replace(m1.f106_descripcion,'''','') collate SQL_Latin1_General_Cp1251_CS_AS marca,
	                            f120_id_unidad_inventario,
	                            m2.f106_descripcion 'casa_prov',
                                m2.f106_id id_casa_prov
                            from 
	                            t120_mc_items
	                            inner join t121_mc_items_extensiones ie on ie.f121_id_cia = f120_id_cia and ie.f121_rowid_item = f120_rowid 
	                           -- inner join t126_mc_items_precios p on p.f126_id_cia = f120_id_cia and p.f126_rowid_item = f120_rowid 
	                            inner join t125_mc_items_criterios c1 on c1.f125_id_cia = f120_id_cia and c1.f125_rowid_item = f120_rowid and c1.f125_id_plan = '012' 
	                            inner join t106_mc_criterios_item_mayores m1 on m1.f106_id_cia = c1.f125_id_cia and m1.f106_id_plan = c1.f125_id_plan and m1.f106_id = c1.f125_id_criterio_mayor
	                            inner join t125_mc_items_criterios c2 on c2.f125_id_cia = f120_id_cia and c2.f125_rowid_item = f120_rowid and c2.f125_id_plan = '011' 
	                            inner join t106_mc_criterios_item_mayores m2 on m2.f106_id_cia = c2.f125_id_cia and m2.f106_id_plan = c2.f125_id_plan and m2.f106_id = c2.f125_id_criterio_mayor
                            where
	                            f120_id_cia = 1
	                            and f120_id=@item_ref";
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
					res = new string[7];
					while (dr.Read())
					{
						res[0] = dr.GetInt32(0).ToString();
						res[1] = dr.GetString(1).ToString();
						res[2] = dr.GetString(2).ToString();
						res[3] = dr.GetString(3).ToString();
						res[4] = dr.GetString(4).ToString();
						res[5] = dr.GetString(5).ToString();
						res[6] = dr.GetString(6).ToString();
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

		public async Task<DataTable> ListarPlanes()
		{
			string SQL = @"select 
	                            f105_id,
	                            f105_descripcion
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

		private string ObternerListaPrecios(string co)
		{
			string SQL = @"select
	                            f23_lp
                            from
	                            t23_centros_op_listas_precio
                            where
	                            f23_id_co=@id_co";

			SqlConnection conn = new SqlConnection(cadena_pac);
			conn.Open();
			SqlCommand cmd = new SqlCommand(SQL, conn);
			cmd.CommandType = CommandType.Text;
			cmd.CommandTimeout = 60;
			cmd.Parameters.AddWithValue("@id_co", co);
			string res = Convert.ToString(cmd.ExecuteScalar());
			conn.Close();
			return res;
		}

		public List<object[]> ObtenerDatosItemCo(string item_ref, string id_instalacion)
		{
			string SQL = $@"select
							f120_id,
							dbo.F_GENERICO_HALLAR_PREC_VTA(1, @id_lista_precios, ie.f121_rowid, GETDATE(), f131_id_unidad_medida) precio,
							convert(decimal(18,2), round(dbo.F_GENERICO_HALLAR_PREC_VTA(1, @id_lista_precios, ie.f121_rowid, GETDATE(), f131_id_unidad_medida)/
							(case
								when
									len(rtrim(dbo.F_GENERICO_HALLAR_MOVTO_ENT(f120_id_cia, isnull(f120_rowid_movto_entidad, 0), '001', 'FACTOR', 3))) > 0
								then
									cast(dbo.F_GENERICO_HALLAR_MOVTO_ENT(f120_id_cia, isnull(f120_rowid_movto_entidad, 0), '001', 'FACTOR', 3) as decimal(18, 2))
							else 1
							end),2,1)) pum,
							isnull(f132_cant_existencia_1,0) existencia,
							(case
								when
									len(rtrim(dbo.F_GENERICO_HALLAR_MOVTO_ENT(f120_id_cia, isnull(f120_rowid_movto_entidad, 0), '001', 'FACTOR', 3))) > 0
								then
									cast(dbo.F_GENERICO_HALLAR_MOVTO_ENT(f120_id_cia, isnull(f120_rowid_movto_entidad, 0), '001', 'FACTOR', 3) as decimal(18, 2))
							else 1
							end) factor,
							isnull(f132_id_instalacion,@id_instalacion) f132_id_instalacion
						from
							t120_mc_items
							inner join t121_mc_items_extensiones ie on ie.f121_id_cia = f120_id_cia and ie.f121_rowid_item = f120_rowid
							left outer join t132_mc_items_instalacion on f132_id_cia=f121_id_cia and f132_rowid_item_ext=f121_rowid and f132_id_instalacion =@id_instalacion
							left join t131_mc_items_barras on f131_id_cia=f121_id_cia and f131_rowid_item_ext=f121_rowid and f131_id=f121_id_barras_principal
						where
							f120_id_cia=1
							and f120_id=@id";

			List<object[]> res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_unoee);
				conn.Open();
				SqlCommand cmd = new SqlCommand(SQL, conn);
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 60;
				cmd.Parameters.AddWithValue("@id", item_ref);
				string lista_precios = ObternerListaPrecios(id_instalacion);
				cmd.Parameters.AddWithValue("@id_lista_precios", lista_precios);
				cmd.Parameters.AddWithValue("@id_instalacion", id_instalacion);

				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				if (dr.HasRows)
				{
					res = new List<object[]>();
					while (dr.Read())
					{
						object[] row = new object[5];
						row[0] = dr.GetInt32(0);
						row[1] = dr.GetDecimal(1);
						row[2] = dr.GetDecimal(2);
						row[3] = dr.GetDecimal(3);
						row[4] = dr.GetDecimal(4);
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

		public string ObtenerRazonSocial(string id)
		{
			string SQL = @"select 
								f200_razon_social 
							from 
								t200_mm_terceros
							where
								f200_id=@id
								and f200_id_cia=1";
			string res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_unoee);
				conn.Open();
				SqlCommand cmd = new SqlCommand(SQL, conn);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@id", id);
				res = Convert.ToString(cmd.ExecuteScalar());
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener Razón social: " + ex.Message);
			}
			return res;
		}

		public DataTable ObtenerCoCluster(string cod_cluster)
		{
			string SQL = @"select
								f06_id_co,
                                f06_desc_co
							from
								t05_clusters
								inner join t06_co_clusters on f06_cod_cluster=f05_cod
							where
								f05_cod=@cod";

			DataTable res = null;
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
					res = new DataTable();
					res.Load(dr);
				}
				dr.Close();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener Centros de operación del Cluster: " + ex.Message);
			}
			return res;
		}

		public async Task<DataTable> ListarCriterios(string id_plan)
		{
			string SQL = @"select 
								f106_id,
								f106_descripcion
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
			string SQL_DESCUENTO = @"insert into 
	                                        t17_descuento_directo
                                        (
	                                        f17_consecutivo,
	                                        f17_id_tipo_dinamica,
	                                        f17_usuario,
                                            f17_estado,
                                            f17_consecutivo_retro,
                                            f17_id_usuario
                                        )
                                        values
                                        (
	                                        @consecutivo,
	                                        @id_tipo_dinamica,
	                                        @usuario,
                                            0,
                                            @consecutivo_retro,
                                            @id_usuario
                                        )";

			string SQL_TIPO_COM = @"insert into
										t18_tipo_comunicacion_descuento_directo
									(
										f18_cons_descuento,
										f18_id_tipo_comunicacion
									)
									values
									(
										@cons_descuento,
										@id_tipo_comunicacion
									)";

			string SQL_TIPO_EXH = @"insert into
	                                    t20_tipo_exhibicion_descuento_directo
                                    (
	                                    f20_cons_descuento,
	                                    f20_id_tipo_exhibicion
                                    )
                                    values
                                    (
	                                    @cons_descuento,
	                                    @id_tipo_exhibicion
                                    )";

			string SQL_DET_DESCUENTO = @"insert into
											t19_detalle_descuento_directo
										(
											f19_cons_descuento,
											f19_tipo,
											f19_item,
											f19_referencia,
											f19_descripcion,
                                            f19_id_casa_prov,
                                            f19_casa_prov,
											f19_marca_item,
											f19_um,
											f19_precio,
											f19_pum,
											f19_existencia,
											f19_id_plan,
											f19_plan,
											f19_id_criterio,
											f19_criterio,
                                            f19_tipo_descuento,
											f19_descuento,
											f19_porc_proveedor,
											f19_porc_megatiendas,
                                            f19_precio_fin,
                                            f19_fecha_ini_desc,
                                            f19_fecha_fin_desc,
											f19_id_co,
											f19_co,
                                            f19_regional_cluster,
                                            f19_observacion,
                                            f19_modo_cobro,
                                            f19_ind_regional_cluster,
                                            f19_factor,
                                            f19_pum2,
											f19_cod_cluster,
											f19_nit,	
											f19_proveedor,	
											f19_id_plan2,	
											f19_plan2,	
											f19_id_criterio2,	
											f19_criterio2,
											f19_id_plan3,	
											f19_plan3,	
											f19_id_criterio3,	
											f19_criterio3
										)
										values
										(
											@cons_descuento,
											@tipo,
											@item,
											@referencia,
											@descripcion,
                                            @id_casa_prov,
                                            @casa_prov,
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
                                            @precio_fin,
                                            @fecha_ini_desc,
                                            @fecha_fin_desc,
											@id_co,
											@co,
                                            @regional_cluster,
                                            @observacion,
                                            @modo_cobro,
                                            @ind_regional_cluster,
                                            @factor,
                                            @pum2,
											@cod_cluster,
											@nit,	
											@proveedor,	
											@id_plan2,	
											@plan2,	
											@id_criterio2,	
											@criterio2,
											@id_plan3,	
											@plan3,	
											@id_criterio3,	
											@criterio3
										)";

			String SQL_CONSECUTIVO = @"update
	                                        t00_configuracion
                                        set
	                                        f00_valor=CONVERT(int,f00_valor) + 1
                                        where
	                                        f00_id=2";

			SqlTransaction trans = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				trans = conn.BeginTransaction();

				SqlCommand cmd_descuento = new SqlCommand(SQL_DESCUENTO, conn, trans);
				cmd_descuento.CommandType = CommandType.Text;
				cmd_descuento.CommandTimeout = 600;
				cmd_descuento.Parameters.AddWithValue("@consecutivo", descuento.Consecutivo);
				cmd_descuento.Parameters.AddWithValue("@consecutivo_retro", descuento.ConsecutivoRetroplanning == -1 ? (object)DBNull.Value : descuento.ConsecutivoRetroplanning);
				cmd_descuento.Parameters.AddWithValue("@id_tipo_dinamica", descuento.TipoDinamica);
				cmd_descuento.Parameters.AddWithValue("@usuario", Usuarios.NombreUsuario);
				cmd_descuento.Parameters.AddWithValue("@id_usuario", Usuarios.Id);
				cmd_descuento.ExecuteNonQuery();

				if (descuento.TipoComunicacion != null)
				{
					SqlCommand cmd_tipo_comunicacion = new SqlCommand(SQL_TIPO_COM, conn, trans);
					cmd_tipo_comunicacion.CommandType = CommandType.Text;
					cmd_tipo_comunicacion.CommandTimeout = 600;
					foreach (int tipo_com in descuento.TipoComunicacion)
					{
						cmd_tipo_comunicacion.Parameters.AddWithValue("@cons_descuento", descuento.Consecutivo);
						cmd_tipo_comunicacion.Parameters.AddWithValue("@id_tipo_comunicacion", tipo_com);
						cmd_tipo_comunicacion.ExecuteNonQuery();
						cmd_tipo_comunicacion.Parameters.Clear();
					}
				}

				if (descuento.TipoExhibicion != null)
				{
					SqlCommand cmd_tipo_exhibicion = new SqlCommand(SQL_TIPO_EXH, conn, trans);
					cmd_tipo_exhibicion.CommandType = CommandType.Text;
					cmd_tipo_exhibicion.CommandTimeout = 600;
					foreach (int tipo_exh in descuento.TipoExhibicion)
					{
						cmd_tipo_exhibicion.Parameters.AddWithValue("@cons_descuento", descuento.Consecutivo);
						cmd_tipo_exhibicion.Parameters.AddWithValue("@id_tipo_exhibicion", tipo_exh);
						cmd_tipo_exhibicion.ExecuteNonQuery();
						cmd_tipo_exhibicion.Parameters.Clear();
					}
				}

				SqlCommand cmd_detalle = new SqlCommand(SQL_DET_DESCUENTO, conn, trans);
				cmd_detalle.CommandType = CommandType.Text;
				cmd_detalle.CommandTimeout = 600;
				foreach (Descuento.Detalle detalle in detalles)
				{
					cmd_detalle.Parameters.AddWithValue("@cons_descuento", descuento.Consecutivo);
					cmd_detalle.Parameters.AddWithValue("@tipo", detalle.Tipo);
					cmd_detalle.Parameters.AddWithValue("@item", detalle.Item == "" ? (object)DBNull.Value : detalle.Item);
					cmd_detalle.Parameters.AddWithValue("@referencia", detalle.Referencia == "" ? (object)DBNull.Value : detalle.Referencia);
					cmd_detalle.Parameters.AddWithValue("@descripcion", detalle.Descripcion == "" ? (object)DBNull.Value : detalle.Descripcion);
					cmd_detalle.Parameters.AddWithValue("@nit", detalle.Nit);
					cmd_detalle.Parameters.AddWithValue("@proveedor", detalle.Proveedor);
					cmd_detalle.Parameters.AddWithValue("@id_casa_prov", detalle.IdCasaProveedor == "" ? (object)DBNull.Value : detalle.IdCasaProveedor);
					cmd_detalle.Parameters.AddWithValue("@casa_prov", detalle.CasaProveedor == "" ? (object)DBNull.Value : detalle.CasaProveedor);
					cmd_detalle.Parameters.AddWithValue("@marca_item", detalle.MarcaItem == "" ? (object)DBNull.Value : detalle.MarcaItem);
					cmd_detalle.Parameters.AddWithValue("@um", detalle.UndMedida == "" ? (object)DBNull.Value : detalle.UndMedida);
					cmd_detalle.Parameters.AddWithValue("@precio", detalle.PrecioInicial == 0 ? (object)DBNull.Value : detalle.PrecioInicial);
					cmd_detalle.Parameters.AddWithValue("@factor", detalle.Factor);
					cmd_detalle.Parameters.AddWithValue("@pum", detalle.PumInicial == 0 ? (object)DBNull.Value : detalle.PumInicial);
					cmd_detalle.Parameters.AddWithValue("@existencia", detalle.Existencia == 0 ? (object)DBNull.Value : detalle.Existencia);
					cmd_detalle.Parameters.AddWithValue("@id_plan", detalle.IdPlan == "" ? (object)DBNull.Value : detalle.IdPlan);
					cmd_detalle.Parameters.AddWithValue("@plan", detalle.Plan == "" ? (object)DBNull.Value : detalle.Plan);
					cmd_detalle.Parameters.AddWithValue("@id_criterio", detalle.IdCriterio == "" ? (object)DBNull.Value : detalle.IdCriterio);
					cmd_detalle.Parameters.AddWithValue("@criterio", detalle.Criterio == "" ? (object)DBNull.Value : detalle.Criterio);
					cmd_detalle.Parameters.AddWithValue("@id_plan2", detalle.IdPlan2 == "" ? (object)DBNull.Value : detalle.IdPlan2);
					cmd_detalle.Parameters.AddWithValue("@plan2", detalle.Plan2 == "" ? (object)DBNull.Value : detalle.Plan2);
					cmd_detalle.Parameters.AddWithValue("@id_criterio2", detalle.IdCriterio2 == "" ? (object)DBNull.Value : detalle.IdCriterio2);
					cmd_detalle.Parameters.AddWithValue("@criterio2", detalle.Criterio2 == "" ? (object)DBNull.Value : detalle.Criterio2);
					cmd_detalle.Parameters.AddWithValue("@id_plan3", detalle.IdPlan3 == "" ? (object)DBNull.Value : detalle.IdPlan3);
					cmd_detalle.Parameters.AddWithValue("@plan3", detalle.Plan3 == "" ? (object)DBNull.Value : detalle.Plan3);
					cmd_detalle.Parameters.AddWithValue("@id_criterio3", detalle.IdCriterio3 == "" ? (object)DBNull.Value : detalle.IdCriterio3);
					cmd_detalle.Parameters.AddWithValue("@criterio3", detalle.Criterio3 == "" ? (object)DBNull.Value : detalle.Criterio3);

					cmd_detalle.Parameters.AddWithValue("@tipo_descuento", detalle.TipoDescuento);
					cmd_detalle.Parameters.AddWithValue("@descuento", detalle.Descuento == 0 ? (object)DBNull.Value : detalle.Descuento);
					cmd_detalle.Parameters.AddWithValue("@porc_proveedor", detalle.AsumeProveedor == 0 ? (object)DBNull.Value : detalle.AsumeProveedor);
					cmd_detalle.Parameters.AddWithValue("@porc_megatiendas", detalle.AsumeMegatiendas == 0 ? (object)DBNull.Value : detalle.AsumeMegatiendas);
					cmd_detalle.Parameters.AddWithValue("@precio_fin", detalle.PrecioFinal);
					cmd_detalle.Parameters.AddWithValue("@pum2", detalle.PumFinal == 0 ? (object)DBNull.Value : detalle.PumFinal);
					cmd_detalle.Parameters.AddWithValue("@fecha_ini_desc", detalle.FechaInicialDescuento);
					cmd_detalle.Parameters.AddWithValue("@fecha_fin_desc", detalle.FechaFinalDescuento);
					cmd_detalle.Parameters.AddWithValue("@modo_cobro", detalle.ModoCobro);
					cmd_detalle.Parameters.AddWithValue("@id_co", detalle.IdCentroOperacion == "" ? (object)DBNull.Value : detalle.IdCentroOperacion);
					cmd_detalle.Parameters.AddWithValue("@co", detalle.CentroOperacion == "" ? (object)DBNull.Value : detalle.CentroOperacion);
					cmd_detalle.Parameters.AddWithValue("@regional_cluster", detalle.RegionalCluster == "" ? (object)DBNull.Value : detalle.RegionalCluster);
					cmd_detalle.Parameters.AddWithValue("@ind_regional_cluster", detalle.IndRegionalCluster);
					cmd_detalle.Parameters.AddWithValue("@cod_cluster", detalle.CodCluster == "" ? (object)DBNull.Value : detalle.CodCluster);
					cmd_detalle.Parameters.AddWithValue("@observacion", detalle.Observacion == "" ? (object)DBNull.Value : detalle.Observacion);

					cmd_detalle.ExecuteNonQuery();
					cmd_detalle.Parameters.Clear();
				}

				SqlCommand cmd_consecutivo = new SqlCommand(SQL_CONSECUTIVO, conn, trans);
				cmd_consecutivo.CommandType = CommandType.Text;
				cmd_consecutivo.CommandTimeout = 600;
				cmd_consecutivo.ExecuteNonQuery();

				trans.Commit();
				conn.Close();
			}
			catch (SqlException ex)
			{
				throw new Exception("Error al guardar dinámica: " + ex.Message);
			}
			catch (Exception ex)
			{
				trans.Rollback();
				throw new Exception("Error al guardar dinámica: " + ex.Message);
			}
		}

		public void EditarDescuento(Descuento descuento, List<Descuento.Detalle> detalles)
		{
			string SQL_DESCUENTO = @"update
	                                    t17_descuento_directo
                                    set
	                                    f17_id_tipo_dinamica=@id_tipo_dinamica,
                                        f17_usuario_edicion=@usuario_edicion
                                    where
	                                    f17_consecutivo=@consecutivo";

			string SQL_DEL_TIPO_COM = @"delete
	                                        t18_tipo_comunicacion_descuento_directo
                                        where
	                                        f18_cons_descuento=@cons_descuento";

			string SQL_TIPO_COM = @"insert into
										t18_tipo_comunicacion_descuento_directo
									(
										f18_cons_descuento,
										f18_id_tipo_comunicacion
									)
									values
									(
										@cons_descuento,
										@id_tipo_comunicacion
									)";


			string SQL_DEL_TIPO_EXH = @"delete
	                                        t20_tipo_exhibicion_descuento_directo
                                        where
	                                        f20_cons_descuento=@cons_descuento";

			string SQL_TIPO_EXH = @"insert into
	                                    t20_tipo_exhibicion_descuento_directo
                                    (
	                                    f20_cons_descuento,
	                                    f20_id_tipo_exhibicion
                                    )
                                    values
                                    (
	                                    @cons_descuento,
	                                    @id_tipo_exhibicion
                                    )";

			string SQL_DEL_DET_DESCUENTO = @"delete
	                                            t19_detalle_descuento_directo
                                            where
	                                            f19_cons_descuento=@cons_descuento
                                                and f19_rechazado=0";

			string SQL_DET_DESCUENTO = @"insert into
											t19_detalle_descuento_directo
										(
											f19_cons_descuento,
											f19_tipo,
											f19_item,
											f19_referencia,
											f19_descripcion,
                                            f19_id_casa_prov,
                                            f19_casa_prov,
											f19_marca_item,
											f19_um,
											f19_precio,
											f19_pum,
											f19_existencia,
											f19_id_plan,
											f19_plan,
											f19_id_criterio,
											f19_criterio,
                                            f19_tipo_descuento,
											f19_descuento,
											f19_porc_proveedor,
											f19_porc_megatiendas,
                                            f19_precio_fin,
                                            f19_fecha_ini_desc,
                                            f19_fecha_fin_desc,
											f19_id_co,
											f19_co,
                                            f19_regional_cluster,
                                            f19_observacion,
                                            f19_modo_cobro,
                                            f19_ind_regional_cluster,
                                            f19_factor,
                                            f19_pum2,
											f19_cod_cluster,
											f19_nit,	
											f19_proveedor,	
											f19_id_plan2,	
											f19_plan2,	
											f19_id_criterio2,	
											f19_criterio2,
											f19_id_plan3,	
											f19_plan3,	
											f19_id_criterio3,	
											f19_criterio3
										)
										values
										(
											@cons_descuento,
											@tipo,
											@item,
											@referencia,
											@descripcion,
                                            @id_casa_prov,
                                            @casa_prov,
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
                                            @precio_fin,
                                            @fecha_ini_desc,
                                            @fecha_fin_desc,
											@id_co,
											@co,
                                            @regional_cluster,
                                            @observacion,
                                            @modo_cobro,
                                            @ind_regional_cluster,
                                            @factor,
                                            @pum2,
											@cod_cluster,
											@nit,	
											@proveedor,	
											@id_plan2,	
											@plan2,	
											@id_criterio2,	
											@criterio2,
											@id_plan3,	
											@plan3,	
											@id_criterio3,	
											@criterio3
										)";

			SqlTransaction trans = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				trans = conn.BeginTransaction();

				SqlCommand cmd_descuento = new SqlCommand(SQL_DESCUENTO, conn, trans);
				cmd_descuento.CommandType = CommandType.Text;
				cmd_descuento.Parameters.AddWithValue("@consecutivo", descuento.Consecutivo);
				cmd_descuento.Parameters.AddWithValue("@id_tipo_dinamica", descuento.TipoDinamica);
				cmd_descuento.Parameters.AddWithValue("@usuario_edicion", Usuarios.NombreUsuario);
				cmd_descuento.ExecuteNonQuery();

				SqlCommand cmd_del_tipo_comunicacion = new SqlCommand(SQL_DEL_TIPO_COM, conn, trans);
				cmd_del_tipo_comunicacion.CommandType = CommandType.Text;
				cmd_del_tipo_comunicacion.Parameters.AddWithValue("@cons_descuento", descuento.Consecutivo);
				cmd_del_tipo_comunicacion.ExecuteNonQuery();

				if (descuento.TipoComunicacion != null)
				{
					SqlCommand cmd_tipo_comunicacion = new SqlCommand(SQL_TIPO_COM, conn, trans);
					cmd_tipo_comunicacion.CommandType = CommandType.Text;
					foreach (int tipo_com in descuento.TipoComunicacion)
					{
						cmd_tipo_comunicacion.Parameters.AddWithValue("@cons_descuento", descuento.Consecutivo);
						cmd_tipo_comunicacion.Parameters.AddWithValue("@id_tipo_comunicacion", tipo_com);
						cmd_tipo_comunicacion.ExecuteNonQuery();
						cmd_tipo_comunicacion.Parameters.Clear();
					}
				}

				SqlCommand cmd_del_tipo_exhibicion = new SqlCommand(SQL_DEL_TIPO_EXH, conn, trans);
				cmd_del_tipo_exhibicion.CommandType = CommandType.Text;
				cmd_del_tipo_exhibicion.CommandType = CommandType.Text;
				cmd_del_tipo_exhibicion.Parameters.AddWithValue("@cons_descuento", descuento.Consecutivo);
				cmd_del_tipo_exhibicion.ExecuteNonQuery();

				if (descuento.TipoExhibicion != null)
				{
					SqlCommand cmd_tipo_exhibicion = new SqlCommand(SQL_TIPO_EXH, conn, trans);
					cmd_tipo_exhibicion.CommandType = CommandType.Text;
					foreach (int tipo_exh in descuento.TipoExhibicion)
					{
						cmd_tipo_exhibicion.Parameters.AddWithValue("@cons_descuento", descuento.Consecutivo);
						cmd_tipo_exhibicion.Parameters.AddWithValue("@id_tipo_exhibicion", tipo_exh);
						cmd_tipo_exhibicion.ExecuteNonQuery();
						cmd_tipo_exhibicion.Parameters.Clear();
					}
				}

				SqlCommand cmd_del_detalle = new SqlCommand(SQL_DEL_DET_DESCUENTO, conn, trans);
				cmd_del_detalle.CommandType = CommandType.Text;
				cmd_del_detalle.CommandType = CommandType.Text;
				cmd_del_detalle.Parameters.AddWithValue("@cons_descuento", descuento.Consecutivo);
				cmd_del_detalle.ExecuteNonQuery();

				SqlCommand cmd_detalle = new SqlCommand(SQL_DET_DESCUENTO, conn, trans);
				cmd_detalle.CommandType = CommandType.Text;
				foreach (Descuento.Detalle detalle in detalles)
				{
					cmd_detalle.Parameters.AddWithValue("@cons_descuento", descuento.Consecutivo);
					cmd_detalle.Parameters.AddWithValue("@tipo", detalle.Tipo);
					cmd_detalle.Parameters.AddWithValue("@item", detalle.Item == "" ? (object)DBNull.Value : detalle.Item);
					cmd_detalle.Parameters.AddWithValue("@referencia", detalle.Referencia == "" ? (object)DBNull.Value : detalle.Referencia);
					cmd_detalle.Parameters.AddWithValue("@descripcion", detalle.Descripcion == "" ? (object)DBNull.Value : detalle.Descripcion);
					cmd_detalle.Parameters.AddWithValue("@nit", detalle.Nit);
					cmd_detalle.Parameters.AddWithValue("@proveedor", detalle.Proveedor);
					cmd_detalle.Parameters.AddWithValue("@id_casa_prov", detalle.IdCasaProveedor == "" ? (object)DBNull.Value : detalle.IdCasaProveedor);
					cmd_detalle.Parameters.AddWithValue("@casa_prov", detalle.CasaProveedor == "" ? (object)DBNull.Value : detalle.CasaProveedor);
					cmd_detalle.Parameters.AddWithValue("@marca_item", detalle.MarcaItem == "" ? (object)DBNull.Value : detalle.MarcaItem);
					cmd_detalle.Parameters.AddWithValue("@um", detalle.UndMedida == "" ? (object)DBNull.Value : detalle.UndMedida);
					cmd_detalle.Parameters.AddWithValue("@precio", detalle.PrecioInicial == 0 ? (object)DBNull.Value : detalle.PrecioInicial);
					cmd_detalle.Parameters.AddWithValue("@factor", detalle.Factor);
					cmd_detalle.Parameters.AddWithValue("@pum", detalle.PumInicial == 0 ? (object)DBNull.Value : detalle.PumInicial);
					cmd_detalle.Parameters.AddWithValue("@existencia", detalle.Existencia == 0 ? (object)DBNull.Value : detalle.Existencia);
					cmd_detalle.Parameters.AddWithValue("@id_plan", detalle.IdPlan == "" ? (object)DBNull.Value : detalle.IdPlan);
					cmd_detalle.Parameters.AddWithValue("@plan", detalle.Plan == "" ? (object)DBNull.Value : detalle.Plan);
					cmd_detalle.Parameters.AddWithValue("@id_criterio", detalle.IdCriterio == "" ? (object)DBNull.Value : detalle.IdCriterio);
					cmd_detalle.Parameters.AddWithValue("@criterio", detalle.Criterio == "" ? (object)DBNull.Value : detalle.Criterio);
					cmd_detalle.Parameters.AddWithValue("@id_plan2", detalle.IdPlan2 == "" ? (object)DBNull.Value : detalle.IdPlan2);
					cmd_detalle.Parameters.AddWithValue("@plan2", detalle.Plan2 == "" ? (object)DBNull.Value : detalle.Plan2);
					cmd_detalle.Parameters.AddWithValue("@id_criterio2", detalle.IdCriterio2 == "" ? (object)DBNull.Value : detalle.IdCriterio2);
					cmd_detalle.Parameters.AddWithValue("@criterio2", detalle.Criterio2 == "" ? (object)DBNull.Value : detalle.Criterio2);
					cmd_detalle.Parameters.AddWithValue("@id_plan3", detalle.IdPlan3 == "" ? (object)DBNull.Value : detalle.IdPlan3);
					cmd_detalle.Parameters.AddWithValue("@plan3", detalle.Plan3 == "" ? (object)DBNull.Value : detalle.Plan3);
					cmd_detalle.Parameters.AddWithValue("@id_criterio3", detalle.IdCriterio3 == "" ? (object)DBNull.Value : detalle.IdCriterio3);
					cmd_detalle.Parameters.AddWithValue("@criterio3", detalle.Criterio3 == "" ? (object)DBNull.Value : detalle.Criterio3);

					cmd_detalle.Parameters.AddWithValue("@tipo_descuento", detalle.TipoDescuento);
					cmd_detalle.Parameters.AddWithValue("@descuento", detalle.Descuento == 0 ? (object)DBNull.Value : detalle.Descuento);
					cmd_detalle.Parameters.AddWithValue("@porc_proveedor", detalle.AsumeProveedor == 0 ? (object)DBNull.Value : detalle.AsumeProveedor);
					cmd_detalle.Parameters.AddWithValue("@porc_megatiendas", detalle.AsumeMegatiendas == 0 ? (object)DBNull.Value : detalle.AsumeMegatiendas);
					cmd_detalle.Parameters.AddWithValue("@precio_fin", detalle.PrecioFinal);
					cmd_detalle.Parameters.AddWithValue("@pum2", detalle.PumFinal == 0 ? (object)DBNull.Value : detalle.PumFinal);
					cmd_detalle.Parameters.AddWithValue("@fecha_ini_desc", detalle.FechaInicialDescuento);
					cmd_detalle.Parameters.AddWithValue("@fecha_fin_desc", detalle.FechaFinalDescuento);
					cmd_detalle.Parameters.AddWithValue("@modo_cobro", detalle.ModoCobro);
					cmd_detalle.Parameters.AddWithValue("@id_co", detalle.IdCentroOperacion == "" ? (object)DBNull.Value : detalle.IdCentroOperacion);
					cmd_detalle.Parameters.AddWithValue("@co", detalle.CentroOperacion == "" ? (object)DBNull.Value : detalle.CentroOperacion);
					cmd_detalle.Parameters.AddWithValue("@regional_cluster", detalle.RegionalCluster == "" ? (object)DBNull.Value : detalle.RegionalCluster);
					cmd_detalle.Parameters.AddWithValue("@ind_regional_cluster", detalle.IndRegionalCluster);
					cmd_detalle.Parameters.AddWithValue("@cod_cluster", detalle.CodCluster == "" ? (object)DBNull.Value : detalle.CodCluster);
					cmd_detalle.Parameters.AddWithValue("@observacion", detalle.Observacion == "" ? (object)DBNull.Value : detalle.Observacion);

					cmd_detalle.ExecuteNonQuery();
					cmd_detalle.Parameters.Clear();
				}

				trans.Commit();
				conn.Close();
			}
			catch (SqlException ex)
			{
				throw new Exception("Error al editar dinámica: " + ex.Message);
			}
			catch (Exception ex)
			{
				trans.Rollback();
				throw new Exception("Error al editar dinámica: " + ex.Message);
			}
		}

		public void EnviarCorreo(string to, string body, string subject, string[] cc)
		{
			try
			{
				Configuration config = ConfigurationManager.OpenExeConfiguration(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe");
				AppSettingsSection section = config.AppSettings;

				string smtp = section.Settings["smtp"].Value;
				int puerto = Convert.ToInt32(section.Settings["puerto"].Value);
				string from = section.Settings["from"].Value;
				string pwd = section.Settings["pwd"].Value;

				MailMessage mail = new MailMessage();
				SmtpClient SmtpServer = new SmtpClient(smtp);

				mail.From = new MailAddress(from, "Notificación");

				mail.To.Add(to);

				if (cc != null)
				{
					foreach (string c in cc)
					{
						mail.CC.Add(c);
					}
				}
				mail.IsBodyHtml = true;
				mail.Subject = subject;
				mail.Body = body;
				mail.Priority = MailPriority.High;

				SmtpServer.Port = puerto;
				SmtpServer.Credentials = new System.Net.NetworkCredential(from, pwd);
				SmtpServer.EnableSsl = false; //Para gmail true;

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
					throw new Exception("SocketException, Error al enviar correo: " + ex.InnerException.Message + Environment.NewLine);
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
					throw new Exception("Exception, Error al enviar correo: " + ex.InnerException.Message + Environment.NewLine);
				}
				else
				{
					throw new Exception("Exception, Error al enviar correo: " + ex.Message + Environment.NewLine);
				}
			}
		}

		public DataTable ListarDescuento(string fecha_ini, string fecha_fin)
		{
			string SQL = @"select 
	                            f17_consecutivo,
	                            convert(varchar(10),f08_id) + '-' + f08_descripcion f08_descripcion,
	                            f17_usuario,
	                            CONVERT(varchar,f17_fecha,23) f17_fecha,
	                            f12_consecutivo,
	                            f12_fecha_ini_vig,
	                            f12_fecha_fin_vig,
                                f12_descripcion
                            from 
	                            t17_descuento_directo
	                            inner join t08_tipo_dinamica on f17_id_tipo_dinamica=f08_id
	                            left join t12_retroplanning on f17_consecutivo_retro=f12_consecutivo
                            where
	                            f17_usuario=@id_usuario
	                            and convert(date,f17_fecha) between @fecha_ini and @fecha_fin
                                and isnull(f17_estado,0)=0";
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = new SqlCommand(SQL, conn);
				cmd.Parameters.AddWithValue("@id_usuario", Usuarios.NombreUsuario);
				cmd.Parameters.AddWithValue("@fecha_ini", fecha_ini);
				cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
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
				throw new Exception("Error al listar dinámica: " + ex.Message);
			}
			return res;
		}

		public List<int> ObtenerTiposComunicacionDescuento(int id_descuento)
		{
			string SQL = @"select
	                            f18_id_tipo_comunicacion
                            from
	                            t18_tipo_comunicacion_descuento_directo
                            where
	                            f18_cons_descuento=@id_descuento";
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

		public List<int> ObtenerTiposExhibicionDescuento(int id_descuento)
		{
			string SQL = @"select
	                            f20_id_tipo_exhibicion
                            from
	                            t20_tipo_exhibicion_descuento_directo
                            where
	                            f20_cons_descuento=@id_descuento";
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
				throw new Exception("Error al obtener tipos exhibición descuento: " + ex.Message);
			}
			return res;
		}

		public DataTable ObtenerDetalleDescuento(int id_descuento)
		{
			string SQL = @"select 
	                            f19_id,
	                            f19_cons_descuento,
	                            f19_tipo,
	                            f19_item,
	                            trim(f19_referencia) f19_referencia,
	                            trim(f19_descripcion) f19_descripcion,
								trim(f19_nit) f19_nit,
								trim(f19_proveedor) f19_proveedor,
                                trim(f19_id_casa_prov) f19_id_casa_prov,
                                trim(f19_casa_prov) f19_casa_prov,
	                            trim(f19_marca_item) f19_marca_item,
	                            f19_um,
	                            f19_precio,
                                f19_factor,
	                            f19_pum,
	                            isnull(f19_existencia,0) f19_existencia,
	                            f19_id_plan,
	                            f19_plan,
	                            f19_id_criterio,
	                            f19_criterio,
								f19_id_plan2,
	                            f19_plan2,
	                            f19_id_criterio2,
	                            f19_criterio2,
								f19_id_plan3,
	                            f19_plan3,
	                            f19_id_criterio3,
	                            f19_criterio3,
	                            f19_tipo_descuento,
	                            f19_descuento,
	                            f19_porc_proveedor,
	                            f19_porc_megatiendas,
                                f19_precio_fin,
                                f19_pum2,
	                            CONVERT(VARCHAR(10), f19_fecha_ini_desc, 103) f19_fecha_ini_desc,
	                            CONVERT(VARCHAR(10), f19_fecha_fin_desc, 103) f19_fecha_fin_desc,
	                            f19_id_co,
	                            f19_co,
                                f19_observacion,
                                f19_modo_cobro,
                                f19_regional_cluster,
                                case  f19_ind_regional_cluster
                                    when 1 then 1
                                    else 0
                                end f19_ind_regional_cluster,
								f19_cod_cluster
                            from
	                            t17_descuento_directo
	                            inner join t19_detalle_descuento_directo on f19_cons_descuento=f17_consecutivo
                            where
	                            f17_consecutivo=@cons_descuento
                                and f19_rechazado=0";
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@cons_descuento", id_descuento);
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

		public void CambiarEstadoDescuento(int consecutivo, int estado)
		{
			string SQL = @"update
	                            t17_descuento_directo
                            set
	                            f17_estado=@estado
                            where
	                            f17_consecutivo=@consecutivo";
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@estado", estado);
				cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
				cmd.ExecuteNonQuery();
				conn.Close();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al cambiar estado: " + ex.Message);
			}
		}

		public void RechazarLineaDescuento(int id)
		{
			string SQL = @"update
	                        t19_detalle_descuento_directo
                        set
	                        f19_rechazado=1
                        where
	                        f19_id=@id";
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@id", id);
				cmd.ExecuteNonQuery();
				conn.Close();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al rechazar linea descuento: " + ex.Message);
			}
		}

		public void RechazarTodoDescuento(int consecutivo)
		{
			string SQL = @"update
							t19_detalle_descuento_directo
						set
							f19_rechazado=1
						where
							f19_cons_descuento=@consecutivo";
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
				cmd.ExecuteNonQuery();
				conn.Close();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al rechazar todo descuento: " + ex.Message);
			}
		}

		public void GuardarCorreoPendiente(string to, string body, string subject, string cc)
		{
			string SQL = @"insert into
	                            t22_correos_pendientes
                            (
	                            f22_to,
	                            f22_body,
	                            f22_subject,
                                f22_cc,
								f22_fecha
                            )
                            values
                            (
	                            @to,
	                            @body,
	                            @subject,
                                @cc,
								getdate()
                            )";
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@to", to);
				cmd.Parameters.AddWithValue("@body", body);
				cmd.Parameters.AddWithValue("@subject", subject);
				cmd.Parameters.AddWithValue("@cc", cc);
				cmd.ExecuteNonQuery();
				conn.Close();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al guardar correo pendiente: " + ex.Message);
			}
		}

		public DataTable ListarProveedores()
		{
			string SQL = @"select
								f200_nit,
								f200_razon_social
							from
								t200_mm_terceros
							where
								f200_ind_proveedor = 1 and
								f200_ind_empleado = 0 and
								f200_ind_estado= 1 and
								f200_id_cia=1
							";
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_unoee);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
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
				throw new Exception("Error al listar proveedores: " + ex.Message);
			}
			return res;
		}

		public DataTable ListarItemsPlanCriterio(string plan1, string criterio1, string plan2, string criterio2, string plan3, string criterio3)
		{
			string SQL = @"select distinct
								f120_id,
								convert(varchar(10),f120_id) + ' - ' + f120_descripcion f120_descripcion
							from 
								t120_mc_items 
								left outer join t125_mc_items_criterios c1 on c1.f125_rowid_item=f120_rowid and c1.f125_id_cia=f120_id_cia
								left outer join t125_mc_items_criterios c2 on c2.f125_rowid_item=f120_rowid and c2.f125_id_cia=f120_id_cia and c2.f125_id_cia=c1.f125_id_cia
								left outer join t125_mc_items_criterios c3 on c3.f125_rowid_item=f120_rowid and c3.f125_id_cia=f120_id_cia and c3.f125_id_cia=c2.f125_id_cia
							where 
								f120_id_cia=1 and
								(c1.f125_id_plan=@plan1
								and c1.f125_id_criterio_mayor=@criterio1)";

			if ((plan2 != "-1" && plan2 != "") && (criterio2 != "-1" && criterio2 != ""))
				SQL += @"and
						(c2.f125_id_plan=@plan2
						and c2.f125_id_criterio_mayor=@criterio2) ";

			if ((plan3 != "-1" && plan3 != "") && (criterio3 != "-1" && criterio3 != ""))

				SQL += @"and
					(c3.f125_id_plan=@plan3
					and c3.f125_id_criterio_mayor=@criterio3)";

			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_unoee);
				conn.Open();
				SqlCommand cmd = new SqlCommand(SQL, conn);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@plan1", plan1);
				cmd.Parameters.AddWithValue("@criterio1", criterio1);
				if ((plan2 != "-1" && plan2 != "") && (criterio2 != "-1" && criterio2 != ""))
				{
					cmd.Parameters.AddWithValue("@plan2", plan2);
					cmd.Parameters.AddWithValue("@criterio2", criterio2);
				}

				if ((plan3 != "-1" && plan3 != "") && (criterio3 != "-1" && criterio3 != ""))
				{
					cmd.Parameters.AddWithValue("@plan3", plan3);
					cmd.Parameters.AddWithValue("@criterio3", criterio3);
				}
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
				throw new Exception("Error al listar items plan criterio: " + ex.Message);
			}
			return res;
		}
	}
}
