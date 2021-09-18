using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _speed;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private Camera _camera;

    public Vector2 Speed => _speed;

    private Vector2 _startPosition;

    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            float pos = _camera.ScreenToViewportPoint(Input.mousePosition).y - _startPosition.y;
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + pos * _speed.y, _minY, _maxY), transform.position.z);
            _startPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        }

        transform.Translate(_speed.x * Time.deltaTime, 0, 0);
    }
}
