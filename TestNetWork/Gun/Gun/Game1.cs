using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ClassesForSerialize;
using TestNetWork;
using System.Threading;
using Game1;
using System.Windows.Forms;
using Size_ = System.Drawing.Size;
using Point_ = System.Drawing.Point;
namespace Gun
{


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Client client;
        Thread Thread;
        // PlayerInfo hero;
        Texture2D groundTexture;
        // Vector2 groundVector;
        Form form;
        FpsCounter fpsCounter;

        SpriteFont spriteFont;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            GameConstants.g = 0.45f;
            client = new Client();
            client.GameSession = new GameSession();
            client.GameSession.Player = new Player();
            client.GameSession.Player.PlayerInfo.HP = 10000;
            Random rnd = new Random(System.DateTime.Now.Second * System.DateTime.Now.Minute);

            client.GameSession.Player.PlayerInfo.teamNumber = rnd.Next(1, 100);

            this.Exiting += new EventHandler<EventArgs>(Game1_Exiting);

            // button.BackColor = System.Drawing.Color.White;
            IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = true;
            // button.Click += new EventHandler(button_Click);

            graphics.PreferredBackBufferWidth = 800;//800
            graphics.PreferredBackBufferHeight = 600;//600
            Thread = new Thread(client.startGameSession);

            Thread.Start();
        }

        void Game1_Exiting(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        void button_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GameConstants.bullet = Content.Load<Texture2D>("Texture//bullet");
            GameConstants.playerL = Content.Load<Texture2D>("Texture//playerL");

            GameConstants.playerR = Content.Load<Texture2D>("Texture//playerR");
            groundTexture = Content.Load<Texture2D>("Texture//ground");
            spriteFont = Content.Load<SpriteFont>("base");
            fpsCounter = new FpsCounter(spriteFont);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GameConstants.keyboardState = Keyboard.GetState();
            GameConstants.mouseState = Mouse.GetState();
            GameConstants.gameTime = gameTime;

            client.GameSession.update();

            fpsCounter.update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // spriteBatch.Begin();

            //spriteBatch.Begin();
     
            //spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred,
            BlendState.NonPremultiplied, null, null, null, null, client.GameSession.Camera.Transform);
            spriteBatch.Draw(groundTexture, new Vector2(0, 0), Color.White);
            if (client.GameSession.PlayersList != null)
            {
                for (int i = 0; i < client.GameSession.PlayersList.Count; i++)
                {
                    client.GameSession.PlayersList[i].draw(spriteBatch);
                }
            }

            if (client.GameSession.BulletsList != null)
            {
                for (int i = 0; i < client.GameSession.BulletsList.Count; i++)
                {
                    client.GameSession.BulletsList[i].draw(spriteBatch);
                }
            }
            lock (IpPort.locker)
            {
                client.stringTable.draw(spriteBatch, spriteFont);
            }

            spriteBatch.End();

            spriteBatch.Begin();
            fpsCounter.draw(spriteBatch, new Vector2(10, 10));
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
