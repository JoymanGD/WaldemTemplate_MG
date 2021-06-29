using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Waldem.GameManagement;

namespace Waldem.UI
{
    public class GUIProcessor
    {
        private List<GUIElement> GUIElements = new List<GUIElement>();

        public GUIProcessor(){
            WaldemGame.Instance.Services.AddService(GetType(), this);
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