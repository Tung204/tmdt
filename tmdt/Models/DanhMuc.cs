using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmdt.Models
{
    public class DanhMuc
    {
        [Key]
        public int Id { get; set; } //UUID Danh mục
        [Required]
        [MaxLength(255, ErrorMessage = "Tên danh mục không được vượt quá 255 ký tự.")]
        public string Name { get; set; } = string.Empty; // Tên danh mục

        [Required]
        [Column(TypeName = "nvarchar(max)")] // Full
        public string Description { get; set; } = string.Empty; // Mô tả danh mục

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
    }
}
