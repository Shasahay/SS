using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Request
{
    public class ProductRequest
    {
        public long ProductId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int GradeId { get; set; }
        public int SectionId { get; set; }
        public int BrandId { get; set; }
        public string ShortPictureUrl { get; set; }
        public string PictureUrl { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductManufacturerPicture { get; set; }
        public string DocumentUrl { get; set; }
    }
}
