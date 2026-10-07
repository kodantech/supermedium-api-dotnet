using Microsoft.EntityFrameworkCore;
using SuperMediumDotNet.Models;

namespace SuperMediumDotNet.Data;

public class SuperMediumContext(DbContextOptions<SuperMediumContext> options) : DbContext(options)
{
    public DbSet<Post> Posts => Set<Post>();

    public DbSet<Tag> Tags => Set<Tag>();
}