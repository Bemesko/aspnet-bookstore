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
}