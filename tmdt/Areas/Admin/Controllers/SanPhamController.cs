using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using tmdt.Areas.Customer.Controllers;
using tmdt.Data;
using tmdt.Models;

namespace tmdt.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.ToList();
            return View(sanpham);
        }
        //public IActionResult Upsert(int id)
        //{
        //    SanPham sanpham = new SanPham();
        //    IEnumerable<SelectListItem> dsdanhmuc = _db.DanhMuc.Select(
        //        item => new SelectListItem
        //        {
        //            Value = item.Id.ToString(),
        //            Text = item.Name
        //        }
        //        );
        //    ViewBag.DSTheLoai = dsdanhmuc;

        //    // Danh sách nhà sản xuất
        //    IEnumerable<SelectListItem> dsNhaSanXuat = _db.Attributes.Select(
        //        item => new SelectListItem
        //        {
        //            Value = item.Id.ToString(),
        //            Text = item.Name
        //        }
        //    );
        //    ViewBag.DSNhaSX = dsNhaSanXuat;

        //    if (id == 0)
        //    {
        //        return View(sanpham);
        //    }
        //    else
        //    {
        //        sanpham = _db.SanPham
        //           .Include(sp => sp.TheLoai)  // Bao gồm TheLoai
        //           .Include(sp => sp.NhaSanXuat)  // Bao gồm NhaSanXuat
        //           .FirstOrDefault(sp => sp.Id == id);

        //        if (sanpham == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(sanpham);
        //    }
        //}
        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                if (sanpham.Id == 0)
                {
                    _db.SanPham.Add(sanpham);
                }
                else
                {
                    _db.SanPham.Update(sanpham);
                }
                // Lưu lại
                _db.SaveChanges();
                //Chuyen trang ve index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var sanpham = _db.SanPham.FirstOrDefault(sp => sp.Id == id);
            if (sanpham == null)
            {
                return Json(new { success = false, message = "Sản phẩm không tìm thấy" });
            }
            _db.SanPham.Remove(sanpham);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
