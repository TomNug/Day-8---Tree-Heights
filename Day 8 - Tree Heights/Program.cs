/*
 * 30373
 * 25512
 * 65332
 * 33549
 * 35390
 * 
 * Numbers are tree heights, from 0 to 9. 
 * A tree is visible if it can be seen from an edge 
 * Only orthogonal movement is considered
 * 
 * Calculate the number of visible trees
*/

class Program
{

    public static bool isVisible(int startRow, int startCol, int[,] forest)
    {
        bool visibleN = true;
        bool visibleE = true;
        bool visibleS = true;
        bool visibleW = true;
        int height = forest[startRow, startCol];
        // Check North
        for (int row = startRow-1; row >= 0; row--)
        {
            if (forest[row, startCol] >= height)
            {
                visibleN = false;
                break;
            }
        }
        // Check South
        for (int row = startRow + 1; row < forest.GetLength(0); row++)
        {
            if (forest[row, startCol] >= height)
            {
                visibleS = false;
                break;
            }
        }
        // Check East
        for (int col = startCol + 1; col < forest.GetLength(1); col++)
        {
            if (forest[startRow, col] >= height)
            {
                visibleE = false;
                break;
            }
        } 

        // Check West
        for (int col = startCol - 1; col >= 0; col--)
        {
            if (forest[startRow, col] >= height)
            {
                visibleW = false;
                break;
            }
        }

        Console.WriteLine(String.Format("({0},{1})\tN:{2}\tE:{3}\tS:{4}\tW:{5}", startRow, startCol, visibleN, visibleE, visibleS, visibleW));
        return visibleN || visibleE || visibleS || visibleW;
    }
    public static void Main(string[] args)
    {
        // Read in row of tree heights
        string[] rows = System.IO.File.ReadAllLines(@"C:\Users\Tom\Documents\Advent\Day 8 - Tree Heights\Day 8 - Tree Heights\data_test.txt");

        int numRows = rows.Length;
        int numCols = rows[0].Length;
        int[,] forest = new int[numRows, numCols];
        // Each row is a string of ints, need to read and convert each one
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                forest[row, col] = (int)Char.GetNumericValue(rows[row][col]);
            }

        }

        // Target of the challenge
        int numVisibleTrees = 0;
        // Check each tree
        // Determine if it's visible
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                bool visible = isVisible(row, col, forest);
                if(visible)
                {
                    numVisibleTrees++;
                }
                Console.WriteLine(String.Format("({0},{1}) visibility: {2}\n", row, col, visible));
            }

        }
        Console.WriteLine(String.Format("There are {0} visible trees", numVisibleTrees));

    }
    
}





