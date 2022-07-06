// Program.cs ~ 7Games ~ https://github.com/7Games/tic-tac-toe-cs

namespace TicTacToe {
    class Program {

        //Bools
        static bool isRunning = true;

        //Strings
        static string board = "╔═══╦═══╦═══╗\n║   ║   ║   ║\n╠═══╬═══╬═══╣\n║   ║   ║   ║\n╠═══╬═══╬═══╣\n║   ║   ║   ║\n╚═══╩═══╩═══╝\n";

        //Ints
        //0 = no shape;     1 = cross;      2 = circle;
        static int[,] shapeLocations = new int[,] { {0, 0, 0},
                                                    {0, 0, 0},
                                                    {0, 0, 0}};

        static int[,] spaceLocations = new int[,] { {16, 20, 24}, 
                                                    {44, 48, 52}, 
                                                    {72, 76, 80}};
        static int cursorX = 1;
        static int cursorY = 1;
        //0 = cross;    1 = circle;
        static int turn = 0;

        static void Main(string[] args) {
            Console.Clear();
            while(isRunning){
                Console.SetCursorPosition(0, 0);
                //Turn the board into a char array
                char[] screen = board.ToCharArray();

                //Adds the 'x' and 'o' to the board
                for(int i = 0; i < 3; i++) {
                    for(int j = 0; j < 3; j++) {
                        if(shapeLocations[i, j] == 1)
                            screen[spaceLocations[i, j]] = 'x';
                    }
                    for(int k = 0; k < 3; k++) {
                        if(shapeLocations[i, k] == 2)
                            screen[spaceLocations[i, k]] = 'o';
                    }
                }

                //Adds the cursor to the char board
                screen[spaceLocations[cursorY, cursorX]] = '#';

                char[] info = new string("Use the arrow keys to move\nthe cursor and press space to place 'x'.").ToCharArray();

                for(int i = 0; i<info.Length; i++) {
                    screen.Append(info[i]);
                }

                for(int i = 0; i<screen.Length; i++) {
                    Console.ForegroundColor = ConsoleColor.White;
                    if(screen[i] == 'x') {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if(screen[i] == 'o') {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(screen[i]);
                }
                
                //Get input from Console
                switch(Console.ReadKey().Key){
				case ConsoleKey.UpArrow:
                    cursorY-=1;
					break;
				case ConsoleKey.DownArrow:
                    cursorY+=1;
					break;
				case ConsoleKey.RightArrow:
                    cursorX+=1;
					break;
				case ConsoleKey.LeftArrow:
                    cursorX-=1;
					break;
                }

                if(cursorX<0) {
                    cursorX = 0;
                }
                if(cursorX>2) {
                    cursorX = 2;
                }
                if(cursorY<0) {
                    cursorY = 0;
                }
                if(cursorY>2) {
                    cursorY = 2;
                }
            }
        }
    }
}