using beckend.DALL.Interfasec;
using beckend.Domain.Models.Exercises;

namespace beckend.DALL.Repositories
{
    public class EcerciseRepository : IExerciseRepository
    {
        public Task<IEnumerable<Exercise>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Exercise> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Exercise> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exercise>> GetIntlen(int count)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exercise>> GetRange(int start, int end)
        {
            throw new NotImplementedException();
        }
    }
}
