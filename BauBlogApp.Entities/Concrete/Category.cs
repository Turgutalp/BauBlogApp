using System.Collections.Generic;
using BauBlogApp.Shared.Entities.Abstract;

namespace BauBlogApp.Entities.Concrete
{
    //Category sinifina EB'den turedin IE implemente ediyosun dedik.
    public class Category: EntityBase,IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}