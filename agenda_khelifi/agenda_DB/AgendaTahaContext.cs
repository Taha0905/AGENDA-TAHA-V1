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

    public virtual DbSet<Réseauxsociaux> Réseauxsociauxes { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Todolist> Todolists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=agenda_taha", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contacte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contactes");

            entity.Property(e => e.Id).HasColumnName("ID");
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

            entity.HasIndex(e => e.RéseauxSociauxIdRéseauxSociaux, "fk_Profil_Reseau_RéseauxSociaux1_idx");

            entity.Property(e => e.IdProfilReseau).HasColumnName("idProfil_Reseau");
            entity.Property(e => e.ContactesId).HasColumnName("Contactes_ID");
            entity.Property(e => e.Pseudo).HasMaxLength(45);
            entity.Property(e => e.RéseauxSociauxIdRéseauxSociaux).HasColumnName("RéseauxSociaux_id réseaux_sociaux");

            entity.HasOne(d => d.Contactes).WithMany(p => p.ProfilReseaus)
                .HasForeignKey(d => d.ContactesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Profil_Reseau_Contactes");

            entity.HasOne(d => d.RéseauxSociauxIdRéseauxSociauxNavigation).WithMany(p => p.ProfilReseaus)
                .HasForeignKey(d => d.RéseauxSociauxIdRéseauxSociaux)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Profil_Reseau_RéseauxSociaux1");
        });

        modelBuilder.Entity<Réseauxsociaux>(entity =>
        {
            entity.HasKey(e => e.IdRéseauxSociaux).HasName("PRIMARY");

            entity.ToTable("réseauxsociaux");

            entity.Property(e => e.IdRéseauxSociaux).HasColumnName("id réseaux_sociaux");
            entity.Property(e => e.Nom).HasMaxLength(45);
            entity.Property(e => e.Url).HasMaxLength(45);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PRIMARY");

            entity.ToTable("task");

            entity.HasIndex(e => e.ToDoListIdlist, "fk_Task_ToDoList1_idx");

            entity.Property(e => e.IdTask).HasColumnName("idTask");
            entity.Property(e => e.TaskDescription)
                .HasColumnType("text")
                .HasColumnName("Task_description");
            entity.Property(e => e.TaskName)
                .HasMaxLength(45)
                .HasColumnName("Task_name");
            entity.Property(e => e.ToDoListIdlist).HasColumnName("ToDoList_idlist");

            entity.HasOne(d => d.ToDoListIdlistNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ToDoListIdlist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Task_ToDoList1");
        });

        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.HasKey(e => e.Idlist).HasName("PRIMARY");

            entity.ToTable("todolist");

            entity.Property(e => e.Idlist)
                .ValueGeneratedNever()
                .HasColumnName("idlist");
            entity.Property(e => e.DateCreation).HasColumnName("date_creation");
            entity.Property(e => e.DateFin).HasColumnName("date_fin");
            entity.Property(e => e.ListName)
                .HasMaxLength(45)
                .HasColumnName("list_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
