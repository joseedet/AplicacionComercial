using AplicacionComercial.Common.Entities;
using AplicacionComercial.Interfaces.ProcedimientosAl;
using AplicacionComercial.Web.Data;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace AplicacionComercial.Web.Repository.ProcedimientoAlmacenados
{
    public class AlmacenProductoPARepository : GenericProcedimientosAlmacenados<BodegaProducto>, IAlmacenProducto
    {
        DataContext _dataContext;
        public AlmacenProductoPARepository(DataContext dataContext) : base(dataContext)
        {

            _dataContext = dataContext;
        }


        public new async Task Agregar(string nombre, BodegaProducto bodegaProducto)
        {
           var parameters = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@productoId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = bodegaProducto.Idproducto
                        },
                        new SqlParameter() {
                            ParameterName = "@almacenId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = bodegaProducto.Idbodega
                        },
                         new SqlParameter() {
                            ParameterName = "@stock",
                            SqlDbType =  System.Data.SqlDbType.Float,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = bodegaProducto.Stock
                        },
                         new SqlParameter() {
                            ParameterName = "@minimo",
                            SqlDbType =  System.Data.SqlDbType.Float,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = bodegaProducto.Minimo
                        },
                         new SqlParameter() {
                            ParameterName = "@maximo",
                            SqlDbType =  System.Data.SqlDbType.Float,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = bodegaProducto.Maximo
                        },
                         new SqlParameter() {
                            ParameterName = "@diasReposicion",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = bodegaProducto.DiasReposicion
                        },

                        new SqlParameter() {
                            ParameterName = "@cantidaMinima",
                            SqlDbType =  System.Data.SqlDbType.Float,
                            Direction = System.Data.ParameterDirection.Input,
                            Value=bodegaProducto.CantidadMinima
                        }};

            await _dataContext.Database
            .ExecuteSqlRawAsync($"[dbo].[InsertarAlmacenProducto] (@productoId, @almacenId, @stock, @minimo, @maximo, @diasReposicion, @cantidaMinima"
                                ,parameters);
           
        }
    }
}
