using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Gun.Map
{
    public class MapObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle { get; set; }

        public MapObject(Texture2D Texture,Vector2 Position)
        {
            this.Texture = Texture;
            this.Position = Position;
        }

        public void draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(Texture,Position,Color.White);
        }

        

    }
}
