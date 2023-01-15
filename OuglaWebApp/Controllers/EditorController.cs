using Microsoft.AspNetCore.Mvc;
using OuglaWebApp.Models;
using System.Reflection.Metadata;

namespace OuglaWebApp.Controllers
{
    public class EditorController : Controller
    {

        public IActionResult Editor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditorContent(Content content, IFormFile logo,IFormFile Banner, IFormFile objImg)
        {
            try
            {
                if (logo != null)
                {
                    using (var target = new MemoryStream())
                    {
                        await logo.CopyToAsync(target);
                        content.logoImg = target.ToArray();
                    }
                }
                if (Banner != null)
                {
                    using (var target = new MemoryStream())
                    {
                        await logo.CopyToAsync(target);
                        content.logoImg = target.ToArray();
                    }
                }
                if (objImg != null)
                {
                    using (var target = new MemoryStream())
                    {
                        await logo.CopyToAsync(target);
                        content.logoImg = target.ToArray();
                    }
                }

            }
            catch (Exception)
            {
                TempData["msg"] = "<script>alert('Oops! Something went wrong');</script>";
                return RedirectToAction("BlogEditor", "Blog");
            }
        }
        public async Task<byte[]> ImgConversion(IFormFile file,string ImgType) 
        {
            byte[] imgInByte= null;
            if (file != null)
            {
                using (var target = new MemoryStream())
                {
                    await file.CopyToAsync(target);
                    imgInByte = target.ToArray();
                }
                return imgInByte;
            }
        }
    }
}
