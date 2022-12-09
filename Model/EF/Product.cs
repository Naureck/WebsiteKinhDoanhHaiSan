namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập tên sản phẩm!")]
        public string Name { get; set; }

        [StringLength(10)]
        [DisplayName("Mã sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập mã sản phẩm!")]
        public string Code { get; set; }

        [StringLength(250)]
        [DisplayName("Từ khóa")]
        [Required(ErrorMessage = "Bạn chưa nhập từ khóa!")]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [DisplayName("Mô tả (Optional)")]
        public string Description { get; set; }

        [StringLength(250)]
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        [DisplayName("Thêm hình ảnh")]
        public string MoreImages { get; set; }

        [DisplayName("Giá sản phẩm")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Bạn hãy nhập số!")]
        [Required(ErrorMessage = "Bạn chưa nhập giá sản phẩm!")]
        public decimal? Price { get; set; }

        [DisplayName("Giá khuyến mãi (Optional)")]
        public decimal? PromotionPrice { get; set; }

        public bool? IncludedVAT { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [DisplayName("Mã danh mục")]
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Thông tin chi tiết")]
        public string Detail { get; set; }

        [StringLength(50)]
        [DisplayName("Khối lượng")]
        public string Warranty { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người tạo")]
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

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }
    }
}
