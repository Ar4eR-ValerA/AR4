using System;

namespace ConsoleApplication1
{
    public static class Actions
    {
        public static void Saving(Tasks activeTasks, Tasks completedTasks, string[] activeInput)
        {
            try
            {
                activeTasks.Save(activeInput[1], false);
                completedTasks.Save(activeInput[1], true);
            }
            catch (Exception e)
            {
                Console.WriteLine("   " + e.Message);
            }
        }

        public static void Loading(Tasks activeTasks, Tasks completedTasks, string[] activeInput)
        {
            try
            {
                activeTasks.Load(activeInput[1], false);
                completedTasks.Load(activeInput[1], true);
            }
            catch (Exception e)
            {
                Console.WriteLine("   " + e.Message + "\n");
                Console.WriteLine("   Возможно файл содержит лишние переходы на следующую строку");
            }
        }

        public static void Adding(Tasks activeTasks, string[] activeInput)
        {
            try
            {
                string id = activeInput[1], nameOfTask = activeInput[2], info = "";
                for (int i = 3; i < activeInput.Length; i++)
                {
                    info = info + activeInput[i];
                }

                activeTasks.Add(new Task(id, nameOfTask, info));
            }
            catch (Exception e)
            {
                Console.WriteLine("   Неверный формат ввода");
            }
        }

        public static void AllOut(Tasks activeTasks, Tasks completedTasks)
        {
            if (activeTasks.arr.Count > 0)
            {
                Console.Write("**---------------Невыполненные задачи-------------**\n");
                activeTasks.All();
                Console.Write("**------------------------------------------------**\n");
            }

            if (completedTasks.arr.Count > 0)
            {
                Console.Write("**----------------Выполненные задачи--------------**\n");
                completedTasks.All();
                Console.Write("**------------------------------------------------**\n");
            }

            if (completedTasks.arr.Count == 0 && activeTasks.arr.Count == 0)
            {
                Console.Write("   Задач нет\n");
            }
        }

        public static void CompletedOut(Tasks completedTasks)
        {
            if (completedTasks.arr.Count > 0)
            {
                Console.Write("**----------------Выполненные задачи--------------**\n");
                completedTasks.All();
                Console.Write("**------------------------------------------------**\n");
            }
            else
            {
                Console.Write("   Нет выполненных задач\n");
            }
        }

        public static void Completing(Tasks activeTasks, Tasks completedTasks, string[] activeInput)
        {
            string completeKey = activeInput[1];
            foreach (Task i in activeTasks.arr)
            {
                if (i.id == completeKey)
                {
                    completedTasks.Add(new Task(i, true));
                    activeTasks.arr.Remove(i);
                    break;
                }
            }
        }

        public static void Deleting(Tasks activeTasks, Tasks completedTasks, string[] activeInput)
        {
            string deleteKey = activeInput[1];
            foreach (Task i in activeTasks.arr)
            {
                if (i.id == deleteKey)
                {
                    activeTasks.arr.Remove(i);
                    break;
                }
            }
            foreach (Task i in completedTasks.arr)
            {
                if (i.id == deleteKey)
                {
                    completedTasks.arr.Remove(i);
                    break;
                }
            }
        }
        

        public static void Helping()
        {
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
        }
    }
}