using System.ComponentModel.DataAnnotations;

namespace EVProjectDup.Models
{
    public class Station
    {
        [Key]
        public int CSId { get; set; }

        [Required]
        public string CSEmail { get; set; }

        [Required]
        public string CSPhoneNumber { get; set; }

        [Required]
        public string CSName { get; set; }

        [Required]
        public string CSDescription { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PinCode { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public int NoOfPorts { get; set; }


        public string imagurl { get; set; }

        [Required]
        public string AdressLink { get; set; }

     
        public int Price { get; set; }


        public string status { get; set; }

    }
}
