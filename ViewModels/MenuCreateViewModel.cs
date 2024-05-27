using hotelcourseworkV2.Models;


namespace hotelcourseworkV2.ViewModels{

    public class MenuCreateViewModel
    {       
            public int Id { get; set; }
            public int HotelId { get; set; }
            public List<int> SelectedDishIds { get; set; }

            public List<Dish> AvailableDishes { get; set; }
    }

}