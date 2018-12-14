using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Book.Models
{
    public partial class Book04Context : DbContext
    {
        public Book04Context()
        {
        }

        public Book04Context(DbContextOptions<Book04Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TableBook> TableBook { get; set; }
        public virtual DbSet<TableCustomer> TableCustomer { get; set; }
        public virtual DbSet<TableDetail> TableDetail { get; set; }
        public virtual DbSet<TableOrder> TableOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-RSEVAK5\\SQLEXPRESS;Initial Catalog=Book04;Integrated Security=True");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableBook>(entity =>
            {
                entity.HasKey(e => e.Idbook);

                entity.ToTable("Table_Book");

                entity.Property(e => e.Idbook).HasColumnName("IDBook");

                entity.Property(e => e.DetailBook).IsUnicode(false);

                entity.Property(e => e.NameBook)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PictureBook).HasColumnType("image");
            });

            modelBuilder.Entity<TableCustomer>(entity =>
            {
                entity.HasKey(e => e.Idcus);

                entity.ToTable("Table_Customer");

                entity.Property(e => e.Idcus).HasColumnName("IDCus");

                entity.Property(e => e.Idcard)
                    .HasColumnName("IDcard")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.NameCus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PictureCus).HasColumnType("image");

                entity.Property(e => e.Tel)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TableDetail>(entity =>
            {
                entity.HasKey(e => e.Iddetail);

                entity.ToTable("Table_Detail");

                entity.Property(e => e.Iddetail).HasColumnName("IDDetail");

                entity.Property(e => e.Idbook).HasColumnName("IDBook");

                entity.Property(e => e.Idorder).HasColumnName("IDOrder");

                entity.Property(e => e.Numbook)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNum)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdbookNavigation)
                    .WithMany(p => p.TableDetail)
                    .HasForeignKey(d => d.Idbook)
                    .HasConstraintName("FK_Table_Detail_Table_Book");

                entity.HasOne(d => d.IdorderNavigation)
                    .WithMany(p => p.TableDetail)
                    .HasForeignKey(d => d.Idorder)
                    .HasConstraintName("FK_Table_Detail_Table_Order");
            });

            modelBuilder.Entity<TableOrder>(entity =>
            {
                entity.HasKey(e => e.Idorder);

                entity.ToTable("Table_Order");

                entity.Property(e => e.Idorder).HasColumnName("IDOrder");

                entity.Property(e => e.DateOrder)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Idcus).HasColumnName("IDCus");

                entity.HasOne(d => d.IdcusNavigation)
                    .WithMany(p => p.TableOrder)
                    .HasForeignKey(d => d.Idcus)
                    .HasConstraintName("FK_Table_Order_Table_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
