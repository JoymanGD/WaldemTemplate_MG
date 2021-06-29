using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Waldem.GameManagement;

namespace Waldem.UI
{
    public class GUIProcessor
    {
        public SpriteFont SpriteFont { get; private set; }
        private List<GUIElement> GUIElements = new List<GUIElement>();

        public GUIProcessor(SpriteFont spriteFont){
            var game = WaldemGame.Instance;
            game.Services.AddService(GetType(), this);
            
            SpriteFont = spriteFont;
        }

        public void Update(GameTime gameTime){
            foreach (var item in GUIElements)
            {
                item.Update(gameTime);
            }
        }
        
        public void Draw(GameTime gameTime){
            foreach (var item in GUIElements)
            {
                item.Draw(gameTime);
            }
        }

        public void AddElement(GUIElement element){
            if(element == null) return;

            GUIElements.Add(element);
        }
    }
}