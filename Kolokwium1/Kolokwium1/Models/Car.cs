namespace Kolokwium1.Models;
using System.ComponentModel.DataAnnotations;

public class Car
{
    public int ID { get; set; }
    [StringLength(17)]
    public string VIN { get; set; }
    [StringLength(100)]
    public string Name { get; set; }
    public int Seats { get; set; }
    public int PricePerDay { get; set; }
    public int ModelID { get; set; }
    public int ColorID { get; set; }

    public Model Model { get; set; }
    public Color Color { get; set; }
}