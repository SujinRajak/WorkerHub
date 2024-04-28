using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerHub.Domain.Entities
{
    public class UserAcademic
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string Qualification { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Graduated { get; set; }
        public string Addressname { get; set; }
        public string Description { get; set; }

    }
}
