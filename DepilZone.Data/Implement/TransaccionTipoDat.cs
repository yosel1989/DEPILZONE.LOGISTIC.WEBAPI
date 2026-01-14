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
    public class TransaccionTipoDat : ITransaccionTipoDat
    {
        public async Task<List<TransaccionTipoDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_TransaccionTipo_Listar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Registrar(TransaccionTipoDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_TransaccionTipo_Registrar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pNombreCorto", model.NombreCorto);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pCodigo", model.Codigo);
                cmd.Parameters.AddWithValue("pIdTransaccionClase", model.IdTransaccionClase);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadRegistrar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<bool> Actualizar(int id, TransaccionTipoDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_TransaccionTipo_Modificar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pNombreCorto", model.NombreCorto);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pCodigo", model.Codigo);
                cmd.Parameters.AddWithValue("pIdTransaccionClase", model.IdTransaccionClase);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadActualizar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        // READER

        static async Task<List<TransaccionTipoDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<TransaccionTipoDTO> collection = new List<TransaccionTipoDTO>();
                while (await reader.ReadAsync())
                {
                    TransaccionTipoDTO obj = new TransaccionTipoDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"].ToString());
                    obj.NombreCorto = Convert.ToString(reader["NombreCorto"].ToString());
                    obj.Descripcion = DBNull.Value == reader["Descripcion"] ? null : Convert.ToString(reader["Descripcion"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.Codigo = Convert.ToString(reader["Codigo"]);
                    obj.IdTransaccionClase = Convert.ToInt32(reader["IdTransaccionClase"]);
                    obj.Clase = Convert.ToString(reader["Clase"]);
                    obj.ClaseCorto = Convert.ToString(reader["ClaseCorto"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<bool> ReadRegistrar(DbDataReader reader)
        {
            try
            {
                bool exito = false;
                string errorMensaje = "";
                string errorDetalle = "";
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);

                    if (!exito) {
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

        static async Task<bool> ReadActualizar(DbDataReader reader)
        {
            try
            {
                bool exito = false;
                string errorMensaje = "";
                string errorDetalle = "";
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
