using BeautyStudio.Application.Models.BeautyStudio;
using BeautyStudio.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautyStudio.MVC.Controllers
{
    public class BeautyStudioController : Controller
    {
        private readonly IBeautyStudioService _beautyStudioService;

        public BeautyStudioController(IBeautyStudioService beautyStudioService) 
        {
            _beautyStudioService = beautyStudioService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBeautyStudioDto beautyStudio)
        {
            if (!ModelState.IsValid)
                return View(beautyStudio);

            await _beautyStudioService.Create(beautyStudio);
            return RedirectToAction(nameof(Create));
        }
    }
}
