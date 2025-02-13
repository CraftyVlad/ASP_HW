namespace ASP_HW
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public List<string> DisciplineList { get; set; } = new();
    }
}
