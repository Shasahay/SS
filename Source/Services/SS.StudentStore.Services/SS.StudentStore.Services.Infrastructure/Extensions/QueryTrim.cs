using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SS.StudentStore.Services.Infrastructure.Extensions
{
    public static class QueryTrim
    {
        #region Revisit later for genetic method
        //public static IQueryable<TEntity> GenericTrim(this IQueryable<TEntity> value, int trimValue)
        //{
        //    PropertyInfo[] propertyInfos;
        //    propertyInfos = typeof(TEntity).GetProperties(BindingFlags.Public);
        //    value.Where(x => x. == trimValue)
        //} 
        #endregion

        public static IQueryable<ProductView> CategoryTrim(this IQueryable<ProductView> productViews, int id)
        => productViews.Where(x => x.CategoryId == id);
        public static IQueryable<ProductView> SubCategoryTrim(this IQueryable<ProductView> productViews, int id)
        => productViews.Where(x => x.SubCategoryId == id);
        public static IQueryable<ProductView> GradeTrim(this IQueryable<ProductView> productViews, int id)
        => productViews.Where(x => x.GradeId == id);
        public static IQueryable<ProductView> SectionTrim(this IQueryable<ProductView> productViews, int id)
        => productViews.Where(x => x.SectionId == id);
        public static IQueryable<ProductView> BrandTrim(this IQueryable<ProductView> productViews, int id)
        => productViews.Where(x => x.BrandId == id);

        public static IQueryable<ProductView> ProductViewFilterTrim(this IQueryable<ProductView> productViews, ProductFilterRequest prodFilterRequest)
        {
            if ((prodFilterRequest.CategoryId.HasValue && prodFilterRequest.CategoryId.Value > 0))
                productViews = productViews.CategoryTrim(prodFilterRequest.CategoryId.Value);
            if ((prodFilterRequest.SubCategoryId.HasValue && prodFilterRequest.SubCategoryId.Value > 0))
                productViews = productViews.SubCategoryTrim(prodFilterRequest.SubCategoryId.Value);
            if ((prodFilterRequest.SectionId.HasValue && prodFilterRequest.SectionId.Value > 0))
                productViews = productViews.SectionTrim(prodFilterRequest.SectionId.Value);
            if ((prodFilterRequest.GradeId.HasValue && prodFilterRequest.GradeId.Value > 0))
                productViews = productViews.GradeTrim(prodFilterRequest.GradeId.Value);
            if ((prodFilterRequest.BrandId.HasValue && prodFilterRequest.BrandId.Value > 0))
                productViews = productViews.BrandTrim(prodFilterRequest.BrandId.Value);

            return productViews;
           
            //return productViews.Where(x => x.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase) ||
            //                           x.CategoryId == categoryId ||
            //                           x.SubCategoryId == subcaregoryId ||
            //                           x.SectionId == sectionId ||
            //                           x.GradeId == gradeId ||
            //                           x.BrandId == bradeId
            //                       );
        }

        //public static IQueryable<ProductView> ProductViewSearchTrim(this IQueryable<ProductView> productViews, ProductFilterRequest prodFilterRequest)
        //{
        //    return productViews.Where( x => SqlMethods)
        //}


    }
}
