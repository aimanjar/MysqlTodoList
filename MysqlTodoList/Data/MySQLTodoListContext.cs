using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySQLTodoList.Models;

namespace MySQLTodoList.Data
{
    public partial class MySQLTodoListContext : DbContext
    {
        public MySQLTodoListContext()
        {
        }

        public MySQLTodoListContext(DbContextOptions<MySQLTodoListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TodoTable> TodoTables { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TodoTable>(entity =>
            {
                entity.ToTable("todo_table");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.StatusActivity)
                    .HasMaxLength(255)
                    .HasColumnName("Status_Activity");

                entity.Property(e => e.Task).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
