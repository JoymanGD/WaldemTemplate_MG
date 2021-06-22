using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Waldem.Patterns;
using Waldem.SceneManagement.SceneManager;
using Waldem.Helpers;

namespace Waldem.GameManagement
{
    public class WaldemGame : Singleton<WaldemGame>
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }
        public ISceneManager SceneManager { get; private set; }

        public WaldemGame(){
            Graphics = new GraphicsDeviceManager(this);
            Graphics.GraphicsProfile = GraphicsProfile.HiDef;

            Graphics.PreferredBackBufferHeight = 1024;
            Graphics.PreferredBackBufferWidth = 768;
            Graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            Drawer.Initialize(Content);
            base.LoadContent();
        }

        protected override void Initialize()
        {   
            SceneManager = new DefaultSceneManager();
            
            #region AddingScenes
            // add scenes here
            #endregion

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            SceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            SceneManager.Draw(SpriteBatch);

            base.Draw(gameTime);
        }
    }
}