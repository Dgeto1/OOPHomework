using System;
using System.Collections.Generic;

namespace Football
{
	public class Game
	{
        private Team team1;
        private Team team2;
        private Referee referee;
        private Referee assistantReferee1;
        private Referee assistantReferee2;
        private List<Goal> goals;

        public Team Team1
        {
            get { return team1; }
            set
            {
                if (team1.Players.Count == 11)
                {
                    team1 = value;
                }
                else
                {
                    throw new Exception("Players must be 11");
                }
            }
        }
        public Team Team2
        {
            get { return team2; }
            set
            {
                if (team2.Players.Count == 11)
                {
                    team2 = value;
                }
                else
                {
                    throw new Exception("Players must be 11");
                }
            }
        }
        public Referee Referee
        {
            get { return referee; }
            set { referee = value; }
        }
        public Referee AssistantReferee1
        {
            get { return assistantReferee1; }
            set
            {
                assistantReferee1 = value;
            }
        }
        public Referee AssistantReferee2
        {
            get { return assistantReferee2; }
            set
            {
                assistantReferee2 = value;
            }
        }
        public List<Goal> Goals
        {
            get { return goals; }
            set
            {
                goals = value;
            }
        }
        public void Goal(Goal g)
        {
            Goals.Add(g);
        }
        public void GameResult()
        {
            int team1 = 0, team2 = 0;
            foreach (Goal g in Goals)
            {
                if (Team1.Players.Contains(g.Player))
                    team1++;
                if (Team2.Players.Contains(g.Player))
                    team2++;
            }
            Console.WriteLine($"Team 1 have: {team1} goals \n Team 2 have: {team2} goals");
        }
        public void Winner()
        {
            int team1 = 0, team2 = 0;
            foreach (Goal g in Goals)
            {
                if (Team1.Players.Contains(g.Player))
                    team1++;
                if (Team2.Players.Contains(g.Player))
                    team2++;
            }
            if (team1 == team2)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                if (team1 > team2)
                {
                    Console.WriteLine("Team 1 is winner");
                }
                else { Console.WriteLine("Team 2 is winner"); }
            }
        }   
    }
}

