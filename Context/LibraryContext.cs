using Microsoft.EntityFrameworkCore;
using Library_CRUD.Models;
namespace Library_CRUD.Context;

public class LibraryContext : DbContext
{
    public DbSet<Author> Authors {get;set;}
    public DbSet<Book> Books {get;set;}
    public DbSet<Borrow> Borrows {get;set;}

    public LibraryContext(DbContextOptions<LibraryContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(author => {
            author.ToTable("authors");
            author.HasKey(p => p.AuthorId).HasName("author_id");
            author.Property(p => p.Name).HasColumnName("name");
            author.Property(p => p.LastName).HasColumnName("last_name");
            author.Property(p => p.BirthDate).HasColumnName("birth_date");
            author.Property(p => p.CreationDate).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("creation_date");
            author.Property(p => p.UpdateDate).ValueGeneratedOnUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("update_date");
        });
        modelBuilder.Entity<Book>(book => {
            book.ToTable("books");
            book.HasKey(p => p.BookId).HasName("book_id");
            book.Property(p => p.Title).HasColumnName("title");
            book.Property(p => p.ISBN);
            book.HasOne(p => p.Author).WithMany(p => p.Book).HasForeignKey(p => p.AuthorId).HasConstraintName("book_author");
            book.Property(p => p.CreationDate).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("creation_date");
            book.Property(p => p.UpdateDate).ValueGeneratedOnUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("update_date");
        });
        modelBuilder.Entity<Borrow>(borrow => {
            borrow.ToTable("borrows");
            borrow.HasKey(p => p.BorrowId).HasName("borrow_id");
            borrow.Property(p => p.BorrowDate).HasColumnName("borrow_date").IsRequired();
            borrow.Property(p => p.ReturnDate).HasColumnName("return_date").IsRequired();
            borrow.HasMany(p => p.Books).WithMany(p => p.Borrows).UsingEntity<BorrowsBooks>(
                j => j
                     .HasOne(p => p.Book)
                     .WithMany(p => p.BorrowsBooks)
                     .HasForeignKey(p => p.BookId)
                     .IsRequired(),
                j => j
                     .HasOne(p => p.Borrow)
                     .WithMany(p => p.BorrowsBooks)
                     .HasForeignKey(p => p.BorrowId)
                     .IsRequired()
            );
            borrow.Property(p => p.CreationDate).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("creation_date");
            borrow.Property(p => p.UpdateDate).ValueGeneratedOnUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("update_date");
        });
    }
}