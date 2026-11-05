using Microsoft.IdentityModel.Tokens;
using RogovTRPO8.Models;

namespace RogovTRPO8.Services
{
    //static public class RestaurantService
    //{
    //    static private RogovDbContext _db = DBService.Instance.Context;

    //    static public List<Restaurant> GetAllRest(string? cuisine = null, decimal? minRating = null )
    //    {
    //        var list = _db.Restaurants.ToList( );
    //        if (!cuisine.IsNullOrEmpty( )) list = list.FindAll(m => m.Cuisine == cuisine); ;
    //        if (minRating!=null) list = list.FindAll(m => m.Rating >= minRating);
    //        return list;

    //    }
    //    static public Restaurant? Get(int id)
    //    {
    //        return _db.Restaurants.Find(id);
    //    }
    //    static public bool AddRest(Restaurant restaurant) 
    //    {
    //        if(restaurant.Name.IsNullOrEmpty() || restaurant.Cuisine.IsNullOrEmpty()
    //            || restaurant.Rating < 0 || restaurant.Rating > 5 || restaurant.AverageCheck <= 0) return false;
    //        _db.Add(restaurant);
    //        _db.SaveChanges();
    //        return true;
    //    }
    //    static public bool PutRest(int id, Restaurant restaurant)
    //    {
    //        var restaurantOrig = _db.Restaurants.Find(id);
    //        if (restaurantOrig == null) return false;

    //        if (restaurant.Name.IsNullOrEmpty() || restaurant.Cuisine.IsNullOrEmpty()
    //            || restaurant.Rating < 0 || restaurant.Rating > 5 || restaurant.AverageCheck < 0) return false;
    //        if (restaurant.AverageCheck <= 0) return false;

    //        restaurantOrig.Name = restaurant.Name;
    //        restaurantOrig.Cuisine = restaurant.Cuisine;
    //        restaurantOrig.Rating = restaurant.Rating;
    //        restaurantOrig.AverageCheck = restaurant.AverageCheck;
    //        restaurantOrig.IsOpen = restaurant.IsOpen;

    //        _db.SaveChanges();
    //        return true;
    //    }
    //    static public bool PatchRest (int id, RestaurantDTO restaurant)
    //    {
    //        if (restaurant == null) return false;

    //        var restaurantOrig = _db.Restaurants.Find(id);
    //        if (restaurantOrig == null) return false;

    //        if (!restaurant.Name.IsNullOrEmpty( )) restaurantOrig.Name = restaurant.Name;
    //        if (!restaurant.Cuisine.IsNullOrEmpty( )) restaurantOrig.Cuisine = restaurant.Cuisine;
    //        if (restaurant.Rating != null && restaurant.Rating >= 0 && restaurant.Rating <= 5) restaurantOrig.Rating = (decimal)restaurant.Rating;
    //        if (restaurant.AverageCheck != null && restaurant.AverageCheck > 0) restaurantOrig.AverageCheck = (decimal)restaurant.AverageCheck;
    //        if (restaurant.IsOpen != null) restaurantOrig.IsOpen = (bool)restaurant.IsOpen;

    //        _db.SaveChanges( );
    //        return true;
    //    }
    //    static public bool DeleteRest (int id)
    //    {
    //        var restForDel = _db.Restaurants.Find(id);
    //        if (restForDel == null) return false;
    //        _db.Restaurants.Remove(restForDel);
    //        _db.SaveChanges( );
    //        return true;
    //    }
    //}
}