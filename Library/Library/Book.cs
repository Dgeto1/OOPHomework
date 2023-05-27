using System;
namespace Library
{
	public class Book
	{
		private string title;
		private string author;
		private string genre;
		private bool isAvailable = true;

		public string Title
		{
			get
			{
                if (String.IsNullOrEmpty(title))
                {
                    throw new ArgumentException("Title can't be null or empty!");
                }
				return title;
            }
			set
			{
				this.title = value;
			}
		}
		public string Author
		{
			get
			{
                if (String.IsNullOrEmpty(author))
                {
                    throw new ArgumentException("Author can't be null or empty!");
                }
				return author;
            }
			set
			{
				author = value;
			}
		}

		public string Genre
		{
			get
			{
                if (String.IsNullOrEmpty(genre))
                {
                    throw new ArgumentException("Genre can't be null or empty!");
                }
				return genre;
            }
			set
			{
                genre = value;
            }
		}
		public bool IsAvailable { get; set; }

		public Book(string title, string author, string genre, bool isAvailable)
		{
			this.Title = title;
			this.Author = author;
			this.Genre = genre;
			this.IsAvailable = isAvailable;
		}
	}
}

