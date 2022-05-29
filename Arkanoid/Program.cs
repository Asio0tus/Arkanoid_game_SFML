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
        static Texture blockTextureStrong1;
        static Texture blockTextureStrong2;
        static Texture blockTextureStrong3;
        static Texture backgroundTexture;
        static Texture butttonLevel1Texture;
        static Texture butttonLevel2Texture;
        static Texture butttonLevel3Texture;

        static Sprite platform;        
        static Field field;

        static Ball ball;
        static MainMenu mainMenu;
        

        static bool play = false;
        static bool start = false;
        static bool gameOver = false;

        public static void SetStartPosition()
        {            
            platform.Position = new Vector2f(400, 500);
            ball.sprite.Position = new Vector2f(platform.Position.X + platform.Texture.Size.X * 0.5f, platform.Position.Y - ball.sprite.Texture.Size.Y);
        }


        static void Main(string[] args)
        {

            window = new RenderWindow(new VideoMode(800, 600), "Arkanoid");
            window.Closed += Window_Closed;
            window.SetFramerateLimit(60);

            ballTexture = new Texture("Ball.png");
            platformkTexture = new Texture("Stick.png");
            blockTextureStrong1 = new Texture("Block3.png");
            blockTextureStrong2 = new Texture("Block2.png");
            blockTextureStrong3 = new Texture("Block1.png");
            backgroundTexture = new Texture("background.png");
            butttonLevel1Texture = new Texture("buttonlevel1.png");
            butttonLevel2Texture = new Texture("buttonlevel2.png");
            butttonLevel3Texture = new Texture("buttonlevel3.png");

            ball = new Ball(ballTexture);
            platform = new Sprite(platformkTexture);
           
            field = new Field();

            mainMenu = new MainMenu(backgroundTexture, butttonLevel1Texture, butttonLevel2Texture, butttonLevel3Texture);

                      
                        


            while (window.IsOpen == true)
            {
                while(play == false)
                {
                    window.Clear();

                    window.DispatchEvents();

                    if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
                    {
                        mainMenu.ChoiceLevel(window);
                    }

                    if (mainMenu.level > 0)
                    {
                        play = true;
                        field.GenerateField(mainMenu.level, blockTextureStrong1, blockTextureStrong2, blockTextureStrong3);
                        SetStartPosition();
                    }
                        

                    

                    window.Draw(mainMenu.background);
                    window.Draw(mainMenu.butttonLevel1);
                    window.Draw(mainMenu.butttonLevel2);
                    window.Draw(mainMenu.butttonLevel3);

                    window.Display();
                }

                while (play == true)
                {


                    window.Clear();

                    window.DispatchEvents();


                    if (start == false)
                    {
                        if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
                        {
                            ball.Start(5, new Vector2f(0, -1));
                            start = true;
                        }

                        ball.sprite.Position = new Vector2f(platform.Position.X + platform.Texture.Size.X * 0.5f - ball.sprite.Texture.Size.X * 0.5f, platform.Position.Y - ball.sprite.Texture.Size.Y);

                    }

                    if (start == true)
                    {
                        ball.Move(new Vector2i(0, 0), new Vector2i(800, 600));

                        if (ball.sprite.Position.Y > 800)
                        {
                            ball.health -= 1;
                            start = false;
                        }

                    }

                    ball.CheckCollision(platform, "Platform");
                    for (int i = 0; i < field.blocks.Length; i++)
                    {
                        if (ball.CheckCollision(field.blocks[i].sprite, "Block") == true)
                        {
                            field.blocks[i].strength -= 1;

                            if (field.blocks[i].strength == 0) field.blocks[i].sprite.Position = new Vector2f(1000, 1000);
                            if (field.blocks[i].strength == 1) field.blocks[i].sprite.Texture = blockTextureStrong1;
                            if (field.blocks[i].strength == 2) field.blocks[i].sprite.Texture = blockTextureStrong2;

                            break;
                        }
                    }



                    platform.Position = new Vector2f(Mouse.GetPosition(window).X - platform.TextureRect.Width / 2, platform.Position.Y);
                    if (Mouse.GetPosition(window).X < 0 + platform.Texture.Size.X * 0.5f) platform.Position = new Vector2f(0, platform.Position.Y);
                    if (Mouse.GetPosition(window).X > 800 - platform.Texture.Size.X * 0.5f) platform.Position = new Vector2f(800 - platform.Texture.Size.X, platform.Position.Y);



                    //Draw
                    window.Draw(ball.sprite);
                    window.Draw(platform);

                    for (int i = 0; i < field.blocks.Length; i++)
                    {
                        window.Draw(field.blocks[i].sprite);
                    }

                    window.Display();
                }

            }

        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
