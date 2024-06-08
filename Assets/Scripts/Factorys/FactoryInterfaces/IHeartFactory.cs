using UnityEngine;

public interface IHeartFactory
{
    public Heart Create(Vector2 position, Quaternion rotation);
}
