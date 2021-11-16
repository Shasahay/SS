using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class StagingProduct
    {
        [Key]
        public long? ProductId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public long SubCategoryId { get; set; }
        public long GradeId { get; set; }
        public long SectionId { get; set; }
        public long BrandId { get; set; }
        public string ShortPictureUrl { get; set; }
        public string PictureUrl { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductManufacturerPicture { get; set; }
        public string ProductManufacturerProfile { get; set; }
        public string DocumentUrl { get; set; }
        public int DocumentType { get; set; }
        public bool? IsActive { get; set; }
        public int StatusId { get; set; }
        public Guid ProductUID { get; set; }

    }
}
