using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class CustomTableTypeColumn
    {
        // There is reason to follow this naming convention
        [Key]
        public string COLUMN_NAME { get; set; }
        public string TYPE_NAME { get; set; }
        public bool NULLABLE { get; set; }
    }
}
