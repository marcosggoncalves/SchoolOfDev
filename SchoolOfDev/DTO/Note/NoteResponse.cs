namespace SchoolOfDev.DTO.Note
{
    public class NoteResponse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Entities.User Student { get; set; }
        public virtual Entities.Course Course { get; set; }
    }
}
