using Labs.Waters.API.Models;

namespace Labs.Waters.API.Repository.Interfaces
{
    public interface IRegisterRepository
    {
        /// <summary>
        /// Get All Registered User
        /// </summary>
        /// <returns></returns>
        public Task<List<Register>> GetAllRegisteredUsers();
        /// <summary>
        /// Get Registered User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Register> GetRegisteredUserById(int id);

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public Task<Register> RegisterUser(Register register);
        /// <summary>
        /// Delete Registered User
        /// </summary>
        /// <param name="id"></param>
        public Task DeleteRegisteredUser(int id);
    }
}
