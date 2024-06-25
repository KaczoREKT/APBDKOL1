﻿namespace Kolokwium1.Models;
using System.ComponentModel.DataAnnotations;

public class CarRental
{
    public int ID { get; set; }
    public int ClientID { get; set; }
    public int CarID { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int TotalPrice { get; set; }
    public int Discount { get; set; }

    public Client Client { get; set; }
    public Car Car { get; set; }
}