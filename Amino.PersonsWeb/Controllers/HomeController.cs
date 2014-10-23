using System;
using System.Web.Mvc;
using Amino.PersonsWeb.ApplicationServices;
using Amino.PersonsWeb.Models;
using Castle.Core.Logging;

namespace Amino.PersonsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPersonsApplicationService _personsApplicationService;
        private readonly IZipCodeService _zipCodeService;

        public HomeController(IPersonsApplicationService personsApplicationService, IZipCodeService zipCodeService, ILogger logger)
        {
            _logger = logger;
            _personsApplicationService = personsApplicationService;
            _zipCodeService = zipCodeService;
        }

        public ActionResult Index()
        {
            var personsViewModel = _personsApplicationService.GetPersons();
            return View(personsViewModel);
        }

        public ActionResult CreatePerson()
        {
            var newPersonViewModel = new CreatePersonViewModel();
            newPersonViewModel.SelectZipCode = _zipCodeService.GetZipCodeViewModel();
            
            return View(newPersonViewModel);
        }

        [HttpPost]
        public ActionResult CreatePersonPost(CreatePersonViewModel createPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                _personsApplicationService.CreatePerson(createPersonViewModel);
                return RedirectToAction("Index");
            }

            createPersonViewModel.SelectZipCode = _zipCodeService.GetZipCodeViewModel();
            return View("CreatePerson", createPersonViewModel);
        }

        public ActionResult ShowPerson(Guid IdOfpersonToShow)
        {
            var personToShow = _personsApplicationService.GetPerson(IdOfpersonToShow);
            return View(personToShow);
        }
    }
}