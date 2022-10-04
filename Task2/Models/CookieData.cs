using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class CookieData
    {
        [Required]
        [Display(Name = "Value For Cookie")]
        [StringLength(15)]
        public string Value { get; set; }

        [Required]
        [Display(Name = "Date For Cookie")]
        public DateTime Date { get; set; }
    }
}
