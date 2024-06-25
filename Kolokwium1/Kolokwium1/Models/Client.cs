namespace Kolokwium1.Models;
using System.ComponentModel.DataAnnotations;

public class Client
{
    public int ID { get; set; }
    [StringLength(50)]
    public string FirstName { get; set; }
    [StringLength(100)]
    public string LastName { get; set; }
    [StringLength(100)]
    public string Address { get; set; }

    public ICollection<CarRental> CarRentals { get; set; }
}