using AutoMapper;
using SchoolOfDev.DTO.Note;
using SchoolOfDev.Entities;

namespace SchoolOfDev.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteRequest>();
            CreateMap<Note, NoteResponse>();

            CreateMap<NoteRequest, Note>();
            CreateMap<NoteResponse, Note>();
        }
    }
}
