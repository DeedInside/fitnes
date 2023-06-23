using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beckend.Domain.Models.Exercises
{
    public class SetWorckout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Список тренировок
        /// </summary>
        public List<int> WorkoutId { get; set; }
        public List<Workout> ListWorkout { get; set; }
    }
}
