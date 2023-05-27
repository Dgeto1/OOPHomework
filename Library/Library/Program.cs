using System;
using System.Collections.Generic;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            const string USERNAME = "library";
            const string PASSWORD = "library123";

            Book book1 = new Book("Harry Potter", "J. K. Rowling", "Fantasy", true);
            Book book2 = new Book("Pod igoto", "Ivan Vazov", "Historic", true);
            Book book3 = new Book("Bay Ganio", "Aleko Konstantinov", "Comic", false);
            List<Book> books = new List<Book>();
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);

            Library library = new Library("Narodna biblioteka", "Plovdiv", books);

            int pickedNumber = 0;
            while (pickedNumber != 3)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Welcome to Narodna Biblioteka");
                Console.WriteLine("Please, choose your role in the library!");
                Console.WriteLine("1.Client");
                Console.WriteLine("2.Librarist");
                Console.WriteLine("3.Leave the library");

                pickedNumber = int.Parse(Console.ReadLine());
                if (pickedNumber == 1)
                {
                    Console.WriteLine("Choose from the list above!");
                    Console.WriteLine("1.Get a book");
                    Console.WriteLine("2.Return a book");
                    Console.WriteLine("3.Show all books");
                    Console.WriteLine("4.Search a book by author");
                    Console.WriteLine("5.Seacrh a book by genre");

                    int choosedNumber = int.Parse(Console.ReadLine());

                    switch (choosedNumber)
                    {
                        case 1:
                            Console.WriteLine("Enter the book's title!");
                            string titleName = Console.ReadLine();
                            library.TakeBook(titleName);
                            break;
                        case 2:
                            Console.WriteLine("Enter the book's title!");
                            string bookName = Console.ReadLine();
                            library.ReturnBook(bookName);
                            break;
                        case 3:
                            library.ShowAllBooks();
                            break;
                        case 4:
                            Console.WriteLine("Please, enter the author's name!");
                            string authorName = Console.ReadLine();
                            library.SearchBooksByAuthor(authorName);
                            break;
                        case 5:
                            Console.WriteLine("Please, enter the genre!");
                            string genre = Console.ReadLine();
                            library.SearchBooksByGenre(genre);
                            break;
                    }
                }
                if(pickedNumber == 2)
                {
                    Console.WriteLine("Please, enter the username and the password");
                    string username = Console.ReadLine();
                    string password = Console.ReadLine();
                    if(username != USERNAME || password != PASSWORD)
                    {
                        Console.WriteLine("Sorry, your username or passowrd is incorrect!");
                    }
                    else
                    {
                        Console.WriteLine("1.Add new book");
                        Console.WriteLine("2.Delete a book");
                        int choosedNum = int.Parse(Console.ReadLine());
                        switch (choosedNum)
                        {
                            case 1:
                                Console.WriteLine("Please, enter the details of the book!");
                                Book book = new Book(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), true);
                                library.AddBook(book);
                                break;
                            case 2:
                                Console.WriteLine("Please, enter the details of the book!");
                                string bookName = Console.ReadLine();
                                library.RemoveBook(bookName);
                                break;
                        }
                    }
                }
            }
            if(pickedNumber == 3)
            {
                Console.WriteLine("You left the library!");
            }
        }
    }
}

