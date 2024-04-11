using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace agenda_khelifi.agenda_DB;

public partial class AgendaTahaContext : DbContext
{
    public AgendaTahaContext()
    {
    }

    public AgendaTahaContext(DbContextOptions<AgendaTahaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contacte> Contactes { get; set; }

    public virtual DbSet<ProfilReseau> ProfilReseaus { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Todolist> Todolists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=172.31.254.84;port=3306;user=taha;password=123;database=agenda_taha;allowpublickeyretrieval=True", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.23-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contacte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contactes");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Adresse).HasMaxLength(45);
            entity.Property(e => e.CodePostal).HasMaxLength(45);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Nom).HasMaxLength(45);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Prenom).HasMaxLength(45);
            entity.Property(e => e.Status).HasColumnType("enum('Amis','Famille','Collègue')");
            entity.Property(e => e.Ville).HasMaxLength(45);
        });

        modelBuilder.Entity<ProfilReseau>(entity =>
        {
            entity.HasKey(e => e.IdProfilReseau).HasName("PRIMARY");

            entity.ToTable("profil_reseau");

            entity.HasIndex(e => e.ContactesId, "fk_Profil_Reseau_Contactes_idx");

            entity.Property(e => e.IdProfilReseau)
                .HasColumnType("int(11)")
                .HasColumnName("idProfil_Reseau");
            entity.Property(e => e.ContactesId)
                .HasColumnType("int(11)")
                .HasColumnName("Contactes_ID");
            entity.Property(e => e.NomDansReseaux)
                .HasMaxLength(45)
                .HasColumnName("Nom_dans_reseaux");
            entity.Property(e => e.NomReseaux)
                .HasMaxLength(45)
                .HasColumnName("Nom_reseaux");
            entity.Property(e => e.Url)
                .HasMaxLength(45)
                .HasColumnName("URL");

            entity.HasOne(d => d.Contactes).WithMany(p => p.ProfilReseaus)
                .HasForeignKey(d => d.ContactesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Profil_Reseau_Contactes");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PRIMARY");

            entity.ToTable("task");

            entity.Property(e => e.IdTask)
                .HasColumnType("int(11)")
                .HasColumnName("idTask");
            entity.Property(e => e.DateDebut).HasColumnName("Date_debut");
            entity.Property(e => e.DateFin).HasColumnName("Date_fin");
            entity.Property(e => e.TaskDescription)
                .HasColumnType("text")
                .HasColumnName("Task_description");
            entity.Property(e => e.TaskName)
                .HasMaxLength(45)
                .HasColumnName("Task_name");
        });

        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("todolist");

            entity.HasIndex(e => e.TaskIdTask, "fk_todolist_task1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.ListName)
                .HasMaxLength(45)
                .HasColumnName("list_name");
            entity.Property(e => e.Status)
                .HasColumnType("enum('Fini','En cours')")
                .HasColumnName("status");
            entity.Property(e => e.TaskIdTask)
                .HasColumnType("int(11)")
                .HasColumnName("task_idTask");

            entity.HasOne(d => d.TaskIdTaskNavigation).WithMany(p => p.Todolists)
                .HasForeignKey(d => d.TaskIdTask)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_todolist_task1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
