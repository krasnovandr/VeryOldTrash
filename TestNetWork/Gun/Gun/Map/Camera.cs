using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ClassesForSerialize;
using Microsoft.Xna.Framework.Input;

namespace Gun.Map
{
    public class Camera
    {
        public Matrix Transform {get; set;}
        public Vector2 Centre {get; set;}
        public float scale {get; set;}
        public float angle { get; set; }


        public Camera()
        {

            angle = (float)Math.PI * 2.0f;
            scale = 1.0f;

        }
        public void Update(Vector2 vect)
        {

            Centre = new Vector2(vect.X * scale - 450 * scale, vect.Y * scale - 350 * scale);

            if (GameConstants.keyboardState.IsKeyDown(Keys.F1))
            {
                scale += 0.01f;
            }
            if (GameConstants.keyboardState.IsKeyDown(Keys.F2))
            {
                scale -= 0.01f;
            }
            if (GameConstants.keyboardState.IsKeyDown(Keys.F3))
            {
                angle += (float)Math.PI / 90;
                // transform = Matrix.CreateTranslation(new Vector3(-centre, 0.0f)) *
                //   Matrix.CreateRotationZ(angle) * Matrix.CreateTranslation(new Vector3(vect, 0.0f));
                // Matrix.CreateTranslation(new Vector3(machine.Engine.getVector(), 0.0f));
            }
            if (GameConstants.keyboardState.IsKeyDown(Keys.F4))
            {
                angle -= (float)Math.PI / 90;
            }



            //Transform = Matrix.CreateScale(new Vector3(scale, scale, 0)) * Matrix.CreateRotationZ(angle) *
            //            Matrix.CreateTranslation(new Vector3(-Centre.X * scale, -Centre.Y * scale, 0));
            Transform = 
                //Matrix.CreateScale(new Vector3(scale, scale, 0)) * Matrix.CreateRotationZ(angle) *
                    Matrix.CreateTranslation(new Vector3(-Centre.X , 0, 0));

        }


    }
}
