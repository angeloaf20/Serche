using Serche.Graphics.Core.Window;

namespace Serche.Graphics.Core
{
    class Game
    {
        public static void Main(string[] args)
        {
            using (WindowManager gameWin = new WindowManager(1280, 720, "Serche"))
            {
                gameWin.Run();
            }
        }
    }
}
