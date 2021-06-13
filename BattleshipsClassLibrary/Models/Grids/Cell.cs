using BattleshipsClassLibrary.Models.Enums;
using BattleshipsClassLibrary.Models.Ships;

namespace BattleshipsClassLibrary.Models.Grids
{
    public class Cell
    {
        public Cell(Coordinate coordinate, CellHitStatus cellStatus)
        {
            Coordinate = coordinate;
            CellStatus = cellStatus;
        }

        public Coordinate Coordinate { get; set; }
        public CellHitStatus CellStatus { get; set; }
        public CellShipDesignationEnum? CellOccupancy { get; set; }
        public Ship Ship { get; set; }
    }
}
