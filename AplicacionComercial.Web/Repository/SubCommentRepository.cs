using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

namespace AplicacionComercial.Web.Repository
{
    public class SubCommentRepository : GenericRepository<SubComment>, ICommentRepository
    {
        public SubCommentRepository(DataContext context) : base(context)
        {



        }

    }
}
