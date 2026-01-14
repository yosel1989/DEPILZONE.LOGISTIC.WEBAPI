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
    public class OrdenCompraDat : IOrdenCompraDat
    {
        public async Task<List<OrdenCompraDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_OrdenCompra_Listar", conn)
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

        public async Task<bool> Registrar(OrdenCompraDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_OrdenCompra_Registrar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pDetalle", JsonSerializer.Serialize(model.Detalle) );
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


        public async Task<OrdenCompraDTO> Buscar(int id)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_OrdenCompra_Buscar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        // READER

        static async Task<List<OrdenCompraDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<OrdenCompraDTO> collection = new List<OrdenCompraDTO>();
                while (await reader.ReadAsync())
                {
                    OrdenCompraDTO obj = new OrdenCompraDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Items = Convert.ToInt32(reader["Items"]);
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

        static async Task<OrdenCompraDTO> ReadBuscar(DbDataReader reader)
        {
            try
            {
                OrdenCompraDTO obj = new OrdenCompraDTO();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Items = Convert.ToInt32(reader["Items"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);
                }

                //Leer Detalle
                List<OrdenCompraDetalleDTO> detalle = new List<OrdenCompraDetalleDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        OrdenCompraDetalleDTO item = new OrdenCompraDetalleDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                            Articulo = Convert.ToString(reader["Articulo"]),
                            Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            UnidadMedida = Convert.ToString(reader["UnidadMedida"])
                        };
                        detalle.Add(item);
                    }
                    obj.Detalle = detalle;
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }


}
