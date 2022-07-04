using UnityEngine;

public class TransformableView : MonoBehaviour
{
    private Transformable _transformable;

    public void Init(Transformable transformable)
    {
        _transformable = transformable;
    }

    private void Update()
    {
        if (_transformable != null)
            transform.position = _transformable.Position;
    }
}
