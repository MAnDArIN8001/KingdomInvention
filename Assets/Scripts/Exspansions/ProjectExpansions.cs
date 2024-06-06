using UnityEngine;

public static class ProjectExpansions
{
    public static Vector2 GetRandomDirectionVector() => new Vector2() { x = Random.Range(0f, 1.1f), y = Random.Range(0f, 1.1f) };
}
