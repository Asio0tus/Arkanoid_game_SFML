﻿using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Arkanoid
{
    class Field
    {
        public Block[] blocks;

        

        public void GenerateField(int level, Texture strong1, Texture strong2, Texture strong3)
        {

            Random rnd = new Random();

            int index = 0;
            
            if(level == 1)
            {
                blocks = new Block[40];
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        blocks[index] = new Block();

                        blocks[index].strength = rnd.Next(1, 3);
                        
                        if (blocks[index].strength == 1) blocks[index].sprite = new Sprite(strong1);
                        if (blocks[index].strength == 2) blocks[index].sprite = new Sprite(strong2);
                        

                        blocks[index].sprite.Position = new Vector2f(x * (blocks[index].sprite.TextureRect.Width + 15) + 75, y * (blocks[index].sprite.TextureRect.Height + 15) + 50);


                        index++;
                    }
                }
            }

            if(level == 2)
            {
                blocks = new Block[60];
                for (int y = 0; y < 6; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        blocks[index] = new Block();

                        blocks[index].strength = rnd.Next(1, 4);
                        
                        if (blocks[index].strength == 1) blocks[index].sprite = new Sprite(strong1);
                        if (blocks[index].strength == 2) blocks[index].sprite = new Sprite(strong2);
                        if (blocks[index].strength == 3) blocks[index].sprite = new Sprite(strong3);


                        blocks[index].sprite.Position = new Vector2f(x * (blocks[index].sprite.TextureRect.Width + 15) + 75, y * (blocks[index].sprite.TextureRect.Height + 15) + 50);


                        index++;
                    }
                }
            }

            if(level == 3)
            {
                blocks = new Block[100];
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        blocks[index] = new Block();
                                                
                        blocks[index].strength = rnd.Next(2, 4);
                                                
                        if (blocks[index].strength == 2) blocks[index].sprite = new Sprite(strong2);
                        if (blocks[index].strength == 3) blocks[index].sprite = new Sprite(strong3);


                        blocks[index].sprite.Position = new Vector2f(x * (blocks[index].sprite.TextureRect.Width + 15) + 75, y * (blocks[index].sprite.TextureRect.Height + 15) + 50);


                        index++;
                    }
                }
            }

            
        }
    }
}
