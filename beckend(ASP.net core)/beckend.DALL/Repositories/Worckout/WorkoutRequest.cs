using beckend.Domain.Models.Exercises;
using beckend.DALL.Interfasec.Worckout;
using Microsoft.EntityFrameworkCore;

namespace beckend.DALL.Repositories.Worckout
{
    public class WorkoutRequest : IWorkout
    {
        public async Task<bool> AddRecord(Workout record)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (record != null)
                    {
                        await db.AddAsync(record);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Workout>> GetAll()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var ret = await db.workoutsDb.ToListAsync();
                    if (ret != null)
                    {
                        return ret;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Workout> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRecordById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
