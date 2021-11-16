using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Filters
{
    public class ProductFilter : BaseFilter<ProductView>
    {
        public ProductFilter(ProductFilterRequest prodFilterRequest)
            : base(x => 
                        (string.IsNullOrEmpty(prodFilterRequest.Search) || x.Name.Contains(prodFilterRequest.Search, StringComparison.CurrentCultureIgnoreCase)) && 
                        (!prodFilterRequest.CategoryId.HasValue || x.CategoryId == prodFilterRequest.CategoryId) &&
                        (!prodFilterRequest.SubCategoryId.HasValue || x.SubCategoryId == prodFilterRequest.SubCategoryId) &&
                        (!prodFilterRequest.SectionId.HasValue || x.SectionId == prodFilterRequest.SectionId) &&
                        (!prodFilterRequest.GradeId.HasValue || x.GradeId == prodFilterRequest.GradeId) &&
                        (!prodFilterRequest.BrandId.HasValue || x.BrandId == prodFilterRequest.BrandId)
                  )

        {
            AddOrderBy(x => x.Name);
            ApplyPaging(prodFilterRequest.PageSize * (prodFilterRequest.PageNumber - 1), prodFilterRequest.PageSize);
            if (!string.IsNullOrEmpty(prodFilterRequest.SortField))
            {
                switch (prodFilterRequest.SortField)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }
    }
}
