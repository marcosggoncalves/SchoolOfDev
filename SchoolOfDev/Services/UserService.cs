using Microsoft.EntityFrameworkCore;
using SchoolOfDev.Entities;
using SchoolOfDev.Exceptions;
using SchoolOfDev.Helpers;
using BC = BCrypt.Net.BCrypt;

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

            if (!user.Password.Equals(user.ConfirmPassword)) {
                throw new BadRequestException("Senhas não conferem.");
            }

            User userDb = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.UserName == user.UserName);

            if(userDb is not null)
            {
                throw new BadRequestException($"Usuário {user.UserName} já cadastro no sistema.");
            }

            user.Password = BC.HashPassword(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Delete(int id)
        {
            User userDb = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (userDb is null)
            {
                throw new KeyNotFoundException("Usuário não localizado em nosso banco de dados.");
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
                throw new KeyNotFoundException("Usuário não localizado em nosso banco de dados.");
            }

            return userDb;
        }

        public async Task Update(User userIn, int id)
        {

            if (userIn.Id != id)
            {
                throw new BadRequestException("ID da rota é diferente do ID do usuário.");
            }else if (!userIn.Password.Equals(userIn.ConfirmPassword))
            {
                throw new BadRequestException("Senhas não conferem.");
            }

            User userDb = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

            if (userDb is null)
            {
                throw new KeyNotFoundException("Usuário não localizado em nosso banco de dados.");
            }
            else if (!BC.Verify(userIn.CurrentPassword, userDb.Password))
            {
                throw new BadRequestException("Senha atual incorreta, não foi possivel alterar senha.");
            }

            userIn.CreatedAt = userDb.CreatedAt;
            userIn.Password = BC.HashPassword(userIn.Password);

            _context.Entry(userIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
