using Microsoft.CodeAnalysis.Scripting;
using Org.BouncyCastle.Crypto.Generators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmdt.Models
{
    public class NewUser
    {
        [Key]
        public int Id { get; set; } // UUID Người dùng

        [Required]
        [StringLength(50, ErrorMessage = "Tên người dùng không được vượt quá 50 ký tự.")]
        public string Name { get; set; } = string.Empty; // Tên người dùng

        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        public string Email { get; set; } = string.Empty; // Email


        [Required]
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty; // Password

        [StringLength(255, ErrorMessage = "Địa chỉ không được vượt quá 255 ký tự.")]
        public string Address { get; set; } = string.Empty; // Địa chỉ

        [Required]
        [StringLength(50, ErrorMessage = "Số điện thoại không được vượt quá 50 ký tự.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string PhoneNumber { get; set; } = string.Empty; // Số điện thoại

        [Required]
        public string Role {  get; set; } // Customer, Admin

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
