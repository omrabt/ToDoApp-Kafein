using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfUserDal : EfEntityRepositoryBase<User, ToDoAppContext>, IUserDal
    {
    
    }
}
