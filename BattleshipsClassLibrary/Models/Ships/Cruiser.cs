using BattleshipsClassLibrary.Models.Enums;

namespace BattleshipsClassLibrary.Models.Ships
{
    class Cruiser : Ship
    {
        public Cruiser()
        {
            HitPoints = 3;
            Length = 3;
            Name = "Cruiser";
            Designation = CellShipDesignationEnum.Cruiser;
        }
    }
}
