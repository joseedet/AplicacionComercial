using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;
using System.Linq;

namespace AplicacionComercial.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;
        public CombosHelper(DataContext context)
        {
            _dataContext = context;
        }
        public IEnumerable<SelectListItem> GetComboDepartamento()
        {
            List<SelectListItem> list = _dataContext.Departamentos.Select(t => new SelectListItem
            {
                Text = t.Descripcion,
                Value = $"{t.Id}"
            })
            .OrderBy(t => t.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "Seleciona un departamento...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboIva()
        {
            List<SelectListItem> list = _dataContext.Ivas.Select(t => new SelectListItem
            {
                Text = t.Descripcion,
                Value = $"{t.Id}"
            })
             .OrderBy(t => t.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "Seleciona un tipo de IVA ...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboMedida()
        {
            List<SelectListItem> list = _dataContext.Medidas.Select(t => new SelectListItem
            {
                Text = t.Descripcion,
                Value = $"{t.Id}"
            })
                        .OrderBy(t => t.Text)
                        .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "Seleciona un tipo medida ...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetAlmacen()
        {
            List<SelectListItem> list = _dataContext.Productos.Select(t => new SelectListItem
            {
                Text = t.Nombre,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "Seleciona un producto ...]",
                Value = "0"
            });
            return list;
        }

    }
}
