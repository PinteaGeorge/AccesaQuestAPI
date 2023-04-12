using AccesaQuestAPI.Context;
using AccesaQuestAPI.Models;
using AccesaQuestAPI.Models.ViewModels;

namespace AccesaQuestAPI.Repositories
{
    public class UserRepository
    {
        private readonly ContextDb _context;
        public UserRepository(ContextDb contextDb)
        {
            _context = contextDb;
        }
        public Task<User> FindAsync(int userId)
        {
            return _context.Users
                .FindAsync(userId)
                .AsTask();
        }
    }
}
