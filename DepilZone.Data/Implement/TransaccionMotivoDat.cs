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
    public class TransaccionMotivoDat : ITransaccionMotivoDat
    {
        public async Task<List<TransaccionMotivoDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_TransaccionMotivo_Listar", conn)
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


        // READER

        static async Task<List<TransaccionMotivoDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<TransaccionMotivoDTO> collection = new List<TransaccionMotivoDTO>();
                while (await reader.ReadAsync())
                {
                    TransaccionMotivoDTO obj = new TransaccionMotivoDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"].ToString());
                    obj.Codigo = Convert.ToInt32(reader["Codigo"]);
                    obj.IdTipoTransaccion = Convert.ToInt32(reader["IdTipoTransaccion"]);
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
