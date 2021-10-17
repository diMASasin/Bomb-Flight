using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Bool : MonoBehaviour
{
    public bool X { get; private set; }
    public bool Y { get; private set; }
    public bool Z { get; private set; }

    public static Vector3Bool False { get; private set; } = new Vector3Bool(false, false, false);

    public Vector3Bool(bool x, bool y, bool z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Vector3Bool _isPositionFreezed;
    private Vector3 _interpolationValue;
    private CameraTarget _currentTarget;

    private void Start()
    {
        _isPositionFreezed = Vector3Bool.False;
        FreezePosition(false, false, false);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        SetInterpolationValue();

        _camera.transform.position = new Vector3(
        Mathf.Lerp(_camera.transform.position.x, _currentTarget.Target.transform.position.x + _currentTarget.Offset.x, _interpolationValue.x),
        Mathf.Lerp(_camera.transform.position.y, _currentTarget.Target.transform.position.y + _currentTarget.Offset.y, _interpolationValue.y),
        Mathf.Lerp(_camera.transform.position.z, _currentTarget.Target.transform.position.z + _currentTarget.Offset.z, _interpolationValue.z));
    }

    private void SetInterpolationValue()
    {
        float interpolationValueX = _isPositionFreezed.X ? 1 : _currentTarget.Speed * Time.deltaTime;
        float interpolationValueY = _isPositionFreezed.Y ? 1 : _currentTarget.Speed * Time.deltaTime;
        float interpolationValueZ = _isPositionFreezed.Z ? 1 : _currentTarget.Speed * Time.deltaTime;
        _interpolationValue = new Vector3(interpolationValueX, interpolationValueY, interpolationValueZ);
    }

    public void SetTarget(CameraTarget target)
    {
        _currentTarget = target;
    }
    
    public void FreezePosition(bool x = false, bool y = false, bool z = false)
    {
        _isPositionFreezed = new Vector3Bool(x, y, z);
    }
}
