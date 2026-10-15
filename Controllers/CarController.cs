using Microsoft.AspNetCore.Mvc;
using HW_BSEF24M016.Models;

namespace HW_BSEF24M016.Controllers
{
    public class CarController : Controller
    {
        private static List<Car> availableCars = new List<Car> { new Car { Id = 1, Name = "Alto", PricePerDay = 3000m }, new Car { Id = 2, Name = "Corolla", PricePerDay = 6000m }, new Car { Id = 3, Name = "Civic", PricePerDay = 8000m } };
        private static List<Car> bookedCars = new List<Car>();

        [HttpGet]
        public IActionResult Index()
        {

            return View(availableCars);
        }
        [HttpPost]
        public IActionResult Book(int id)
        {
            Car ?car = availableCars.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return RedirectToAction("Index");
            }

            availableCars.Remove(car);
            bookedCars.Add(car);

            return RedirectToAction("Booked");
        }
        [HttpGet]
        public IActionResult Booked()
        {

            return View(bookedCars);
        }

    }
}
