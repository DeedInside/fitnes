using beckend.Domain.Models.Exercises;
using beckend.Domain.Models.@enum;
using System.Text.Json;
using beckend.Domain.Models;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        //PersonalExercise perExercices = new PersonalExercise(1,"ShortName","Name","description",groupMuscle.back,groupExercises.competitive,new List<groupMuscle>(),100,10,5);
        //PersonalExercise perExercices2 = new PersonalExercise(2, "ShortName2", "Name2", "description2", groupMuscle.back, groupExercises.competitive, new List<groupMuscle>() 
        //{ 
        //    groupMuscle.back,
        //    groupMuscle.hands
        //}, 200, 20, 50);


        //List <PersonalExercise> listPErs = new List<PersonalExercise>();

        //listPErs.Add(perExercices);
        //listPErs.Add(perExercices2);

        //Workout work = new Workout()
        //{
        //    Id = 1,
        //    MainWork = groupMuscle.back,
        //    Description = "workout back",
        //    //Exercise = new List<int>() { 1,2},
        //    //PersonalExercise = listPErs

        //};


        string stringConnect = "C:\\Users\\loy4f\\OneDrive\\Рабочий стол\\fitnes\\beckend(ASP.net core)\\beckend.Domain\\Data\\Workout.json";

        string filePath = System.IO.Path.GetFullPath("Exercise.json");

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        using (FileStream fs = new FileStream(stringConnect, FileMode.OpenOrCreate))
        {
            //var notJson = JsonSerializer.Deserialize<List<Exercise>>(fs);
            //File.WriteAllText(stringConnect, string.Empty);
            //notJson.Add(exercise);
            //StreamWriter sw = new StreamWriter(fs);

           // JsonSerializer.Serialize<Workout>(fs, work, options);
            
            Console.WriteLine("complite, path: " + stringConnect);
        }
        
        //using (FileStream fs = new FileStream(stringConnect, FileMode.Open))
        //{
        //    var notJson = JsonSerializer.Deserialize<List<Exercise>>(fs);
        //    foreach (var item in notJson)
        //    {
        //        if (item.additionalGroupMuscle[0] == exercise.additionalGroupMuscle[0])
        //        {
        //            Console.WriteLine($"find object {item.additionalGroupMuscle[0]}");
        //        }
        //        Console.WriteLine(Exercise.print(item));

        //    }
        //}
    }
}