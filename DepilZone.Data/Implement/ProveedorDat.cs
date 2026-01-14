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
    public class ProveedorDat : IProveedorDat
    {
        public async Task<List<ProveedorDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Proveedor_Listar", conn)
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

        public async Task<List<ProveedorDTO>> ListarPorParametros(string parametros)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Proveedor_BuscarPorParametros", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pParametros", parametros);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarPorParametros(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Registrar(ProveedorDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Proveedor_Registrar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pRuc", model.Ruc);
                cmd.Parameters.AddWithValue("pRazonSocial", model.RazonSocial);
                cmd.Parameters.AddWithValue("pContactoNombre", model.ContactoNombre);
                cmd.Parameters.AddWithValue("pContactoApellido", model.ContactoApellido);
                cmd.Parameters.AddWithValue("pContactoTelefono", model.ContactoTelefono);
                cmd.Parameters.AddWithValue("pContactoCorreo", model.ContactoCorreo);
                cmd.Parameters.AddWithValue("pIdUbicacion", model.IdUbicacion);
                cmd.Parameters.AddWithValue("pDireccion", model.Direccion);
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

        public async Task<bool> Modificar(int id, ProveedorDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Proveedor_Modificar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pRuc", model.Ruc);
                cmd.Parameters.AddWithValue("pRazonSocial", model.RazonSocial);
                cmd.Parameters.AddWithValue("pContactoNombre", model.ContactoNombre);
                cmd.Parameters.AddWithValue("pContactoApellido", model.ContactoApellido);
                cmd.Parameters.AddWithValue("pContactoTelefono", model.ContactoTelefono);
                cmd.Parameters.AddWithValue("pContactoCorreo", model.ContactoCorreo);
                cmd.Parameters.AddWithValue("pIdUbicacion", model.IdUbicacion);
                cmd.Parameters.AddWithValue("pDireccion", model.Direccion);
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

        static async Task<List<ProveedorDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<ProveedorDTO> collection = new List<ProveedorDTO>();
                while (await reader.ReadAsync())
                {
                    ProveedorDTO obj = new ProveedorDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Ruc = DBNull.Value == reader["Ruc"] ? null : reader["Ruc"].ToString();
                    obj.RazonSocial = DBNull.Value == reader["RazonSocial"] ? null : reader["RazonSocial"].ToString();
                    obj.ContactoNombre = DBNull.Value == reader["ContactoNombre"] ? null : reader["ContactoNombre"].ToString();
                    obj.ContactoApellido = DBNull.Value == reader["ContactoApellido"] ? null : reader["ContactoApellido"].ToString();
                    obj.ContactoTelefono = DBNull.Value == reader["ContactoTelefono"] ? null : reader["ContactoTelefono"].ToString();
                    obj.ContactoCorreo = DBNull.Value == reader["ContactoCorreo"] ? null : reader["ContactoCorreo"].ToString();
                    obj.IdUbicacion = DBNull.Value == reader["IdUbicacion"] ? null : Convert.ToString(reader["IdUbicacion"]);
                    obj.Direccion = DBNull.Value == reader["Direccion"] ? null : Convert.ToString(reader["Direccion"]);

                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.UsuarioRegistro = DBNull.Value == reader["UsuarioRegistro"] ? null : Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);


                    obj.Ubigeo = DBNull.Value == reader["Ubigeo"] ? null : Convert.ToString(reader["Ubigeo"]);
                    obj.Ciudad = DBNull.Value == reader["Ciudad"] ? null : Convert.ToString(reader["Ciudad"]);
                    obj.Distrito = DBNull.Value == reader["Distrito"] ? null : Convert.ToString(reader["Distrito"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<ProveedorDTO>> ReadListarPorParametros(DbDataReader reader)
        {
            try
            {
                List<ProveedorDTO> collection = new List<ProveedorDTO>();
                while (await reader.ReadAsync())
                {
                    ProveedorDTO obj = new ProveedorDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Ruc = DBNull.Value == reader["Ruc"] ? null : reader["Ruc"].ToString();
                    obj.RazonSocial = DBNull.Value == reader["RazonSocial"] ? null : reader["RazonSocial"].ToString();
                    obj.ContactoNombre = DBNull.Value == reader["ContactoNombre"] ? null : reader["ContactoNombre"].ToString();
                    obj.ContactoApellido = DBNull.Value == reader["ContactoApellido"] ? null : reader["ContactoApellido"].ToString();
                    obj.ContactoTelefono = DBNull.Value == reader["ContactoTelefono"] ? null : reader["ContactoTelefono"].ToString();
                    obj.ContactoCorreo = DBNull.Value == reader["ContactoCorreo"] ? null : reader["ContactoCorreo"].ToString();
                    obj.IdUbicacion = DBNull.Value == reader["IdUbicacion"] ? null : Convert.ToString(reader["IdUbicacion"]);
                    obj.Direccion = DBNull.Value == reader["Direccion"] ? null : Convert.ToString(reader["Direccion"]);

                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.UsuarioRegistro = DBNull.Value == reader["UsuarioRegistro"] ? null : Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);


                    obj.Ubigeo = DBNull.Value == reader["Ubigeo"] ? null : Convert.ToString(reader["Ubigeo"]);
                    obj.Ciudad = DBNull.Value == reader["Ciudad"] ? null : Convert.ToString(reader["Ciudad"]);
                    obj.Distrito = DBNull.Value == reader["Distrito"] ? null : Convert.ToString(reader["Distrito"]);
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
                        throw new AlertException(errorMensaje);
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
                        throw new AlertException(errorMensaje);
                    }
                }

                return exito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// RELATION SHIP
        ///

        public async Task<List<ProveedorDTO>> ListarPorArticulo(int idArticulo)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_ArticuloProveedor_ListarPorArticulo", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdArticulo", idArticulo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarPorArticulo(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        // READER RELATION SHIP
        static async Task<List<ProveedorDTO>> ReadListarPorArticulo(DbDataReader reader)
        {
            try
            {
                List<ProveedorDTO> collection = new List<ProveedorDTO>();
                while (await reader.ReadAsync())
                {
                    ProveedorDTO obj = new ProveedorDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Ruc = DBNull.Value == reader["Ruc"] ? null : reader["Ruc"].ToString();
                    obj.RazonSocial = DBNull.Value == reader["RazonSocial"] ? null : reader["RazonSocial"].ToString();
                    obj.ContactoNombre = DBNull.Value == reader["ContactoNombre"] ? null : reader["ContactoNombre"].ToString();
                    obj.ContactoApellido = DBNull.Value == reader["ContactoApellido"] ? null : reader["ContactoApellido"].ToString();
                    obj.ContactoTelefono = DBNull.Value == reader["ContactoTelefono"] ? null : reader["ContactoTelefono"].ToString();
                    obj.ContactoCorreo = DBNull.Value == reader["ContactoCorreo"] ? null : reader["ContactoCorreo"].ToString();
                    obj.IdUbicacion = DBNull.Value == reader["IdUbicacion"] ? null : Convert.ToString(reader["IdUbicacion"]);
                    obj.Direccion = DBNull.Value == reader["Direccion"] ? null : Convert.ToString(reader["Direccion"]);

                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.UsuarioRegistro = DBNull.Value == reader["UsuarioRegistro"] ? null : Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);


                    obj.Ubigeo = DBNull.Value == reader["Ubigeo"] ? null : Convert.ToString(reader["Ubigeo"]);
                    obj.Ciudad = DBNull.Value == reader["Ciudad"] ? null : Convert.ToString(reader["Ciudad"]);
                    obj.Distrito = DBNull.Value == reader["Distrito"] ? null : Convert.ToString(reader["Distrito"]);
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
