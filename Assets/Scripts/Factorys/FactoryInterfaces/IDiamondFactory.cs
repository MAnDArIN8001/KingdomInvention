using UnityEngine;

public interface IDiamondFactory
{
    public Diamond Create(Vector2 position, Quaternion rotation);
}
