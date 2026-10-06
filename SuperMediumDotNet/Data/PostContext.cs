using Microsoft.EntityFrameworkCore;

namespace SuperMediumDotNet.Data;

public class PostContext(DbContextOptions<PostContext> options) : DbContext(options)
{
}