using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeMultiplicationTable.Web.Models.Input;
using PrimeMultiplicationTable.Web.Models.Output;
using PrimeMultiplicationTable.Web.Repositories;
using System;

namespace PrimeMultiplicationTable.Web.Controllers
{
    public class PrimesController : Controller
    {
        private readonly ILogger<PrimesController> _logger;
        private readonly IPrimeRepository _primeRepository;

        public PrimesController(ILogger<PrimesController> logger,
                                IPrimeRepository primeRepository)
        {
            _logger = logger;
            _primeRepository = primeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Result()
        {
            _logger.LogInformation("Calling Result view without any input");
            PrimeOutputModelView modelToReturn = new PrimeOutputModelView()
            {
                ErrorMessage = "You have to specify the input to calculate. Please go back to home page and try it again."
            };

            return View(modelToReturn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(PrimeInputModelView model)
        {
            if (ModelState.IsValid)
            {
                PrimeOutputModelView modelToReturn;
                try
                {
                    var primesList = _primeRepository.GetPrimesList(model.PrimesCount);

                    modelToReturn = new PrimeOutputModelView()
                    {
                        InputValue = model.PrimesCount,
                        AxisXPrimeNumbers = primesList
                    };

                    _logger.LogInformation($"Calculation process correctly. Value: {model.PrimesCount}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error during calculation. Value: {model.PrimesCount}. Error: {ex}");

                    modelToReturn = new PrimeOutputModelView()
                    {
                        ErrorMessage = "Something went wrong during calculation. Please go back and try it again."
                    };
                }

                return View("Result", modelToReturn);
            }
            else
            {
                return View("Index", model);
            }
        }
    }
}
