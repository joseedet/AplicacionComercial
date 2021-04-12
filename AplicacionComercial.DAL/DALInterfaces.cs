using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionComercial.DAL
{
    public interface DALInterfaces<T> where T : class
    {
        void Insertar(string Descripcion, bool activo);
        bool Actualizar(string Descripcion, bool activo);
        bool Eliminar(bool activo, int id);
        Task<List<T>> TodosLosRegistros(string NombreProcedimiento);


    }
}
