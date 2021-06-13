namespace BattleshipsClassLibrary.Models.Grids
{
    public class Grid
    {
        public Grid(int numRows, int numColumns)
        {
            Cells = new Cell[numRows, numColumns];
        }

        /// <summary>
        /// Initializes the grid by setting all cells to Empty
        /// </summary>
        /// <returns></returns>
        public Grid Init()
        {
            for (int r = 0; r < Cells.GetLength(0); r++)
            {
                for (int c = 0; c < Cells.GetLength(1); c++) // Who asked for c++ ? :)
                {
                    Cells[r, c] = new Cell(new Coordinate(r, c), Enums.CellHitStatus.Normal);
                }
            }

            return this;
        }

        public Cell[,] Cells { get; set; }

        public string Name { get; set; }
    }
}
