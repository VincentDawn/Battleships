using BattleshipsClassLibrary.Models.Enums;
using BattleshipsClassLibrary.Models.Grids;
using BattleshipsClassLibrary.Models.Ships;
using System;

namespace BattleshipsClassLibrary.Helpers
{
    public static class ShipPlacementHelper
    {
        public static bool IsValidPlacementArea(Ship ship, Coordinate originCoordinate, OrientationEnum orientation, Grid grid)
        {
            try
            {
                // Check the cell status of all the cells in an area
                for (int i = 0; i < ship.Length; i++)
                {
                    Coordinate coordinate = new Coordinate(0, 0);
                    // For length of ship
                    if (orientation == OrientationEnum.Horizontal)
                    {
                        // Go right
                        coordinate = new Coordinate(originCoordinate.Row, originCoordinate.Column + i);
                    }
                    else if (orientation == OrientationEnum.Vertical)
                    {
                        // Go up
                        coordinate = new Coordinate(originCoordinate.Row + i, originCoordinate.Column);
                    }

                    // Check out of bounds
                    if (grid.Cells[coordinate.Row, coordinate.Column] == null)
                    {
                        return false;
                    }

                    // Check occupancy
                    if (grid.Cells[coordinate.Row, coordinate.Column].CellOccupancy != null)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool PlaceShip(Ship ship, Coordinate originCoordinate, OrientationEnum orientation, Grid grid)
        {
            try
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    Coordinate coordinate = new Coordinate(0, 0);
                    // For length of ship
                    if (orientation == OrientationEnum.Horizontal)
                    {
                        // Go right
                        coordinate = new Coordinate(originCoordinate.Row, originCoordinate.Column + i);
                    }
                    else if (orientation == OrientationEnum.Vertical)
                    {
                        // Go up
                        coordinate = new Coordinate(originCoordinate.Row + i, originCoordinate.Column);
                    }

                    // Insert
                    grid.Cells[coordinate.Row, coordinate.Column].CellOccupancy = ship.Designation;
                    grid.Cells[coordinate.Row, coordinate.Column].Ship = ship;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
