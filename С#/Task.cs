namespace ConsoleApplication1
{
    public class Task
    {
        public string id, name, info;
        public bool check = false;
        
        
        public Task(string activeId, string activeName, string activeInfo)
        {
            id = activeId;
            name = activeName;
            info = activeInfo;
        }
        
        public Task(string activeId, string activeName, string activeInfo, bool activeCheck)
        {
            id = activeId;
            name = activeName;
            info = activeInfo;
            check = activeCheck;
        }
        
        public Task(Task activeTask, bool activeCheck)
        {
            id = activeTask.id;
            name = activeTask.name;
            info = activeTask.info;
            check = activeCheck;
        }
    }
}