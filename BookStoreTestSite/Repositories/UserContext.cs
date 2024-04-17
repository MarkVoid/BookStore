using BookStore.Entities;
using Microsoft.EntityFrameworkCore;


namespace BookStore.Repositories
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
