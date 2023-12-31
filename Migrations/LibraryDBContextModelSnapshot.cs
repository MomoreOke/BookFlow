﻿// <auto-generated />
using System;
using LibraryManagement.Data.LibraryDBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagement.Migrations
{
    [DbContext(typeof(LibraryDBContext))]
    partial class LibraryDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryManagement.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Author_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Author_Name");

                    b.HasKey("AuthorId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("AuthorId"), false);

                    b.ToTable("Author", "dbo");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Book_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("Author_Id");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Book_Name");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("Genre_Id");

                    b.Property<string>("LoanedCopies")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Loaned_Copies");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int")
                        .HasColumnName("Number_of_pages");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int")
                        .HasColumnName("Publisher_Id");

                    b.Property<int>("TotalCopies")
                        .HasColumnType("int")
                        .HasColumnName("Total_Copies");

                    b.HasKey("BookId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("BookId"), false);

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Book", "dbo");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.BookReservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReservationID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<int?>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_Id");

                    b.Property<DateTime>("ExpectedAvailabilityDate")
                        .HasColumnType("date")
                        .HasColumnName("Expected_Availability_Date");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    b.HasKey("ReservationId")
                        .HasName("PK_Book_Reservation");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ReservationId"), false);

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("BookReservation", "dbo");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Genre_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Genre_Name");

                    b.HasKey("GenreId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("GenreId"), false);

                    b.ToTable("Genre", "dbo");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Loan", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Loan_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanId"), 1L, 1);

                    b.Property<int?>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_Id");

                    b.Property<DateTime?>("LoanDate")
                        .HasColumnType("date")
                        .HasColumnName("Loan_Date");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("date")
                        .HasColumnName("Return_Date");

                    b.Property<string>("ReturnStatus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Return_Status");

                    b.HasKey("LoanId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("LoanId"), false);

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("Loan", "dbo");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("User_Address");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("User_Email");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("User_PhoneNumber");

                    b.HasKey("MemberId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("MemberId"), false);

                    b.ToTable("Member", "dbo");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Publisher_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"), 1L, 1);

                    b.Property<string>("PublusherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Publusher_Name");

                    b.HasKey("PublisherId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("PublisherId"), false);

                    b.ToTable("Publisher", "dbo");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Review_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<int?>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_Id");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    b.Property<string>("ReviewDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Review_Description");

                    b.Property<int?>("ReviewScore")
                        .HasColumnType("int")
                        .HasColumnName("Review_Score");

                    b.HasKey("ReviewId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ReviewId"), false);

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("Review", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("LoginProvider"), false);

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleId", "UserId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("RoleId", "UserId"), false);

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginProvider");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("LoginProvider"), false);

                    b.HasIndex("UserId");

                    b.ToTable("UserTokens", "dbo");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Book", b =>
                {
                    b.HasOne("LibraryManagement.Data.LibraryDBContext.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("FK_Author_Book");

                    b.HasOne("LibraryManagement.Data.LibraryDBContext.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .IsRequired()
                        .HasConstraintName("FK_Genre_Book");

                    b.HasOne("LibraryManagement.Data.LibraryDBContext.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .IsRequired()
                        .HasConstraintName("FK_Publisher_Book");

                    b.Navigation("Author");

                    b.Navigation("Genre");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.BookReservation", b =>
                {
                    b.HasOne("LibraryManagement.Data.LibraryDBContext.Book", "Book")
                        .WithMany("BookReservations")
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_Book_BookReservation");

                    b.HasOne("LibraryManagement.Data.LibraryDBContext.Member", "Member")
                        .WithMany("BookReservations")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_Member_BookReservation");

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Loan", b =>
                {
                    b.HasOne("LibraryManagement.Data.LibraryDBContext.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_Book_Loan");

                    b.HasOne("LibraryManagement.Data.LibraryDBContext.Member", "Member")
                        .WithMany("Loans")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_Member_Loan");

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Review", b =>
                {
                    b.HasOne("LibraryManagement.Data.LibraryDBContext.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_Book_Review");

                    b.HasOne("LibraryManagement.Data.LibraryDBContext.Member", "Member")
                        .WithMany("Reviews")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_Member_Review");

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LibraryManagement.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LibraryManagement.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LibraryManagement.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Book", b =>
                {
                    b.Navigation("BookReservations");

                    b.Navigation("Loans");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Member", b =>
                {
                    b.Navigation("BookReservations");

                    b.Navigation("Loans");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("LibraryManagement.Data.LibraryDBContext.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
