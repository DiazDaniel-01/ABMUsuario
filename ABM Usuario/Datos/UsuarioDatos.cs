using ABM_Usuario.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ABM_Usuario.Datos
{
    public class UsuarioDatos
    {
        public List<UsuarioModel> Listar() { 
            var oLista = new List<UsuarioModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())){
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar",conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read())
                    {
                        oLista.Add(new UsuarioModel()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Contraseña = dr["Contraseña"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])
                        });
                    }
                }

            }
            return oLista;
        }

        public UsuarioModel Obtener(int IdUsuario)
        {
            var oUsuario = new UsuarioModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oUsuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        oUsuario.Nombre = dr["Nombre"].ToString();
                        oUsuario.Apellido = dr["Apellido"].ToString();
                        oUsuario.Correo = dr["Correo"].ToString();
                        oUsuario.Contraseña = dr["Contraseña"].ToString();
                        oUsuario.Activo = Convert.ToBoolean(dr["Activo"]);
                    }
                }

            }
            return oUsuario;
        }

        public bool Guardar(UsuarioModel ousuario) {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", ousuario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", ousuario.Apellido);
                    cmd.Parameters.AddWithValue("Correo", ousuario.Correo);
                    cmd.Parameters.AddWithValue("Contraseña", ousuario.Contraseña);
                    cmd.Parameters.AddWithValue("Activo", ousuario.Activo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e){

                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Editar(UsuarioModel ousuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", ousuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombre", ousuario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", ousuario.Apellido);
                    cmd.Parameters.AddWithValue("Correo", ousuario.Correo);
                    cmd.Parameters.AddWithValue("Contraseña", ousuario.Contraseña);
                    cmd.Parameters.AddWithValue("Activo", ousuario.Activo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }


        public bool Eliminar(int IdUsuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

    }
}
