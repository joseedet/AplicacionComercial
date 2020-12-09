using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Repository
{
    public class ConceptoRepository:GenericRepository<Concepto>,IConcepto
    {
        public ConceptoRepository(DataContext dataContext):base(dataContext)
        {


        }
    }
}
