using System;
using System.Collections.Generic;

namespace Library
{
	public class Library
	{
		private string name;
		private string address;
		private List<Book> books;

		public string Name
		{
			get
			{
                if (String.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Name can't be null or empty!");
                }
				return name;
            }
			set
			{
                name = value;
            }
		}
		public string Address
		{
			get
			{
                if (String.IsNullOrEmpty(address))
                {
                    throw new ArgumentException("Address can't be null or empty!");
                }
				return address;
            }
			set
			{
                address = value;
            }
		}

		public Library(string name, string address, List<Book> books)
		{
			this.Name = name;
			this.Address = address;
			this.books = books;
			books = new List<Book>();
		}

		public void ShowAllBooks()
		{
			foreach(var x in books)
			{
				Console.WriteLine($"{x.Title} - {x.Author} - {x.Genre} - {x.IsAvailable}");
			}
		}

		public void SearchBooksByAuthor(string author)
		{
			List<Book> booksByAuthor = new List<Book>();
			for(int i=0; i<books.Count; i++)
			{
				if (books[i].Author == author)
				{
					booksByAuthor.Add(books[i]);
				}
			}
			foreach(var x in booksByAuthor)
			{
				Console.WriteLine($"{x.Title} - {x.Author} - {x.Genre} - {x.IsAvailable}");
			}
		}

		public void SearchBooksByGenre(string genre)
		{
            List<Book> booksByGenre = new List<Book>();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Genre == genre)
                {
                    booksByGenre.Add(books[i]);
                }
            }
            foreach (var x in booksByGenre)
            {
                Console.WriteLine($"{x.Title} - {x.Author} - {x.Genre} - {x.IsAvailable}");
            }
        }

		public void AddBook(Book book)
		{
			books.Add(book);
			Console.WriteLine($"You added {book.Title} to the library!");
		}

		public void RemoveBook(string bookName)
		{
			bool isFounded = false;
			foreach(var x in books)
			{
				if(x.Title == bookName)
				{
                    books.Remove(x);
					isFounded = true;
                    Console.WriteLine($"You removed {x.Title} from the library!");
					break;
                }
			}
			if(!isFounded)
			{
				Console.WriteLine("Sorry, we don't have this book!");
			}
		}

		public void TakeBook(string bookName)
		{
			bool isFound = false;
			foreach (var x in books)
			{
				if (x.Title == bookName && x.IsAvailable)
				{
					x.IsAvailable = false;
					isFound = true;
					Console.WriteLine("Enjoy reading!");
					break;
				}
			}
			if(!isFound)
			{
                Console.WriteLine("Sorry, we don't have this book at the moment!");
            }
		}

		public void ReturnBook(String nameBook)
		{
			bool isFounded = false;
			foreach(var x in books)
			{
				if(x.Title == nameBook && !x.IsAvailable)
				{
                    x.IsAvailable = true;
					isFounded = true;
                    Console.WriteLine("Thank you for returning the book!");
					break;
                }
			}
			if(!isFounded)
			{
				Console.WriteLine("This book is not from our library!");
			}
		}
	}
}

