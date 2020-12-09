using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Repository
{
    public class BodegaRepository:GenericRepository<Bodega>,IBodega
    {
        public BodegaRepository(DataContext dataContext):base(dataContext)
        {


        }
    }
}
