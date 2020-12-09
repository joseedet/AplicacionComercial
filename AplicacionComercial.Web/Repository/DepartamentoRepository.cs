
using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Repository
{
    public class DepartamentoRepository:GenericRepository<Departamento>,IDepartamentoRepository
    {
        
        public DepartamentoRepository(DataContext dataContext):base(dataContext)
        {


        }
    }
}
