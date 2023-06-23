using beckend.DALL.Interfasec.Worckout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beckend.DALL.Repositories.Worckout
{
    public class SetWorckout : ISetWorckout
    {
        public Task<ISetWorckout> AddRecord(ISetWorckout record)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ISetWorckout>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ISetWorckout> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ISetWorckout> UpdateRecordById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
