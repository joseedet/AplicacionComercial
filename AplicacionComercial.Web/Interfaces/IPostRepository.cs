using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Interfaces
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        //TODO: Mirar video y poner los datos que faltan
        List<Post> GetAll(string category);
        // new IQueryable IndexViewModel GetAll(int pageNumber);
        IndexViewModel GetAllPosts(int pageNumber);
        IndexViewModel GetAllPosts(int pageNumber, string category);

    }
}
