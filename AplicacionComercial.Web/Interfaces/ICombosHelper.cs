using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Interfaces
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboDepartamento();
        IEnumerable<SelectListItem> GetComboIva();
        IEnumerable<SelectListItem> GetComboMedida();
        IEnumerable<SelectListItem> GetAlmacen();

    }
}
