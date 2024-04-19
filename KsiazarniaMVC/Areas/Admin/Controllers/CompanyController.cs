using KsiazarniaDataAccess.Repository.IRepository;
using KsiazarniaModels;
using KsiazarniaUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KsiazarniaWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        // GET: CoverTypeController
        public ActionResult Index()
        {
            IEnumerable<Company> companyList = _unitOfWork.Company.GetAll();
            return View(companyList);
        }


        // GET: CoverTypeController/Edit/5
        public ActionResult Upsert(int? id)
        {
            Company company = new Company();

            if (id is null or 0)
            {
                return View(company);
            }

            company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            return View(company); 
        }

        // POST: CoverTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }

                _unitOfWork.Save();
                TempData["Success"] = "Company  created successfully!";
                return RedirectToAction("Index");
            }
        
            return View(company);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll();
            return Json(new { data = companyList });
        }

        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            var company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if (company == null)
            {
                return Json(new { success = false, message = "Item not found" });
            }
            _unitOfWork.Company.Remove(company);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Item deleted successfully" });
        }
        #endregion
    }
}
