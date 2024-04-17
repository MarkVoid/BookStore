using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class BooksRepository
    {
        private readonly UserContext _options;

        public BooksRepository(UserContext options)
        {
            _options = options;
        }
        public Book GetById(int id)
        {
            return _options.Books.Where(i => i.BookId == id).FirstOrDefault();
        }
        public List<Book> GetAll(int UserId)
        {
            return _options.Books.Where(i => i.UserId == UserId).ToList();

        }

        public void Delete(int id)
        {
            Book item = _options.Books.Where(i => i.BookId == id).FirstOrDefault();
            _options.Books.Remove(item);
            _options.SaveChanges();

        }

        public void Insert(Book item)
        {
            _options.Books.Add(item);
            _options.SaveChanges();


        }
        public void Update(Book item)
        {
            _options.Entry(item).State = EntityState.Modified;
            _options.SaveChanges();
        }
    }
}
