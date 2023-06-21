using Labs.Waters.API.Data;
using Labs.Waters.API.Models;
using Labs.Waters.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labs.Waters.API.Repository.Implementations
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly LabsDbContext labsDbContext;

        public RegisterRepository(LabsDbContext labsDbContext)
        {
            this.labsDbContext = labsDbContext;
        }
        public async Task<List<Register>>  GetAllRegisteredUsers()
        {
            var users = await labsDbContext.Register.ToListAsync();
            return users;
        }

        public async Task<Register> GetRegisteredUserById(int id)
        {
            var user = await labsDbContext.Register.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<Register> RegisterUser(Register register)
        {
            labsDbContext.Register.Add(register);
            await labsDbContext.SaveChangesAsync();
            return register;
        }

        public async Task DeleteRegisteredUser(int id)
        {
            var user = await labsDbContext.Register.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                labsDbContext.Remove(user);
                await labsDbContext.SaveChangesAsync();
            }
        }
    }
}
