using System.ComponentModel.DataAnnotations;

namespace Property_Backend.Model
{
    public class City
    {
        [Required]
        public int cityId { get; set; }
        [Required]
        public string cityName { get; set; }
        [Required]
        public  DateTime createdDate { get; set; }
        [Required]
        public DateTime updatedDate { get; set;}
        [Required]
        public bool isDeleted { get; set; }

    }
}
