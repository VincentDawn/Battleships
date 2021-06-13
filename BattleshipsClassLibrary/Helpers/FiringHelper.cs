using BattleshipsClassLibrary.Models.Enums;
using BattleshipsClassLibrary.Models.Grids;
using BattleshipsClassLibrary.Models.Ships;
using System;

namespace BattleshipsClassLibrary.Helpers
{
    public static class FiringHelper
    {
        public static bool CanFireAtCoordinate(Coordinate coordinate, Grid myFiringGrid)
        {
            try
            {
                // Check status of grid
                if (HasCoordinateBeenFiredOn(coordinate, myFiringGrid))
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool HasCoordinateBeenFiredOn(Coordinate coordinate, Grid firingGrid)
        {
            return firingGrid.Cells[coordinate.Row, coordinate.Column].CellStatus != CellHitStatus.Normal;
        }

        public static CellHitStatus FireAtCoordinate(Coordinate coordinate, Grid myFiringGrid, Grid enemyGrid)
        {
            // Is occupied by ship
            var isOccupied = enemyGrid.Cells[coordinate.Row, coordinate.Column].CellOccupancy.HasValue;
            CellHitStatus cellHitStatus = CellHitStatus.Miss;
            if (isOccupied)
            {
                // Deal damage to ship.
                enemyGrid.Cells[coordinate.Row, coordinate.Column].Ship.TakeDamage(1);

                cellHitStatus = CellHitStatus.Hit;
            }
            // Update my grid
            myFiringGrid.Cells[coordinate.Row, coordinate.Column].CellStatus = cellHitStatus;

            // Update enemygrid
            enemyGrid.Cells[coordinate.Row, coordinate.Column].CellStatus = cellHitStatus;

            return cellHitStatus;
        }

        public static Ship ShipSunkAtCoordinate(Coordinate coordinate, Grid enemyGrid)
        {
            if (enemyGrid.Cells[coordinate.Row, coordinate.Column].Ship.HasSunk())
            {
                return enemyGrid.Cells[coordinate.Row, coordinate.Column].Ship;
            }
            else
            {
                return null;
            }
        }
    }
}
