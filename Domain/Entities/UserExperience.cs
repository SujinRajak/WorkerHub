namespace Domain.Entities
{
    public class UserExperience
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string Sector { get; set; }
        public string Position { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string WorkPlace { get; set; }
        public string Addressname { get; set; }
        public string Description { get; set; }
        public int yearsExp { get; set; }
    }
}
