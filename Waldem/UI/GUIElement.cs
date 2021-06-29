using Microsoft.Xna.Framework;
using Waldem.GameManagement;

namespace Waldem.UI
{
    public abstract class GUIElement
    {
        public GUIElement(){
            var processor = WaldemGame.Instance.Services.GetService<GUIProcessor>();
            processor.AddElement(this);
        }

        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}