using GUC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUC.Services
{
    public interface IGucRepo
    {
        public IEnumerable<ListDto> GetList();
    }
}
