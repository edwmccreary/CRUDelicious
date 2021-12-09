using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishID {get;set;}
        [Required(ErrorMessage = "Your dish must have a name")]
        //[MinLength(2,ErrorMessage = "Your dish name must be atleast 2 characters")]
        public string Name {get;set;}
        [Required(ErrorMessage = "You must enter a Chef name")]
        //[MinLength(2,ErrorMessage = "Your Chef name must be atleast 2 characters")]
        public string Chef {get;set;}
        [Required(ErrorMessage = "You must rate the tastiness of your dish")]
        //[Range(1,5,ErrorMessage = "Tastiness value must be between 1 and 5")]
        public int Tastiness {get;set;}
        [Required(ErrorMessage = "You must specify the number of calories for your dish")]
        //[Range(0, int.MaxValue, ErrorMessage = "Calories must be more than 0")]
        public int Calories {get;set;}
        [Required(ErrorMessage = "Your dish must have a description")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}