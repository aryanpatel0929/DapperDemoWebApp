namespace WebApplication1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using DapperDemo.Data.PersonRepository;
    using DapperDemo.Data.Models;
    public class AddNewUserController : Controller
    {
        private readonly ILogger<AddNewUserController> _logger;
        private readonly IDataBaseOperation _dataBaseOperation;

        public AddNewUserController(ILogger<AddNewUserController> logger, IDataBaseOperation dataBaseOperation)
        {
            _logger = logger;
            _dataBaseOperation = dataBaseOperation;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(PersonModel person)
        {
            if (ModelState.IsValid)
            {
                await _dataBaseOperation.InsertPerson(person);
                return RedirectToAction("Index", "Home");
            }
            return View(person);
        }
    }
}