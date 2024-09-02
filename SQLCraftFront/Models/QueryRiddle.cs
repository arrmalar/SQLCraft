namespace SQLCraftFront.Models
{
    public class QueryRiddle
    {
        public int QueryRiddleID {  get; set; }

        public string Title { get; set; }

        public string Difficulty { get; set; }

        public string Question { get; set; }

        public bool IsCompleted { get; set; }

        public string Answer { get; set; }
    }
}
