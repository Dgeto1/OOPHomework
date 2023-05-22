using System;
namespace Library
{
	public class Book
	{
		private string title;
		private string author;
		private string genre;
		private bool isAvailable = true;

		public string Title { get; set; }
		public string Author { get; set; }
		public string Genre { get; set; }
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

