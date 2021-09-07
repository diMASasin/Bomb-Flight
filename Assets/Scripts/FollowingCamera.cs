using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;


    private void Update()
    {
        _camera.transform.position = new Vector3(
            Mathf.Lerp(_camera.transform.position.x, _target.transform.position.x + _offset.x, 1),
            Mathf.Lerp(_camera.transform.position.y, _target.transform.position.y + _offset.y, _speed * Time.deltaTime),
            Mathf.Lerp(_camera.transform.position.z, _target.transform.position.z + _offset.z, 1));
        
    }
}
