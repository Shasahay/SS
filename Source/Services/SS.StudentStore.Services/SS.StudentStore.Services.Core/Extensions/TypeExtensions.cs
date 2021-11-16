using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SS.StudentStore.Services.Core.Extensions
{
    public static class TypeExtensions
    {
        public static DataTable AddColumn(this DataTable dt, string columnName, Type type, bool isNullable = true)
        {
            var newColumn = dt.Columns.Add(columnName, type);
            return dt;
        }

        public static Type ToType(this string typeName)
        {
            switch (typeName.Trim().ToLower())
            {
                case "bigint":
                    return typeof(long);
                case "bit":
                    return typeof(bool);
                case "decimal":
                    return typeof(decimal);
                default:
                    return typeof(string);
            }
        }
    }
}
