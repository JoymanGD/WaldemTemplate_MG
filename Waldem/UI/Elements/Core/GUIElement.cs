using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Waldem.GameManagement;

namespace Waldem.UI
{
    public abstract class GUIElement
    {
        public Vector2 Position { get; protected set; }
        protected SpriteBatch SpriteBatch { get; private set; }
        protected GUIProcessor Processor { get; private set; }

        public GUIElement(Vector2 position){
            Processor = WaldemGame.Instance.Services.GetService<GUIProcessor>();
            Processor.AddElement(this);

            SpriteBatch = WaldemGame.Instance.SpriteBatch;

            Position = position;
        }

        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}