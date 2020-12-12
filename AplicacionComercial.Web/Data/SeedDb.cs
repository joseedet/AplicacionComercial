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
            await CheckClienteAsync();
            await CheckProveedor();
            //await CheckProducto();

        }

       
        private async Task CheckBodegaAsync()
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
        private async Task CheckConceptoAsync()
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
        private async Task CheckDepartamentoAsync()
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
        private async Task CheckIva()
        {
            if (!_dataContext.Ivas.Any())
            {
                _dataContext.Ivas.Add(new Iva
                {
                    Descripcion = "21%",
                    Tarifa = 1.21,
                    Activo = true

                });

                _dataContext.Ivas.Add(new Iva
                {
                    Descripcion = "10 %",
                    Tarifa = 1.10,
                    Activo = true
                });

                _dataContext.Ivas.Add(new Iva
                {
                    Descripcion = "4 %",
                    Tarifa = 1.04,
                    Activo = true
                });

                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckMedida()
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
        //private async Task CheckProducto()
        //{
        //    if (!_dataContext.Productos.Any())
        //    {
        //        _dataContext.Productos.Add(new Producto
        //        {
        //            Activo = true,
        //            Descripcion="No disponible",
        //            Iddepartamento=1,
        //            Idiva=3,
        //            Idmedida="1",

        //        });

        //    }

        //     await _dataContext.SaveChangesAsync();
        //}

        private async Task CheckTipoDocumentoAsync()
        {
            if (!_dataContext.TiposDocumentos.Any())
            {
                _dataContext.TiposDocumentos.Add(new TipoDocumento
                {
                    Descripcion = "NIF",
                    Activo = true

                });
                _dataContext.TiposDocumentos.Add(new TipoDocumento
                {
                    Descripcion = "NIE",
                    Activo = true

                });

                _dataContext.TiposDocumentos.Add(new TipoDocumento
                {
                    Descripcion = "CIF",
                    Activo = true

                });

                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckClienteAsync()
        {
            if(! _dataContext.Clientes.Any())
            {
                _dataContext.Clientes.Add(new Cliente
                {
                    Activo = true,
                    Aniversario = DateTime.Now,
                    ApellidosContacto = "Pérez Reverte",
                    CodPostal="08025",
                    Correo="perezreverte@gmail.com",
                    Direccion="C/ Libertad 25 1º 1ª" ,
                    Documento="4599988L",
                    Foto="",
                    IdtipoDocumento=1,
                    Movil="691005533",
                    NombreComercial="Horticultura Pérez",
                    NombresContacto="Juan",
                    Notas="Esto es una prueba",
                    Poblacion="Barcelona",
                    Provincia="Barcelona",
                    Telefono="931811220"                 

                });
                _dataContext.Clientes.Add(new Cliente
                {
                    Activo = true,
                    Aniversario = DateTime.Now,
                    ApellidosContacto = "Pérez López",
                    CodPostal = "08025",
                    Correo = "perezlopez@gmail.com",
                    Direccion = "C/ Libertad 25 1º 1ª",
                    Documento = "4599966T",
                    Foto = "",
                    IdtipoDocumento = 1,
                    Movil = "691225500",
                    NombreComercial = "Moviles Pérez",
                    NombresContacto = "Francisco",
                    Notas = "Esto es una prueba",
                    Poblacion = "Barcelona",
                    Provincia = "Barcelona",
                    Telefono = "931851155"

                });
            }           
            await _dataContext.SaveChangesAsync();
        }
        private async Task CheckProveedor()
        {
            if (!_dataContext.Proveedores.Any())
            {
                _dataContext.Proveedores.Add(new Proveedor
                {
                    Activo = true,
                    Nombre = "Tierra Española",
                    ApellidosContacto = "Montiel Garcia",
                    CodPostal = "08025",
                    Correo = "tierraespanola@gmail.com",
                    Direccion = "C/ Canuto 25 1º 1ª",
                    Documento = "B4599966L",
                    IdtipoDocumento = 3,
                    Movil = "691225500",
                    NombresContacto = "Juan",
                    Notas = "Esto es una prueba",
                    Poblacion = "Barcelona",
                    Provincia = "Barcelona",
                    Telefono = "931851157"
                });
                _dataContext.Proveedores.Add(new Proveedor
                {
                    Activo = true,
                    Nombre = "Tierra Quemada",
                    ApellidosContacto = "Garcia Garcia",
                    CodPostal = "08024",
                    Correo = "tierraquemada@gmail.com",
                    Direccion = "C/ del agua 25 1º 1ª",
                    Documento = "B4599944L",
                    IdtipoDocumento = 3,
                    Movil = "690225500",
                    NombresContacto = "Tomás",
                    Notas = "Esto es una prueba",
                    Poblacion = "Barcelona",
                    Provincia = "Barcelona",
                    Telefono = "931801135"

                });
            }
            
            await _dataContext.SaveChangesAsync();
        }
    }
}
