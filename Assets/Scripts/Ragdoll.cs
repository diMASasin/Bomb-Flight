using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _allRigidbodies;

    private void Awake()
    {
        for (int i = 0; i < _allRigidbodies.Length; i++)
            _allRigidbodies[i].isKinematic = true;
    }

    public void MakePhysical()
    {
        for (int i = 0; i < _allRigidbodies.Length; i++)
            _allRigidbodies[i].isKinematic = false;
    }
}
