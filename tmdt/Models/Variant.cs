using System.ComponentModel.DataAnnotations;

namespace tmdt.Models
{
    public class Variant
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Name { get; set; } = string.Empty; // Tên

        [Required]
        public HashSet<String> images { get; set; } = new HashSet<String>(); // Danh sách Ảnh sản phẩm

        [Required]
        public string Size { get; set; } = string.Empty; // Size

        [Required] public string Color { get; set; } = string.Empty;

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
