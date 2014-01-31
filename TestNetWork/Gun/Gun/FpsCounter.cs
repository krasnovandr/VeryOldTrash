using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ClassesForSerialize;

namespace Game1
{
    class FpsCounter
    {
        int frames = 0;
        float time = 0.0f;
        int fps = 0;
        SpriteFont spriteFont;

        public FpsCounter(SpriteFont spriteFont)
        {
            this.spriteFont = spriteFont;
        }

        public void update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (time >= 1)
            {
                fps = frames;
                frames = 0;
                time = 0;
            }
        }

        public void draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            frames++;
            spriteBatch.DrawString(spriteFont, string.Format("FPS hack = {0}", fps.ToString()),
             vector, Color.Black);
        }
    }
}
