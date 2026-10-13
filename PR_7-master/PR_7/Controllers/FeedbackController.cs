using System.Web.Mvc;
using FeedbackApp.Models;

namespace FeedbackApp.Controllers
{
    public class FeedbackController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Feedback model)
        {
            if (ModelState.IsValid)
            {
                TempData["UserName"] = model.Name;
                TempData["UserRating"] = model.Rating;

                return RedirectToAction("Success");
            }

            return View(model);
        }

        public ActionResult Success()
        {
            if (TempData["UserName"] == null)
            {
                return RedirectToAction("Create");
            }

            return View();
        }
    }
}