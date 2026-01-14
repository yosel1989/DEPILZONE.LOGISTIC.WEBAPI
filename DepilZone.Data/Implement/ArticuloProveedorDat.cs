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
    public class ArticuloProveedorDat : IArticuloProveedorDat
    {


        public async Task<bool> Registrar(ArticuloDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_ArticuloProveedor_Registrar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdArticulo", model.Id);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pProveedores", JsonSerializer.Serialize(model.Proveedores) );
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


        // READER


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

    }

   
}
