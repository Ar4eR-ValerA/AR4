using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1
{
    public class Tasks
    {
        public List<Task> arr;

        public Tasks()
        {
            arr = new List<Task>();
        }

        public void Add(Task a)
        {
            arr.Add(a);
        }

        public void All()
        {
            foreach (Task a in arr)
            {
                Console.Write("   " + a.id + " " + a.name + " " + a.info + "\n");
            }
        }


        public void Save(string nameOfWriteFile, bool check)
        {
            using (StreamWriter sw = new StreamWriter($@"{nameOfWriteFile}", check, System.Text.Encoding.Default))
            {
                foreach (Task temp in arr)
                {
                    string status = temp.check.ToString();
                    sw.WriteLine(status + " " + temp.id + " " + temp.name + " " + temp.info);
                }
            }
        }

        public void Load(string nameOfReadFile, bool check)
        {
            using (StreamReader sr = new StreamReader($@"{nameOfReadFile}"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] taskFromFile = line.Split(' ');
                    if ((taskFromFile[0] == "True") != check)
                        continue;
                    string newId = taskFromFile[1], newNameOfTask = taskFromFile[2], newInfo = "";
                    for (int i = 3; i < taskFromFile.Length; i++)
                    {
                            newInfo = newInfo + " " + taskFromFile[i]; 
                    }
                    arr.Add(new Task(newId, newNameOfTask, newInfo, check));
                }
            }
        }
    }
}