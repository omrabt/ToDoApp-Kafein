using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAssignmentService
    {
        IDataResult<List<Assignment>> GetAll(int userId);
        IResult Add(Assignment assignment);
        IResult Update(Assignment assignment);
        IResult Delete(Assignment assignment);
    }
}
