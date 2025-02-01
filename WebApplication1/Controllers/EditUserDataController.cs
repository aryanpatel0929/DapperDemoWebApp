namespace WebApplication1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using DapperDemo.Data.PersonRepository;
    using DapperDemo.Data.Models;
    public class EditUserDataController : Controller
    {
        private readonly ILogger<AddNewUserController> _logger;
        private readonly IDataBaseOperation _dataBaseOperation;

        public EditUserDataController(ILogger<AddNewUserController> logger, IDataBaseOperation dataBaseOperation)
        {
            _logger = logger;
            _dataBaseOperation = dataBaseOperation;
        }

        public IActionResult Index(int id)
        {
            PersonModel personModel = _dataBaseOperation.GetPerson(id).Result;
            return View(personModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(PersonModel person)
        {
            if (ModelState.IsValid)
            {
                await _dataBaseOperation.UpdatePerson(person);
                return RedirectToAction("Index", "Home");
            }
            return View(person);
        }
    }
}