using UnityEngine;

public interface IGenericFactory
{
    public IPickable Create(Vector2 position, Quaternion rotation);
}
