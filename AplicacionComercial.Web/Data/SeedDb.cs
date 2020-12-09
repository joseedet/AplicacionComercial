using AplicacionComercial.Common.Entities;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {

            _dataContext = dataContext;

        }
        public async Task SeedAsync()
        {

            await _dataContext.Database.EnsureCreatedAsync();
            await CheckTipoDocumentoAsync();
            await CheckConceptoAsync();
            await CheckDepartamentoAsync();
            await CheckBodegaAsync();
            await CheckMedida();
            await CheckIva();

        }

       

        public async Task CheckTipoDocumentoAsync()
        {

            if(!_dataContext.TiposDocumentos.Any())
            {
                _dataContext.TiposDocumentos.Add(new TipoDocumento
                {
                    Descripcion = "NIF",
                    Activo = true

                });
                _dataContext.TiposDocumentos.Add(new TipoDocumento
                {
                    Descripcion = "NIE",
                    Activo=true
                    
                });

                _dataContext.TiposDocumentos.Add(new TipoDocumento
                {
                    Descripcion = "CIF",
                    Activo = true

                });

                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task CheckConceptoAsync()
        {
            if (!_dataContext.Conceptos.Any())
            {
                _dataContext.Conceptos.Add(new Concepto
                {
                    Descripcion = "Entrada",
                    Activo = true

                });

                _dataContext.Conceptos.Add(new Concepto
                {
                    Descripcion = "Salida",
                    Activo = true
                });

                _dataContext.Conceptos.Add(new Concepto
                {
                    Descripcion = "Incognita",
                    Activo = true
                });

                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task CheckDepartamentoAsync()
        {
            if (!_dataContext.Departamentos.Any())
            {
                _dataContext.Departamentos.Add(new Departamento
                {
                    Descripcion = "Electronica",
                    Activo = true

                });

                _dataContext.Departamentos.Add(new Departamento
                {
                    Descripcion = "Telefonia",
                    Activo = true
                });

                _dataContext.Departamentos.Add(new Departamento
                {
                    Descripcion = "Hogar",
                    Activo = true
                });

                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task CheckBodegaAsync()
        {
            if (!_dataContext.Bodegas.Any())
            {
                _dataContext.Bodegas.Add(new Bodega
                {
                    Descripcion = "Barcelona",
                    Activo = true

                });

                _dataContext.Bodegas.Add(new Bodega
                {
                    Descripcion = "Madrid",
                    Activo = true
                });

                _dataContext.Bodegas.Add(new Bodega
                {
                    Descripcion = "Sevilla",
                    Activo = true
                });

                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task CheckMedida()
        {
            if (!_dataContext.Medidas.Any())
            {
                _dataContext.Medidas.Add(new Medida
                {
                    Descripcion = "Unidad",
                    Activo = true

                });

                _dataContext.Medidas.Add(new Medida
                {
                    Descripcion = "Litro",
                    Activo = true
                });

                _dataContext.Medidas.Add(new Medida
                {
                    Descripcion = "Kg",
                    Activo = true
                });

                await _dataContext.SaveChangesAsync();
            }
        }
       public async Task CheckIva()
        {
            if (!_dataContext.Ivas.Any())
            {
                _dataContext.Ivas.Add(new Iva
                {
                    Descripcion = "21%",
                    Tarifa=1.21,
                    Activo = true

                });

                _dataContext.Ivas.Add(new Iva
                {
                    Descripcion = "10 %",
                    Tarifa=1.10,
                    Activo = true
                });

                _dataContext.Ivas.Add(new Iva
                {
                    Descripcion = "4 %",
                    Tarifa=1.04,
                    Activo = true
                });

                await _dataContext.SaveChangesAsync();
            }

        }


    }
}
