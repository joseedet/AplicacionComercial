using Microsoft.AspNetCore.Http;

using System.IO;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Interfaces
{
    public interface IFileManager
    {

        FileStream imageStream(string image);
        Task<string> SaveImage(IFormFile file);
        bool RemoveImage(string image);
    }
}
