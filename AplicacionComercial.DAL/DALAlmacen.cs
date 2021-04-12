using AplicacionComercial.Common.Entities;
using AplicacionComercial.DAL.DSAplicacionComercialTableAdapters;
using AplicacionComercial.Web.Data;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace AplicacionComercial.DAL
{
    //Cambiar todo ya que la funciones tienen que ser estáticas.
    public class DALAlmacen : DALInterfaces<Bodega>
    {
        private readonly BodegasTableAdapter _ds = new BodegasTableAdapter();
        private readonly DataContext _dataContext;

        public bool Actualizar(string Descripcion, bool activo)
        {
            try
            {
                if (activo == false)
                {
                    return false;
                }
                _ds.ActualizarAlmacen(Descripcion, activo);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public void Insertar(string Descripcion, bool activo)
        {
            _ds.InsertarAlmacen(Descripcion, activo);
        }

        public bool Eliminar(bool activo, int id)
        {
            try
            {
                _ds.EliminarAlmacen(activo, id);
                return true;
            }
            catch

            {
                return false;
            }
        }

        public async Task<List<Bodega>> TodosLosRegistros(string NombreProcedimiento)
        {
            List<Bodega> bodegas = new List<Bodega>();
            var conn = _dataContext.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = NombreProcedimiento;
                    command.CommandType = CommandType.StoredProcedure;

                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new Bodega
                            {
                                Id = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                Activo = reader.GetBoolean(2)


                            };
                            bodegas.Add(row);
                        }
                    }
                    reader.Dispose();
                }
            }
            catch
            {

                conn.Close();

            }
            finally
            {

                conn.Close();
            }
            throw new NotImplementedException();
            //foreach()
            //return _ds.GetData();
        }
    }


}
