using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Waldem.UI
{
    public abstract class ScalableElement : GUIElement
    {
        public Size2 Size { get; protected set; }

        public ScalableElement(Vector2 position, Size2 size) : base(position){
            Size = Size;
        }
    }
}