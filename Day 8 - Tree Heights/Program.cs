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
    // Scenic score is the number of trees visible in each direction before reaching an edge, or a higher tree
    public static int scenicScore(int startRow, int startCol, int[,] forest)
    {
        int height = forest[startRow, startCol];
        int scoreN = 0;
        int scoreE = 0;
        int scoreS = 0;
        int scoreW = 0;

        // Check North
        for (int row = startRow-1; row >= 0; row--)
        {
            scoreN++;
            if (forest[row, startCol] >= height)
            {
                break;
            }
        }
        // Check South
        for (int row = startRow + 1; row < forest.GetLength(0); row++)
        {
            scoreS++;
            if (forest[row, startCol] >= height)
            {
                break;
            }
        }
        // Check East
        for (int col = startCol + 1; col < forest.GetLength(1); col++)
        {
            scoreE++;
            if (forest[startRow, col] >= height)
            {
                break;
            }
        } 

        // Check West
        for (int col = startCol - 1; col >= 0; col--)
        {
            scoreW++;
            if (forest[startRow, col] >= height)
            {
                break;
            }
        }

        Console.WriteLine(String.Format("({0},{1})\tN:{2}\tE:{3}\tS:{4}\tW:{5}", startRow, startCol, scoreN, scoreE, scoreS, scoreW));
        return scoreN * scoreE * scoreS * scoreW;
    }
    public static void Main(string[] args)
    {
        // Read in row of tree heights
        //string[] rows = System.IO.File.ReadAllLines(@"C:\Users\Tom\Documents\Advent\Day 8 - Tree Heights\Day 8 - Tree Heights\data_test.txt");
        string[] rows = System.IO.File.ReadAllLines(@"C:\Users\Tom\Documents\Advent\Day 8 - Tree Heights\Day 8 - Tree Heights\data_full.txt");
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

        // Check each tree
        // Determine ScenicScore
        // Store the highest score
        int highestScenicScore = 0;
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                int score = scenicScore(row, col, forest);
                if (score > highestScenicScore)
                {
                    highestScenicScore = score;
                }
                Console.WriteLine(String.Format("({0},{1}) score: {2}\n", row, col, score));
            }

        }
        Console.WriteLine(String.Format("The best tree has a score of {0}", highestScenicScore));

    }
    
}





