using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TowerView : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite)
    {
        _sprite.sprite = sprite;
    }

    public void Shoot()
    {
        // запускать анiмацiю
    }
}
