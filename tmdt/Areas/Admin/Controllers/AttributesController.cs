using Microsoft.AspNetCore.Mvc;
using tmdt.Data;
using tmdt.Models;

namespace tmdt.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttributesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AttributesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ProductAttribute> attributes = _db.ProductAttribute.ToList();
            return View(attributes);
        }
        public IActionResult Upsert(int? id)
        {
            ProductAttribute model = new ProductAttribute();

            if (id == null || id == 0)
            {
                // Tạo mới Attribute (Create)
                return View(model);
            }

            // Lấy dữ liệu từ DB nếu đang sửa (Edit)
            model = _db.ProductAttribute.FirstOrDefault(a => a.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Upsert(ProductAttribute attributes)
        {

            if (ModelState.IsValid)
            {
                if (attributes.Id == 0)
                {
                    _db.ProductAttribute.Add(attributes);
                }
                else
                {
                    _db.ProductAttribute.Update(attributes);
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
            var attributes = _db.ProductAttribute.FirstOrDefault(sp => sp.Id == id);
            if (attributes == null)
            {
                return Json(new { success = false, message = "Thuộc tính không tìm thấy" });
            }
            _db.ProductAttribute.Remove(attributes);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
