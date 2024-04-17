using BookStore.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class ContactsRepository
    {
        private readonly UserContext _options;

        public ContactsRepository(UserContext options)
        {
            _options = options;
        }
        public Contact GetById(int id)
        {
            return _options.Contacts.Where(i => i.ContactId == id).FirstOrDefault();
        }
        public List<Contact> GetAll(int UserId)
        {
            return _options.Contacts.Where(i => i.UserId == UserId).ToList();

        }
        public void Delete(int id)
        {
            Contact item = _options.Contacts.Where(i => i.ContactId == id).FirstOrDefault();
            _options.Contacts.Remove(item);
            _options.SaveChanges();

        }
        public void Insert(Contact item)
        {
            _options.Contacts.Add(item);
            _options.SaveChanges();

        }
        public void Update(Contact item)
        {
            _options.Entry(item).State = EntityState.Modified;
            _options.SaveChanges();
        }
    }
}
