using BattleshipsClassLibrary.Models.Enums;
using BattleshipsClassLibrary.Models.Grids;
using BattleshipsClassLibrary.Models.Ships;
using System.Collections.Generic;

namespace BattleshipsClassLibrary.Interfaces
{
    public interface IGame
    {
        int GetPlayerCount();
        List<Ship> GetShipsToPlaceForPlayer(int playerId);
        bool PlaceShipForPlayer(Ship ship, Coordinate originCoordinate, OrientationEnum orientation, int playerId);
        CellHitStatus FireAtCoordinate(Coordinate coordinate, int playerId);
        Grid GetFiringGridForPlayer(int playerId);
        Grid GetMyGridForPlayer(int playerId);
        bool HasPlayerWon(int playerId);
        Ship ShipSunkAtCoordinate(Coordinate coordinate, int playerId);
        bool CanFireAtCoordinate(Coordinate coordinate, int playerId);
        List<Ship> GetEnemyShipsBar(int playerId);
    }
}
