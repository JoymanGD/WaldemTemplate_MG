using System;
using System.Collections.Generic;

public class TypedServiceLocator<Key, Value> : ServiceLocator<Key, Value> where Key : Type
{
    public void AddService<T>(Value value) where T : Key => AddService((Key)typeof(T), value);

    public Value GetService<T>() where T : Key => GetService((Key)typeof(T));

    public bool Contains<T>() where T : Key => Contains((Key)typeof(T));
}