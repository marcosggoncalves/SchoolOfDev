using Microsoft.EntityFrameworkCore;
using SchoolOfDev.Entities;
using SchoolOfDev.Helpers;

namespace SchoolOfDev.Services
{
    public interface INoteService
    {
        public Task<Note> Create(Note Note);
        public Task<Note> GetById(int id);
        public Task<List<Note>> GetAll();
        public Task Update(Note NoteIn, int id);
        public Task Delete(int id);
    }

    public class NoteService : INoteService
    {
        private readonly DataContext _context;

        public NoteService(DataContext context)
        {
            _context = context;
        }

        public async Task<Note> Create(Note Note)
        {
            _context.Notes.Add(Note);
            await _context.SaveChangesAsync();

            return Note;
        }

        public async Task Delete(int id)
        {
            Note noteDb = await _context.Notes.SingleOrDefaultAsync(u => u.Id == id);

            if (noteDb is null)
            {
                throw new Exception("Curso não localizado em nosso banco de dados.");
            }

            _context.Notes.Remove(noteDb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAll()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note> GetById(int id)
        {
            Note noteDb = await _context.Notes.SingleOrDefaultAsync(u => u.Id == id);

            if (noteDb is null)
            {
                throw new Exception("Curso não localizado em nosso banco de dados.");
            }

            return noteDb;
        }

        public async Task Update(Note NoteIn, int id)
        {

            if (NoteIn.Id != id)
            {
                throw new Exception("ID da rota é diferente do ID do curso.");
            }

            Note noteDb = await _context.Notes.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

            if (noteDb is null)
            {
                throw new Exception("Curso não localizado em nosso banco de dados.");
            }

            _context.Entry(NoteIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}