using UnityEngine;

public static class VectorExtension
{
    public static Vector2 Randomize(this Vector2 center, float radius)
    {
        return center + Random.insideUnitCircle * radius;
    }
}
