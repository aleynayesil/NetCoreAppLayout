using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAppLayout.Models
{
    //bu sınıfın validasyonu için fluent api validation kullanıcaz
    public class CategoryUpdateInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
