using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Gun.Map
{
    public class Map
    {
        MapObject backGround;
        List<MapObject> mapObjects;

        public void draw(SpriteBatch spriteBatch)
        {

            backGround.draw(spriteBatch);
            foreach (MapObject obj in mapObjects)
            {
                obj.draw(spriteBatch);
            }
        }
    }

   


}
