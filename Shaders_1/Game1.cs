using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shaders_1
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteBatch backgroundSpriteBatch;
        Texture2D bgTexture;
        Texture2D catTexture;
        Effect defaultShader;

        Texture2D noise;
        Texture2D perlinNoise;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundSpriteBatch = new SpriteBatch(GraphicsDevice);
            bgTexture = Content.Load<Texture2D>("xp_background");
            catTexture = Content.Load<Texture2D>("cat");
            defaultShader = Content.Load<Effect>("DefaultShader");


            noise = Content.Load<Texture2D>("noise");
            perlinNoise = Content.Load<Texture2D>("perlin_noise");
            // TODO: use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Vector2 screenMiddle = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);

            // TODO: Add your drawing code here

            backgroundSpriteBatch.Begin();
            backgroundSpriteBatch.Draw(bgTexture, Vector2.Zero, Color.White);
            backgroundSpriteBatch.End();

            spriteBatch.Begin(effect:defaultShader);
            spriteBatch.Draw(catTexture, screenMiddle - new Vector2 (catTexture.Width/2, catTexture.Height/2), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
