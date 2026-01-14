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
    public class UbigeoDat : IUbigeoDat
    {
        public async Task<List<UDepartamentoDTO>> Departamentos()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Ubigeo_Departamentos", conn)
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

        public async Task<List<UCiudadDTO>> Ciudades(string IdDepartamento)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Ubigeo_CiudadByDepartamento", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdDepartamento", IdDepartamento);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCiudades(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<UDistritoDTO>> Distritos(string IdDepartamento, string IdCiudad)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("LG_SP_Ubigeo_DistritoByCiudadByDepartamento", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdDepartamento", IdDepartamento);
                cmd.Parameters.AddWithValue("pIdCiudad", IdCiudad);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadDistritos(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }





        // READER

        static async Task<List<UDepartamentoDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<UDepartamentoDTO> collection = new List<UDepartamentoDTO>();
                while (await reader.ReadAsync())
                {
                    UDepartamentoDTO obj = new UDepartamentoDTO();

                    obj.Id = Convert.ToString(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<UCiudadDTO>> ReadCiudades(DbDataReader reader)
        {
            try
            {
                List<UCiudadDTO> collection = new List<UCiudadDTO>();
                while (await reader.ReadAsync())
                {
                    UCiudadDTO obj = new UCiudadDTO();

                    obj.Id = Convert.ToString(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<List<UDistritoDTO>> ReadDistritos(DbDataReader reader)
        {
            try
            {
                List<UDistritoDTO> collection = new List<UDistritoDTO>();
                while (await reader.ReadAsync())
                {
                    UDistritoDTO obj = new UDistritoDTO();

                    obj.Id = Convert.ToString(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
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
