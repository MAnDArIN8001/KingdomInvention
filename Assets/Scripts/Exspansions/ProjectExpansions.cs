using UnityEngine;

public static class ProjectExpansions
{
    public static Vector2 GetRandomDirectionVector() => new Vector2() { x = Random.Range(0, 1), y = Random.Range(0, 1) };
}
