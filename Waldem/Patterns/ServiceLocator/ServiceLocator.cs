using System;
using System.Collections.Generic;

public abstract class ServiceLocator<Key, Value>
{
    public Dictionary<Key, Value> Services { get; protected set; }

    public virtual void AddService(Key key, Value value) => Services.Add(key, value);

    public virtual bool Contains(Key key) => Services.ContainsKey(key);

    public virtual Value GetService(Key key) => Services[key];
}