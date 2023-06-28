namespace Calendar
{
    public class Calendar
    {
       public int Id { get; set; } // ���������� ������������� ���������
        public int UserId { get; set; } // ������������� ������������, � �������� ��������� ���������

        public required User User { get; set; }

        public Calendar(User user)
        {
            User = user;
            UserId = user.Id;
            user.Calendars.Add(this);
        }
    }
}