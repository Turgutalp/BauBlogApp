using System;

namespace BauBlogApp.Shared.Entities.Abstract
{
    // Base degerlerin diger siniflarda degisiklige ugramasi soz konusu olabilir.
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime  CreatedDate { get; set; } = DateTime.Now; // ovveride CreatedDate = new DateTime(2021/01/01);
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now; // ovver ModifiedDate = new DateTime()
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool  IsActive { get; set; } = true;

        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";

        public virtual string Note { get; set; }

    }
}