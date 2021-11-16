using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class Category //: BaseEntity  Add in furture if require along with sp changes
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
