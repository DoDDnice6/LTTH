namespace QLTVMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }

        public virtual DbSet<BOOK> BOOKs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<PUBLISHING> PUBLISHINGs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BOOK>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PUBLISHING>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<PUBLISHING>()
                .HasMany(e => e.BOOKs)
                .WithOptional(e => e.PUBLISHING)
                .HasForeignKey(e => e.PublishID);
        }
    }
}
