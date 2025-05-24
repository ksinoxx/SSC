using Microsoft.AspNetCore.Mvc;
using SSC.Services;

namespace SSC.Controllers
{
    public class AdminController : Controller
    {
        private readonly GoogleSheetsService googleSheetsServise;
        public AdminController()
        {
            googleSheetsServise = new GoogleSheetsService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetSheetUrl(string sheetUrl)
        {
            HttpContext.Session.SetString("GoogleSheetUrl", sheetUrl);
            ViewBag.Message = "Google Sheet URl установлен.";
            return View("Index");
        }

        [HttpPost]
        public ActionResult UpdateCode()
        {
            string newCode = Guid.NewGuid().ToString().Substring(0, 5);
            string sheetUrl = HttpContext.Session.GetString("GoogleSheetUrl");
            if (string.IsNullOrEmpty(sheetUrl))
            {
                ViewBag.Error = "Google Sheet Url не указан.";
                return View("Index");
            }

            bool result = googleSheetsServise.UpdateOneTimeCode(newCode, sheetUrl);
            if (result)
            {
                ViewBag.Message = "Новый код сгенерирован" + newCode;
            }
            else
            {
                ViewBag.Error = "Не удалось обновить код";
            }
            return View("Index");
        }
    }

}
