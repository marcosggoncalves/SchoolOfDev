using Microsoft.EntityFrameworkCore;
using SchoolOfDev.Entities;
using SchoolOfDev.Exceptions;
using SchoolOfDev.Helpers;

namespace SchoolOfDev.Services
{
    public interface ICourseService
    {
        public Task<Course> Create(Course Course);
        public Task<Course> GetById(int id);
        public Task<List<Course>> GetAll();
        public Task Update(Course CourseIn, int id);
        public Task Delete(int id);
    }

    public class CourseService : ICourseService
    {
        private readonly DataContext _context;

        public CourseService(DataContext context)
        {
            _context = context;
        }

        public async Task<Course> Create(Course Course)
        {
            Course courseDb = await _context.Courses.AsNoTracking().SingleOrDefaultAsync(u => u.Name == Course.Name);

            if (courseDb is not null)
            {
                throw new KeyNotFoundException($"Curso {Course.Name} já cadastro no sistema.");
            }

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return Course;
        }

        public async Task Delete(int id)
        {
            Course courseDb = await _context.Courses.SingleOrDefaultAsync(u => u.Id == id);

            if (courseDb is null)
            {
                throw new KeyNotFoundException("Curso não localizado em nosso banco de dados.");
            }

            _context.Courses.Remove(courseDb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetById(int id)
        {
            Course courseDb = await _context.Courses.SingleOrDefaultAsync(u => u.Id == id);

            if (courseDb is null)
            {
                throw new BadRequestException("Curso não localizado em nosso banco de dados.");
            }

            return courseDb;
        }

        public async Task Update(Course CourseIn, int id)
        {

            if (CourseIn.Id != id)
            {
                throw new BadRequestException("ID da rota é diferente do ID do curso.");
            }

            Course courseDb = await _context.Courses.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

            if (courseDb is null)
            {
                throw new KeyNotFoundException("Curso não localizado em nosso banco de dados.");
            }

            CourseIn.CreatedAt = courseDb.CreatedAt;

            _context.Entry(CourseIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}