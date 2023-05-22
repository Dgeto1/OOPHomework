using System;
namespace BankingSystem
{
	public class Client
	{
		private string firstName;
		private string secondName;
		private string pin;
		private string address;
		private double money;

		public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PIN { get; set; }
		public string Address { get; set; }
		public double Money { get; set; }

		public Client(string firstName, string secondName, string pin, string address, double money)
		{
			this.FirstName = firstName;
			this.SecondName = secondName;
			this.PIN = pin;
			this.Address = address;
			this.Money = money;
		}
	}
}

