namespace Kolokwium1.Models;
using System.ComponentModel.DataAnnotations;

public class Color
{
    public int ID { get; set; }
    [StringLength(100)]
    public string Name { get; set; }
}