using AplicacionComercial.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionComercial.Common.Entities
{
    public class Comment:IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}
