using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using Waldem.Helpers;
using MonoGame.Extended;
using MonoGame.Extended.Tweening;
using Waldem.GameManagement;

namespace Waldem.SceneManagement.SceneManager
{
    public class DefaultSceneManager : ISceneManager
    {
        public Dictionary<Type, IScene> Scenes { get; set; } = new Dictionary<Type, IScene>();
        public IScene CurrentScene { get; set; }
        private Color FadeColor;
        private float FadeAlpha;
        private Size2 FadeSize;
        private Tweener Tweener;
        
        public DefaultSceneManager(IEnumerable<IScene> _startScenes){
            foreach (var item in _startScenes)
            {
                Scenes.Add(item.GetType(), item);
                
                if(item.IsFirst) ChangeCurrentScene(item);
            }
            SetupFading();
        }

        public DefaultSceneManager(IScene _scene){
            AddScene(_scene);
            ChangeCurrentScene(_scene);
            SetupFading();
        }

        public DefaultSceneManager(){
            SetupFading();
        }

        private void SetupFading(){
            FadeColor = Color.Black;
            
            FadeAlpha = 1;

            var gDev = WaldemGame.Instance.GraphicsDevice;            
            var width = gDev.Adapter.CurrentDisplayMode.Width;
            var height = gDev.Adapter.CurrentDisplayMode.Height;

            FadeSize = new Size2(width, height);

            Tweener = new Tweener();
        }

        public void Fade(FadeTypes type, float duration = 1){
            float result = type == FadeTypes.In ? 0 : 1;

            Tweener.TweenTo(this, expression: s=>s.FadeAlpha, result, duration);
        }

        public enum FadeTypes
        {
            In, Out
        }

        public void Update(GameTime _gameTime){
            CurrentScene?.Update(_gameTime);

            Tweener.Update(_gameTime.GetElapsedSeconds());
        }

        public void Draw(SpriteBatch _spriteBatch){
            CurrentScene?.Draw(_spriteBatch);

            if(FadeAlpha > 0){
                FadeColor.A = (byte)FadeAlpha;
                Drawer.DrawFillRectangle(_spriteBatch, Vector2.Zero, FadeSize, FadeColor);
            }
        }

        public void AddScene<T>() where T:IScene{
            var newScene = Activator.CreateInstance(typeof(T)) as IScene;
            Scenes.Add(typeof(T), newScene);
            
            if(CurrentScene == null) ChangeCurrentScene(newScene);
        }

        public void AddScene(IScene _scene){
            Scenes.Add(_scene.GetType(), _scene);

            if(CurrentScene == null) ChangeCurrentScene(_scene);
        }

        public void RemoveScene<T>() where T:IScene{
            Scenes[typeof(T)].Dispose();
            Scenes.Remove(typeof(T));
        }

        public IScene GetScene<T>() where T:IScene{
            return Scenes[typeof(T)];
        }

        public void RunFirstScene(){
            if(Scenes.Count < 2) return; //if there is only one scene - no need to search for the first

            foreach (var pair in Scenes)
            {
                if(pair.Value.IsFirst){
                    ChangeCurrentScene(pair.Value);
                    return;
                }
            }

            throw new Exception("No scene with attribute 'IsFirst' was added. Define first scene parent's field 'IsFirst' as true");
        }

        public void ChangeCurrentScene(IScene _scene){
            if(_scene != CurrentScene){
                CurrentScene = _scene;

                if(!_scene.Initialized){
                    _scene.Initialize();
                }
            }
        }

        public void ChangeCurrentScene<T>(){
            var type = typeof(T);
            var _scene = Scenes[type];

            if(_scene == null){
                throw new Exception("There is no such scene (" + type + ")");
            }
            
            if(_scene != CurrentScene){
                CurrentScene = _scene;

                if(!_scene.Initialized){
                    _scene.Initialize();
                }
            }
        }

        public void NextScene(){
            if(CurrentScene == null) return;
            
            var nextID = CurrentScene.ID + 1;

            var nextScene = Scenes.FirstOrDefault(x => x.Value.ID == nextID).Value;

            if(nextScene != null) ChangeCurrentScene(nextScene);
        }

        public void PreviousScene(){
            if(CurrentScene == null) return;
            
            var nextID = CurrentScene.ID - 1;

            var previousScene = Scenes.FirstOrDefault(x => x.Value.ID == nextID).Value;

            if(previousScene != null) ChangeCurrentScene(previousScene);
        }
    }
}