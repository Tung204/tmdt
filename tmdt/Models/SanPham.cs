using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmdt.Models
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; } //UUID sản phẩm 
        [Required]
        [MaxLength(255, ErrorMessage = "Tên sản phẩm không được vượt quá 255 ký tự.")]
        public string Name { get; set; } = string.Empty; // Tên sản phẩm

        [Required]
        [Column(TypeName = "nvarchar(max)")] // Full
        public string Description { get; set; } = string.Empty; // Mô tả sản phẩm

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 0.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Price { get; set; } // Giá sản phẩm

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Trọng lượng phải lớn hơn 0.")]
        public Decimal Weight { get; set; } // Trọng lượng sản phẩm

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Ngày tạo mặc định là thời gian hiện tại

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow; // Ngày cập nhật

        // Ràng buộc: UpdatedDate không được nhỏ hơn CreatedDate
        public bool IsValid()
        {
            return UpdatedDate >= CreatedDate;
        }
        [Required]
        public HashSet<String> images { get; set; } = new HashSet<String>(); // Danh sách Ảnh sản phẩm

        [Required]
        [Range(1, double.MaxValue, ErrorMessage ="Số lượng phải lớn hơn 1")]
        public int Quantity { get; set; } // số lượng sản phẩm

        [Required]
        public int DanhMucId { get; set; }
        [ForeignKey(nameof(DanhMucId))]
        [ValidateNever]
        public DanhMuc DanhMuc { get; set; } = null!;

        [Required]
        public int VariantId { get; set; }
        [ForeignKey(nameof(VariantId))]
        [ValidateNever]
        public Variant Variant { get; set; } = null!;
    }
}
