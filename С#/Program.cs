using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Tasks activeTasks = new Tasks();
            Tasks completedTasks = new Tasks();
            
            bool t = true;
            Console.Write("   Введите /help для списка команд \n");
            while (t)
            {
                string[] activeInput = Console.ReadLine().Split(' ');
                string key = activeInput[0];
                switch (key)
                {
                    case "/save":
                        Actions.Saving(activeTasks, completedTasks, activeInput);
                        break;

                    case "/load":
                        activeTasks = new Tasks();
                        completedTasks = new Tasks();
                        Actions.Loading(activeTasks, completedTasks, activeInput);
                        break;
                    
                    case "/add":
                        Actions.Adding(activeTasks, activeInput);
                        break;
                    
                    case "/all":
                        Actions.AllOut(activeTasks, completedTasks);
                        break;
                    
                    case "/completed":
                        Actions.CompletedOut(completedTasks);
                        break;
                    
                    case "/complete":
                        Actions.Completing(activeTasks, completedTasks, activeInput);
                        break;
                    
                    case "/delete":
                        Actions.Deleting(activeTasks, completedTasks, activeInput);
                        break;
                    
                    case "/help":
                        Actions.Helping();
                        break;
                    
                    case "/clean":
                        activeTasks = new Tasks();
                        completedTasks = new Tasks();
                        break;
                    
                    case "/end":
                        t = false;
                        break;
                    
                    default:
                        Console.Write("   Такой команды не существует \n");
                        break;    
                }
            }
        }
    }
}