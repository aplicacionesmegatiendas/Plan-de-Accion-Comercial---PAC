using DocumentFormat.OpenXml.Office2010.CustomUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PlanAccionComercial.Class
{
	public class Reportes
	{
		private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;

		public DataTable ListarRetroplanning(string fecha_ini, string fecha_fin)
		{
			string SQL = @"select distinct
                                f12_consecutivo,
	                            f12_descripcion,
	                            FORMAT(f12_fecha_ini_vig, 'dd/MM/yyyy') f12_fecha_ini_vig,
	                            FORMAT(f12_fecha_fin_vig, 'dd/MM/yyyy') f12_fecha_fin_vig,
	                            f11_id,
	                            f11_descripcion
                            from
                                t12_retroplanning
                                inner join t11_estados on f12_id_estado=f11_id
                            where
	                            CONVERT(date,f12_fecha_creacion) between @fecha_ini and @fecha_fin";
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@fecha_ini", fecha_ini);
				cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al listar retroplanning: " + ex.Message);
			}
			return res;
		}

		public DataTable CrearReporteEstado(string fecha_ini, string fecha_fin, int tipo_dinamica, bool consecutivo_reto, bool consecutivo_descuento, int consecutivo, int id_usuario)
		{
			string SQL = @"select
	                            f17_consecutivo,
	                            f08_descripcion,
	                            f17_fecha,
	                            f12_consecutivo,
	                            f12_descripcion,
	                            f12_fecha_ini_vig,
	                            f12_fecha_fin_vig,
	                            f04_nombre,
                                f04_id,
	                            case f17_estado
		                            when 0 then 'Sin confirmar'
		                            when 1 then 'Confirmado'
									when 2 then 'Cargado'
									when 3 then 'Liquidado'
									when 4 then 'Rechazado'
	                            end estado
                            from
	                            t17_descuento_directo
	                            inner join t08_tipo_dinamica on f17_id_tipo_dinamica=f08_id
	                            inner join t04_usuarios on f17_id_usuario=f04_id
	                            left join t12_retroplanning on f17_consecutivo_retro=f12_consecutivo
                            where ";
			if(id_usuario!=0)
						SQL+="f17_id_usuario=@usuario and ";
			if (consecutivo_reto)
				SQL += "f12_consecutivo=@consecutivo";
			
			else if (consecutivo_descuento)
				SQL += "f17_consecutivo=@consecutivo";
			else
				SQL += @"convert(date,f17_fecha) between @fecha_ini and @fecha_fin ";

			if (tipo_dinamica > 0)
			{
				SQL += " and f08_id=@id_tipo_dinamica";
			}
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout=600;
				if (id_usuario != 0)
					cmd.Parameters.AddWithValue("@usuario", id_usuario);
				cmd.Parameters.AddWithValue("@fecha_ini", fecha_ini);
				cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
				if (consecutivo_reto || consecutivo_descuento)
				{
					cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
				}
				if (tipo_dinamica > 0)
				{
					cmd.Parameters.AddWithValue("@id_tipo_dinamica", tipo_dinamica);
				}
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al crear reporte estado: " + ex.Message);
			}
			return res;
		}

		public DataTable CrearReporteComercial(string fecha_ini, string fecha_fin, int tipo_dinamica, bool consecutivo_reto, bool consecutivo_descuento, int consecutivo)
		{
			string SQL = @"select
	                            f17_consecutivo,
	                            f08_descripcion,
	                            f17_fecha,
	                            f12_consecutivo,
	                            f12_descripcion,
	                            f12_fecha_ini_vig,
	                            f12_fecha_fin_vig,
	                            f04_nombre,
                                f04_id,
	                            case f17_estado
		                            when 0 then 'Sin confirmar'
		                            when 1 then 'Confirmado'
									when 2 then 'Cargado'
									when 3 then 'Liquidado'
	                            end estado
                            from
	                            t17_descuento_directo
	                            inner join t08_tipo_dinamica on f17_id_tipo_dinamica=f08_id
	                            inner join t04_usuarios on f17_id_usuario=f04_id
	                            left join t12_retroplanning on f17_consecutivo_retro=f12_consecutivo
                            where 
								f17_estado in(0,1,2) and ";
			if (consecutivo_reto)
			{
				SQL += "f12_consecutivo=@consecutivo";
			}
			else if (consecutivo_descuento)
			{
				SQL += "f17_consecutivo=@consecutivo";
			}
			else
			{
				SQL += @"convert(date,f17_fecha) between @fecha_ini and @fecha_fin ";
			}

			if (tipo_dinamica > 0)
			{
				SQL += " and f08_id=@id_tipo_dinamica";
			}
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 600;
				cmd.Parameters.AddWithValue("@fecha_ini", fecha_ini);
				cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
				if (consecutivo_reto || consecutivo_descuento)
				{
					cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
				}
				if (tipo_dinamica > 0)
				{
					cmd.Parameters.AddWithValue("@id_tipo_dinamica", tipo_dinamica);
				}
				
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al crear reporte comercial: " + ex.Message);
			}
			return res;
		}

		public DataTable CrearReporteMercadeo(string fecha_ini, string fecha_fin, int tipo_dinamica, bool consecutivo_reto, bool consecutivo_descuento, int consecutivo)
		{
			string SQL = @"select
	                            f17_consecutivo,
	                            f08_descripcion,
	                            f17_fecha,
	                            f12_consecutivo,
	                            f12_descripcion,
	                            f12_fecha_ini_vig,
	                            f12_fecha_fin_vig,
	                            f04_nombre,
                                f04_id,
	                            case f17_estado
		                            when 0 then 'Sin confirmar'
		                            when 1 then 'Confirmado'
									when 2 then 'Cargado'
									when 3 then 'Liquidado'
	                            end estado
                            from
	                            t17_descuento_directo
	                            inner join t08_tipo_dinamica on f17_id_tipo_dinamica=f08_id
	                            inner join t04_usuarios on f17_id_usuario=f04_id
	                            left join t12_retroplanning on f17_consecutivo_retro=f12_consecutivo
                            where 
								f17_estado in(1,2) and ";
			if (consecutivo_reto)
			{
				SQL += "f12_consecutivo=@consecutivo";
			}
			else if (consecutivo_descuento)
			{
				SQL += "f17_consecutivo=@consecutivo";
			}
			else
			{
				SQL += @"convert(date,f17_fecha) between @fecha_ini and @fecha_fin";
			}

			if (tipo_dinamica > 0)
			{
				SQL += " and f08_id=@id_tipo_dinamica";
			}
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 600;
				cmd.Parameters.AddWithValue("@fecha_ini", fecha_ini);
				cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
				if (consecutivo_reto || consecutivo_descuento)
				{
					cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
				}
				if (tipo_dinamica > 0)
				{
					cmd.Parameters.AddWithValue("@id_tipo_dinamica", tipo_dinamica);
				}
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al crear reporte mercadeo: " + ex.Message);
			}
			return res;
		}

		public DataTable CrearReporteLiquidacion(string fecha_ini, string fecha_fin, int tipo_dinamica, string proveedor, bool consecutivo_reto, bool consecutivo_descuento, int consecutivo)
		{
			string SQL = @"select distinct
								f17_consecutivo,
								f08_descripcion,
								f17_fecha,
								f12_consecutivo,
								f12_descripcion,
								f12_fecha_ini_vig,
								f12_fecha_fin_vig,
								f04_nombre,
								f04_id,
								--f19_proveedor,
								case f17_estado
									when 0 then 'Sin confirmar'
									when 1 then 'Confirmado'
									when 2 then 'Cargado'
									when 3 then 'Liquidado'
								end estado
							from
								t17_descuento_directo
								inner join t08_tipo_dinamica on f17_id_tipo_dinamica=f08_id
								inner join t04_usuarios on f17_id_usuario=f04_id
								left join t12_retroplanning on f17_consecutivo_retro=f12_consecutivo
								left join t19_detalle_descuento_directo on f19_cons_descuento=f17_consecutivo 
							where
								f17_estado in(2,3) 
								and convert(date,getdate()) > f19_fecha_fin_desc ";

			if (consecutivo_reto)
			{
				SQL += "and f12_consecutivo=@consecutivo ";
			}
			else if (consecutivo_descuento)
			{
				SQL += "and f17_consecutivo=@consecutivo ";
			}
			else
			{
				SQL += @"and convert(date,f17_fecha) between @fecha_ini and @fecha_fin ";
			}

			if (tipo_dinamica > 0 && proveedor != "")
			{
				SQL += "and f08_id=@id_tipo_dinamica " +
						"and f19_nit=@nit";
			}
			else if (tipo_dinamica == 0 && proveedor != "")
			{
				SQL += "and f19_nit=@nit ";
			}
			else if (tipo_dinamica > 0 && proveedor == "")
			{
				SQL += "and f08_id=@id_tipo_dinamica ";
			}
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 600;
				cmd.Parameters.AddWithValue("@fecha_ini", fecha_ini);
				cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
				if (consecutivo_reto || consecutivo_descuento)
				{
					cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
				}
				if (tipo_dinamica > 0)
				{
					cmd.Parameters.AddWithValue("@id_tipo_dinamica", tipo_dinamica);
				}
				if (proveedor != "")
				{
					cmd.Parameters.AddWithValue("@nit", proveedor);
				}
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al crear reporte liquidación: " + ex.Message);
			}
			return res;
		}

		public List<string> ListarNegociadoresSinDescuento(string consecutivo)
		{
			string SQL = @"select 
	                            f04_id,
	                            f04_nombre,
	                            f04_email
                            from 
	                            t12_retroplanning
	                            inner join t13_negociadores_retroplanning on f13_consecutivo_retro=f12_consecutivo
	                            inner join t04_usuarios on f13_id_usuario=f04_id
                            where
	                            f12_consecutivo=@consecutivo
	                            and f13_id_usuario not in
					            (
						            select 
							            f14_id_usuario 
						            from 
							            t14_descuento_retroplanning 
						            where 
							            f14_consecutivo_retro=f13_consecutivo_retro 
					            )";
			List<string> res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
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
				conn.Close();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al listar negociadores sin descuento: " + ex.Message);
			}
			return res;
		}

		public DataTable ReporteOperaciones(string fecha_ini, string fecha_fin, string id_co, int tipo_dinamica)
		{
			string SQL = @"select 
	                            f17_consecutivo,
	                            f19_id_co,
	                            f19_co,
	                            trim(isnull(convert(varchar(10),f19_item),'')) f19_item,
	                            trim(isnull(convert(varchar(20),f19_referencia),'')) f19_referencia,
	                            trim(isnull(convert(varchar(40),f19_descripcion),'')) f19_descripcion,
	                            isnull(convert(varchar(50),f19_plan),'') f19_plan,
	                            isnull(convert(varchar(50),f19_criterio),'') f19_criterio,
	                            f08_descripcion tipo_din,
	                            convert(varchar(10),f19_fecha_ini_desc,23) f19_fecha_ini_desc,
	                            convert(varchar(10),f19_fecha_fin_desc,23) f19_fecha_fin_desc,
	                            (
		                            select 
			                            STRING_AGG(f07_descripcion, ', ')  
		                            from 
			                            t07_tipo_comunicacion
			                            inner join t18_tipo_comunicacion_descuento_directo on f18_id_tipo_comunicacion=f07_id
		                            where
			                            f18_cons_descuento=f17_consecutivo
	                            ) tipo_com,
	                            (
		                            select 
			                            STRING_AGG(f21_descripcion, ', ')  
		                            from 
			                            t21_tipo_exhibicion
			                            inner join t20_tipo_exhibicion_descuento_directo on f20_id_tipo_exhibicion=f21_id
		                            where
			                            f20_cons_descuento=f17_consecutivo
	                            ) tipo_exh,
	                            f19_precio,
	                            f19_descuento,
	                            f19_existencia,
	                            f19_precio_fin,
                                trim(f19_observacion) f19_observacion
                            from 
	                            t17_descuento_directo
	                            inner join t08_tipo_dinamica on f17_id_tipo_dinamica=f08_id
	                            inner join t19_detalle_descuento_directo on f19_cons_descuento=f17_consecutivo
                            where
	                            f17_estado in(1,2) and
	                             f19_fecha_ini_desc >= @fecha_ini and f19_fecha_fin_desc <= @fecha_fin and
                                f19_rechazado=0";
			if (!id_co.Equals(""))
			{
				SQL += " and f19_id_co=@id_co";
			}

			if (tipo_dinamica > 0)
			{
				SQL += " and f17_id_tipo_dinamica=@id_tipo_dinamica";
			}

			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 600;
				cmd.Parameters.AddWithValue("@fecha_ini", fecha_ini);
				cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
				cmd.Parameters.AddWithValue("@id_co", id_co);
				if (tipo_dinamica > 0)
				{
					cmd.Parameters.AddWithValue("@id_tipo_dinamica", tipo_dinamica);
				}
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al crear reporte operaciones: " + ex.Message);
			}
			return res;
		}

		public DataTable ListarDescuentoDirecto(string fecha_ini, string fecha_fin)
		{
			string SQL = @"select 
	                            f17_consecutivo,
	                            f08_descripcion,
	                            f17_estado,
	                            f17_fecha,
                                f12_consecutivo,
	                            f12_descripcion,
	                            f12_fecha_ini_vig,
	                            f12_fecha_fin_vig,
	                            f04_nombre,
                                f04_id
                            from 
	                            t17_descuento_directo
	                            inner join t08_tipo_dinamica on f17_id_tipo_dinamica=f08_id
	                            inner join t04_usuarios on f17_id_usuario=f04_id
	                            left join t12_retroplanning on f17_consecutivo_retro=f12_consecutivo
                            where 
                                f17_estado in('1','2')
                                and convert(date,f17_fecha) between @fecha_ini and @fecha_fin";

			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@fecha_ini", fecha_ini);
				cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al listar descuentos directo: " + ex.Message);
			}
			return res;
		}

		public DataTable VerDetalleDescuento(int consecutivo, bool rechazado)
		{
			string SQL = @"select 
	                            f17_consecutivo,
	                            f19_id_co,
	                            f19_co,
	                            trim(isnull(convert(varchar(10),f19_item),'')) f19_item,
	                            trim(isnull(convert(varchar(20),f19_referencia),'')) f19_referencia,
	                            trim(isnull(convert(varchar(40),f19_descripcion),'')) f19_descripcion,
                                trim(isnull(f19_proveedor, '')) f19_casa_prov,
	                            trim(isnull(convert(varchar(50),f19_plan),'')) f19_plan,
	                            trim(isnull(convert(varchar(50),f19_criterio),'')) f19_criterio,
	                            convert(varchar(10),f19_fecha_ini_desc,23) f19_fecha_ini_desc,
	                            convert(varchar(10),f19_fecha_fin_desc,23) f19_fecha_fin_desc,
	                            f19_precio,
	                            f19_descuento,
	                            f19_existencia,
	                            f19_precio_fin	precio_fin,
                                trim(f19_observacion) f19_observacion,
                                f19_id,
                                f19_tipo_descuento,
                                f19_rechazado
                            from 
	                            t17_descuento_directo
	                            inner join t19_detalle_descuento_directo on f19_cons_descuento=f17_consecutivo
                            where
	                            f17_consecutivo=@consecutivo";
			if (rechazado == true)
			{
				SQL += " and f19_rechazado=0";
			}
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 600;
				cmd.Parameters.AddWithValue("@consecutivo", consecutivo);

				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al ver detalle: " + ex.Message);
			}
			return res;
		}

		public DataTable VerDetalleReporteComercial(int consecutivo)
		{
			string SQL = $@"select distinct
								d1.f19_item,
								d1.f19_referencia,
								d1.f19_descripcion,
								f19_nit,
								f19_proveedor,
								d1.f19_fecha_ini_desc,
								d1.f19_fecha_fin_desc,
								d1.f19_modo_cobro,
								d1.f19_descuento,
								case	
									f19_tipo_descuento
									when 'P' then 'Porcentaje'
									when 'V' then 'Valor'
									when 'O' then 'Precio oferta'
								end tipo_descuento,
							d1.f19_porc_proveedor,
							d1.f19_porc_megatiendas,
							case
								(
								select 
									COUNT(d2.f19_rechazado) 
								from 
									t19_detalle_descuento_directo d2
								where 
									d2.f19_cons_descuento=f17_consecutivo
									and d2.f19_rechazado=1
									and d2.f19_ind_regional_cluster=1
									and d2.f19_item=d1.f19_item
									and d2.f19_regional_cluster=d1.f19_regional_cluster
								)
								when 0 then
									null 
								else
									f19_precio
							end f19_precio,
							case
								(
								select 
									COUNT(d2.f19_rechazado) 
								from 
									t19_detalle_descuento_directo d2
								where 
									d2.f19_cons_descuento=f17_consecutivo
									and d2.f19_rechazado=1
									and d2.f19_ind_regional_cluster=1
									and d2.f19_item=d1.f19_item
									and d2.f19_regional_cluster=d1.f19_regional_cluster
								)
								when 0 then
									null 
								else
									f19_precio_fin
							end f19_precio_fin,
							case
								(
								select 
									COUNT(d2.f19_rechazado) 
								from 
									t19_detalle_descuento_directo d2
								where 
									d2.f19_cons_descuento=f17_consecutivo
									and d2.f19_rechazado=1
									and d2.f19_ind_regional_cluster=1
									and d2.f19_item=d1.f19_item
									and d2.f19_regional_cluster=d1.f19_regional_cluster
								)
								when 0 then
									null 
								else
									f19_pum2
							end f19_pum2,
								(
								select 
									sum(d2.f19_existencia) 
								from 
									t19_detalle_descuento_directo d2
								where 
									d2.f19_cons_descuento=f17_consecutivo
									and d2.f19_rechazado=0
									and d2.f19_ind_regional_cluster=1
									and d2.f19_item=d1.f19_item
									and d2.f19_regional_cluster=d1.f19_regional_cluster
								)
								 f19_existencia,
							case
								(
								select 
									COUNT(d2.f19_rechazado) 
								from 
									t19_detalle_descuento_directo d2
								where 
									d2.f19_cons_descuento=f17_consecutivo
									and d2.f19_rechazado=1
									and d2.f19_ind_regional_cluster=1
									and d2.f19_item=d1.f19_item
									and d2.f19_regional_cluster=d1.f19_regional_cluster
								)
								when 0 then
									null 
								else
									f19_id_co
							end f19_id_co,
							case
								(
								select 
									COUNT(d2.f19_rechazado) 
								from 
									t19_detalle_descuento_directo d2
								where 
									d2.f19_cons_descuento=f17_consecutivo
									and d2.f19_rechazado=1
									and d2.f19_ind_regional_cluster=1
									and d2.f19_item=d1.f19_item
									and d2.f19_regional_cluster=d1.f19_regional_cluster
								)
								when 0 then
									null 
								else
									f19_co
							end f19_co,
								f19_regional_cluster,
								f19_ind_regional_cluster,
								f19_observacion
						from 
							t17_descuento_directo 
							inner join t19_detalle_descuento_directo d1 on f19_cons_descuento=f17_consecutivo
						where 
							f17_consecutivo={consecutivo}
							and f19_ind_regional_cluster = 1
							and f19_rechazado=0
						union
						select distinct
								f19_item,
								f19_referencia,
								f19_descripcion,
								f19_nit,
								f19_proveedor,
								f19_fecha_ini_desc,
								f19_fecha_fin_desc,
								f19_modo_cobro,
								f19_descuento,
								case	
									f19_tipo_descuento
									when 'P' then 'Porcentaje'
									when 'V' then 'Valor'
									when 'O' then 'Precio oferta'
								end tipo_descuento,
								f19_porc_proveedor,
								f19_porc_megatiendas,
								f19_precio,
								f19_precio_fin,
								f19_pum2,
								f19_existencia,
								f19_id_co,
								f19_co,
								f19_regional_cluster,
								f19_ind_regional_cluster,
								f19_observacion
						from 
							t17_descuento_directo 
							inner join t19_detalle_descuento_directo on f19_cons_descuento=f17_consecutivo
						where 
							f17_consecutivo={consecutivo}
							and f19_ind_regional_cluster = 0
							and f19_rechazado=0";
			/*string SQL = @"CREATE TABLE #tmp 
							(
								f17_consecutivo int,
								f19_item int,
								f19_referencia nchar(20),
								f19_descripcion varchar(40),
								f19_nit varchar(20),
								f19_proveedor varchar(150),
								f19_fecha_ini_desc date,
								f19_fecha_fin_desc date,
								f19_modo_cobro varchar(10),
								f19_descuento decimal(18,2),
								f19_tipo_descuento varchar(20),
								f19_porc_proveedor decimal(18,2),
								f19_porc_megatiendas decimal(18,2),
								f19_precio decimal(18,2),
								f19_precio_fin decimal(18,2),
								f19_pum2 decimal(18,2),
								f19_existencia decimal(18,2),
								f19_id_co varchar(3),
								f19_co varchar(50),
								f19_regional_cluster varchar(20),
								f19_ind_regional_cluster bit,
								f19_observacion varchar(5000),
								f19_rechazado bit
							)
							insert into #tmp 
							(
								f17_consecutivo,
								f19_item,
								f19_referencia,
								f19_descripcion,
								f19_nit,
								f19_proveedor,
								f19_fecha_ini_desc,
								f19_fecha_fin_desc,
								f19_modo_cobro,
								f19_descuento,
								f19_tipo_descuento,
								f19_porc_proveedor,
								f19_porc_megatiendas,
								f19_precio,
								f19_precio_fin,
								f19_pum2,
								f19_existencia,
								f19_id_co,
								f19_co,
								f19_regional_cluster,
								f19_ind_regional_cluster,
								f19_observacion,
								f19_rechazado
							)
							select distinct
									f17_consecutivo,
									d1.f19_item,
									d1.f19_referencia,
									d1.f19_descripcion,
									f19_nit,
									f19_proveedor,
									d1.f19_fecha_ini_desc,
									d1.f19_fecha_fin_desc,
									d1.f19_modo_cobro,
									d1.f19_descuento,
									case	
										f19_tipo_descuento
										when 'P' then 'Porcentaje'
										when 'V' then 'Valor'
										when 'O' then 'Precio oferta'
									end tipo_descuento,
									d1.f19_porc_proveedor,
									d1.f19_porc_megatiendas,
									f19_precio,
									f19_precio_fin,
									f19_pum2,
									f19_existencia,
									f19_id_co,
									f19_co,
									f19_regional_cluster,
									f19_ind_regional_cluster,
									f19_observacion,
									f19_rechazado
							from 
								t17_descuento_directo 
								inner join t19_detalle_descuento_directo d1 on f19_cons_descuento=f17_consecutivo
							where 
								f17_consecutivo=@consecutivo
								and f19_ind_regional_cluster = 1
								and f19_rechazado=0
							union
							select distinct
									f17_consecutivo,
									f19_item,
									f19_referencia,
									f19_descripcion,
									f19_nit,
									f19_proveedor,
									f19_fecha_ini_desc,
									f19_fecha_fin_desc,
									f19_modo_cobro,
									f19_descuento,
									case	
										f19_tipo_descuento
										when 'P' then 'Porcentaje'
										when 'V' then 'Valor'
										when 'O' then 'Precio oferta'
									end tipo_descuento,
									f19_porc_proveedor,
									f19_porc_megatiendas,
									f19_precio,
									f19_precio_fin,
									f19_pum2,
									f19_existencia,
									f19_id_co,
									f19_co,
									f19_regional_cluster,
									f19_ind_regional_cluster,
									f19_observacion,
									f19_rechazado
							from 
								t17_descuento_directo 
								inner join t19_detalle_descuento_directo on f19_cons_descuento=f17_consecutivo
							where 
								f17_consecutivo=@consecutivo
								and f19_ind_regional_cluster = 0
								and f19_rechazado=0


							select distinct 
									f19_item,
									f19_referencia,
									f19_descripcion,
									f19_nit,
									f19_proveedor,
									f19_fecha_ini_desc,
									f19_fecha_fin_desc,
									f19_modo_cobro,
									f19_descuento,
									f19_tipo_descuento,
									f19_porc_proveedor,
									f19_porc_megatiendas,
									case
									(
										select 
											count(d2.f19_rechazado)
										from 
											t19_detalle_descuento_directo d2
										where 
											d2.f19_cons_descuento=f17_consecutivo
											and d2.f19_rechazado=1
											and d2.f19_ind_regional_cluster=1
											and d2.f19_item=f19_item
											and d2.f19_regional_cluster=f19_regional_cluster
									)
									when 0 then
										null 
									else
										f19_precio
									end f19_precio,
									case
									(
									select 
										count(d2.f19_rechazado)
									from 
										t19_detalle_descuento_directo d2
									where 
										d2.f19_cons_descuento=f17_consecutivo
										and d2.f19_rechazado=1
										and d2.f19_ind_regional_cluster=1
										and d2.f19_item=f19_item
										and d2.f19_regional_cluster=f19_regional_cluster
									)
									when 0 then
										null 
									else
										f19_precio_fin
									end f19_precio_fin,
									case
									(
									select 
										COUNT(d2.f19_rechazado) 
									from 
										t19_detalle_descuento_directo d2
									where 
										d2.f19_cons_descuento=f17_consecutivo
										and d2.f19_rechazado=1
										and d2.f19_ind_regional_cluster=1
										and d2.f19_item=f19_item
										and d2.f19_regional_cluster=f19_regional_cluster
									)
									when 0 then
										null 
									else
										f19_pum2
									end f19_pum2,
									(
										select 
											sum(d2.f19_existencia) 
										from 
											t19_detalle_descuento_directo d2
										where 
											d2.f19_cons_descuento=f17_consecutivo
											and d2.f19_rechazado=0
											and d2.f19_ind_regional_cluster=1
											and d2.f19_item=f19_item
											and d2.f19_regional_cluster=f19_regional_cluster
									)
									f19_existencia,
									case
									(
									select 
										COUNT(d2.f19_rechazado) 
									from 
										t19_detalle_descuento_directo d2
									where 
										d2.f19_cons_descuento=f17_consecutivo
										and d2.f19_rechazado=1
										and d2.f19_ind_regional_cluster=1
										and d2.f19_item=f19_item
										and d2.f19_regional_cluster=f19_regional_cluster
									)
									when 0 then
										null 
									else
										f19_id_co
									end f19_id_co,
									case
									(
									select 
										COUNT(d2.f19_rechazado) 
									from 
										t19_detalle_descuento_directo d2
									where 
										d2.f19_cons_descuento=f17_consecutivo
										and d2.f19_rechazado=1
										and d2.f19_ind_regional_cluster=1
										and d2.f19_item=f19_item
										and d2.f19_regional_cluster=f19_regional_cluster
									)
									when 0 then
										null 
									else
										f19_co
									end f19_co,
									f19_regional_cluster,
									f19_ind_regional_cluster,
									f19_observacion
							from 
								#tmp
							where
								f19_precio_fin>0
							drop table #tmp ";*/
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandTimeout = 600;
				//cmd.Parameters.AddWithValue("@consecutivo",consecutivo);
				//cmd.CommandType = CommandType.Text;
				//cmd.CommandTimeout = 1200;
				//SqlParameter consecutivo_param = new SqlParameter("@consecutivo", SqlDbType.VarChar, 50);
				//consecutivo_param.Value = consecutivo;
				//cmd.Parameters.Add(consecutivo_param);
				//cmd.Prepare();
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al ver detalle: " + ex.Message);
			}
			return res;
		}

		public DataTable VerDetalleReporteMercadeo(int consecutivo)
		{
			string SQL = @"select distinct
								d1.f19_item,
								d1.f19_referencia,
								d1.f19_descripcion,
								f19_nit,
								f19_proveedor,
								case	
									f19_tipo_descuento
									when 'P' then 'Porcentaje'
									when 'V' then 'Valor'
									when 'O' then 'Precio oferta'
								end tipo_descuento,
								d1.f19_descuento,
								d1.f19_precio,
								d1.f19_precio_fin,
								d1.f19_pum2,
								d1.f19_fecha_ini_desc,
								d1.f19_fecha_fin_desc,
								sum(f19_existencia) f19_existencia,
								f19_regional_cluster,
								f19_ind_regional_cluster,
								f19_observacion
							from 
								t17_descuento_directo 
								inner join t19_detalle_descuento_directo d1 on f19_cons_descuento=f17_consecutivo
							where 
								f17_consecutivo=@consecutivo
								and f19_ind_regional_cluster = 1
								and f19_rechazado=0
							group by
								d1.f19_item,
								d1.f19_referencia,
								d1.f19_descripcion,
								d1.f19_nit,
								d1.f19_proveedor,
								d1.f19_fecha_ini_desc,
								d1.f19_fecha_fin_desc,
								d1.f19_descuento,
								d1.f19_precio,
								d1.f19_precio_fin,
								d1.f19_pum2,
								d1.f19_regional_cluster,
								d1.f19_ind_regional_cluster,
								d1.f19_observacion,
								d1.f19_tipo_descuento
							union
							select distinct
								d1.f19_item,
								d1.f19_referencia,
								d1.f19_descripcion,
								f19_nit,
								f19_proveedor,
								case	
									f19_tipo_descuento
									when 'P' then 'Porcentaje'
									when 'V' then 'Valor'
									when 'O' then 'Precio oferta'
								end tipo_descuento,
								d1.f19_descuento,
								d1.f19_precio,
								d1.f19_precio_fin,
								d1.f19_pum2,
								d1.f19_fecha_ini_desc,
								d1.f19_fecha_fin_desc,
								d1.f19_existencia,
								d1.f19_regional_cluster,
								d1.f19_ind_regional_cluster,
								d1.f19_observacion
							from 
								t17_descuento_directo 
								inner join t19_detalle_descuento_directo d1 on f19_cons_descuento=f17_consecutivo
							where 
								f17_consecutivo=@consecutivo
								and f19_ind_regional_cluster = 0
								and f19_rechazado=0";
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 600;
				cmd.Parameters.AddWithValue("@consecutivo", consecutivo);

				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al ver detalle: " + ex.Message);
			}
			return res;
		}

		public DataTable VerDetalleReporteLiquidacion(int consecutivo, string nit)
		{
			string SQL = @"select distinct
								d1.f19_item,
								d1.f19_referencia,
								d1.f19_descripcion,
								d1.f19_nit,
								d1.f19_proveedor,
								case	
									f19_tipo_descuento
									when 'P' then 'Porcentaje'
									when 'V' then 'Valor'
									when 'O' then 'Precio oferta'
								end tipo_descuento,
								d1.f19_descuento,
								d1.f19_porc_proveedor,
								d1.f19_porc_megatiendas,
								d1.f19_modo_cobro,
								d1.f19_fecha_ini_desc,
								d1.f19_fecha_fin_desc,
								case
								(
									select 
										COUNT(d2.f19_rechazado) 
									from 
										t19_detalle_descuento_directo d2
									where 
										d2.f19_cons_descuento=f17_consecutivo
										and d2.f19_rechazado=1
										and d2.f19_ind_regional_cluster=1
										and d2.f19_item=d1.f19_item
										and d2.f19_regional_cluster=d1.f19_regional_cluster
								)
								when 0 then
									null 
								else
									d1.f19_id_co
								end f19_id_co,
								case
								(
									select 
										COUNT(d2.f19_rechazado) 
									from 
										t19_detalle_descuento_directo d2
									where 
										d2.f19_cons_descuento=f17_consecutivo
										and d2.f19_rechazado=1
										and d2.f19_ind_regional_cluster=1
										and d2.f19_item=d1.f19_item
										and d2.f19_regional_cluster=d1.f19_regional_cluster
								)
								when 0 then
									null 
								else
									d1.f19_co
								end f19_co,
								d1.f19_regional_cluster,
								d1.f19_ind_regional_cluster,
								d1.f19_observacion
							from 
								t17_descuento_directo 
								inner join t19_detalle_descuento_directo d1 on f19_cons_descuento=f17_consecutivo
							where 
								f17_consecutivo=@consecutivo
								and d1.f19_ind_regional_cluster = 1
								and d1.f19_rechazado=0";
							if (nit!="")
								SQL += " and f19_nit=@nit ";
							SQL+=@"union
							select distinct
								d1.f19_item,
								d1.f19_referencia,
								d1.f19_descripcion,
								f19_nit,
								f19_proveedor,
								case	
									f19_tipo_descuento
									when 'P' then 'Porcentaje'
									when 'V' then 'Valor'
									when 'O' then 'Precio oferta'
								end tipo_descuento,
								d1.f19_descuento,
								d1.f19_porc_proveedor,
								d1.f19_porc_megatiendas,
								d1.f19_modo_cobro,
								d1.f19_fecha_ini_desc,
								d1.f19_fecha_fin_desc,
								d1.f19_id_co,
								f19_co,
								f19_regional_cluster,
								f19_ind_regional_cluster,
								f19_observacion
							from 
								t17_descuento_directo 
								inner join t19_detalle_descuento_directo d1 on f19_cons_descuento=f17_consecutivo
							where 
								f17_consecutivo=@consecutivo
								and f19_ind_regional_cluster = 0
								and f19_rechazado=0";
							if (nit != "")
								SQL += " and f19_nit=@nit ";
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 600;
				cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
				if (nit != "")
					cmd.Parameters.AddWithValue("@nit", nit);
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al ver detalle: " + ex.Message);
			}
			return res;
		}

		public DataTable VerDetalleItemRegionalCluster(int consecutivo, string item, string regional_cluster)
		{
			string SQL = @"select distinct
							f19_id_co,
		                    f19_co,
		                    f19_precio,
		                    f19_precio_fin,
		                    f19_pum2,
		                    f19_existencia
						from 
							t19_detalle_descuento_directo d2
						where 
							d2.f19_cons_descuento=@consecutivo
							and d2.f19_rechazado=0
							and d2.f19_ind_regional_cluster=1
							and d2.f19_item=@item
							and d2.f19_regional_cluster=@regional_cluster";
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@consecutivo", consecutivo);
				cmd.Parameters.AddWithValue("@item", item);
				cmd.Parameters.AddWithValue("@regional_cluster", regional_cluster);

				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al ver detalle: " + ex.Message);
			}
			return res;
		}

		public DataTable ListarItemsPlanCriterio(string plan, string criterio)
		{
			string SQL = @"	select 
								f120_id,
								f120_descripcion,
								f125_id_plan,
								f125_id_criterio_mayor
							from 
								t120_mc_items 
								inner join t125_mc_items_criterios on f125_rowid_item=f120_rowid and f125_id_cia=f120_id_cia
							where 
								f125_id_plan=@plan
								and f125_id_criterio_mayor=@criterio";
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@plan", plan);
				cmd.Parameters.AddWithValue("@criterio", criterio);

				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al listar ítems por plan y criterio: " + ex.Message);
			}
			return res;
		}

		public DataTable ListarProveedoresDescuento()
		{
			string SQL = @"select distinct
								f19_nit,
								f19_proveedor
							from 
								t19_detalle_descuento_directo
							where
								(f19_nit is not null and f19_nit <> '') and
								(f19_proveedor is not null and f19_proveedor <> '')";
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
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
				conn.Close();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al listar proveedores descuento: " + ex.Message);
			}
			return res;
		}

		public DataTable CrearReporteRetroplanning(string fecha_ini, string fecha_fin, int tipo_dinamica_id, int consecutivo)
		{
			string SQL = @"select 
								f12_consecutivo,
								f12_descripcion,
								f08_descripcion,
								f12_fecha_ini_vig,
								f12_fecha_fin_vig,
								f12_fecha_entrega_mercadeo,
								f12_fecha_entrega_comercial,
								f11_descripcion
							from 
								t12_retroplanning
								inner join t11_estados on f12_id_estado=f11_id
								inner join t08_tipo_dinamica on f12_id_tipo_dinamica=f08_id
                            where ";
			if (consecutivo != -1)
			{
				SQL += "f12_consecutivo=@consecutivo_id";
			}
			else if (tipo_dinamica_id != -1)
			{
				SQL += "f08_id=@id_tipo_dinamica and " +
					"convert(date,f12_fecha_creacion) between @fecha_ini and @fecha_fin";
			}
			else
			{
				SQL += @"convert(date,f12_fecha_creacion) between @fecha_ini and @fecha_fin";
			}
			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.CommandTimeout = 600;
				cmd.Parameters.AddWithValue("@fecha_ini", fecha_ini);
				cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
				if (consecutivo != -1)
				{
					cmd.Parameters.AddWithValue("@consecutivo_id", consecutivo);
				}
				if (tipo_dinamica_id != -1)
				{
					cmd.Parameters.AddWithValue("@id_tipo_dinamica", tipo_dinamica_id);
				}
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al crear reporte retroplanning: " + ex.Message);
			}
			return res;
		}

		public DataTable ListarNegociadoresRetroplanning(int consecutivo)
		{
			string SQL = @"select
							f04_nombre,
							case when f17_id_usuario is null then
								convert(bit,0)
							else
								convert(bit,1)
							end cargado
						from 
							t04_usuarios	
							inner join t13_negociadores_retroplanning on f13_id_usuario=f04_id
							left outer join t17_descuento_directo on f17_consecutivo_retro=f13_consecutivo_retro and f17_id_usuario=f13_id_usuario
						where
							f13_consecutivo_retro=@consecutivo
						order by
							2 desc";

			DataTable res = null;
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;

				cmd.Parameters.AddWithValue("@consecutivo", consecutivo);

				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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
				throw new Exception("Error al consultar negociadores retroplannig: " + ex.Message);
			}
			return res;
		}

		public void EliminarDescuentosNoConfirmados()
		{
			string SQL = @"delete
								t17_descuento_directo
							where
								f17_consecutivo in(
									select 
										f17_consecutivo 
									from 
										t17_descuento_directo 
									where 
										f17_estado=0 
										and DATEDIFF(D, f17_fecha,GETDATE())>=30
								)";
			try
			{
				SqlConnection conn = new SqlConnection(cadena_pac);
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandTimeout = 300;
				cmd.CommandText = SQL;
				cmd.CommandType = CommandType.Text;
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al eliminar descuentos sin confirmar: " + ex.Message);
			}
		}
	}
}
