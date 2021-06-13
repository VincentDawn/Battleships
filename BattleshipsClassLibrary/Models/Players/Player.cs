using BattleshipsClassLibrary.Models.Grids;
using BattleshipsClassLibrary.Models.Ships;
using System.Collections.Generic;

namespace BattleshipsClassLibrary.Models.Players
{
    public class Player
    {
        public int PlayerNumber { get; set; }
        public Grid MyGrid { get; set; }
        public Grid FiringGrid { get; set; }
        public List<Ship> Ships { get; set; }

        /// <summary>
        /// Initialize player boards with default ships(one of each) and grid sizes(10, 10).
        /// </summary>
        public Player() : this(
            new List<Ship>(){
                new Battleship(),
                new Carrier(),
                new Cruiser(),
                new Destroyer(),
                new Submarine()
            },
            10,
            10)
        { }

        public Player(List<Ship> ships, int rowCount, int columnCount)
        {
            // Default list of ships
            Ships = ships;

            // Own board init
            MyGrid = new Grid(rowCount, columnCount).Init();

            // Enemy board init
            FiringGrid = new Grid(rowCount, columnCount).Init();
        }
    }
}
