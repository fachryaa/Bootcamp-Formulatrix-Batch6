using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day22.Model;

public class Product
{
	public long ProductId { get; set; }
	public long CategoryId { get; set; }	
	public string ProductName { get; set; }	= null!;
	public int Cost { get; set; }
	public virtual Category? Category { get; set; }
}
