using BattleshipsClassLibrary.Models.Enums;

namespace BattleshipsClassLibrary.Models.Ships
{
    class Carrier : Ship
    {
        public Carrier()
        {
            HitPoints = 5;
            Length = 5;
            Name = "Carrier";
            Designation = CellShipDesignationEnum.Carrier;
        }
    }
}
