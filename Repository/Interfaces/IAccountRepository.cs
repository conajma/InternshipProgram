using Labs.Waters.API.Models;

namespace Labs.Waters.API.Repository.Interfaces
{
    public interface IAccountRepository
    {
        public Task<string> LoginUser(Login login);
    }
}
