
using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Repository
{
    public class MedidaRepository:GenericRepository<Medida>,IMedidaRepository
    {

        public MedidaRepository(DataContext dataContext):base(dataContext)
        {


        }
    }
}
