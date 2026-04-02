using Microsoft.EntityFrameworkCore;

namespace TPLOCAL1.Data;

public class FormContext : DbContext
{
    public FormContext(DbContextOptions<FormContext> options)
        : base(options)
    {
    }

    public DbSet<TPLOCAL1.Models.Form> Form { get; set; } = default!;
}
