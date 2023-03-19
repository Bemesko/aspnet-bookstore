using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _database;

    public CategoryController(ApplicationDbContext database)
    {
        _database = database;
    }
    public IActionResult Index()
    {
        IEnumerable<Category> objectCategoryList = _database.Categories.OrderBy(category => category.DisplayOrder);
        return View(objectCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("DisplayOrder", "The Display Order cannot exactly match the name.");
        }
        if (!ModelState.IsValid)
        {
            return View(obj);
        }

        _database.Categories.Add(obj);
        _database.SaveChanges();

        // will look for the Index action in the same controller, controller name can be optionally defined
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var retrievedCategory = _database.Categories.Find(id);

        if (retrievedCategory == null)
        {
            return NotFound();
        }

        return View(retrievedCategory);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("DisplayOrder", "The Display Order cannot exactly match the name.");
        }
        if (!ModelState.IsValid)
        {
            return View(obj);
        }

        _database.Categories.Update(obj);
        _database.SaveChanges();

        // will look for the Index action in the same controller, controller name can be optionally defined
        return RedirectToAction("Index");
    }
}