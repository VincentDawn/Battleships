using BattleshipsClassLibrary.Models.Enums;
using BattleshipsClassLibrary.Models.Grids;
using BattleshipsClassLibrary.Models.Ships;
using System;
using System.Collections.Generic;

namespace BattleshipsConsole.Helpers
{
    public class ConsoleHelper
    {
        private const string IntroMessage = "Intro message";
        private const string SunkMessage = "Hit and sunk";
        private const string HitMessage = "Hit";
        private const string MissMessage = "Miss";
        private const string VictoryMessage = "You have won";

        public void RenderMyGrid(Grid grid)
        {
            // a space
            Console.WriteLine();

            // print the grid, in blue by default
            for (int r = grid.Cells.GetLength(0) - 1; r >= 0; r--)
            {
                // row #
                WriteColourString(r.ToString(), ConsoleColor.White);
                Console.Write(" "); // Some space

                for (int c = 0; c < grid.Cells.GetLength(1); c++)
                {
                    // Open bracket
                    WriteColourString("[", ConsoleColor.Blue);

                    ConsoleColor color;
                    switch (grid.Cells[r, c].CellStatus)
                    {
                        case CellHitStatus.Hit:
                            color = ConsoleColor.Red;
                            break;
                        case CellHitStatus.Miss:
                            color = ConsoleColor.White;
                            break;
                        default:
                            color = ConsoleColor.Blue;
                            break;
                    }

                    // Character or empty space for ship
                    WriteColourString(grid.Cells[r, c].CellOccupancy != null ? ((char)grid.Cells[r, c].CellOccupancy).ToString() : " ", color);

                    // Close bracket
                    WriteColourString("]", ConsoleColor.Blue);
                }
                // EOL
                WriteColourString(Environment.NewLine, ConsoleColor.Blue);
            }

            // Col along bottom
            // 2 spaces
            // 1 space and id and another space 
            string bottomLine = "  ";
            for (int i = 0; i < grid.Cells.GetLength(0); i++)
            {
                bottomLine += $" {i} ";
            }
            WriteLine(bottomLine);
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void PrintIntroMessage()
        {
            Console.WriteLine(IntroMessage);
        }

        public void PrintHitMessage()
        {
            Console.WriteLine(HitMessage);
        }

        public void PrintMissMessage()
        {
            Console.WriteLine(MissMessage);
        }

        public void PrintSunkMessage()
        {
            Console.WriteLine(SunkMessage);
        }

        public void WriteLine(string str, ConsoleColor colour = ConsoleColor.White)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(str);
            Console.ResetColor();

        }

        public char GetInput()
        {
            var keyinfo = Console.ReadKey();

            // empty line
            Console.WriteLine();

            return keyinfo.KeyChar;
        }

        private void WriteColourString(string str, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.Write(str);
            Console.ResetColor();
        }

        public void EnemyGrid(Grid grid)
        {
            // print the grid, in blue by default
            for (int r = grid.Cells.GetLength(0) - 1; r >= 0; r--)
            {
                // row #
                WriteColourString(r.ToString(), ConsoleColor.White);
                Console.Write(" "); // Some space

                for (int c = 0; c < grid.Cells.GetLength(1); c++)
                {
                    // Open bracket
                    WriteColourString("[", ConsoleColor.Blue);

                    ConsoleColor color;
                    char statusCharacter;
                    switch (grid.Cells[r, c].CellStatus)
                    {
                        case CellHitStatus.Hit:
                            color = ConsoleColor.Red;
                            statusCharacter = 'X';
                            break;
                        case CellHitStatus.Miss:
                            color = ConsoleColor.White;
                            statusCharacter = 'X';
                            break;
                        default:
                            color = ConsoleColor.Blue;
                            statusCharacter = ' ';
                            break;
                    }

                    // Character or empty space for ship
                    WriteColourString(statusCharacter.ToString(), color);

                    // Close bracket
                    WriteColourString("]", ConsoleColor.Blue);
                }
                // EOL
                WriteColourString(Environment.NewLine, ConsoleColor.Blue);
            }

            // Col along bottom
            // 2 spaces
            // 1 space and id and another space 
            string bottomLine = "  ";
            for (int i = 0; i < grid.Cells.GetLength(0); i++)
            {
                bottomLine += $" {i} ";
            }
            WriteLine(bottomLine);
        }

        public void RenderEnemyShipBar(List<Ship> ships)
        {
            ConsoleColor color = ConsoleColor.White;
            foreach (var ship in ships)
            {
                // Examples online also showed the ship type
                if (ship.HasSunk())
                {
                    color = ConsoleColor.Red;
                }
                else
                {
                    color = ConsoleColor.White;
                }

                WriteColourString("[", color);
                WriteColourString(((char)ship.Designation).ToString(), color);
                WriteColourString("]", color);
            }

            WriteColourString(Environment.NewLine, color);
        }

        public void PrintVictoryMessage()
        {
            Console.WriteLine(VictoryMessage);
        }
    }
}
