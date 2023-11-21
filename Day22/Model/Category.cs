using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Day22.Model;

public class Category
{
	public long CategoryId { get; set; }
	
	public string CategoryName { get; set; } = null!;
	
	public string Description { get; set; } = null!;
	
	public ICollection<Product> Products { get; set; } = null!;
}
