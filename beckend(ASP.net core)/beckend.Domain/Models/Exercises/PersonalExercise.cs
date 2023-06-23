using beckend.Domain.Models.@enum;

namespace beckend.Domain.Models.Exercises
{
    /// <summary>
    /// Модель упражнения для персональной тренировки 
    /// </summary>
    public class PersonalExercise 
    {
        public PersonalExercise(int id, string? shortName, string name, string? description, double weight, short repetitions, short approaches)
        {
            Id = id;
            this.shortName = shortName;
            this.name = name;
            this.description = description;
            //this.groupMuscle = groupMuscle;
            //this.groupExercises = groupExercises;
            //this.additionalGroupMuscle = additionalGroupMuscle;
            Weight = weight;
            Repetitions = repetitions;
            Approaches = approaches;
        }

        public int Id { get; set; }
        public string? shortName { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public int ExerciseId { get; set; }
        public Exercise exercise { get; set; }
        /// <summary>
        /// Основная задействованная группа мышц
        /// </summary>
        //public groupMuscle groupMuscle { get; set; }
        ///// <summary>
        ///// группа сложности
        ///// </summary>
        //public groupExercises groupExercises { get; set; }
        ///// <summary>
        ///// Дополнительные задействованный группы мышц
        ///// </summary>
        //public List<groupMuscle> additionalGroupMuscle { get; set; }
        /// <summary>
        /// вес на упражнение
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// кол-во выплняемых повторений
        /// </summary>
        public short Repetitions { get; set; }
        /// <summary>
        /// кол-во выполняемых подходов
        /// </summary>
        public short Approaches { get; set;}
    }
}
