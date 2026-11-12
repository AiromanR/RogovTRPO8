using RogovTRPO8.Models;

namespace RogovTRPO8.Services
{
    static public class AuthService
    {
        static private readonly RogovDbContext _db = DBService.Instance.Context;

        static public List<User> GetUsersFromDb ()
        {
            return _db.Users.ToList( );
        }
        static public void UserSaveToDb (User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges( );
        }
    }
}
