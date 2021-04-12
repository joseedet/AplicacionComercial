using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Data.Entities;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Repository
{
    public class TipoDocumentoRepository:GenericRepository<TipoDocumento>,ITipoDocumento
    {
        //private DataContext _context;
        public TipoDocumentoRepository(DataContext dataContext):base(dataContext)
        {


        }
    }
}
