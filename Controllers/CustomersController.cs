using Microsoft.AspNetCore.Mvc;
using websitecrud.Data;
using websitecrud.Models;

namespace websitecrud.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }
        [HttpGet]
public IActionResult Create()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Customer customer)
{
    if (ModelState.IsValid)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    return View(customer);
}
public IActionResult Edit(int id)
{
    var customer = _context.Customers.Find(id);

    if (customer == null)
    {
        return NotFound();
    }

    return View(customer);
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(Customer customer)
{
    if (ModelState.IsValid)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    return View(customer);
}
public IActionResult Delete(int id)
{
    var customer = _context.Customers.Find(id);

    if (customer == null)
    {
        return NotFound();
    }

    _context.Customers.Remove(customer);
    _context.SaveChanges();

    return RedirectToAction(nameof(Index));
}
    }
}