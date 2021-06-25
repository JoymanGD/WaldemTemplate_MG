using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Waldem.Patterns;
using Waldem.SceneManagement.SceneManager;
using Waldem.SceneManagement;
using Waldem.Helpers;
using System;
using System.Linq;

namespace Waldem.GameManagement
{
    public class WaldemGame : GameSingleton<WaldemGame>
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }
        public ISceneManager SceneManager { get; private set; }

        public WaldemGame(){
            Graphics = new GraphicsDeviceManager(this);
            Graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void SetSceneManager(ISceneManager sceneManager){
            SceneManager = sceneManager;
        }

        public void SetResolution(int width, int height){
            Graphics.PreferredBackBufferHeight = height;
            Graphics.PreferredBackBufferWidth = width;
            Graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            Drawer.Initialize(Content);
            base.LoadContent();
        }

        protected override void Initialize()
        {   
            SetSceneManager(new DefaultSceneManager());
            
            #region AddingScenes
            // add scenes here
            var type = typeof(IScene);
            var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p));

            foreach (var item in types)
            {
                if(item.BaseType == type){
                    var t = item.UnderlyingSystemType;
                    var newScene = Activator.CreateInstance(t);
                    SceneManager.AddScene(newScene as IScene);
                }
            }
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