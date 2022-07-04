using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class TransformExtension
{
    public static List<Vector2> Convert(this List<Transform> transforms)
    {
        return transforms.Select(i => (Vector2)i.position).ToList();
    }
}
