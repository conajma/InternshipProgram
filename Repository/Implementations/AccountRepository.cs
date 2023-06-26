using Labs.Waters.API.Data;
using Labs.Waters.API.Models;
using Labs.Waters.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labs.Waters.API.Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly LabsDbContext labsDbContext;

        public AccountRepository(LabsDbContext labsDbContext)
        {
            this.labsDbContext = labsDbContext;
        }
        public async Task<string> LoginUser(Login login)
        {
            var user = await labsDbContext.Register.FirstOrDefaultAsync(f => f.Email == login.Email);
            if(user == null)
            {
                return "NotFound";
            }
            if (user.Email == login.Email && user.Password == login.Password)
            {
                return login.Email;
            }
            else
            {
                return "Unauthorized";
            }
        }

    }
}
