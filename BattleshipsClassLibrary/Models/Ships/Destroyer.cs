using BattleshipsClassLibrary.Models.Enums;

namespace BattleshipsClassLibrary.Models.Ships
{
    class Destroyer : Ship
    {
        public Destroyer()
        {
            HitPoints = 2;
            Length = 2;
            Name = "Destroyer";
            Designation = CellShipDesignationEnum.Destroyer;
        }
    }
}
