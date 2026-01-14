using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class AuthDat : IAuthDat
    {
        public async Task<UsuarioDTO> Login(CredencialesDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Auth_Login", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pUsuario", model.Usuario);
                cmd.Parameters.AddWithValue("pPassword", model.Clave);
                cmd.Parameters.AddWithValue("pEncrypto", DBConn.ParametroCripto());
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadLogin(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<bool> ChangePassword(CambioClaveDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Auth_CambiarClave", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", model.idUsuario);
                cmd.Parameters.AddWithValue("pActualClave", model.actualClave);
                cmd.Parameters.AddWithValue("pNuevaClave", model.nuevaClave);
                cmd.Parameters.AddWithValue("pEncrypto", DBConn.ParametroCripto());
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadChangePassword(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        // READER

        static async Task<UsuarioDTO> ReadLogin(DbDataReader reader)
        {
            try
            {
                bool exito = false;
                string errorMensaje = "";
                string errorDetalle = "";
                UsuarioDTO obj = new UsuarioDTO();
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        errorMensaje = Convert.ToString(reader["Mensaje"]);
                        errorDetalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(errorMensaje + " " + errorDetalle);
                    }

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.Perfil = Convert.ToString(reader["Perfil"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.IdPerfil = Convert.ToInt32(reader["IdPerfil"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdGenero = Convert.ToInt32(reader["IdGenero"]);

                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<bool> ReadChangePassword(DbDataReader reader)
        {
            try
            {
                bool exito = false;
                string errorMensaje = "";
                string errorDetalle = "";
                UsuarioDTO obj = new UsuarioDTO();
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        errorMensaje = Convert.ToString(reader["Mensaje"]);
                        errorDetalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(errorMensaje + " " + errorDetalle);
                    }

                }

                return exito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

   
}
