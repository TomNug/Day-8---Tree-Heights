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
                Console.WriteLine(String.Format("Row is {0}, element is {1}", rows[row], rows[row][col]));
                forest[row, col] = (int)Char.GetNumericValue(rows[row][col]);
            }

        }
    }
    
}





