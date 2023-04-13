using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AssignmentManager : IAssignmentService
    {
        IAssignmentDal _assignmentDal;
        public AssignmentManager()
        {
            _assignmentDal = new EfAssignmentDal();
        }
        public IResult Add(Assignment assignment)
        {
            _assignmentDal.Add(assignment);
            return new SuccessResult(Messages.AssignmentAdded);
        }

        public IResult Delete(Assignment assignment)
        {
            var assignmentExist = _assignmentDal.Get(p => p.AssignmentId == assignment.AssignmentId);
            if (assignmentExist == null)
            {
                return new ErrorResult(Messages.AssignmentDoesNotExist);
            }
            _assignmentDal.Delete(assignment);
            return new SuccessResult(Messages.AssignmentDeleted);
        }


        public IDataResult<List<Assignment>> GetAll(int userId)
        {   
           return new SuccessDataResult<List<Assignment>>(_assignmentDal.GetAll(p=> p.UserId == userId),Messages.AssignmentListed);
        }

        public IResult Update(Assignment assignment)
        {
            var assignmentExist = _assignmentDal.Get(p => p.AssignmentId == assignment.AssignmentId);
            if (assignmentExist == null)
            {
                return new ErrorResult(Messages.AssignmentDoesNotExist);
            }
            _assignmentDal.Update(assignment);
            return new SuccessResult(Messages.AssignmentUpdated);
        }
    }
}
