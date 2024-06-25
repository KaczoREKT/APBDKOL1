namespace Kolokwium1.Models
{
    public class AddClientRequest
    {
        public ClientRequest Client { get; set; }
        public int CarId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }

    public class ClientRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}