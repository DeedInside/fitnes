using beckend.Domain.Models.Exercises;
using beckend.Domain.Models.@enum;
using System.Text.Json;
using beckend.Domain.Models;
using System.Diagnostics;

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


        string stringConnect = "C:\\Users\\loy4f\\OneDrive\\Рабочий стол\\fitnes\\beckend(ASP.net core)\\beckend.Domain\\Data\\Exercise.json";

        string filePath = System.IO.Path.GetFullPath("Exercise.json");

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        using (FileStream fs = new FileStream(stringConnect, FileMode.OpenOrCreate))
        {
            var notJson = JsonSerializer.Deserialize<List<Exercise>>(fs);
            File.WriteAllText(stringConnect, string.Empty);
            notJson.Add(exercise);
            //StreamWriter sw = new StreamWriter(fs);

            JsonSerializer.Serialize<List<Exercise>>(fs, notJson, options);
            
            Console.WriteLine("complite, path: " + stringConnect);
        }
        
        using (FileStream fs = new FileStream(stringConnect, FileMode.Open))
        {
            var notJson = JsonSerializer.Deserialize<List<Exercise>>(fs);
            foreach (var item in notJson)
            {
                if (item.additionalGroupMuscle[0] == exercise.additionalGroupMuscle[0])
                {
                    Console.WriteLine($"find object {item.additionalGroupMuscle[0]}");
                }
                Console.WriteLine(Exercise.print(item));

            }
        }
    }
}