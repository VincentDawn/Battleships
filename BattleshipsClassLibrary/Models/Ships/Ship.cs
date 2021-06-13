using BattleshipsClassLibrary.Models.Enums;

namespace BattleshipsClassLibrary.Models.Ships
{
    public class Ship
    {
        public int HitPoints { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public CellShipDesignationEnum Designation { get; set; }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }

        public bool HasSunk()
        {
            return HitPoints <= 0;
        }
    }
}
