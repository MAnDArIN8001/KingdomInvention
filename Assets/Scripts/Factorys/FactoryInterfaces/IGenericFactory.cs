using UnityEngine;

public interface IGenericFactory
{
    public object Create(Vector2 position, Quaternion rotation);
}
