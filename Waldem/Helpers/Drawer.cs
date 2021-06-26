using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Waldem.Helpers
{
    public static class Drawer
    {

    #region Core
        private static void WrapDrawing(SpriteBatch _spriteBatch, Action _drawing){
            _spriteBatch.Begin();
            _drawing.Invoke();
            _spriteBatch.End();
        }
    #endregion


    #region Draw string
        public static void DrawString(SpriteBatch _spriteBatch, SpriteFont spriteFont, string _text, Vector2 position, Color color){
            if(_text == null) return;
            
            WrapDrawing(_spriteBatch, ()=>{
                _spriteBatch.DrawString(spriteFont, _text, position, color);
            });
        }

        public static void DrawString(SpriteBatch _spriteBatch, SpriteFont spriteFont, string _text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects spriteEffects, float layerDepth){
            if(_text == null) return;
            
            WrapDrawing(_spriteBatch, ()=>{
                _spriteBatch.DrawString(spriteFont, _text, position, color, rotation, origin, scale, spriteEffects, layerDepth);
            });
        }
    #endregion


    #region Draw Line
        public static void DrawLine(SpriteBatch _spriteBatch, float x1, float y1, float x2, float y2, Color color, float thickness = 1, float layerDepth = 0){
            WrapDrawing(_spriteBatch, ()=>{
                _spriteBatch.DrawLine(x1, y1, x2, y2, color, thickness, layerDepth);
            });
        }

        public static void DrawLine(SpriteBatch _spriteBatch, Vector2 first, Vector2 second, Color color, float thickness = 1, float layerDepth = 0){
            WrapDrawing(_spriteBatch, ()=>{
                _spriteBatch.DrawLine(first, second, color, thickness, layerDepth);
            });
        }

        public static void DrawLine(SpriteBatch _spriteBatch, Vector2 point, float length, float angle, Color color, float thickness = 1, float layerDepth = 0){
            WrapDrawing(_spriteBatch, ()=>{
                _spriteBatch.DrawLine(point, length, angle, color, thickness, layerDepth);
            });
        }
    #endregion


    #region Draw Circle
        public static void DrawCircle(SpriteBatch _spriteBatch, float x, float y, float radius, int sides, Color color, float thickness = 1, float layerDepth = 0){
            WrapDrawing(_spriteBatch, ()=>{
                _spriteBatch.DrawCircle(x, y, radius, sides, color, thickness, layerDepth);
            });
        }

        public static void DrawCircle(SpriteBatch _spriteBatch, Vector2 center, float radius, int sides, Color color, float thickness = 1, float layerDepth = 0){
            WrapDrawing(_spriteBatch, ()=>{
                _spriteBatch.DrawCircle(center, radius, sides, color, thickness, layerDepth);
            });
        }
    #endregion


    #region Draw Rectangle
        public static void DrawRectangle(SpriteBatch _spriteBatch, float x, float y, float width, int height, Color color, float thickness = 1, float layerDepth = 0){
            WrapDrawing(_spriteBatch, ()=>{
                _spriteBatch.DrawRectangle(x, y, width, height, color, thickness, layerDepth);
            });
        }

        public static void DrawRectangle(SpriteBatch _spriteBatch, Vector2 location, Size2 size, Color color, float thickness = 1, float layerDepth = 0){
            WrapDrawing(_spriteBatch, ()=>{
                _spriteBatch.DrawRectangle(location, size, color, thickness, layerDepth);
            });
        }

        public static void DrawFillRectangle(SpriteBatch _spriteBatch, Vector2 location, Size2 size, Color color){
            WrapDrawing(_spriteBatch, ()=>{
                _spriteBatch.FillRectangle(location, size, color);
            });
        }
    #endregion


    #region Draw texture
        public static void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Color color){
            if(texture == null) return;
            
            WrapDrawing(spriteBatch, ()=>{
                spriteBatch.Draw(texture, position, color);
            });
        }
        
        public static void Draw(SpriteBatch spriteBatch, Texture2D texture, Rectangle sourceRectangle, Vector2 position, Color color){
            if(texture == null) return;
            
            WrapDrawing(spriteBatch, ()=>{
                spriteBatch.Draw(texture, position, sourceRectangle, color);
            });
        }
        
        public static void Draw(SpriteBatch spriteBatch, Texture2D texture, Rectangle sourceRectangle, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale){
            if(texture == null) return;
            
            WrapDrawing(spriteBatch, ()=>{
                spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, SpriteEffects.None, 1);
            });
        }
        
        public static void Draw(SpriteBatch spriteBatch, Texture2D texture, Rectangle sourceRectangle, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects spriteEffects, float layerDepth){
            if(texture == null) return;
            
            WrapDrawing(spriteBatch, ()=>{
                spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, spriteEffects, layerDepth);
            });
        }
    #endregion
    }
}