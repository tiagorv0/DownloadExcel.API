namespace DownloadExcel.API.Models
{
    public class Audit
    {
        public Audit(int id, string name, string? company, string role, string ipAddress, DateTime dateAndTime, string action)
        {
            Id = id;
            Name = name;
            Company = company;
            Role = role;
            IpAddress = ipAddress;
            DateAndTime = dateAndTime;
            Action = action;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Company { get; set; }
        public string Role { get; set; }
        public string IpAddress { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Action { get; set; }
    }
}
