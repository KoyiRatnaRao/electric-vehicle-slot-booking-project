using System.ComponentModel.DataAnnotations;

namespace EVProjectDup.Models
{
    public class Booking
    {
        [Key]
        public int BId { get; set; }

        [Required]
        public int CSId { get; set; }

        [Required]
        public int PortNumber { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public string VehicleName { get; set; }

        [Required]
        public string VehicleNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }

}
