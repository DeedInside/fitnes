using beckend.Domain.Models.@enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beckend.Domain.Models.Exercises
{
    /// <summary>
    /// Модель одного дня тренеровки 
    /// </summary>
    public class Workout
    {
        /// <summary>
        /// ID тренировки
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата проведения тренировки
        /// </summary>
        public DateOnly TimeWorkout { get; set; }
        /// <summary>
        /// Дата когда была выполнена тренировка 
        /// </summary>
        public DateOnly ModifiedTimeWorkout { get; set; }
        /// <summary>
        /// Основная прорабатываемая группа мышц 
        /// </summary>
        public groupMuscle MainWork { get; set; }
        /// <summary>
        /// Описание к тренеровке 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Список ID упражнений на тренеровку (id соответствуют мз базы упражнений)
        /// </summary>
        public List<int> ExerciseId { get; set; }
        /// <summary>
        /// список упражнений с выполняемой нагшрузкой 
        /// </summary>
        public List<PersonalExercise> ListPersonalExercise { get; set; }
    }
}
