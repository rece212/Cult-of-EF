using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prjEFExample.Model;

public partial class RwanvigdbContext : DbContext
{
    public RwanvigdbContext()
    {
    }

    public RwanvigdbContext(DbContextOptions<RwanvigdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:rwanvig.database.windows.net,1433;Initial Catalog=rwanvigdb;Persist Security Info=False;User ID=rwanvig;Password=@Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__tblConta__AA2FFB8553909CA4");

            entity.ToTable("tblContacts");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TblContacts)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblContac__Usern__619B8048");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__tblUsers__536C85E5F4DDAC4E");

            entity.ToTable("tblUsers");

            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
