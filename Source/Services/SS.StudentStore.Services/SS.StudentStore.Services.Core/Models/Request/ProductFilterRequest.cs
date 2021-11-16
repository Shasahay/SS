using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Request
{
    public class ProductFilterRequest
    {
        private const int MaxPageSize = 100;
        private string _search { get; set; }
        private int _pageSize = 10;
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? SectionId { get; set; }
        public int? GradeId { get; set; }
        public int? BrandId { get; set; }
        //public int PageIndex { get; set; } = 1;

        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; 
        }
        public string SortField { get; set; }
        public string SortDirection { get; set; }
        public string Search
        {
            get => _search;
            set => _search = value;
        }
    }
}
