﻿using exercise.webapi.Data;
using exercise.webapi.DTO;
using exercise.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.webapi.Repository
{
    public class BookRepository: IBookRepository
    {
        DataContext _db;
        
        public BookRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _db.Books.Include(b => b.Author).ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _db.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> AddBook(Book book)
        {
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _db.Books.Update(book);
            await _db.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var target = await _db.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
            if (target == null) return false;
            _db.Books.Remove(target);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
