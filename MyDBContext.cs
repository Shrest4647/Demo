using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class MyDBContext : DbContext
{
    public DbSet<Book>? Books { get; set; }
    public DbSet<Author>? Authors { get; set; }

    public string DbPath { get; }

    public MyDBContext(DbContextOptions<MyDBContext> options): base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "publication_database.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // // // special "local" folder for your platform.
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDBContext).Assembly);
    }
}

