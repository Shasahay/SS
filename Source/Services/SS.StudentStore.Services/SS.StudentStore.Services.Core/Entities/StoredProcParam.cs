using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class StoredProcParam
    {
        // There is reason to follow this naming convention
        [Key]
        public string PARAMETER_NAME { get; set; }
        public string PARAMATER_MODE { get; set; }
        public string DATA_TYPE { get; set; }
        public string USER_DEFINED_TYPE_SCHEMA { get; set; }
        public string USER_DEFINED_TYPE_NAME { get; set; }
    }
}
