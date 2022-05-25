using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Arkanoid
{
    class Program
    {
        static RenderWindow window;

        static Texture ballTexture;
        static Texture platformkTexture;
        static Texture blockTexture;

        static Sprite platform;
        static Sprite[] blocks;

        static Ball ball;

        public static void SetStartPosition()
        {
            int index = 0;

            for(int y = 0; y < 10; y++)
            {
                for(int x = 0; x < 10; x++)
                {                    
                    blocks[index].Position = new Vector2f(x * (blocks[index].TextureRect.Width + 15) + 75, y * (blocks[index].TextureRect.Height + 15) + 50);
                    index++;
                }
            }

            platform.Position = new Vector2f(400, 500);
            ball.sprite.Position = new Vector2f(375, 400);
        }


        static void Main(string[] args)
        {

            window = new RenderWindow(new VideoMode(800, 600), "Arkanoid");
            window.Closed += Window_Closed;
            window.SetFramerateLimit(60);

            ballTexture = new Texture("Ball.png");
            platformkTexture = new Texture("Stick.png");
            blockTexture = new Texture("Block.png");

            ball = new Ball(ballTexture);
            platform = new Sprite(platformkTexture);
            blocks = new Sprite[100];

            for( int i = 0; i < blocks.Length; i++) blocks[i] = new Sprite(blockTexture);
            

            SetStartPosition();


            while (window.IsOpen == true)
            {
                window.Clear();

                window.DispatchEvents();

                if(Mouse.IsButtonPressed(Mouse.Button.Left) == true)
                {
                    ball.Start(5, new Vector2f(0, -1));
                }

                ball.Move(new Vector2i(0,0), new Vector2i(800, 600));

                ball.CheckCollision(platform, "Platform");
                for (int i = 0; i < blocks.Length; i++)
                {
                    if(ball.CheckCollision(blocks[i], "Block") == true)
                    {
                        blocks[i].Position = new Vector2f(1000, 1000);
                        break;
                    }
                }
                

                platform.Position = new Vector2f(Mouse.GetPosition(window).X - platform.TextureRect.Width / 2, platform.Position.Y);

                //Draw
                window.Draw(ball.sprite);
                window.Draw(platform);

                for(int i = 0; i < blocks.Length; i++)
                {
                    window.Draw(blocks[i]);
                }

                window.Display();

            }

        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
