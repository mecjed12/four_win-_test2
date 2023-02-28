using System;

class FourInARow
{   


   

    // das ist noch eine änderung und eine zweite
    private static char[,] board = new char[6, 7];
    private static bool playerOneTurn = true;

    static void Main(string[] args)
    {
        // Initialize the board with empty spaces
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                board[row, col] = ' ';
            }
        }

        // Start the game loop
        while (true)
        {
            // Print the current board state
            Console.Clear();
            PrintBoard();

            // Get the current player's move
            int col = GetPlayerMove();

            // Check if the move is valid
            if (!IsMoveValid(col))
            {
                Console.WriteLine("That column is full. Please choose another.");
                Console.ReadLine();
                continue;
            }

            // Make the move and check if the game is over
            if (MakeMove(col))
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine($"Player {(playerOneTurn ? "1" : "2")} wins!");
                break;
            }

            // Switch to the other player's turn
            playerOneTurn = !playerOneTurn;
        }
    }

    private static void PrintBoard()
    {
        Console.WriteLine("  1 2 3 4 5 6 7");
        Console.WriteLine("---------------");
        for (int row = 0; row < 6; row++)
        {
            Console.Write("| ");
            for (int col = 0; col < 7; col++)
            {
                Console.Write($"{board[row, col]}| ");
            }
            Console.WriteLine();
            Console.WriteLine("---------------");
        }
    }

    private static int GetPlayerMove()
    {
        Console.WriteLine($"Player {(playerOneTurn ? "1" : "2")}, enter a column number (1-7):");
        int col = int.Parse(Console.ReadLine()) - 1;
        return col;
    }

    private static bool IsMoveValid(int col)
    {
        if (col < 0 || col > 6)
        {
            return false;
        }

        return board[0, col] == ' ';
    }

    private static bool MakeMove(int col)
    {
        for (int row = 5; row >= 0; row--)
        {
            if (board[row, col] == ' ')
            {
                board[row, col] = (playerOneTurn ? 'X' : 'O');
                return CheckForWin(row, col);
            }
        }

        return false;
    }

    private static bool CheckForWin(int row, int col)
    {
        char symbol = (playerOneTurn ? 'X' : 'O');

        // Check for horizontal win
        for (int c = Math.Max(col - 3, 0); c <= Math.Min(col + 3, 6); c++)
        {
            if (board[row, c] == symbol &&
                board[row, c + 1] == symbol &&
                board[row, c + 2] == symbol &&
                board[row, c + 3] == symbol)
            {
                return true;
            }
        }

        // Check for vertical win
        for (int r = Math.Max(row - 3, 0); r <= Math.Min(row + 3, 5); r++)
        {
            if (board[r, col] == symbol &&
                board[r + 1, col] == symbol &&
                board[r + 2, col] == symbol &&
                board[r + 3, col] == symbol)
            {
                return true;
            }
        }

        // Check for diagonal win (top-left to bottom-right)
        for (int offset = -3; offset <= 3; offset++)
        {
            if (col + offset < 0 || col + offset > 6 ||
                row + offset < 0 || row + offset > 5 ||
                col + offset + 1 < 0 || col + offset + 1 > 6 ||
                row + offset + 1 < 0 || row + offset + 1 > 5 ||
                col + offset + 2 < 0 || col + offset + 2 > 6 ||
                row + offset + 2 < 0 || row + offset + 2 > 5 ||
                col + offset + 3 < 0 || col + offset + 3 > 6 ||
                row + offset + 3 < 0 || row + offset + 3 > 5)
            {
                continue;
            }

            if (board[row + offset, col + offset] == symbol &&
                board[row + offset + 1, col + offset + 1] == symbol &&
                board[row + offset + 2, col + offset + 2] == symbol &&
                board[row + offset + 3, col + offset + 3] == symbol)
            {
                return true;
            }
        }

        // Check for diagonal win (top-right to bottom-left)
        for (int offset = -3; offset <= 3; offset++)
        {
            if (col - offset < 0 || col - offset > 6 ||
                row + offset < 0 || row + offset > 5 ||
                col - offset - 1 < 0 || col - offset - 1 > 6 ||
                row + offset + 1 < 0 || row + offset + 1 > 5 ||
                col - offset - 2 < 0 || col - offset - 2 > 6 ||
                row + offset + 2 < 0 || row + offset + 2 > 5 ||
                col - offset - 3 < 0 || col - offset - 3 > 6 ||
                row + offset + 3 < 0 || row + offset + 3 > 5)
            {
                continue;
            }

            if (board[row + offset, col - offset] == symbol &&
                board[row + offset + 1, col - offset - 1] == symbol &&
                board[row + offset + 2, col - offset - 2] == symbol &&
                board[row + offset + 3, col - offset - 3] == symbol)
            {
                return true;
            }
        }

        return false;
    }
}

