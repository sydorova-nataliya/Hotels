using System.ComponentModel.DataAnnotations;
using hotelcourseworkV2.Models;


namespace hotelcourseworkV2.ViewModels{

    public class DishCreateViewModel
    {    
        public int DishId {get;set;}   

        [Required]
        [MaxLength(30)]
        [Display(Name = "Назва")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Рецепт")]
        public string Recipe { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Значення повино бути більше нуля")]
        [Display(Name = "Вага")]
        public int Weight { get; set; }

        [Required]
        [MaxLength(2)]
        [Display(Name = "Кількість")]
        public string Unit { get; set; }

        [Required]
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }

        [Display(Name = "Інгрідієнти")]
        public List<int> SelectedIngredients { get; set; }

        public List<Ingredient> AvailableIngredients { get; set; }
    }

}