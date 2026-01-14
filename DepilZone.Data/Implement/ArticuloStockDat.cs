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
    public class ArticuloStockDat : IArticuloStockDat
    {
        public async Task<List<ArticuloStockDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_ArticuloStock_Listar", conn)
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

        public async Task<List<ArticuloStockDTO>> ListarPorParametros(string parametros)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_ArticuloStock_BuscarPorParametros", conn)
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

        public async Task<List<ArticuloStockDTO>> ListarPorSedeyParametros(int idSede, string parametros)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_ArticuloStock_BuscarPorSedeyParametros", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pParametros", parametros);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarPorSedeyParametros(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Registrar(ArticuloStockDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_ArticuloStock_Registrar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdArticulo", model.IdArticulo);
                cmd.Parameters.AddWithValue("pStockInicial", model.StockInicial);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdAlmacen", model.IdAlmacen);
                cmd.Parameters.AddWithValue("pIdAlmacenUbicacion", model.IdAlmacenUbicacion);
                cmd.Parameters.AddWithValue("pIdTransaccion", model.IdTransaccion);
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


        public async Task<bool> Actualizar(int id, ArticuloStockDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_ArticuloStock_Modificar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pIdArticulo", model.IdArticulo);
                cmd.Parameters.AddWithValue("pStockInicial", model.StockInicial);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdAlmacen", model.IdAlmacen);
                cmd.Parameters.AddWithValue("pIdAlmacenUbicacion", model.IdAlmacenUbicacion);
                cmd.Parameters.AddWithValue("pIdTransaccion", model.IdTransaccion);
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

        public async Task<List<ArticuloStockTrackingHistory>> BuscarMovimientos(int idArticuloStock, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_ArticuloStock_BuscarMovimientos", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdArticuloStock", idArticuloStock);
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarMovimientos(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ArticuloStockDTO>> ListarPorSedeyArticulo(int idSede, int idArticulo)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_ArticuloStock_Buscar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdArticulo", idArticulo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarPorSedeyArticulo(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ArticuloStockTrackingHistory>> ConsultarMovimientos(int bloque, int idSede, int idArticulo, string fechaDesde, string fechaHasta)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_ArticuloStock_ConsultarMovimientos", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if(bloque == 1)
                {
                    cmd.Parameters.AddWithValue("pFechaDesde", Convert.ToDateTime(fechaDesde));
                    cmd.Parameters.AddWithValue("pFechaHasta", Convert.ToDateTime(fechaHasta));
                }

                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdArticulo", idArticulo);
                cmd.Parameters.AddWithValue("pBloque", bloque);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarMovimientos(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        // READER

        static async Task<List<ArticuloStockDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<ArticuloStockDTO> collection = new List<ArticuloStockDTO>();
                while (await reader.ReadAsync())
                {
                    ArticuloStockDTO obj = new ArticuloStockDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdArticulo = Convert.ToInt32(reader["IdArticulo"]);
                    obj.Articulo = Convert.ToString(reader["Articulo"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Stock = Convert.ToInt32(reader["Stock"]);
                    obj.StockInicial = Convert.ToInt32(reader["StockInicial"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdAlmacen = Convert.ToInt32(reader["IdAlmacen"]);
                    obj.Almacen = Convert.ToString(reader["Almacen"]);
                    obj.IdAlmacenUbicacion = DBNull.Value == reader["IdAlmacenUbicacion"] ? (int?)null : Convert.ToInt32(reader["IdAlmacenUbicacion"]);
                    obj.AlmacenUbicacion = DBNull.Value == reader["AlmacenUbicacion"] ? null : Convert.ToString(reader["AlmacenUbicacion"]);
                    obj.IdTransaccion = DBNull.Value == reader["IdTransaccion"] ? (int?)null : Convert.ToInt32(reader["IdTransaccion"]);


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

        static async Task<List<ArticuloStockDTO>> ReadListarPorSedeyParametros(DbDataReader reader)
        {
            try
            {
                List<ArticuloStockDTO> collection = new List<ArticuloStockDTO>();
                while (await reader.ReadAsync())
                {
                    ArticuloStockDTO obj = new ArticuloStockDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdArticulo = Convert.ToInt32(reader["IdArticulo"]);
                    obj.Articulo = Convert.ToString(reader["Articulo"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Stock = Convert.ToInt32(reader["Stock"]);
                    obj.StockInicial = Convert.ToInt32(reader["StockInicial"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdAlmacen = Convert.ToInt32(reader["IdAlmacen"]);
                    obj.Almacen = Convert.ToString(reader["Almacen"]);
                    obj.IdAlmacenUbicacion = DBNull.Value == reader["IdAlmacenUbicacion"] ? (int?)null : Convert.ToInt32(reader["IdAlmacenUbicacion"]);
                    obj.AlmacenUbicacion = DBNull.Value == reader["AlmacenUbicacion"] ? null : Convert.ToString(reader["AlmacenUbicacion"]);
                    obj.IdTransaccion = DBNull.Value == reader["IdTransaccion"] ? (int?)null : Convert.ToInt32(reader["IdTransaccion"]);


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

        static async Task<List<ArticuloStockTrackingHistory>> ReadBuscarMovimientos(DbDataReader reader)
        {
            try
            {
                List<ArticuloStockTrackingHistory> collection = new List<ArticuloStockTrackingHistory>();
                while (await reader.ReadAsync())
                {
                    ArticuloStockTrackingHistory obj = new ArticuloStockTrackingHistory();

                    obj.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    obj.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                    obj.IdTransaccion = Convert.ToInt32(reader["IdTransaccion"]);
                    obj.TipoTransaccion = Convert.ToString(reader["TipoTransaccion"]);
                    obj.MotivoTransaccion = Convert.ToString(reader["MotivoTransaccion"]);
                    obj.Articulo = Convert.ToString(reader["Articulo"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdClaseTransaccion = Convert.ToInt32(reader["IdClaseTransaccion"]);
                    obj.Confirmado = Convert.ToBoolean(reader["Confirmado"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<ArticuloStockDTO>> ReadListarPorSedeyArticulo(DbDataReader reader)
        {
            try
            {
                List<ArticuloStockDTO> collection = new List<ArticuloStockDTO>();
                while (await reader.ReadAsync())
                {
                    ArticuloStockDTO obj = new ArticuloStockDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdArticulo = Convert.ToInt32(reader["IdArticulo"]);
                    obj.Articulo = Convert.ToString(reader["Articulo"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Stock = Convert.ToInt32(reader["Stock"]);
                    obj.StockInicial = Convert.ToInt32(reader["StockInicial"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdAlmacen = Convert.ToInt32(reader["IdAlmacen"]);
                    obj.Almacen = Convert.ToString(reader["Almacen"]);
                    obj.IdAlmacenUbicacion = DBNull.Value == reader["IdAlmacenUbicacion"] ? (int?)null : Convert.ToInt32(reader["IdAlmacenUbicacion"]);
                    obj.AlmacenUbicacion = DBNull.Value == reader["AlmacenUbicacion"] ? null : Convert.ToString(reader["AlmacenUbicacion"]);
                    obj.IdTransaccion = DBNull.Value == reader["IdTransaccion"] ? (int?)null : Convert.ToInt32(reader["IdTransaccion"]);


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


    }

   
}
