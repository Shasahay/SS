using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class Grade //: BaseEntity  Add in furture if require along with sp changes
    {
        [Key]
        public int GradeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
