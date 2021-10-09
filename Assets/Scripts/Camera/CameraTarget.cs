using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed = 2;

    public GameObject Target => _target;
    public Vector3 Offset => _offset;
    public float Speed => _speed;
}
