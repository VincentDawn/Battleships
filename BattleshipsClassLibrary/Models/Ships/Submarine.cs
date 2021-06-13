using BattleshipsClassLibrary.Models.Enums;

namespace BattleshipsClassLibrary.Models.Ships
{
    class Submarine : Ship
    {
        public Submarine()
        {
            HitPoints = 3;
            Length = 3;
            Name = "Submarine";
            Designation = CellShipDesignationEnum.Submarine;
        }
    }
}
