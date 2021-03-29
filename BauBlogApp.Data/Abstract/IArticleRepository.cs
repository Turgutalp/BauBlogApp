using BauBlogApp.Entities.Concrete;
using BauBlogApp.Shared.Data.Abstract;

namespace BauBlogApp.Data.Abstract
{
    public interface IArticleRepository : IEntityRepository<Article>
    {
        
    }
}