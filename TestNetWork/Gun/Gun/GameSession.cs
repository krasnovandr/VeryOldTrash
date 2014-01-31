using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesForSerialize;
using Gun.Map;

namespace Gun
{
    public class GameSession
    {
        public Player Player { get; set; }
        public Bullet Bullet { get; set; }
        public List<Player> PlayersList { get; set; }
        public List<Bullet> BulletsList { get; set; }
        public Camera Camera { get; set; }

        public GameSession()
        {
            Camera = new Camera();
        }

        public void checkBoders()
        {
            if (Player.PlayerInfo.Position.X <= 0)
            {
                Player.PlayerInfo.Position.X = 0;
            }

            if (Player.PlayerInfo.Position.X >= 800)
            {
                Player.PlayerInfo.Position.X = 800;
            }

        }

        public void update()
        {
            Player.move();
            Player.CoolDown.addTime();
            checkBoders();
            if (GameConstants.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                if (Player.CoolDown.isReload() == true)
                {

                    Bullet = new Bullet();
                    Bullet.BulletInfo.teamNumber = Player.PlayerInfo.teamNumber;
                    if (Player.PlayerInfo.Direction == 2)
                    {
                        Bullet.BulletInfo.Speed = -Bullet.BulletInfo.Speed;
                        Bullet.BulletInfo.Position = new Microsoft.Xna.Framework.Vector2(Player.PlayerInfo.Position.X + 7, Player.PlayerInfo.Position.Y + 15);
                    }
                    else
                    {
                        Bullet.BulletInfo.Position = new Microsoft.Xna.Framework.Vector2(Player.PlayerInfo.Position.X + 31, Player.PlayerInfo.Position.Y + 15);
                    }
                    Player.CoolDown.clear();
                }


            }
            Camera.Update(Player.PlayerInfo.Position);
        }

    }
}
