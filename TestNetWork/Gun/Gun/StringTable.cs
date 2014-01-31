using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gun
{
    public class StringTable : List<String>
    {
        Vector2 coordinate;

        bool input;
        int index;

      //  CoolDown coolDown;

        int interval;
        int uotLength;
        int height;

        public StringTable()
        {
            coordinate = new Vector2();

            interval = 20;
            uotLength = 100;
            height = 10;

            input = false;
           // coolDown = new CoolDown(10);
        }
        public StringTable(Vector2 coordinate)
        {
            this.coordinate = coordinate;

            interval = 20;
            uotLength = 100;
            height = 10;

            input = false;
           // coolDown = new CoolDown(10);
        }


        public void back(int index)
        {
            if (this.Count > index)
            {
                if (this[index].Length > 0)
                {
                    this[index] = this[index].Remove(this[index].Length - 1);
                }
            }
        }


        public Vector2 Coordinate
        {
            set { this.coordinate = value; }
            get { return this.coordinate; }
        }
        /// <summary>
        /// вертикальный интервал
        /// </summary>
        public int Interval
        {
            set { this.interval = value; }
            get { return this.interval; }
        }
        /// <summary>
        /// длинна для вывода строки
        /// </summary>
        public int OutLength
        {
            set { this.uotLength = value; }
            get { return this.uotLength; }
        }
        /// <summary>
        /// высота строки
        /// </summary>
        public int Height
        {
            set { this.height = value; }
            get { return this.height; }
        }

        /// <summary>
        ///  Функция расчитывает координату для вывода строки
        /// </summary>
        /// <param name="ind"> Индекс </param>
        /// <returns> Координата вывода</returns>
        public Vector2 getCoord(int ind)
        {
            Vector2 vector = new Vector2();

            vector.X = coordinate.X;
            vector.Y = coordinate.Y + ind * (height + interval);

            return vector;
        }
        /// <summary>
        /// Фунция выводит массив строк исходя из свойств interval, length, height по координате coordinate.
        /// </summary>
        /// <param name="spriteBatch"> Обьект для рисования</param>
        /// <param name="font"> Шрифт</param>
        public void draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            int i = 0;
            foreach (String str in this)
            {
                spriteBatch.DrawString(font, str, getCoord(i++), Color.Black);
            }
        }

        public void inputStart(int index)
        {
            input = true;
            this.index = index;
        }
        public void inputStop(int index)
        {
            input = false;
            this.index = index;
        }

        

    }
}
