using AplicacionComercial.Common.Entities;

using System.Collections.Generic;

namespace AplicacionComercial.Web.Models
{
    public class IndexViewModel
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public string Catgory { get; set; }
        public bool NextPage { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<int> Pages { get; internal set; }
    }
}
