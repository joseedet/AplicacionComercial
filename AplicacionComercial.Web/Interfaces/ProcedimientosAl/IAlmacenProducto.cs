using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Interfaces.ProcedimientosAl;

using System.Threading.Tasks;

namespace AplicacionComercial.Interfaces.ProcedimientosAl
{
    public interface IAlmacenProducto : IStoreProcedure<BodegaProducto>
    {
        public new Task Agregar(string nombre, BodegaProducto bodegaProducto);
    }
}
