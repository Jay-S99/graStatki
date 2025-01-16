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
            for (int i = 0; i < BoardSize; i++)
            {
                Console.Write(i);
                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write(" " + board[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void PlayGame()
        {
            char[,] player1Board = CreateBoard();
            char[,] player2Board = CreateBoard();

            Console.WriteLine("Gracz 1: ustaw swoje statki.");
            PlaceShips(player1Board);
            Console.Clear();

            Console.WriteLine("Gracz 2: ustaw swoje statki.");
            PlaceShips(player2Board);
            Console.Clear();

            bool player1Turn = true;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(player1Turn ? "Tura Gracza 1" : "Tura Gracza 2");
                char[,] opponentBoard = player1Turn ? player2Board : player1Board;

                DisplayBoard(opponentBoard);

                Console.Write("Podaj wiersz: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Podaj kolumnę: ");
                int col = int.Parse(Console.ReadLine());

                if (Shoot(opponentBoard, row, col))
                {
                    if (AreAllShipsSunk(opponentBoard, row, col))
                    {
                        Console.WriteLine(player1Turn ? "Gracz 1 wygrywa!" : "Gracz 2 wygrywa!");
                        break;
                    }
                }

                player1Turn = !player1Turn;
            }
        }

        static void PlaceShips(char[,] board)
        {
            int[] shipSizes = { 5, 4, 3, 3, 2 };

            foreach (int size in shipSizes)
            {
                bool placed = false;
                while (!placed)
                {
                    Console.WriteLine($"Umieść statek o długości {size}: ");
                    Console.Write("Podaj wiersz: ");
                    int row = int.Parse(Console.ReadLine());
                    Console.Write("Podaj kolumne: ");
                    int col = int.Parse(Console.ReadLine());
                    Console.Write("Poziomo (h) czy pionowo (v)?: ");
                    char direction = char.Parse(Console.ReadLine());

                    if (CanPlaceShip(board, row, col, direction))
                    {
                        PlaceShip(board, row, col, size, direction);
                        placed = true;
                        DisplayBoard(board);
                    }
                    else
                    {
                        Console.WriteLine("Nie można umieścić statku w tym miejscu! Dawaj jeszcze raz ;)");
                    }
                }


            }

        }
        static bool CanPlaceShip(char[,] board, int row, int col, int size, char direction)
        {
            if (direction == 'h')
            {
                if (col + size > BoardSize) { return false; }
                for (int i = 0; i < size; i++)
                {
                    if (board[row, col + i] != '.') { return false; }
                }
            }
            else if (direction == 'v')
            {
                if (row + size > BoardSize) return false;
                for (int i = 0; i < size; i++)
                {
                    if (board[row + i, col] != '.') return false;
                }
            }
            return true;
        }

        static void PlaceShip(char[,] board, int row, int col, int size, char direction)
        {
            if (direction == 'h')
            {
                for (int i = 0; i < size; i++)
                {
                    board[row, col + i] = 'S';
                }
            }
            else if (direction == 'v')
            {
                for (int i = 0; i < size; i++)
                {
                    board[row + i, col] = 'S';
                }
            }
        }
        static void Main(string[] args)
        {
            char[,] board = CreateBoard();
            DisplayBoard(board);
        }
    }
}
