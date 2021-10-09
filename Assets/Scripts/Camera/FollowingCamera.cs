using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraTarget _player;
    [SerializeField] private CameraTarget _battery;
    [SerializeField] private CameraTarget _boss;

    private CameraTarget _currentTarget;

    private void Start()
    {
        _currentTarget = _player;
    }

    private void Update()
    {
        if (_currentTarget == _battery)
            MoveSmoothly();
        else
            MoveSmoothlyAlongYAxis();
    }

    private void MoveSmoothly()
    {
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _currentTarget.Target.transform.position + _currentTarget.Offset, _currentTarget.Speed * Time.deltaTime);
    }

    private void MoveSmoothlyAlongYAxis()
    {
        _camera.transform.position = new Vector3(
        Mathf.Lerp(_camera.transform.position.x, _currentTarget.Target.transform.position.x + _currentTarget.Offset.x, 1),
        Mathf.Lerp(_camera.transform.position.y, _currentTarget.Target.transform.position.y + _currentTarget.Offset.y, _currentTarget.Speed * Time.deltaTime),
        Mathf.Lerp(_camera.transform.position.z, _currentTarget.Target.transform.position.z + _currentTarget.Offset.z, 1));
    }

    public void SetTarget(CameraTarget target)
    {
        _currentTarget = target;
    }
}
