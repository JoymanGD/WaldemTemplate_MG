using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Waldem.UI
{
    public abstract class RectangleElement : ScalableElement
    {
        public Color BackgroundColor;
        public Color OutlineColor;
        protected RectangleF Bounds { get; private set; }

        public RectangleElement(Vector2 position, Size2 size, bool independent = true) : base(position, size, independent){
            Bounds = new Rectangle(Position.ToPoint(), (Point)size);
            BackgroundColor = Color.Black;
            OutlineColor = Color.White;
        }

        public RectangleElement(Vector2 position, Size2 size, Color backgroundColor, Color outlineColor) : base(position, size){
            Bounds = new Rectangle(Position.ToPoint(), (Point)size);
            BackgroundColor = backgroundColor;
            OutlineColor = outlineColor;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.DrawRectangle(Bounds, BackgroundColor, Bounds.Width);
            SpriteBatch.DrawRectangle(Bounds, OutlineColor);
            SpriteBatch.End();
        }
    }
}