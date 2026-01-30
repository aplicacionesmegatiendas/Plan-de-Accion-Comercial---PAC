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
    public class Roles
    {
        public class Rol
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public bool Activo { get; set; }
        }

        private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;

        public DataTable ListarRoles(bool activo)
        {
            string SQL = @"select
	                            f02_id,
	                            f02_descripcion,
                                f02_activo
                            from
	                            t02_roles";

            if (activo)
            {
                SQL += @" where
                            f02_activo=1";
            }


            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
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
                throw new Exception($"Error al listar roles: {ex.Message}");
            }
            return res;
        }

        public async Task<List<string>> ListarPermisosRol(int id_rol)
        {
            string SQL = @"select
	                            f03_cod_permiso
                            from
	                            t03_permisos_roles
                            where
	                            f03_id_rol=@id_rol";

            List<string> res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_rol", id_rol);
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
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
                throw new Exception("Error al listar permisos: " + ex.Message);
            }
            return res;
        }

        public void GuardarRol(Rol rol, List<string> permisos)
        {
            string SQL_ROL = @"insert into
	                                t02_roles
                                (
	                                f02_descripcion,
	                                f02_activo
                                )
                                values
                                (
	                                @descripcion,
	                                @activo
                                );
                                select
	                                MAX(f02_id)
                                from
	                                t02_roles";

            string SQL_PERMISOS = @"insert into
	                                    t03_permisos_roles
                                    (
	                                    f03_id_rol,
	                                    f03_cod_permiso
                                    )
                                    values
                                    (
	                                    @id_rol,
	                                    @cod_permiso
                                    )";

            SqlTransaction trans = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand cmd_rol = new SqlCommand(SQL_ROL, conn, trans);
                cmd_rol.CommandType = CommandType.Text;
                cmd_rol.Parameters.AddWithValue("@descripcion", rol.Descripcion);
                cmd_rol.Parameters.AddWithValue("@activo", rol.Activo);

                SqlCommand cmd_permiso = new SqlCommand(SQL_PERMISOS, conn, trans);
                cmd_permiso.CommandType = CommandType.Text;
                int.TryParse(Convert.ToString(cmd_rol.ExecuteScalar()), out int r);
                foreach (string permiso in permisos)
                {
                    cmd_permiso.Parameters.AddWithValue("@id_rol", r);
                    cmd_permiso.Parameters.AddWithValue("@cod_permiso", permiso);
                    cmd_permiso.ExecuteNonQuery();
                    cmd_permiso.Parameters.Clear();
                }

                trans.Commit();
                conn.Close();
            }
            catch (SqlException ex)
            {
                string mensaje = ex.Number == 2601 ? "El rol ya existe" : ex.Message;
                trans.Rollback();
                throw new Exception($"Error al guardar el rol: {mensaje}");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception($"Error al guardar el rol: {ex.Message}");
            }
        }

        public void EditarRol(Rol rol, List<string> permisos)
        {
            string SQL_ROL = @"update
	                                t02_roles
                                set
	                                f02_descripcion=@descripcion,
	                                f02_activo=@activo
                                where
	                                f02_id=@id";

            string SQL_DEL_PERMISOS = @"delete
	                                        t03_permisos_roles
                                        where
	                                        f03_id_rol=@id_rol";

            string SQL_PERMISOS = @"insert into
	                                    t03_permisos_roles
                                    (
	                                    f03_id_rol,
	                                    f03_cod_permiso
                                    )
                                    values
                                    (
	                                    @id_rol,
	                                    @cod_permiso
                                    )";

            SqlTransaction trans = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand cmd_rol = new SqlCommand(SQL_ROL, conn, trans);
                cmd_rol.CommandType = CommandType.Text;
                cmd_rol.Parameters.AddWithValue("@descripcion", rol.Descripcion);
                cmd_rol.Parameters.AddWithValue("@activo", rol.Activo);
                cmd_rol.Parameters.AddWithValue("@id", rol.Id);
                cmd_rol.ExecuteNonQuery();

                SqlCommand cmd_del_permiso = new SqlCommand(SQL_DEL_PERMISOS, conn, trans);
                cmd_del_permiso.CommandType = CommandType.Text;
                cmd_del_permiso.Parameters.AddWithValue("@id_rol", rol.Id);
                cmd_del_permiso.ExecuteNonQuery();

                SqlCommand cmd_permiso = new SqlCommand(SQL_PERMISOS, conn, trans);
                cmd_permiso.CommandType = CommandType.Text;

                foreach (string permiso in permisos)
                {
                    cmd_permiso.Parameters.AddWithValue("@id_rol", rol.Id);
                    cmd_permiso.Parameters.AddWithValue("@cod_permiso", permiso);
                    cmd_permiso.ExecuteNonQuery();
                    cmd_permiso.Parameters.Clear();
                }
                trans.Commit();
                conn.Close();
            }
            catch (SqlException ex)
            {
                string mensaje = ex.Number == 2601 ? "El rol ya existe" : ex.Message;
                trans.Rollback();
                throw new Exception($"Error al editar rol: {mensaje}");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception($"Error al editar rol: {ex.Message}");
            }
        }
    }
}
