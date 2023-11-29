using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyAPI.Data;
using MyAPI.DTOs;

namespace MyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
//localhost:port/api/Category
public class CategoryController : ControllerBase
{
	private readonly MyDb _db;
	public CategoryController(MyDb database) 
	{
		_db = database;
	}

	[HttpGet]
	//GET : localhost:port/api/category/asdasdasdasd?
	public IActionResult GetAllCategory([FromQuery] bool orderByName = false) 
	{
		List<CategoryDTO> myList = new();
		List<Category> myCategory = _db.Categories.ToList();
		
		foreach(var c in myCategory) 
		{
			myList.Add(new CategoryDTO()
			{
				Id = c.CategoryId,
				Name = c.CategoryName,
				Description = c.Description
			} );
		}
		
		if (orderByName)
		{
			myList = myList.OrderBy(c => c.Name).ToList();
		}
		return Ok(myList);
	}
	
	[HttpGet]
	[Route("{id:int}")]
	//GET : localhost:port/api/category/{id}
	public IActionResult GetCategoryById([FromRoute] int id) 
	{
		var category = _db.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryId == id);
		if(category is null) 
		{
			return NotFound("Category not found");
		}
		return Ok(category);
	}
	
	[HttpGet]
	[Route("name")]
	//GET : localhost:port/api/category/name
	public IActionResult GetCategoryName() 
	{
		IQueryable<string>? category = _db.Categories.Include(c => c.Products).Select(c => c.CategoryName);
		if(category is null) 
		{
			return NotFound("Category not found");
		}
		return Ok(category);
	}
	
	[HttpPost]
	//POST : localhost:port/api/category
	//Body
	public async Task<IActionResult> CreateCategory([FromBody] RequestCategoryDTO inputcategory)  
	{
		var category = new Category()
		{
			CategoryName = inputcategory.Name,
			Description = inputcategory.Description
		};
		await _db.Categories.AddAsync(category);
		int result = await _db.SaveChangesAsync();
		if (result > 0 ) 
		{
			return Ok("Succeed");
		} 
		return BadRequest("Failed. Category already created before");
	}
	
	[HttpPut]
	[Route("{id:int}")]
	public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] RequestCategoryDTO inputcategory) 
	{
		var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
		if(category is null) 
		{
			return NotFound("Category not found");
		}
		
		category.CategoryName = inputcategory.Name;
		category.Description = inputcategory.Description;
				
		int result = await _db.SaveChangesAsync();
		
		return Ok("Update Succeed");
	} 
	
	[HttpDelete]
	[Route("{id:int}")]
	public async Task<IActionResult> DeleteCategory([FromRoute] int id)
	{
		var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
		if(category is null) 
		{
			return NotFound("Category not found");
		}
		
		_db.Categories.Remove(category);
						
		int result = await _db.SaveChangesAsync();
		
		return Ok(category);
		
	}

	
}

