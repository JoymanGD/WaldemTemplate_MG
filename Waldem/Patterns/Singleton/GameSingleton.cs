using System;
using Microsoft.Xna.Framework;

namespace Waldem.Patterns
{
    public class GameSingleton<T> : Game, ISingleton<T>
    {
        public static T Instance {
            get{
                if(_instance == null){
                    _instance = (T)Activator.CreateInstance(typeof(T));
                }
                return _instance;
            }
        }

        private static T _instance;
    }
}