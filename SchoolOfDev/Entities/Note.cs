using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolOfDev.Entities
{
    public class Note : BaseEntity
    {
        [ForeignKey("User")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int  CourseId { get; set; }
        public Decimal Value { get; set; }
        public virtual User Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
