using System.Threading.Tasks;
using BauBlogApp.Data.Abstract;
using BauBlogApp.Data.Concrete.EntityFramework.Contexts;
using BauBlogApp.Data.Concrete.EntityFramework.Repositories;

namespace BauBlogApp.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BauBlogAppContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        private EfRoleRepository _roleRepository;
        private EfUserRepository _userRepository;
        
        public UnitOfWork(BauBlogAppContext context, EfCommentRepository commentRepository)
        {
            _context = context;
           
        }
        
        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);
        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);
        public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository(_context);
        public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);
        
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}