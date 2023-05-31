using beckend.Domain.Models.@enum;
namespace beckend.Domain.Models.Exercises
{
    public class Exercise
    {
        public int Id { get; set; }
        public string shortName { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public groupMuscle groupMuscle { get; set; }
        public groupExercises groupExercises { get; set; }
        public List<groupMuscle> additionalGroupMuscle { get; set; }


        public static void print(Exercise ex)
        {
            Console.WriteLine($"Id = {ex.Id}");
            Console.WriteLine($"Short name = {ex.shortName}");
            Console.WriteLine($"Name = {ex.name}");
            Console.WriteLine($"Description = {ex.description}");
            Console.WriteLine($"Group muscle = {ex.groupMuscle}");
            Console.WriteLine($"Group Exercises = {ex.groupExercises} {(int)ex.groupExercises}");
            foreach(var item in ex.additionalGroupMuscle)
            {
                Console.WriteLine($"\tadditional group = {item}");
            }
        }
    }
}
