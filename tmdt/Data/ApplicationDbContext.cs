using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tmdt.Models;

namespace tmdt.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<SanPham> SanPham { get; set; }
    public DbSet<DanhMuc> DanhMuc { get; set; }
    public DbSet<ProductAttribute> ProductAttribute { get; set; }
    public DbSet<SearchEngine> SearchEngines { get; set; }
    public DbSet<TaxClass> TaxClasses { get; set; }
    public DbSet<Variant> Variants { get; set; }
}
