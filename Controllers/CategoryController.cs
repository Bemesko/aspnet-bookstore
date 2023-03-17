using BookStore.Data;
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
        var objectCategoryList = _database.Categories.ToList();
        return View();
    }
}