using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.EntityFramework;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfAssignmentDal : EfEntityRepositoryBase<Assignment,ToDoAppContext>, IAssignmentDal
    {
      
    }
}
