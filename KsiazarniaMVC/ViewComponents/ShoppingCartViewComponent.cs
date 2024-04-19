
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using KsiazarniaDataAccess.Repository.IRepository;
using KsiazarniaUtility;

namespace BulkyBookWeb.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claims != null)
            {
                if(HttpContext.Session.GetInt32(SD.SessionCart) == null)
                {
                    HttpContext.Session.SetInt32(
                        SD.SessionCart,
                        _unitOfWork.ShoppingCart.GetAll(u => u.AppUserId == claims.Value).ToList().Count);
                }
                
                return View(HttpContext.Session.GetInt32(SD.SessionCart));
                
            }

          
            HttpContext.Session.Clear();
            return View(0);
            
        }
    }
}
