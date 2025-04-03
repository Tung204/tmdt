using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmdt.Models
{
    public class ProductAttribute
    {
        [Key]
        public int Id { get; set; } //UUID sản phẩm 

        [Required]
        [MaxLength(255, ErrorMessage = "Tên thuộc tính không được vượt quá 255 ký tự.")]
        public string Name { get; set; } = string.Empty; // Tên 

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "VARCHAR(100)")]
        public string AttributeCode { get; set; } // Mã thuộc tính (unique)

        [Required]
        public bool IsRequired { get; set; } = false; // Bắt buộc nhập?

        [Required]
        public bool IsFilterable { get; set; } = false; // Lọc sản phẩm theo thuộc tính?

        [Required]
        public bool ShowToCustomers { get; set; } = true; // Hiển thị cho khách hàng?

        [Required]
        [Range(0, int.MaxValue)]
        public int SortOrder { get; set; } = 0; // Thứ tự sắp xếp

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = "Text"; // Kiểu thuộc tính: Text, Select, Multiselect, Textarea

        public int? AttributeGroupId { get; set; } // Nhóm thuộc tính

        [ForeignKey("AttributeGroupId")]
        public virtual AttributeGroup? AttributeGroup { get; set; }

        // Nếu là Select hoặc Multiselect, cần có danh sách options
        public List<AttributeOption> Options { get; set; } = new List<AttributeOption>();
    }
    public class AttributeOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AttributeId { get; set; }

        [ForeignKey("AttributeId")]
        public virtual ProductAttribute Attribute { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Value { get; set; } = string.Empty; // Giá trị của option

        [Required]
        [Range(0, int.MaxValue)]
        public int SortOrder { get; set; } = 0; // Thứ tự hiển thị
    }

    public class AttributeGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } // Tên nhóm thuộc tính

        public virtual ICollection<ProductAttribute>? Attributes { get; set; } = new List<ProductAttribute>();
    }
}
