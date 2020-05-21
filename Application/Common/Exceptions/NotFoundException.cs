using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object id) 
            : base($"Entity '{name}' which id is ({id}) was not found.")
        {
        }
    }
}
