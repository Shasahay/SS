using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    // later change it to view
    [Table("vwProduct")]
    public class ProductView
    {
        [Key]
        public long ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductTypeName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ShortPictureUrl { get; set; }
        public string PictureUrl { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductManufacturerPicture { get; set; }
        public string DocumentUrl { get; set; }
    }
}
