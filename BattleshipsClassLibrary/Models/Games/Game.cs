using BattleshipsClassLibrary.Helpers;
using BattleshipsClassLibrary.Interfaces;
using BattleshipsClassLibrary.Models.Enums;
using BattleshipsClassLibrary.Models.Grids;
using BattleshipsClassLibrary.Models.Players;
using BattleshipsClassLibrary.Models.Ships;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipsClassLibrary.Models.Games
{
    public class Game : IGame
    {
        public Game()
        {
            Players = new List<Player>()
            {
                new Player(),
                new Player()
            };
        }

        //public Game(int playerCount)
        //{
        //    Players = new List<Player>();
        //    for (int i = 0; i < playerCount; i++)
        //    {
        //        Players.Add(new Player());
        //    }
        //}

        List<Player> Players { get; set; }

        public List<Ship> GetShipsToPlaceForPlayer(int playerId)
        {
            return GetPlayer(playerId).Ships;
        }

        public bool PlaceShipForPlayer(Ship ship, Coordinate originCoordinate, OrientationEnum orientation, int playerId)
        {
            // Get the grid for this player
            var grid = GetPlayer(playerId).MyGrid;

            // Use a ship placer helper to check all the cells along the placement area
            bool isPlacementValid = ShipPlacementHelper.IsValidPlacementArea(ship, originCoordinate, orientation, grid);

            // If valid placement area
            if (!isPlacementValid)
            {
                return false;
            }

            // Insert the ship into the placement area
            return ShipPlacementHelper.PlaceShip(ship, originCoordinate, orientation, grid);
        }

        public CellHitStatus FireAtCoordinate(Coordinate coordinate, int playerId)
        {
            // My firing grid
            var myFiringGrid = GetFiringGridForPlayer(playerId);

            // Enemy grid
            // Temporary for 2 player only game
            var enemyId = playerId == 1 ? 2 : 1;
            var enemyGrid = GetMyGridForPlayer(enemyId);

            return FiringHelper.FireAtCoordinate(coordinate, myFiringGrid, enemyGrid);
        }

        public Grid GetFiringGridForPlayer(int playerId)
        {
            return GetPlayer(playerId).FiringGrid;
        }

        public Grid GetMyGridForPlayer(int playerId)
        {
            return GetPlayer(playerId).MyGrid;
        }

        public bool HasPlayerWon(int playerId)
        {
            // Temporary for 2 player only game
            var enemyId = playerId == 1 ? 2 : 1;

            return GetPlayer(enemyId).Ships.All(x => x.HasSunk());
        }

        public int GetPlayerCount()
        {
            return Players.Count;
        }

        private Player GetPlayer(int playerId)
        {
            return Players[--playerId];
        }

        public Ship ShipSunkAtCoordinate(Coordinate coordinate, int playerId)
        {
            // Enemy grid
            // Temporary for 2 player only game
            var enemyId = playerId == 1 ? 2 : 1;
            var enemyGrid = GetMyGridForPlayer(enemyId);

            return FiringHelper.ShipSunkAtCoordinate(coordinate, enemyGrid);
        }

        public bool CanFireAtCoordinate(Coordinate coordinate, int playerId)
        {
            // My firing grid
            var myFiringGrid = GetFiringGridForPlayer(playerId);

            return FiringHelper.CanFireAtCoordinate(coordinate, myFiringGrid);
        }

        public List<Ship> GetEnemyShipsBar(int playerId)
        {
            // Temporary for 2 player only game
            var enemyId = playerId == 1 ? 2 : 1;

            return GetPlayer(enemyId).Ships;
        }
    }
}
