using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
 * 
 * 
 * 
https://github.com/mattdesl/lwjgl-basics/wiki/ShaderLesson6


http://community.monogame.net/t/solved-normalmap-with-spritebatch/8543/4
http://rbwhitaker.wikidot.com/bump-map-shader-2
http://community.monogame.net/t/mod-tool-normal-maps/9292
http://community.monogame.net/t/solved-2d-image-normalmap-pixel-shader-only-lit-from-one-direction/2742
https://digitalerr0r.wordpress.com/2012/03/03/xna-4-0-shader-programming-4normal-mapping/
https://www.youtube.com/watch?v=y5FtEFtyaFo
http://www.dreamincode.net/forums/topic/271365-normal-mapping/
http://www.paulsprojects.net/tutorials/simplebump/simplebump.html
https://stackoverflow.com/questions/29042849/implementing-normal-mapping-using-opengl-glsl
http://www.mbsoftworks.sk/index.php?page=tutorials&series=1&tutorial=28
http://www.falloutsoftware.com/tutorials/gl/normal-map.html

     */

namespace Shaders_1
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteBatch backgroundSpriteBatch;
        Texture2D bgTexture;
        Texture2D normalTexture;
        Effect normalMapShader;


        Texture2D catTexture;
        Effect defaultShader;


        Vector2 catPosition = Vector2.Zero;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 1024;
            graphics.PreferredBackBufferWidth = 1024;
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
            bgTexture = Content.Load<Texture2D>("154");
            normalTexture = Content.Load<Texture2D>("154_norm");
            normalMapShader = Content.Load<Effect>("NormalMappingShader");

            catTexture = Content.Load<Texture2D>("cat");
            defaultShader = Content.Load<Effect>("DefaultShader");
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

            var kbState = Keyboard.GetState();
            if(kbState.IsKeyDown(Keys.A))
            {
                catPosition.X -= 5;
            }
            if (kbState.IsKeyDown(Keys.D))
            {
                catPosition.X += 5;
            }
            if (kbState.IsKeyDown(Keys.W))
            {
                catPosition.Y -= 5;
            }
            if (kbState.IsKeyDown(Keys.S))
            {
                catPosition.Y += 5;
            }

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
            spriteBatch.Draw(catTexture, catPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
