namespace SchoolOfDev.DTO.Note
{
    public class NoteRequest
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Decimal Value { get; set; }
    }
}
