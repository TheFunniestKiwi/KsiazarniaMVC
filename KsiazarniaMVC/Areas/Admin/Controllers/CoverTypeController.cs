using KsiazarniaDataAccess.Repository.IRepository;
using KsiazarniaModels;
using KsiazarniaUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KsiazarniaWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: CoverTypeController
        public ActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypesList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypesList);
        }

        // GET: CoverTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoverTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(coverType);
                _unitOfWork.Save();
                TempData["Success"] = "Cover Type created successfully!";
                return RedirectToAction("Index");
            }
            return View(coverType);
        }

        // GET: CoverTypeController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }
            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType is null)
            {
                return NotFound();
            }
            return View(coverType); 
        }

        // POST: CoverTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(coverType);
                _unitOfWork.Save();
                TempData["Success"] = "Cover Type updated successfully!";
                return RedirectToAction("Index");
            }
            return View(coverType);
        }

        // GET: CoverTypeController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        // POST: CoverTypeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePOST(int? id)
        {
            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(coverType);
            _unitOfWork.Save();
            TempData["Success"] = "Cover Type deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
