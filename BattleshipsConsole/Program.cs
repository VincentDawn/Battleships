using BattleshipsClassLibrary.Interfaces;
using BattleshipsClassLibrary.Models.Enums;
using BattleshipsClassLibrary.Models.Games;
using BattleshipsClassLibrary.Models.Grids;
using BattleshipsClassLibrary.Models.Ships;
using BattleshipsConsole.Helpers;
using System;

namespace Battleships
{
    class Program
    {
        static void Main()
        {
            ConsoleHelper ConsoleHelper = new ConsoleHelper();
            IGame Game = new Game();

            // Say something at intro
            ConsoleHelper.PrintIntroMessage();
            ConsoleHelper.WriteLine("Press any key to continue");

            // Await input
            ConsoleHelper.GetInput();

            // Clear
            ConsoleHelper.ClearScreen();

            // Foreach player
            for (int playerId = 1; playerId <= Game.GetPlayerCount(); playerId++)
            {
                // Get ships
                var ships = Game.GetShipsToPlaceForPlayer(playerId);
                foreach (var ship in ships)
                {
                    int row;
                    int column;
                    OrientationEnum orientation = OrientationEnum.Horizontal;
                    bool? shipPlacementSuccessful = null;

                    do
                    {
                        // clear
                        ConsoleHelper.ClearScreen();
                        if (shipPlacementSuccessful == false)
                        {
                            ConsoleHelper.WriteLine($"Error placing ship. Please try again.");
                        }

                        ConsoleHelper.WriteLine($"Player {playerId} must place their ships.");

                        // Show own grid at bottom
                        ConsoleHelper.RenderMyGrid(Game.GetMyGridForPlayer(playerId));

                        // Some message saying to place the ship with a coordinate and a orientation
                        // Origin will be bottom left, ship will go from there upwards or to the right
                        // input row, column, orientation (V or H)
                        ConsoleHelper.WriteLine($"Placing ship for player {playerId}");

                        ConsoleHelper.WriteLine($"Your ship is the {ship.Name}, it has {ship.HitPoints} hitpoints, a length of {ship.Length}, and a designation of {(char)ship.Designation}.");

                        ConsoleHelper.WriteLine($"The grid has {Game.GetMyGridForPlayer(playerId).Cells.GetLength(0)} rows and {Game.GetMyGridForPlayer(playerId).Cells.GetLength(1)} columns.");

                        ConsoleHelper.WriteLine($"Please give your ships origin coordinates and an orientation. Ships will extend from the origin either upwards or to the right.");

                        // Get X
                        ConsoleHelper.WriteLine($"Please enter an integer value for the X coordinate.");
                        column = (int)Char.GetNumericValue(ConsoleHelper.GetInput());

                        // Get Y
                        ConsoleHelper.WriteLine($"Please enter an integer value for the Y coordinate.");
                        row = (int)Char.GetNumericValue(ConsoleHelper.GetInput());

                        // Get orientation
                        ConsoleHelper.WriteLine($"Please enter either H or V for the orientation.");
                        var orientationKey = ConsoleHelper.GetInput();
                        if (orientationKey == 'h' || orientationKey == 'H')
                        {
                            orientation = OrientationEnum.Horizontal;
                        }
                        if (orientationKey == 'v' || orientationKey == 'V')
                        {
                            orientation = OrientationEnum.Vertical;
                        }

                        shipPlacementSuccessful = Game.PlaceShipForPlayer(ship, new Coordinate(row, column), orientation, playerId);
                        if (shipPlacementSuccessful == false)
                        {
                            ConsoleHelper.WriteLine("Invalid ship placement. Please try again.");
                        }
                    }
                    while (!shipPlacementSuccessful == true);
                }
            }
            ConsoleHelper.ClearScreen();

            ConsoleHelper.WriteLine($"The ships are now placed.");
            ConsoleHelper.WriteLine($"The game is now ready to start. Press any key to begin play for player 1");
            ConsoleHelper.GetInput();
            ConsoleHelper.ClearScreen();

            while (true) // Loop till game exits
            {
                // Foreach player
                for (int playerId = 1; playerId <= Game.GetPlayerCount(); playerId++)
                {
                    int row;
                    bool? canFireAtCoordinate = null;
                    int column;
                    do
                    {
                        ConsoleHelper.ClearScreen();
                        if (canFireAtCoordinate == false)
                        {
                            ConsoleHelper.WriteLine("Invalid shot placement. Please try again.", ConsoleColor.Red);
                        }

                        // Show enemy ship bar at top?
                        ConsoleHelper.RenderEnemyShipBar(Game.GetEnemyShipsBar(playerId));

                        // Show firing grid at top
                        ConsoleHelper.WriteLine("Firing Grid");
                        ConsoleHelper.EnemyGrid(Game.GetFiringGridForPlayer(playerId));

                        // Show own grid at bottom
                        ConsoleHelper.WriteLine("My Grid");

                        ConsoleHelper.RenderMyGrid(Game.GetMyGridForPlayer(playerId));

                        // Show some space below for messages etc
                        ConsoleHelper.WriteLine($"Please give firing coordinates.");

                        // Get X
                        ConsoleHelper.WriteLine($"Please enter an integer value for the X coordinate.");
                        column = (int)Char.GetNumericValue(ConsoleHelper.GetInput());

                        // Get Y
                        ConsoleHelper.WriteLine($"Please enter an integer value for the Y coordinate.");
                        row = (int)Char.GetNumericValue(ConsoleHelper.GetInput());

                        canFireAtCoordinate = Game.CanFireAtCoordinate(new Coordinate(row, column), playerId);
                    } while (!canFireAtCoordinate == true);

                    ConsoleHelper.ClearScreen();

                    CellHitStatus cellHitStatus = Game.FireAtCoordinate(new Coordinate(row, column), playerId);
                    if (cellHitStatus == CellHitStatus.Hit)
                    {
                        Ship ship = Game.ShipSunkAtCoordinate(new Coordinate(row, column), playerId);
                        if (ship != null)
                        {
                            ConsoleHelper.PrintSunkMessage();
                        }
                        else
                        {
                            ConsoleHelper.PrintHitMessage();
                        }
                    }
                    else if (cellHitStatus == CellHitStatus.Miss)
                    {
                        ConsoleHelper.PrintMissMessage();
                    }

                    if (Game.HasPlayerWon(playerId))
                    {
                        ConsoleHelper.PrintVictoryMessage();

                        // Press any key to end the game
                        ConsoleHelper.WriteLine("Press any key to exit.");
                        ConsoleHelper.GetInput();
                        Environment.Exit(0);
                    }
                    else
                    {
                        // Press any key to end the game
                        ConsoleHelper.WriteLine("Press any key to end your turn.");
                        ConsoleHelper.GetInput();
                    }
                }
            }
        }
    }
}
