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
    public class TransaccionDat : ITransaccionDat
    {
        public async Task<List<TransaccionDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Transaccion_Listar", conn)
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

        public async Task<bool> Registrar(TransaccionDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Transaccion_Registrar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTipoTransaccion", model.IdTipoTransaccion);
                cmd.Parameters.AddWithValue("pIdMotivoTransaccion", model.IdMotivoTransaccion);
                cmd.Parameters.AddWithValue("pIdSedeOrigen", model.IdSedeOrigen);
                cmd.Parameters.AddWithValue("pIdSedeDestino", model.IdSedeDestino);
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

        public async Task<bool> Confirmar(int id, TransaccionDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Transaccion_Confirmar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pDetalle", JsonSerializer.Serialize(model.Detalle) );
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
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

        public async Task<bool> Cancelar(int id, TransaccionDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Transaccion_Cancelar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCancelar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<TransaccionDTO> Buscar(int id)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Transaccion_Buscar", conn)
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

        public async Task<List<TransaccionDetalleDTO>> BuscarDetalle(int id)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_TransaccionDetalle_Buscar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTransaccion", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarDetalle(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<TransaccionDTO>> BuscarPorParametros(string fechaDesde, string fechaHasta, int idTransaccion,  int idTipoTransaccion, int idEstadoTransaccion, int bloque)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Transaccion_BuscarPorParametros", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (bloque == 1)
                {
                    cmd.Parameters.AddWithValue("pFechaDesde", Convert.ToDateTime(fechaDesde));
                    cmd.Parameters.AddWithValue("pFechaHasta", Convert.ToDateTime(fechaHasta));
                }

                cmd.Parameters.AddWithValue("pBloque", bloque);
                cmd.Parameters.AddWithValue("pIdTransaccion", idTransaccion);
                cmd.Parameters.AddWithValue("pIdTipoTransaccion", idTipoTransaccion);
                cmd.Parameters.AddWithValue("pIdEstadoTransaccion", idEstadoTransaccion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarPorParametros(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }




        // READER

        static async Task<List<TransaccionDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<TransaccionDTO> collection = new List<TransaccionDTO>();
                while (await reader.ReadAsync())
                {
                    TransaccionDTO obj = new TransaccionDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdTransaccionPadre = DBNull.Value == reader["IdTransaccionPadre"] ? (int?)null : Convert.ToInt32(reader["IdTransaccionPadre"]);
                    obj.IdTipoTransaccion = Convert.ToInt32(reader["IdTipoTransaccion"]);
                    obj.TipoTransaccion = Convert.ToString(reader["TipoTransaccion"]);
                    obj.IdSedeOrigen = DBNull.Value == reader["IdSedeOrigen"] ? (int?)null : Convert.ToInt32(reader["IdSedeOrigen"]);
                    obj.SedeOrigen = DBNull.Value == reader["SedeOrigen"] ? null : Convert.ToString(reader["SedeOrigen"]);
                    obj.IdSedeDestino = DBNull.Value == reader["IdSedeDestino"] ? (int?)null : Convert.ToInt32(reader["IdSedeDestino"]);
                    obj.SedeDestino = DBNull.Value == reader["SedeDestino"] ? null : Convert.ToString(reader["SedeDestino"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.FechaConfirmo = DBNull.Value == reader["FechaConfirmo"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmo"]);
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

        static async Task<bool> ReadCancelar(DbDataReader reader)
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

        static async Task<TransaccionDTO> ReadBuscar(DbDataReader reader)
        {
            try
            {
                TransaccionDTO obj = new TransaccionDTO();
                while (await reader.ReadAsync())
                {

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdTransaccionPadre = DBNull.Value == reader["IdTransaccionPadre"] ? (int?)null : Convert.ToInt32(reader["IdTransaccionPadre"]);
                    obj.IdTipoTransaccion = Convert.ToInt32(reader["IdTipoTransaccion"]);
                    obj.TipoTransaccionCorto = Convert.ToString(reader["TipoTransaccionCorto"]);
                    obj.TipoTransaccion = Convert.ToString(reader["TipoTransaccion"]);
                    obj.IdSedeOrigen = DBNull.Value == reader["IdSedeOrigen"] ? (int?)null : Convert.ToInt32(reader["IdSedeOrigen"]);
                    obj.SedeOrigen = DBNull.Value == reader["SedeOrigen"] ? null : Convert.ToString(reader["SedeOrigen"]);
                    obj.IdSedeDestino = DBNull.Value == reader["IdSedeDestino"] ? (int?)null : Convert.ToInt32(reader["IdSedeDestino"]);
                    obj.SedeDestino = DBNull.Value == reader["SedeDestino"] ? null : Convert.ToString(reader["SedeDestino"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.FechaConfirmo = DBNull.Value == reader["FechaConfirmo"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmo"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);
                    obj.ImagenCabeceraDocumento = Convert.ToString(reader["ImagenCabeceraDocumento"]);
                    obj.ImagenPieDocumento = Convert.ToString(reader["ImagenPieDocumento"]);
                }

                //Leer Detalle
                List<TransaccionDetalleDTO> detalle = new List<TransaccionDetalleDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        TransaccionDetalleDTO item = new TransaccionDetalleDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Articulo = Convert.ToString(reader["Articulo"]),
                            UnidadMedidaCorto = Convert.ToString(reader["UnidadMedidaCorto"]),
                            Almacen = Convert.ToString(reader["Almacen"]),
                            AlmacenUbicacion = DBNull.Value == reader["AlmacenUbicacion"] ? null : Convert.ToString(reader["AlmacenUbicacion"]),
                            Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            CantidadConfirmada = Convert.ToInt32(reader["CantidadConfirmada"]),
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


        static async Task<List<TransaccionDetalleDTO>> ReadBuscarDetalle(DbDataReader reader)
        {
            try
            {

                //Leer Detalle
                List<TransaccionDetalleDTO> detalle = new List<TransaccionDetalleDTO>();
                while (await reader.ReadAsync())
                {
                   
                    TransaccionDetalleDTO item = new TransaccionDetalleDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdArticuloStock = Convert.ToInt32(reader["IdArticuloStock"]),
                        Articulo = Convert.ToString(reader["Articulo"]),
                        UnidadMedidaCorto = Convert.ToString(reader["UnidadMedidaCorto"]),
                        Almacen = Convert.ToString(reader["Almacen"]),
                        AlmacenUbicacion = DBNull.Value == reader["AlmacenUbicacion"] ? null : Convert.ToString(reader["AlmacenUbicacion"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        CantidadConfirmada = Convert.ToInt32(reader["CantidadConfirmada"]),
                    };
                    detalle.Add(item);
                    
                }

                return detalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<TransaccionDTO>> ReadBuscarPorParametros(DbDataReader reader)
        {
            try
            {
                List<TransaccionDTO> collection = new List<TransaccionDTO>();
                while (await reader.ReadAsync())
                {
                    TransaccionDTO obj = new TransaccionDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdTransaccionPadre = DBNull.Value == reader["IdTransaccionPadre"] ? (int?)null : Convert.ToInt32(reader["IdTransaccionPadre"]);
                    obj.IdTipoTransaccion = Convert.ToInt32(reader["IdTipoTransaccion"]);
                    obj.TipoTransaccion = Convert.ToString(reader["TipoTransaccion"]);
                    obj.IdSedeOrigen = DBNull.Value == reader["IdSedeOrigen"] ? (int?)null : Convert.ToInt32(reader["IdSedeOrigen"]);
                    obj.SedeOrigen = DBNull.Value == reader["SedeOrigen"] ? null : Convert.ToString(reader["SedeOrigen"]);
                    obj.IdSedeDestino = DBNull.Value == reader["IdSedeDestino"] ? (int?)null : Convert.ToInt32(reader["IdSedeDestino"]);
                    obj.SedeDestino = DBNull.Value == reader["SedeDestino"] ? null : Convert.ToString(reader["SedeDestino"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.FechaConfirmo = DBNull.Value == reader["FechaConfirmo"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmo"]);
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


    }

   
}
