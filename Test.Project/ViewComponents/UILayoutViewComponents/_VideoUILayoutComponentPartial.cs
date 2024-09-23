using Microsoft.AspNetCore.Mvc;

namespace Test.Project.ViewComponents.UILayoutViewComponents
{
    public class _VideoUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Çerezi kontrol et
            var cookieValue = HttpContext.Request.Cookies["VideoShown"];
            if (string.IsNullOrEmpty(cookieValue))
            {

                var options = new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddMinutes(30) // 30 dakika geçerli
                };
                HttpContext.Response.Cookies.Append("VideoShown", "true", options);
                return View(); // İlk kez göster
            }

            
            return Content(""); 
        }
    }
}
