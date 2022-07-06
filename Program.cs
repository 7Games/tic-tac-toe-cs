// Program.cs ~ 7Games ~ https://github.com/7Games/tic-tac-toe-cs

namespace TicTacToe {
    class Program {

        //===================================================
        //=====================Variables=====================
        //===================================================
        //==Bools==
        static bool isRunning = true;
        static bool gameOver = false;

        //==Strings==
        static string board = "╔═══╦═══╦═══╗\n║   ║   ║   ║\n╠═══╬═══╬═══╣\n║   ║   ║   ║\n╠═══╬═══╬═══╣\n║   ║   ║   ║\n╚═══╩═══╩═══╝\n";
        static string winner = "none";

        //==Ints==
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

        //==ConsoleColor==
        static ConsoleColor xColor = ConsoleColor.Red;
        static ConsoleColor oColor = ConsoleColor.Green;
        static ConsoleColor boardColor = ConsoleColor.White;
        static ConsoleColor cursorColor = ConsoleColor.Yellow;

        //===================================================
        //=====================Functions=====================
        //===================================================
        static void drawScreen(char[] screen) {
            //Draw the screen
            for(int i = 0; i<screen.Length; i++) {
                //Sets the board color
                Console.ForegroundColor = boardColor;
                //Sees if there any 'x' or 'o' in the board and-
                //- if there are then colors them
                if(screen[i] == 'x') {
                    Console.ForegroundColor = xColor;
                }
                if(screen[i] == 'o') {
                    Console.ForegroundColor = oColor;
                }
                //Sets the cursor color depending on if they-
                //- are on an 'x', 'o' or nothing
                if(screen[i] == '#') {
                    Console.ForegroundColor = cursorColor;
                    if(shapeLocations[cursorY, cursorX] == 1) {
                        Console.ForegroundColor = xColor;
                    }
                    if(shapeLocations[cursorY, cursorX] == 2) {
                        Console.ForegroundColor = oColor;
                    }
                }
                //Writes the character to the screen
                Console.Write(screen[i]);
            }
        }

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
                if(!gameOver)
                    screen[spaceLocations[cursorY, cursorX]] = '#';

                //Draws the screen
                drawScreen(screen);
                
                //Draws the text relevent to if the game is over
                if(!gameOver) {
                    Console.WriteLine("Use [ARROW KEYS] to move the cursor\nand press [SPACE] to place your token");
                } else {
                    Console.Clear();
                    drawScreen(screen);
                    Console.WriteLine(winner + " wins!\nPress [R] to restart.");
                }
                
                //Get input from Console
                switch(Console.ReadKey().Key){
                //Movement Keys
				case ConsoleKey.UpArrow:
                    if(!gameOver)
                        cursorY-=1;
					break;
				case ConsoleKey.DownArrow:
                    if(!gameOver)
                        cursorY+=1;
					break;
				case ConsoleKey.RightArrow:
                    if(!gameOver)
                        cursorX+=1;
					break;
				case ConsoleKey.LeftArrow:
                    if(!gameOver)
                        cursorX-=1;
					break;
                //Places the token
                case ConsoleKey.Spacebar:
                    if(!gameOver) {
                        if(turn == 0) {
                            shapeLocations[cursorY, cursorX] = 1;
                            turn = 1;
                        } else {
                            shapeLocations[cursorY, cursorX] = 2;
                            turn = 0;
                        }
                    }
					break;
                //Resets the game
                case ConsoleKey.R:
                    Console.Clear();
                    winner = "none";
                    cursorX = 1;
                    cursorY = 1;
                    for(int i = 0; i<3; i++) {
                        for(int j = 0; j<3; j++) {
                            shapeLocations[i, j] = 0;
                        }
                    }
                    gameOver = false;
                    break;
                }

                //Checks to see if the cursor is out of bounds
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


                //===============================================
                //=================Line Detector=================
                //===============Warning: Very Bad===============
                //===============================================
                for(int i = 0; i < 3; i++) {
                    for(int j = 0; j < 3; j++) {
                        if(shapeLocations[i, j] == 1) {
                            //Horizontal
                            if(j == 0) {
                                if(shapeLocations[i, j+1] == 1) {
                                    if(shapeLocations[i, j+2] == 1) {
                                        gameOver = true;
                                        winner = "Cross";
                                    }
                                }
                            }
                            //Vertical
                            if(i == 0) {
                                if(shapeLocations[i+1, j] == 1) {
                                    if(shapeLocations[i+2, j] == 1) {
                                        gameOver = true;
                                        winner = "Cross";
                                    }
                                }
                            }

                            //Checking for diagonals
                            if(j == 0 && i == 0) {
                                if(shapeLocations[i+1, j+1] == 1) {
                                    if(shapeLocations[i+2, j+2] == 1) {
                                        gameOver = true;
                                        winner = "Cross";
                                    }
                                }
                            }
                            if(j == 2 && i == 0) {
                                if(shapeLocations[i+1, j-1] == 1) {
                                    if(shapeLocations[i+2, j-2] == 1) {
                                        gameOver = true;
                                        winner = "Cross";
                                    }
                                }
                            }
                        }
                    }
                    for(int k = 0; k < 3; k++) {
                        if(shapeLocations[i, k] == 2) {
                            //Horizontal
                            if(k == 0) {
                                if(shapeLocations[i, k+1] == 2) {
                                    if(shapeLocations[i, k+2] == 2) {
                                        gameOver = true;
                                        winner = "Circle";
                                    }
                                }
                            }
                            //Vertical
                            if(i == 0) {
                                if(shapeLocations[i+1, k] == 2) {
                                    if(shapeLocations[i+2, k] == 2) {
                                        gameOver = true;
                                        winner = "Circle";
                                    }
                                }
                            }

                            //Checking for diagonals
                            if(k == 0 && i == 0) {
                                if(shapeLocations[i+1, k+1] == 2) {
                                    if(shapeLocations[i+2, k+2] == 2) {
                                        gameOver = true;
                                        winner = "Circle";
                                    }
                                }
                            }
                            if(k == 2 && i == 0) {
                                if(shapeLocations[i+1, k-1] == 2) {
                                    if(shapeLocations[i+2, k-2] == 2) {
                                        gameOver = true;
                                        winner = "Circle";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}