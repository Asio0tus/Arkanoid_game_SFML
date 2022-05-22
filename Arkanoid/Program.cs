using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Arkanoid
{
    class Program
    {
        static RenderWindow window;

        static float initRadius()
        {
            Vector2i mousePos = Mouse.GetPosition(window);

            double pif = Math.Pow((mousePos.X - 0), 2) + Math.Pow((mousePos.Y - 0), 2);

            float r = 100 * (float)pif / 1000000;

            Console.WriteLine(pif);
            Console.WriteLine(r);

            return r;

        }

        static void Main(string[] args)
        {

            window = new RenderWindow(new VideoMode(800, 600), "Arkanoid");
            window.Closed += Window_Closed;
            window.SetFramerateLimit(60);

            CircleShape circle = new CircleShape(10);
            circle.Position = new Vector2f(10, 10);
            circle.FillColor = Color.Red;

            while (window.IsOpen == true)
            {
                window.Clear();

                window.DispatchEvents();

                // логика игры

                Vector2i mousePos = Mouse.GetPosition(window);
                circle.Position = new Vector2f(mousePos.X - circle.Radius, mousePos.Y - circle.Radius);
                circle.Radius = initRadius();

                window.Draw(circle);

                window.Display();

            }

        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
