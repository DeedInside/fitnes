using beckend.Domain.Models.@enum;
namespace beckend.Domain.Models.Exercises
{
    /// <summary>
    /// Описание модели упражнения, для общей базы упражнений
    /// </summary>
    public class Exercise
    {
        public int Id { get; set; }
        public string shortName { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        /// <summary>
        /// Основная задействованная группа мышц
        /// </summary>
        public groupMuscle groupMuscle { get; set; }
        /// <summary>
        /// группа сложности
        /// </summary>
        public groupExercises groupExercises { get; set; }
        /// <summary>
        /// Дополнительные задействованный группы мышц
        /// </summary>
        public List<groupMuscle> additionalGroupMuscle { get; set; }
    }
}
