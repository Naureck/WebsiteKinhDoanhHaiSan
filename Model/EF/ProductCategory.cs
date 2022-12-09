namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public long ID { get; set; }

        [StringLength(250)]
        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage = "Bạn chưa nhập tên danh mục!")]
        public string Name { get; set; }

        [StringLength(250)]
        [DisplayName("Từ khóa cho danh mục")]
        [Required(ErrorMessage = "Bạn chưa nhập từ khóa!")]
        public string MetaTitle { get; set; }

        [DisplayName("Tên danh mục cha (optional)")]
        public long? ParentID { get; set; }

        [DisplayName("Thứ tự hiển thị")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn hãy nhập số")]
        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        [DisplayName("Tiêu đề SEO (optional)")]
        public string SeoTitle { get; set; }

        [DisplayName("Ngày tạo (optional)")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Tên người tạo")]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [DisplayName("Hiển thị trên trang chủ")]
        public bool? ShowOnHome { get; set; }

    }
}
