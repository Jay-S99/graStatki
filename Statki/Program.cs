namespace Statki
{
    internal class Program
    {
        void PlaceShips(char[,] board)
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
                        PlaceShips(board, row, col, direction);
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
        bool CanPlaceShip(char[,] board, int row, int col, int size, char direction)
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
                    if(board[row + i, col] != '.') return false;
                }
            }
            return true;
        }

        void PlaceShip(char[,] board, int row, int col, int size, char direction) 
        {
            if(direction == 'h')
            {
                for(int i = 0; i < size;i++)
                {
                    board[row, col + i] = 'S';
                }
            }
            else if (direction == 'v')
            {
                for(int i =0; i < size;i++)
                {
                    board[row + i, col] = 'S';
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
