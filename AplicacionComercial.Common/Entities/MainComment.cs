using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionComercial.Common.Entities
{
    public class MainComment : Comment
    {

        public List<SubComment> SubComments { get; set; }



    }
}
