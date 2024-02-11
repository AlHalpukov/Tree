using Microsoft.EntityFrameworkCore;
using Tree.Entities;

namespace Tree.Data;

public class TreeDbContext : DbContext
{
    public DbSet<Entities.Tree> Trees { get; set; }

    public DbSet<Node> Nodes { get; set; }


    public TreeDbContext(DbContextOptions<TreeDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Entities.Tree>(entity =>
        {
            entity.HasKey(t => t.Id);
        });

        builder.Entity<Node>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasOne(t => t.Tree)
            .WithMany(x => x.Nodes)
            .HasForeignKey(x => x.TreeId)
            .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
