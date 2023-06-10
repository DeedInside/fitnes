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
        public static string print(Exercise ex)
        {
            string ret = $"Id = {ex.Id}\n" +
                $"Short name = {ex.shortName}\n" +
                $"Name = {ex.name}\n" +
                $"Description = {ex.description}\n" +
                $"Group muscle = {ex.groupMuscle} \n"+
                $"Group Exercises = {ex.groupExercises} {(int)ex.groupExercises}\n";
            
            foreach(var item in ex.additionalGroupMuscle)
            {
                ret += $"\tadditional group = {item}\n";
            }
            return ret;
        }
    }
}
