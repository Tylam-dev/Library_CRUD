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
            author.Property(p => p.AuthorId).HasColumnName("author_id");
            author.Property(p => p.Name).HasColumnName("name").IsRequired().HasMaxLength(20);
            author.Property(p => p.LastName).HasColumnName("last_name").IsRequired().HasMaxLength(20);
            author.Property(p => p.BirthDate).HasColumnName("birth_date").IsRequired();
            author.Property(p => p.CreationDate).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("creation_date");
            author.Property(p => p.UpdateDate).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("update_date");
        });
        modelBuilder.Entity<Book>(book => {
            book.ToTable("books");
            book.HasKey(p => p.BookId).HasName("book_id");
            book.Property(p => p.AuthorId).HasColumnName("author_id");
            book.Property(p => p.Title).HasColumnName("title").IsRequired();
            book.Property(p => p.PublicationDate).IsRequired();
            book.Property(p => p.ISBN).IsRequired();
            book.HasOne(p => p.Author).WithMany(p => p.Book).HasForeignKey(p => p.AuthorId).HasConstraintName("book_author").IsRequired();
            book.Property(p => p.CreationDate).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("creation_date");
            book.Property(p => p.UpdateDate).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("update_date");
        });
        modelBuilder.Entity<Borrow>(borrow => {
            borrow.ToTable("borrows");
            borrow.HasKey(p => p.BorrowId).HasName("borrow_id");
            borrow.Property(p => p.BorrowId).HasColumnName("borrow_id");
            borrow.Property(p => p.BorrowDate).HasColumnName("borrow_date").IsRequired();
            borrow.Property(p => p.ReturnDate).HasColumnName("return_date").IsRequired(false);
            borrow.HasMany(p => p.Books).WithMany(p => p.Borrows).UsingEntity<BorrowsBooks>(p => p.ToTable("borrows_books"));
            borrow.Property(p => p.CreationDate).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("creation_date");
            borrow.Property(p => p.UpdateDate).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("update_date");
        });
    }
}