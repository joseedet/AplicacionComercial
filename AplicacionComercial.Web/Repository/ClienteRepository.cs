using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Data.Entities;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Repository
{
    public class ClienteRepository:GenericRepository<Cliente>,IClienteRepository
    {
        public ClienteRepository(DataContext dataContext):base(dataContext)
        {


        }
    }
}
