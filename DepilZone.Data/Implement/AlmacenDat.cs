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
    public class AlmacenDat : IAlmacenDat
    {
        public async Task<List<AlmacenDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Almacen_Listar", conn)
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

        public async Task<bool> Registrar(AlmacenDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Almacen_Registrar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
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


        public async Task<bool> Actualizar(int id, AlmacenDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Almacen_Modificar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
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

        public async Task<List<AlmacenDTO>> BuscarPorSede(int idSede)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Almacen_ListarPorSede", conn)
                {
                    CommandType = CommandType.StoredProcedure   
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
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


        // READER

        static async Task<List<AlmacenDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<AlmacenDTO> collection = new List<AlmacenDTO>();
                while (await reader.ReadAsync())
                {
                    AlmacenDTO obj = new AlmacenDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"].ToString());
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
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
