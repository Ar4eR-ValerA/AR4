using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ConsoleApplication1
{
    public class Task
    {
        public string id, Name, Info;
        public bool Check = false;

        public Task(string i, string N, string In)
        {
            id = i;
            Name = N;
            Info = In;
        }
        
        public Task(string i, string N, string In, bool Ch)
        {
            id = i;
            Name = N;
            Info = In;
            Check = true;
        }
        
        public Task(Task t, bool Ch)
        {
            id = t.id;
            Name = t.Name;
            Info = t.Info;
            Check = true;
        }
    }


    public class Tasks
    {
        public List<Task> arr;

        public Tasks()
        {
            arr = new List<Task>();
        }
        public void add(Task a)
        {
            arr.Add(a);
        }

        public void all()
        {
            foreach (Task a in arr)
            {
                Console.Write("   " + a.id + " " + a.Name + " " + a.Info + "\n");
            }
        }


        public void save(string NameOfWriteFile, bool check)
        {
        //    DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Output");
        //    if (!dirInfo.Exists)
        //    {
        //        dirInfo.Create();
        //    }
            using (StreamWriter sw = new StreamWriter($@"{NameOfWriteFile}", check, System.Text.Encoding.Default))
            {
                foreach (Task temp in arr)
                {
                    string compl = "Невыполнена";
                    if (check)
                    {
                        compl = "Выполнена";
                    }
                    sw.WriteLine(compl + " " + temp.id + " " + temp.Name + " " + temp.Info);
                }
            }
        }

        public void load(string NameOfReadFile, bool check)
        {
            string[] TaskFromFile;
            using (StreamReader sr = new StreamReader($@"{NameOfReadFile}"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        TaskFromFile = line.Split(' ');
                        if ((TaskFromFile[0] == "Выполнена") == check)
                        {

                            string NewId = TaskFromFile[1], NewNameOfTask = TaskFromFile[2], NewInfo = "";
                            for (int i = 3; i < TaskFromFile.Length; i++)
                            {
                                NewInfo = NewInfo + " " + TaskFromFile[i];
                            }
                            

                            arr.Add(new Task(NewId, NewNameOfTask, NewInfo, check));
                        }
                    }
                }
        }
    }
    
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool t = true;
            Console.Write("   Введите /help для списка команд \n");
            Tasks ActiveTasks = new Tasks();
            Tasks CompletedTasks = new Tasks();
            while (t)
            {

                string[] ActiveInput = Console.ReadLine().Split(' ');
                string key = ActiveInput[0];
                switch (key)
                {
                    case "/save":
                        try
                        {
                            ActiveTasks.save(ActiveInput[1], false);
                            CompletedTasks.save(ActiveInput[1], true);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    
                    
                    case "/load":
                        ActiveTasks = new Tasks();
                        CompletedTasks = new Tasks();
                        try
                        {
                            ActiveTasks.load(ActiveInput[1], false);
                            CompletedTasks.load(ActiveInput[1], true);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + "\n");
                            Console.WriteLine("   Возможно файл содержит лишние переходы на следующую строку");
                        }
                        break;

                    
                    case "/add":
                        try
                        {
                            string id = ActiveInput[1], NameOfTask = ActiveInput[2], Info = "";
                            for (int i = 3; i < ActiveInput.Length; i++)
                            {
                                Info = Info + ActiveInput[i];
                            }

                            ActiveTasks.add(new Task(id, NameOfTask, Info));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("   Неверный формат ввода");
                        }
                        break;
                    
                    
                    case "/all":
                        if (ActiveTasks.arr.Count > 0)
                        {
                            Console.Write("**---------------Невыполненные задачи-------------**\n");
                            ActiveTasks.all();
                            Console.Write("**------------------------------------------------**\n");
                        }

                        if (CompletedTasks.arr.Count > 0)
                        {
                            Console.Write("**----------------Выполненные задачи--------------**\n");
                            CompletedTasks.all();
                            Console.Write("**------------------------------------------------**\n");
                        }

                        if (CompletedTasks.arr.Count == 0 && ActiveTasks.arr.Count == 0)
                        {
                            Console.Write("   Задач нет\n");
                        }
                        break;
                    
                    case "/completed":
                        if (CompletedTasks.arr.Count > 0)
                        {
                            Console.Write("**----------------Выполненные задачи--------------**\n");
                            CompletedTasks.all();
                            Console.Write("**------------------------------------------------**\n");
                        }
                        else
                        {
                            Console.Write("   Нет выполненных задач\n");
                        }
                        break;
                    
                    
                    case "/complete":
                        string CompleteKey = ActiveInput[1];
                        foreach (Task i in ActiveTasks.arr)
                        {
                            if (i.id == CompleteKey)
                            {
                                CompletedTasks.add(new Task(i, true));
                                ActiveTasks.arr.Remove(i);
                                break;
                            }
                        }
                        break;
                        
                    
                    case "/delete":
                        string DeleteKey = ActiveInput[1];
                        foreach (Task i in ActiveTasks.arr)
                        {
                            if (i.id == DeleteKey)
                            {
                                ActiveTasks.arr.Remove(i);
                                break;
                            }
                        }
                        foreach (Task i in CompletedTasks.arr)
                        {
                            if (i.id == DeleteKey)
                            {
                                CompletedTasks.arr.Remove(i);
                                break;
                            }
                        }
                        break;
                        
                    
                    case "/clean":
                        ActiveTasks = new Tasks();
                        break;
                    
                    
                    case "/end":
                        t = false;
                        break;
                    
                    
                    case "/help":
                        Console.Write("**-------------------------------------------------------------------**\n");
                        Console.Write("   /save *путь до файла*           Записывает все задачи в файл \n");
                        Console.Write("   /load *путь до файла*           Загружает все задачи из файла\n");
                        Console.Write("   /add *id* *название* *описание* Добавляет новую задачу\n");
                        Console.Write("   /all                            Выводит все задачи \n");
                        Console.Write("   /completed                      Выводит все выполненные задачи \n");
                        Console.Write("   /complete *id*                  Делает задачу выполненной \n");
                        Console.Write("   /delete *id*                    Удаляет задачу \n");
                        Console.Write("   /clean                          Удаляет все задачи \n");
                        Console.Write("   /end                            Завершает программу \n");
                        Console.Write("**-------------------------------------------------------------------**\n");
                        break;
                        
                    
                    default:
                        Console.Write("   Такой команды не существует \n");
                        break;    
                }
            }
        }
    }
}