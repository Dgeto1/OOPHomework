using System;
using System.Collections.Generic;

namespace Library
{
	public class Library
	{
		private string name;
		private string address;
		private List<Book> books;

		public string Name { get; set; }
		public string Address { get; set; }

		public Library(string name, string address)
		{
			this.Name = name;
			this.Address = address;
			books = new List<Book>();
		}

		public void ShowAllBooks()
		{
			foreach(var x in books)
			{
				Console.WriteLine(x);
			}
		}

		public List<Book> SearchBooksByAuthor(string author)
		{
			List<Book> booksByAuthor = new List<Book>();
			for(int i=0; i<books.Count; i++)
			{
				if (books[i].Author == author)
				{
					booksByAuthor.Add(books[i]);
				}
			}

			return booksByAuthor;
		}

		public List<Book> SearchBooksByGenre(string genre)
		{
            List<Book> booksByGenre = new List<Book>();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Genre == genre)
                {
                    booksByGenre.Add(books[i]);
                }
            }

            return booksByGenre;
        }

		public void AddBook(Book book)
		{
			if(books.Contains(book))
			{
				Console.WriteLine("We already have this book!");
			}
			else
			{
                books.Add(book);
            }
		}

		public void RemoveBook(Book book)
		{
			if (!books.Contains(book))
			{
				Console.WriteLine("We don't have this book!");
			}
			else
			{
				books.Remove(book);
			}
		}

		public void TakeBook(Book book)
		{
			if(!books.Contains(book) || !book.IsAvailable)
			{
				Console.WriteLine("Sorry, we don't have this book at the moment!");
			}
			else
			{
				book.IsAvailable = false;
				Console.WriteLine("Enjoy reading!");
			}
		}

		public void ReturnBook(Book book)
		{
			if (!books.Contains(book))
			{
				Console.WriteLine("Sorry, this book isn't from our library!");
			}
			else
			{
				book.IsAvailable = true;
				Console.WriteLine("Thank you for returning the book!");
			}
		}
	}
}

