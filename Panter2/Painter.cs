using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;


    /// <summary>
    /// This is the main type for your game.
    /// </summary

    public class Painter : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


      

        Cannon Cannon;

        InputHelper inputhelper;

         static GameWorld gameWorld;

    public static Random Random { get; private set; }

    public static GameWorld GameWorld
    {
        get { return gameWorld; }
    }

    public static Vector2 ScreenSize { get; private set; }

    public Painter()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            inputhelper = new InputHelper();
        Random = new Random();
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

        MediaPlayer.IsRepeating = true;
        MediaPlayer.Play(Content.Load<Song>("snd_music"));
        gameWorld = new GameWorld(Content);

        ScreenSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);




        // TODO: use this.Content to load your game content here
    }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            inputhelper.Update();
          gameWorld.HandleInput(inputhelper);
            gameWorld.Update(gameTime);


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

    
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            gameWorld.Draw(gameTime, spriteBatch);


           
        }

     

    }

