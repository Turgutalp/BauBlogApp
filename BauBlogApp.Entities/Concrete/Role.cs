
using System.Collections.Generic;
using BauBlogApp.Shared.Entities.Abstract;

namespace BauBlogApp.Entities.Concrete
{
    public class Role : EntityBase,IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
        
    }
}