using Microsoft.Xna.Framework;
using MonoGame.Extended;
using Waldem.Helpers;

namespace Waldem.UI.Elements
{
    public class Label : GUIElement
    {
        public string Text;
        public Color TextColor;

        public Label(Vector2 position, string text, bool independent = true) : base(position, independent)
        {
            Text = text;
            TextColor = Color.SkyBlue;
        }
        
        public Label(Vector2 position, string text, Color textColor, bool independent = true) : base(position, independent)
        {
            Text = text;
            TextColor = textColor;
        }

        public override void Draw(GameTime gameTime)
        {
            Drawer.DrawString(SpriteBatch, Processor.SpriteFont, Text, Position, TextColor);
        }

        public override void Update(GameTime gameTime){}
    }
}