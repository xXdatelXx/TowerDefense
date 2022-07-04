using UnityEngine;
using System.Linq;

public class Finder : MonoBehaviour
{
    /// <returns>
    /// Can return null
    /// </returns>
    public T FindNearest<T>(float radius) where T : MonoBehaviour
    {
        var hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.one)
                        .Where(i => i.collider.GetComponent<T>() != null)
                        .Select(i => i.collider.GetComponent<T>())
                        .ToList();

        if (hits.Count == 0)
            return null;

        T nearestHit = hits[0];
        foreach (T hit in hits)
        {
            if (Vector2.Distance(transform.position, nearestHit.transform.position)
                > Vector2.Distance(transform.position, hit.transform.position))
            {
                nearestHit = hit;
            }
        }

        if (radius < Vector2.Distance(transform.position, nearestHit.transform.position))
            return null;

        return nearestHit;
    }
}
