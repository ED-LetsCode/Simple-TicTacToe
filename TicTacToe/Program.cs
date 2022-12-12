namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tic Tac Toe");
            Console.WriteLine("For 2 Players enter                      [1]");
            Console.WriteLine("For Player against the Computer enter    [2]\n");

            int gameMode = Convert.ToInt32(Console.ReadLine());

            if (gameMode == 1) Play2Vs2();
            else if (gameMode == 2) PlayVsComputer();
        }

        private static void PlayVsComputer()
        {
            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", };
            string player1 = "O", player2 = "X", actualPlayer = "O";
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Clear();
                PrintGameField(arr, actualPlayer);

                if (CheckIfPlayerWon(arr))
                {
                    Console.WriteLine($"Spieler {actualPlayer} hat gewonnen!");
                    break;
                }
                else if (i == 9)
                {
                    Console.WriteLine("Unentschieden");
                    break;
                }

                if (i % 2 == 0)
                {
                    int userInput = int.Parse(Console.ReadLine());
                    arr[userInput - 1] = player1;
                    actualPlayer = player1;
                }
                else
                {
                    int randomNumber = random.Next(0, 8);

                    while (arr[randomNumber] == player1)
                    {
                        randomNumber = random.Next(0, 8);
                    }

                    arr[randomNumber] = player2;
                    actualPlayer = player2;
                }
            }
        }

        private static void Play2Vs2()
        {
            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", };
            string player1 = "O", player2 = "X", actualPlayer = "O";

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Clear();
                PrintGameField(arr, actualPlayer);

                if (CheckIfPlayerWon(arr))
                {
                    Console.WriteLine($"Spieler {actualPlayer} hat gewonnen!");
                    break;
                }
                else if (i == 9)
                {
                    Console.WriteLine("Unentschieden");
                    break;
                }

                int userInput = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    arr[userInput - 1] = player1;
                    actualPlayer = player1;
                }
                else
                {
                    arr[userInput - 1] = player2;
                    actualPlayer = player2;
                }
            }
        }

        private static void PrintGameField(string[] arr, string actualPlayer)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[0]}  |  {arr[1]}  |  {arr[2]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[3]}  |  {arr[4]}  |  {arr[5]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[6]}  |  {arr[7]}  |  {arr[8]}");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"Actual player {actualPlayer}");
        }

        private static bool CheckIfPlayerWon(string[] arr)
        {
            //Horizontale überprüfung
            if (((arr[0] == arr[1]) && (arr[1] == arr[2])) || // <= Hier vergleichen wir ob die Felder 1 2 und 3 gleich sind
                ((arr[3] == arr[4]) && (arr[3] == arr[5])) || // <= Hier vergleichen wir ob die Felder 4 5 und 6 gleich sind
                ((arr[6] == arr[7]) && (arr[6] == arr[8])))   // <= Hier vergleichen wir ob die Felder 7 8 und 9 gleich sind
            {
                return true;
            }

            //Vertikal überprüfung
            if (((arr[0] == arr[3]) && (arr[3] == arr[6])) || //Hier vergleichen wir ob die Felder 0 3 und 6 gleich sind
                ((arr[1] == arr[4]) && (arr[4] == arr[7])) || //Hier vergleichen wir ob die Felder 1 4 und 7 gleich sind
                ((arr[2] == arr[5]) && (arr[5] == arr[8])))   //Hier vergleichen wir ob die Felder 2 5 und 8 gleich sind
            {
                return true;
            }

            //Diagonale überprüfung
            if ((arr[0] == arr[4]) && (arr[4] == arr[8]) ||
                (arr[2] == arr[4]) && (arr[4] == arr[6]))
            {
                return true;
            }

            return false;
        }
    }
}