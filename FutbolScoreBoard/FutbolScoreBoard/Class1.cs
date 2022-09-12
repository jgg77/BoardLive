using System;
using System.Collections.Generic;
using System.Text;

namespace FutbolScoreBoard
{
    public class BoardManagement
    {
        public struct Team 
        {
            public Team(string Name, int Result) 
            {
                name = Name;
                result = Result;
            }
            public string name { get; set; }
            public int result { get; set; }
        }
        public Dictionary<Team,Team> BoardLive;
        public Dictionary<Dictionary<Team,Team>, DateTime> SummaryBoard;

        public BoardManagement() 
        {
            BoardLive = new Dictionary<Team, Team>();
        }
        public bool addGame(Dictionary<Team, Team> board, Team homeTeam, Team awayTeam) 
        {
            try
            {
                board.Add(homeTeam, awayTeam);
                if (board.ContainsKey(homeTeam) & board.ContainsValue(awayTeam))
                    return true;
                else
                    return false;
            }
            catch (Exception EX)
            {
                return false;
            }
        }
        public bool removeGame(Dictionary<Team, Team> board,Team homeTeam)
        {
            try
            {
                board.Remove(homeTeam);
                if (!board.ContainsKey(homeTeam))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateGame(Dictionary<Team, Team> board, Team local, Team away)
        {
            try
            {
                bool teamUpdated = false;
                
                foreach (var TeamLoop in board)
                {
                    if (TeamLoop.Key.name.Equals(local.name))
                    {
                        teamUpdated = true;
                        removeGame(board, local);
                        addGame(board, local, away);
                        break;
                        
                    }
                    if (!teamUpdated & TeamLoop.Value.name.Equals(local.name))
                    {
                        teamUpdated = true;
                        removeGame(board, local);
                        addGame(board, local, away);
                        break;

                    }
                }
                if (teamUpdated)
                    return true;
                else 
                {
                    Console.WriteLine("Something was wrong trying to update the result");
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
        public bool publishBoard(Dictionary<Team, Team> Board)
        {
            try
            {
                foreach (var game in Board)
                    Console.WriteLine(String.Format("{0} - {1}: {2} - {3}", game.Key.name,game.Value.name,game.Key.result,game.Value.result));

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
