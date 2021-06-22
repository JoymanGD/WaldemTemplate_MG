using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Waldem.Helpers
{
    public static class Drawer
    {
        static SpriteFont SpriteFont;

        public static void Initialize(ContentManager _content){
            SpriteFont = _content.Load<SpriteFont>("Fonts/Default");
        }

        public static void DrawString(SpriteBatch _spriteBatch, string _text, Vector2 _position, Color _color){
            WrapDrawing(_spriteBatch, ()=>{
                if(_text != null) _spriteBatch.DrawString(SpriteFont, _text, _position, _color);
            });
        }

        private static void WrapDrawing(SpriteBatch _spriteBatch, Action _drawing){
            _spriteBatch.Begin();
            _drawing.Invoke();
            _spriteBatch.End();
        }
    }
}