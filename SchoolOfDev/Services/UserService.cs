 using Microsoft.EntityFrameworkCore;
using SchoolOfDev.Entities;
using SchoolOfDev.Helpers;

namespace SchoolOfDev.Services
{
    public interface IUserService
    {
        public Task<User> Create(User user);
        public Task<User> GetById(int id);
        public Task<List<User>> GetAll();
        public Task Update(User userIn, int id);
        public Task Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context) {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            User userDb = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.UserName == user.UserName);

            if(userDb is not null)
            {
                throw new Exception($"Usuário {user.UserName} já cadastro no sistema.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Delete(int id)
        {
            User userDb = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (userDb is null)
            {
                throw new Exception("Usuário não localizado em nosso banco de dados.");
            }

            _context.Users.Remove(userDb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
           User userDb = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (userDb is null)
            {
                throw new Exception("Usuário não localizado em nosso banco de dados.");
            }

            return userDb;
        }

        public async Task Update(User userIn, int id)
        {

            if (userIn.Id != id)
            {
                throw new Exception("ID da rota é diferente do ID do usuário.");
            }

            User userDb = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

            if (userDb is null)
            {
                throw new Exception("Usuário não localizado em nosso banco de dados.");
            }

            _context.Entry(userIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
