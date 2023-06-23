using beckend.DALL.Interfasec.Worckout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace beckend.DALL.Repositories.Worckout
{
    public class PersonalExercise : IPersonalExercise
    {
        public Task<IPersonalExercise> AddRecord(IPersonalExercise record)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IPersonalExercise>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IPersonalExercise> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IPersonalExercise> UpdateRecordById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
