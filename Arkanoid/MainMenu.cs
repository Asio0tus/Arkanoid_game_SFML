using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Arkanoid
{
    class MainMenu
    {
        public Sprite background;
        public Sprite butttonLevel1;
        public Sprite butttonLevel2;
        public Sprite butttonLevel3;
        public int level = 0;

        public MainMenu(Texture background, Texture butttonLevel1, Texture butttonLevel2, Texture butttonLevel3)
        {
            this.background = new Sprite(background);
            this.butttonLevel1 = new Sprite(butttonLevel1);
            this.butttonLevel2 = new Sprite(butttonLevel2);
            this.butttonLevel3 = new Sprite(butttonLevel3);

            this.background.Position = new Vector2f(0, 0);
            this.butttonLevel1.Position = new Vector2f(200, 185);
            this.butttonLevel2.Position = new Vector2f(200, 320);
            this.butttonLevel3.Position = new Vector2f(200, 450);
        }

        public void ChoiceLevel(RenderWindow window)
        {
            if (butttonLevel1.GetGlobalBounds().Contains((Mouse.GetPosition(window).X), (Mouse.GetPosition(window).Y))) this.level = 1;
            if (butttonLevel2.GetGlobalBounds().Contains((Mouse.GetPosition(window).X), (Mouse.GetPosition(window).Y))) this.level = 2;
            if (butttonLevel3.GetGlobalBounds().Contains((Mouse.GetPosition(window).X), (Mouse.GetPosition(window).Y))) this.level = 3;
        }
    }
}
