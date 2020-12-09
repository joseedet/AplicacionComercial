
using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Repository
{
    public class IvaRepository:GenericRepository<Iva>,IIvaRepository
    {

        public IvaRepository(DataContext dataContext):base(dataContext)
        {


        }
    }
}
