using SQLite;

namespace Pomodoro_Technique_Android.Backend
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }
}
