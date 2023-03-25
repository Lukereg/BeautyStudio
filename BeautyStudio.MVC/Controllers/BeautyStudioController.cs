using BeautyStudio.Application.BeautyStudio;
using BeautyStudio.Application.BeautyStudio.Commands.CreateBeautyStudio;
using BeautyStudio.Application.BeautyStudio.Queries.GetAllBeautyStudios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeautyStudio.MVC.Controllers
{
    public class BeautyStudioController : Controller
    {
        private readonly IMediator _mediator;

        public BeautyStudioController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var beautyStudios = await _mediator.Send(new GetAllBeautyStudiosQuery());
            return View(beautyStudios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBeautyStudioCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
