using UnityEngine;

public abstract class Movement : Transformable
{
    public Movement(Vector2 position, float rotation) : base(position, rotation)
    {
    }

    public abstract void Move(float deltaTime);
}
