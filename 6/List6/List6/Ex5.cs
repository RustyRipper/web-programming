
namespace List6
{
    class Ex5
    {
        public static string PadBoth(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft).PadRight(length);

        }
        public static void DrawCard(string name, string lName = "Kowalski", string borderMark = "X", int borderWidth = 2, int minWidth = 10)
        {
            for (int i = 0; i < borderWidth * 2 + 2; i++)
            {
                for (int j = 0; j < minWidth; j++)
                {

                    if (i - borderWidth == 0 && j >= borderWidth && j < minWidth - borderWidth)
                    {
                        string line = PadBoth(name, minWidth - (2 * borderWidth));
                        System.Console.Write(line);
                        j += line.Length-1;

                    }
                    else if (i + borderWidth == borderWidth*2+1 && j >= borderWidth && j < minWidth - borderWidth)
                    {
                        string line = PadBoth(lName, minWidth - (2 * borderWidth));
                        System.Console.Write(line);
                        j += line.Length-1;

                    }
                    else {
                        System.Console.Write(borderMark);
                    }
                    
                }
                System.Console.WriteLine();
            }

        }
        public static void test()
        {
            Ex5.DrawCard("Ryszard", "Rys", "X", 2, 20);
            DrawCard("Ryszard", "Rys", "X", minWidth: 12);


            DrawCard("Ryszard", borderWidth: 5, minWidth:20);
        }
    }
}
