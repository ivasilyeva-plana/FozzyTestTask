using FozzyTestTask.Extensions;
using FozzyTestTask.Models;
using FozzyTestTask.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FozzyTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfFirstElements = 5;
            var numberOfLastElements = 3;

            List<EmployeeModel> listFromFile;
            try
            {
                listFromFile = JsonConvert.DeserializeObject<List<EmployeeModel>>(File.ReadAllText(Settings.Default.InputFilePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}{Environment.NewLine}");
                Console.ReadKey();
                throw;
            }
            
            var employeeList = listFromFile?.ToEmployee()
                .OrderByDescending(i => i.Salary())
                .ThenBy(i => i.Specialist.Name).ToList();


            var consoleChar = string.Empty;

            while (consoleChar != "q")
            {
                var help = $"Press some next key for action: {Environment.NewLine}" +
                           $"'a' - all employees; {Environment.NewLine}" +
                           $"'b' - {numberOfFirstElements} names from general list; {Environment.NewLine}" +
                           $"'c' - {numberOfLastElements} last employee ids; {Environment.NewLine}" +
                           $"'d' - save employees collection to file; {Environment.NewLine}" +
                           $"'q' - exit {Environment.NewLine}";

                Console.WriteLine(help);

                consoleChar = Console.ReadLine();

                switch (consoleChar)
                {
                    case "a":
                        var listA = employeeList?.Select(i => 
                            $" \t{i.Specialist.Id} \t{i.Specialist.Name} \t{i.Salary()}");
                        ToConsole(listA);
                        break;
                    case "b":
                        var listB = employeeList?.Take(numberOfFirstElements).Select(i => $"\t{i.Specialist.Name}");
                        ToConsole(listB);
                        break;
                    case "c":
                        var listC = employeeList?.Skip(employeeList.Count - numberOfLastElements)
                            .Select(i => $" \t{i.Specialist.Id}");
                        ToConsole(listC);
                        break;
                    case "d":
                        var listD = employeeList?.Select(i => 
                            new {i.Specialist.Id, i.Specialist.Name, Salary = i.Salary()} );
                        try
                        {
                            File.WriteAllText(Settings.Default.OutputFilePath, JsonConvert.SerializeObject(listD));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"The information wasn't written to file:{Environment.NewLine}" +
                                              $"{ex.Message}{Environment.NewLine}");
                            break;
                        }
                        Console.WriteLine($"File {Settings.Default.OutputFilePath} was created.{Environment.NewLine}");
                        break;
                }


            }

        }

        private static void ToConsole(IEnumerable<string> list)
        {
            if (list == null)
            {
                Console.WriteLine($"No records was found!{Environment.NewLine}");
                return;
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
