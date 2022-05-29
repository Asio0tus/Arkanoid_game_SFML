using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Arkanoid
{
    class Field
    {
        public Block[] blocks = new Block[100];

        

        public void GenerateField(int level, Texture strong1, Texture strong2, Texture strong3)
        {

            Random rnd = new Random();

            int index = 0;                        

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    blocks[index] = new Block();

                    if (level == 1) blocks[index].strength = rnd.Next(1, 2);
                    if (level == 2) blocks[index].strength = rnd.Next(1, 3);
                    if (level == 3) blocks[index].strength = rnd.Next(1, 4);

                    if (blocks[index].strength == 1) blocks[index].sprite = new Sprite(strong1);
                    if (blocks[index].strength == 2) blocks[index].sprite = new Sprite(strong2);
                    if (blocks[index].strength == 3) blocks[index].sprite = new Sprite(strong3);


                    blocks[index].sprite.Position = new Vector2f(x * (blocks[index].sprite.TextureRect.Width + 15) + 75, y * (blocks[index].sprite.TextureRect.Height + 15) + 50);

                    
                    index++;
                }
            }
        }
    }
}
