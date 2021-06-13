using BattleshipsClassLibrary.Models.Enums;

namespace BattleshipsClassLibrary.Models.Ships
{
    class Battleship : Ship
    {
        public Battleship()
        {
            HitPoints = 4;
            Length = 4;
            Name = "Battleship";
            Designation = CellShipDesignationEnum.Battleship;
        }
    }
}
