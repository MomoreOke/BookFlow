using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryManagement.Data.LibraryDBContext
{
    public partial class LibraryDBContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryDBContext()
        {
        }

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookReservation> BookReservations { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<OverdueBook> OverdueBooks { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MOMORE-SPACE\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            //copy this code here
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable(name: "Users");
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId })
                   .IsClustered(false);
                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => e.LoginProvider)
                   .IsClustered(false);
                entity.ToTable("UserLogins");

            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => e.LoginProvider)
                   .IsClustered(false);
                entity.ToTable("UserTokens");
            });

            //ends here

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.AuthorId)
                    .IsClustered(false);

                entity.ToTable("Author");

                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Author_Name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .IsClustered(false);

                entity.ToTable("Book");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Book_Name");

                entity.Property(e => e.GenreId).HasColumnName("Genre_Id");

                entity.Property(e => e.LoanedCopies)
                    .HasMaxLength(10)
                    .HasColumnName("Loaned_Copies");

                entity.Property(e => e.NumberOfPages).HasColumnName("Number_of_pages");

                entity.Property(e => e.PublisherId).HasColumnName("Publisher_Id");

                entity.Property(e => e.TotalCopies).HasColumnName("Total_Copies");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Author_Book");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genre_Book");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publisher_Book");
            });

            modelBuilder.Entity<BookReservation>(entity =>
            {
                entity.HasKey(e => e.ReservationId)
                    .HasName("PK_Book_Reservation")
                    .IsClustered(false);

                entity.ToTable("BookReservation");

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.ExpectedAvailabilityDate)
                    .HasColumnType("date")
                    .HasColumnName("Expected_Availability_Date");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookReservations)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_Book_BookReservation");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.BookReservations)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Member_BookReservation");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .IsClustered(false);

                entity.ToTable("Genre");

                entity.Property(e => e.GenreId).HasColumnName("Genre_Id");

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Genre_Name");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.LoanId)
                    .IsClustered(false);

                entity.ToTable("Loan");

                entity.Property(e => e.LoanId).HasColumnName("Loan_Id");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.LoanDate)
                    .HasColumnType("date")
                    .HasColumnName("Loan_Date");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("date")
                    .HasColumnName("Return_Date");

                entity.Property(e => e.ReturnStatus)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Return_Status");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_Book_Loan");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Member_Loan");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .IsClustered(false);

                entity.ToTable("Member");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.UserAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("User_Address");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("User_PhoneNumber");
            });

            modelBuilder.Entity<OverdueBook>(entity =>
            {
                entity.HasKey(e => e.OverdueBookId)
                    .HasName("PK15")
                    .IsClustered(false);

                entity.ToTable("OverdueBook");

                entity.Property(e => e.OverdueBookId).HasColumnName("OverdueBook_Id");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.BorrowerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FineAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OverdueBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefBook17");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.OverdueBooks)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefMember16");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.PublisherId)
                    .IsClustered(false);

                entity.ToTable("Publisher");

                entity.Property(e => e.PublisherId).HasColumnName("Publisher_Id");

                entity.Property(e => e.PublusherName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Publusher_Name");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .IsClustered(false);

                entity.ToTable("Review");

                entity.Property(e => e.ReviewId).HasColumnName("Review_ID");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.ReviewDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Review_Description");

                entity.Property(e => e.ReviewScore).HasColumnName("Review_Score");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_Book_Review");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Member_Review");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
