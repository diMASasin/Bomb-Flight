using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private Transform _explosionPosition;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardsModifier;
    [SerializeField] private Ragdoll _ragdoll;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _addingForeForLightning = 550;

    public void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);

        _ragdoll.MakePhysical();
        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(CalculateExplosionForce(), _explosionPosition.position, _radius, _upwardsModifier);
            }

        }
    }

    public void StartExplodeWithDelay(float delay)
    {
        StartCoroutine(ExplodeWithDelay(delay));
    }

    private IEnumerator ExplodeWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Explode();
    }

    private float CalculateExplosionForce()
    {
        return _addingForeForLightning * _wallet.Lightnings;
    }
}
