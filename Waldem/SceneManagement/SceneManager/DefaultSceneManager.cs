using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using Waldem.Helpers;

namespace Waldem.SceneManagement.SceneManager
{
    public class DefaultSceneManager : ISceneManager
    {
        public Dictionary<Type, IScene> Scenes { get; set; } = new Dictionary<Type, IScene>();
        public IScene CurrentScene { get; set; }
        
        public DefaultSceneManager(IEnumerable<IScene> _startScenes){
            foreach (var item in _startScenes)
            {
                Scenes.Add(item.GetType(), item);
                
                if(item.IsFirst) ChangeCurrentScene(item);
            }
        }

        public DefaultSceneManager(IScene _scene){
            AddScene(_scene);
            ChangeCurrentScene(_scene);
        }

        public DefaultSceneManager(){}

        public void Update(GameTime _gameTime){
            CurrentScene?.Update(_gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch){
            CurrentScene?.Draw(_spriteBatch);
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