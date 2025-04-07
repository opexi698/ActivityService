using ActivityService.Models.Bos;
using ActivityService.Models.ViewModels;
using ActivityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ActivityService.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityManager _activityManager;

        public ActivityController(IActivityManager activityManager)
        {
            _activityManager = activityManager;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddActivityViewModel addActivityViewModel)
        {
            if (ModelState.IsValid)
            {
                var addActivityBo = new AddActivityBo
                {
                    Name = addActivityViewModel.Name,
                    StartDate = addActivityViewModel.StartDate,
                    EndDate = addActivityViewModel.EndDate,
                    Address = addActivityViewModel.Address,
                    Price = addActivityViewModel.Price
                };
                await _activityManager.AddActivityAsync(addActivityBo);
                return RedirectToAction("Index", "Home");
            }
            return View(addActivityViewModel);
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchActivityViewModel searchActivityViewModel)
        {
            var activities = await _activityManager.SearchActivitiesAsync(
                searchActivityViewModel.Name);

            return View("~/Views/Activity/SearchResults.cshtml", activities);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Guid activityId)
        {
            await _activityManager.RegisterActivityAsync(activityId);
            return RedirectToAction("Search");
        }
    }
}