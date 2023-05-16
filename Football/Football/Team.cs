using System;
using System.Collections.Generic;

namespace Football
{
	public class Team
	{
		private Coach coach;
		private List<FootballPlayer> players;

		public Coach Coach { get; set; }
		public List<FootballPlayer> Players
		{
			get { return players; }
			set
			{
				if (players.Count < 11 && players.Count > 22)
				{
					throw new ArgumentException();
				}
				else
				{
					players = value;
				}
			}
		}

		public Team(Coach coach, List<FootballPlayer> players)
		{
			this.Coach = coach;
			this.players = players;
		}

		public double AverageAge()
		{
			int sum = 0;
			foreach(var x in players)
			{
				sum+=x.Age;
			}
			return sum / players.Count;
		}
	}
}

