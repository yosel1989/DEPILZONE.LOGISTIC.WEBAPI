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
    public class ArticuloDat : IArticuloDat
    {
        public async Task<List<ArticuloDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Articulo_Listar", conn)
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

        public async Task<List<ArticuloDTO>> ListarPorParametros(string parametros)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Articulo_BuscarParametros", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pParametros", parametros);
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

        public async Task<bool> Registrar(ArticuloDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Articulo_Registrar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pCodigo", model.Codigo);
                cmd.Parameters.AddWithValue("pFechaCaducidad", model.FechaCaducidad);
                cmd.Parameters.AddWithValue("pLote", model.Lote);
                cmd.Parameters.AddWithValue("pIdUnidadMedida", model.IdUnidadMedida);
                cmd.Parameters.AddWithValue("pIdCategoria", model.IdCategoria);
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

        public async Task<bool> Modificar(int id, ArticuloDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Articulo_Modificar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pCodigo", model.Codigo);
                cmd.Parameters.AddWithValue("pFechaCaducidad", model.FechaCaducidad);
                cmd.Parameters.AddWithValue("pLote", model.Lote);
                cmd.Parameters.AddWithValue("pIdUnidadMedida", model.IdUnidadMedida);
                cmd.Parameters.AddWithValue("pIdCategoria", model.IdCategoria);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadModificar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        // READER

        static async Task<List<ArticuloDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<ArticuloDTO> collection = new List<ArticuloDTO>();
                while (await reader.ReadAsync())
                {
                    ArticuloDTO obj = new ArticuloDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"].ToString());
                    obj.Descripcion = DBNull.Value == reader["Descripcion"] ? null : Convert.ToString(reader["Descripcion"]);
                    obj.Codigo = DBNull.Value == reader["Codigo"] ? null : Convert.ToString(reader["Codigo"]);
                    obj.IdCategoria = DBNull.Value == reader["IdCategoria"] ? (int?)null : Convert.ToInt32(reader["IdCategoria"]);
                    obj.IdUnidadMedida = DBNull.Value == reader["IdUnidadMedida"] ? (int?)null : Convert.ToInt32(reader["IdUnidadMedida"]);
                    obj.IdEstado =  Convert.ToInt32(reader["IdEstado"]);
                    obj.Categoria = DBNull.Value == reader["Categoria"] ? null : Convert.ToString(reader["Categoria"]);
                    obj.UnidadMedida = DBNull.Value == reader["UnidadMedida"] ? null : Convert.ToString(reader["UnidadMedida"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaCaducidad = DBNull.Value == reader["FechaCaducidad"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaCaducidad"]);
                    obj.Lote = DBNull.Value == reader["Lote"] ? null : Convert.ToString(reader["Lote"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.UsuarioRegistro = DBNull.Value == reader["UsuarioRegistro"] ? null : Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);
                    obj.NumeroProveedores = Convert.ToInt32(reader["NumeroProveedores"]);
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

        static async Task<bool> ReadModificar(DbDataReader reader)
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
