namespace Statki
{
    internal class Program
    {
        const int BoardSize = 10;
        
        static char[,] CreateBoard()
        {
            char[,] board = new char[BoardSize, BoardSize];
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    board[i, j] = '.'; // . oznacza puste pole
                }
            }
            return board;
        }
        
        static void DisplayBoard(char[,] board)
        {
            Console.Write(" ");
            for (int i = 0; i < BoardSize; i++)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();
            for(int i = 0; i < BoardSize; i++)
            {
                Console.Write(i);
                for(int j = 0; j < BoardSize; j++)
                {
                    Console.Write(" " + board[i, j]);
                }
                Console.WriteLine();
            }
        }
        
        static void Main(string[] args)
        {
            char[,] board = CreateBoard();
            DisplayBoard(board);
        }
    }
}
