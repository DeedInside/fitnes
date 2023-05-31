using beckend.Domain.Models.Exercises;
using beckend.Domain.Models.@enum;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        List<Exercise> listEx = new List<Exercise>();
        Exercise exercise = new Exercise()
        {
            Id = 1,
            shortName = "ShortTest",
            name = "Test",
            description = "Test description",
            groupExercises = groupExercises.competitive,
            groupMuscle = groupMuscle.legs,
            additionalGroupMuscle = new List<groupMuscle>() 
            { 
                groupMuscle.back,
                groupMuscle.legs
            }
        };
        listEx.Add(exercise);
        listEx.Add(exercise);
        using (FileStream fs = new FileStream("Exercise.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<List<Exercise>>(fs, listEx);
            Console.WriteLine("complite");
        }
        using (FileStream fs = new FileStream("Exercise.json", FileMode.Open))
        {
            var notJson = JsonSerializer.Deserialize<List<Exercise>>(fs);
            foreach (var item in notJson)
            {
                if (item.additionalGroupMuscle[0] == exercise.additionalGroupMuscle[0])
                {
                    Console.WriteLine($"find object {item.additionalGroupMuscle[0]}");
                }
                Exercise.print(item);

            }
        }
    }
}