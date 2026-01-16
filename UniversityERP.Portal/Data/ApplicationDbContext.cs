using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UniversityERP.Portal.Models;

namespace UniversityERP.Portal.Data;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<School> Schools => Set<School>();
}
