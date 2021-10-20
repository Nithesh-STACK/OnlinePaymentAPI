using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OnlinePaymentAPI.KaniniModel
{
    public partial class stationaryContext : DbContext
    {
        public stationaryContext()
        {
        }

        public stationaryContext(DbContextOptions<stationaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddCart> AddCarts { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Employe> Employes { get; set; }
        public virtual DbSet<Logintabl> Logintabls { get; set; }
        public virtual DbSet<Logintbl> Logintbls { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<Sbaccount> Sbaccounts { get; set; }
        public virtual DbSet<Sbtransaction> Sbtransactions { get; set; }
        public virtual DbSet<ShipmentDetail> ShipmentDetails { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-486\\SQLSERVER2019G3;Database=stationary;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AddCart>(entity =>
            {
                entity.ToTable("AddCart");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo).IsUnicode(false);

                entity.Property(e => e.PlotDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Photo)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.PlotDescription).IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Employe>(entity =>
            {
                entity.ToTable("employe");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Dept)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("dept");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Logintabl>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("Logintabl");

                entity.Property(e => e.LoginId)
                    .HasMaxLength(50)
                    .HasColumnName("Login id");

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Logintbl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("logintbl");

                entity.Property(e => e.Userid)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasKey(e => e.CvvPin)
                    .HasName("PK__PaymentD__B940F7F1F563307B");

                entity.Property(e => e.CvvPin)
                    .ValueGeneratedNever()
                    .HasColumnName("Cvv_Pin");

                entity.Property(e => e.CardHolderName)
                    .IsUnicode(false)
                    .HasColumnName("Card_Holder_Name");

                entity.Property(e => e.DebitCardNumber).HasColumnName("Debit_Card_Number");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("Expiry_Date");
            });

            modelBuilder.Entity<Sbaccount>(entity =>
            {
                entity.HasKey(e => e.Accno)
                    .HasName("PK__sbaccoun__A472931D0464BD0B");

                entity.ToTable("sbaccount");

                entity.Property(e => e.Accno)
                    .ValueGeneratedNever()
                    .HasColumnName("accno");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Custaddress)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("custaddress");

                entity.Property(e => e.Custname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("custname");

                entity.Property(e => e.Transtype)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("transtype");
            });

            modelBuilder.Entity<Sbtransaction>(entity =>
            {
                entity.HasKey(e => e.Transid)
                    .HasName("PK__sbtransa__DB1F6ABF10070997");

                entity.ToTable("sbtransaction");

                entity.Property(e => e.Transid).HasColumnName("transid");

                entity.Property(e => e.Accno).HasColumnName("accno");

                entity.Property(e => e.Amt).HasColumnName("amt");

                entity.Property(e => e.Transactdate)
                    .HasColumnType("datetime")
                    .HasColumnName("transactdate");

                entity.Property(e => e.Transtype)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("transtype");

                entity.HasOne(d => d.AccnoNavigation)
                    .WithMany(p => p.Sbtransactions)
                    .HasForeignKey(d => d.Accno)
                    .HasConstraintName("FK__sbtransac__accno__619B8048");
            });

            modelBuilder.Entity<ShipmentDetail>(entity =>
            {
                entity.HasKey(e => e.MobileNumber)
                    .HasName("PK__Shipment__C892EBD78C24F66C");

                entity.Property(e => e.MobileNumber).HasColumnName("Mobile_Number");

                entity.Property(e => e.AddressDetails)
                    .HasMaxLength(700)
                    .IsUnicode(false)
                    .HasColumnName("Address_Details");

                entity.Property(e => e.BuyersName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Buyers_Name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("students");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
