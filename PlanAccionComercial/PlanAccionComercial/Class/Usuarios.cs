using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlanAccionComercial.Class.Usuarios;

namespace PlanAccionComercial.Class
{
    public class Usuarios
    {
        private string cadena_pac = ConfigurationManager.ConnectionStrings["pac"].ConnectionString;

        public static int Id { get; set; }
        public static string NombreUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Contraseña { get; set; }
        public static List<string> Permisos { get; set; }
        public static int Rol { get; set; }
        public static string Email { get; set; }
        
        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string NombUsuario { get; set; }
            public string Contraseña { get; set; }
            public string Email { get; set; }
            public int Rol { get; set; }
            public string EmailCC { get; set; }
            public bool Activo { get; set; }
            public bool Negociador { get; set; }
        }

        public string Encriptar(string contraseña)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(contraseña);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string Desencriptar(string contraseña)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(contraseña);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public object[] IniciarSesion(string usuario, string password)
        {
            string SQL = @"select 
                                f04_id,
                                f04_id_rol,
                                f04_activo,
                                f04_email,
                                f04_nombre
                            from 
                                t04_usuarios 
                            where 
                                f04_usuario = @usuario and 
                                f04_contraseña = @password";

            object[] res = null;
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    res = new object[5];
                    dr.Read();
                    res[0] = dr[0];
                    res[1] = dr[1];
                    res[2] = dr[2];
                    res[3] = dr[3];
                    res[4] = dr[4];
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al iniciar sesión: " + ex.Message);
            }
            return res;
        }

        public async Task<List<string>> ObtenerPermisosUsuario(int id)
        {
            string SQL = @"select 
	                            p.f01_cod
                            from
                                t01_permisos p
	                            inner join t03_permisos_roles pr on pr.f03_cod_permiso = p.f01_cod
                                inner join t02_roles r on pr.f03_id_rol = r.f02_id
                            where
                                r.f02_id = @id_rol
                                and p.f01_activo=1
                                and r.f02_activo=1";
            List<string> res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_rol", id);

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                if (dr.HasRows)
                {
                    res = new List<string>();
                    while (await dr.ReadAsync())
                    {
                        res.Add(dr.GetString(0));
                    }
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los permisos del usuario: " + ex.Message);
            }
            return res;
        }

        public DataTable ListarUsuarios()
        {
            string SQL = @"select 
                                u.f04_id,
	                            u.f04_usuario,
	                            u.f04_nombre,
	                            u.f04_email,
	                            u.f04_contraseña,
	                            r.f02_id,
	                            r.f02_descripcion,
                                u.f04_activo,
                                u.f04_negociador,
                                u.f04_email_cc
                            from
                                t04_usuarios u
                                left join t02_roles r on u.f04_id_rol = r.f02_id";
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
                throw new Exception("Error al listar los usuarios: " + ex.Message);
            }
            return dt;
        }

        public void GuardarUsuario(Usuario usuario)
        {
            string SQL = @"insert into
                            t04_usuarios
                            (
                                f04_nombre,
                                f04_usuario,
                                f04_contraseña,
                                f04_email,
                                f04_id_rol,
                                f04_activo,
                                f04_negociador,
                                f04_email_cc
                            )
                            values
                            (
                                @nombre,
                                @usuario,
                                @contraseña,
                                @email,
                                @id_rol,
                                @activo,
                                @negociador,
                                @email_cc
                            )";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@usuario", usuario.NombUsuario);
                cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@id_rol", usuario.Rol == -1 ? (object)DBNull.Value : usuario.Rol);
                cmd.Parameters.AddWithValue("@email_cc", usuario.EmailCC == "" ? (object)DBNull.Value : usuario.EmailCC);
                cmd.Parameters.AddWithValue("@activo", usuario.Activo);
                cmd.Parameters.AddWithValue("@negociador", usuario.Negociador);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                string mensaje = "";
                if (ex.Number == 2601)
                {
                    mensaje = $"Error al guardar usuario: El usuario {usuario.NombUsuario} ya esta registrado";
                }
                else
                {
                    mensaje = $"Error al guardar usuario: {ex.Message}";
                }
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar usuario: {ex.Message}");
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            string SQL = @"update
	                        t04_usuarios
                        set
	                        f04_nombre=@nombre,
	                        f04_usuario=@usuario,
	                        f04_contraseña=@contraseña,
	                        f04_email=@email,
	                        f04_id_rol=@id_rol,
                            f04_activo=@activo,
                            f04_negociador=@negociador,
                            f04_email_cc=@email_cc
                        where
	                        f04_id=@id";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@usuario", usuario.NombUsuario);
                cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@id_rol", usuario.Rol == -1 ? (object)DBNull.Value : usuario.Rol);
                cmd.Parameters.AddWithValue("@email_cc", usuario.EmailCC == "" ? (object)DBNull.Value : usuario.EmailCC);
                cmd.Parameters.AddWithValue("@activo", usuario.Activo);
                cmd.Parameters.AddWithValue("@negociador", usuario.Negociador);
                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                string mensaje = "";
                if (ex.Number == 2601)//error de indice unico repetido.
                {
                    mensaje = $"Error al guardar usuario: El usuario {usuario.NombUsuario} ya esta registrado";
                }
                else
                {
                    mensaje = $"Error al guardar usuario: {ex.Message}";
                }
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar usuario: {ex.Message}");
            }
        }

        public DataTable ListarCorreosNotificacionDescuento(bool activo)
        {
            string SQL = @"select  
                                f09_id,
	                            f09_email,
                                f09_activo
                            from 
	                            t09_correos_notificacion";
            if (activo)
                SQL+=@" where
	                        f09_activo=1";
            DataTable res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
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
                throw new Exception("Error al obtener correos notificación descuento: " + ex.Message);
            }
            return res;
        }

        public void GuardarCorreoNotificacionDescuento(string email, bool activo)
        {
            string SQL = @"insert into 
	                        t09_correos_notificacion
                        (
	                        f09_email,
	                        f09_activo
                        )
                        values
                        (
	                        @email,
	                        @activo
                        )";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@activo", activo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar correo: {ex.Message}");
            }
        }

        public void EditarCorreoNotificacionDescuento(int id, string email, bool activo)
        {
            string SQL = @"update
	                            t09_correos_notificacion
                            set
	                            f09_email=@email,
	                            f09_activo=@activo
                            where
	                            f09_id=@id";
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@activo", activo);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al editar correo: {ex.Message}");
            }
        }

        public void EliminarCorreoNotificacionDescuento(int id)
        {
            string SQL = @"delete
	                            t09_correos_notificacion
                            where
	                            f09_id=@id";
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
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar correo: {ex.Message}");
            }
        }

        public string ListarCorreosNegociador(int id)
        {
            string SQL = @"select 
	                        f04_email 
                        from 
	                        t04_usuarios 
                        where
	                        f04_id=@id";
            string res = null;
            try
            {
                SqlConnection conn = new SqlConnection(cadena_pac);
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                res=Convert.ToString(cmd.ExecuteScalar());  
                
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener correos negociador: " + ex.Message);
            }
            return res;
        }

        public string ListarCorreosCCNegociador(int id)
        {
            string SQL = @"select 
	                        f04_email_cc 
                        from 
	                        t04_usuarios 
                        where
	                        f04_id=@id";
            string res = null;
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
                throw new Exception("Error al obtener correos CC negociador: " + ex.Message);
            }
            return res;
        }
    }
}
