using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Waldem.GameManagement;

namespace Waldem.SceneManagement
{
    public abstract class IScene : IDisposable
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public bool Initialized { get; private set; } = false;
        public string AdditionalInfo { get; protected set; }
        public static WaldemGame Game { get; private set; }

        static IScene(){
            Game = WaldemGame.Instance;
        }

        public IScene(){
            Name = GetName();
            ID = Game.SceneManager.Scenes.Count;
        }

        private string GetName(){
            var stringParts = this.ToString().Split('.');
            return stringParts[stringParts.Length-1];
        }

        public virtual void Initialize(){
            Initialized = true;
            InitializeLocal();
        }

        public abstract void InitializeLocal();

        public virtual void Dispose(){}

        public virtual void Reset(){}

        public abstract void Update(GameTime _gameTime);

        public abstract void Draw(SpriteBatch _spriteBatch);
    }
}