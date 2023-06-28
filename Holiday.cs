namespace Calendar
{
    public class Holiday
    {
        public int Id { get; set; } // уникальный идентификатор праздника
        public required string Name { get; set; } //  название праздника
        public DateTime Date { get; set; } // дата праздника
    }
}
