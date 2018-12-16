using demo2.Domain.AggregatesModel;
using demo2.Domain.AggregatesModel.ImageStore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace demo2.Infrastructure.Data
{
    public class Demo2DbContext :  IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public Demo2DbContext(DbContextOptions<Demo2DbContext> options)
           : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ImageStore> ImageStore { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostTag>()
            .HasKey(t => new { t.PostId, t.TagId });

            builder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);

            builder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId);

            builder.Entity<User>().ToTable("Core_User");
            builder.Entity<Role>().ToTable("Core_Role");
            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.HasKey(uc => uc.Id);
                b.ToTable("Core_UserClaim");
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.HasKey(rc => rc.Id);
                b.ToTable("Core_RoleClaim");
            });

            builder.Entity<UserRole>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.RoleId });
                b.HasOne(ur => ur.Role).WithMany(x => x.Users).HasForeignKey(r => r.RoleId);
                b.HasOne(ur => ur.User).WithMany(x => x.Roles).HasForeignKey(u => u.UserId);
                b.ToTable("Core_UserRole");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("Core_UserLogin");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("Core_UserToken");
            });
            
        }

    }
}
