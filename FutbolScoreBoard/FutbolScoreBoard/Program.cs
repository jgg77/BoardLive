using System;

namespace FutbolScoreBoard
{
    class Program: BoardManagement
    {
        static void Main()
        {
            BoardManagement manage = new BoardManagement();
            Team localTeam = new Team("",0);
            Team awayTeam = new Team("", 0);
            Team teamInfoUpdate = new Team();
            string[] args = Console.ReadLine().Split(',');
            do
            {
                switch (args[0])
                {
                    case "ADD":
                        localTeam.name = args[1];
                        localTeam.result = Convert.ToInt32(args[2]);
                        awayTeam.name = args[3];
                        awayTeam.result = Convert.ToInt32(args[4]);
                        if (manage.addGame(manage.BoardLive, localTeam, awayTeam))
                            Console.WriteLine("Added succesfully");
                        else
                            Console.WriteLine("Cannot add the game");
                        break;
                    case "UPDATE":
                        localTeam.name = args[1];
                        localTeam.result = Convert.ToInt32(args[2]);
                        awayTeam.name = args[3];
                        awayTeam.result = Convert.ToInt32(args[4]);
                        if (manage.UpdateGame(manage.BoardLive, localTeam,awayTeam))
                            Console.WriteLine("Updated succesfully");
                        else
                            Console.WriteLine("Cannot update the game");
                        break;
                    case "REMOVE":
                        localTeam.name = args[1];
                        localTeam.result = Convert.ToInt32(args[2]);
                        if (manage.removeGame(manage.BoardLive, localTeam))
                            Console.WriteLine("Updated succesfully");
                        else
                            Console.WriteLine("Cannot update the game");
                        break;
                    case "PUBLISH":
                        if (manage.publishBoard(manage.BoardLive))
                            Console.WriteLine("Done");
                        else
                            Console.WriteLine("Cannot publish the board");
                        break;
                    default:
                        break;
                }
                args = Console.ReadLine().Split(',');
            } while (!args[0].Equals("FINISH"));

        }
    }
}
