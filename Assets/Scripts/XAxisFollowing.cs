using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XAxisFollowing : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _xOffset;

    private void FixedUpdate()
    {
        transform.position = new Vector3(_target.transform.position.x + _xOffset, transform.position.y, transform.position.z);
    }
}
