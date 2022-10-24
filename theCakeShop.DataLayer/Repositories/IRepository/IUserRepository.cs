using theCakeShop.DataLayer.Database;

namespace theCakeShop.DataLayer.Repositories.IRepository
{
    public class IUserRepository : IEntityRepository<User>
    {
        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public User Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> FilterGetDAll(Func<User, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public User Get(Func<User, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<User> GetDAll()
        {
            throw new NotImplementedException();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
