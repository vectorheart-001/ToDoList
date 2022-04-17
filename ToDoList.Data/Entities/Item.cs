namespace ToDoList.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public DateTime DueDateTime { get; set; }
        public bool IsDone { get; set; }
    }
}
