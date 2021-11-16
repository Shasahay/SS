using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class SchemaTableType
    {
        [Key]
        public string ColumnName { get; set; }
        public string TypeName { get; set; }
    }
}
