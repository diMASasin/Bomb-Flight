using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private float _upwardsModifier = 1f;
    [SerializeField] private ParticleSystem _explotionTemplate;

    private Rigidbody _rigidbody;
    private float _speed;
    private bool _isDroped = false;

    private void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void Update()
    {
        transform.Translate(new Vector3(_speed, 0, 0) * Time.deltaTime);
    }

    public void TurnOnGravity()
    {
        _rigidbody.useGravity = true;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetDroped()
    {
        _isDroped = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_layerMask.value != (1 << other.gameObject.layer) && _isDroped)
        {
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            Target target = null;

            if(rigidbody) 
                rigidbody.TryGetComponent<Target>(out target);

            if (target && !target.IsExploded)
            {
                if (target.TryGetComponent(out Ragdoll ragdoll))
                    ragdoll.MakePhysical();

                target.SetExploded();
                target.SpawnReward();
            }

            if (rigidbody && !rigidbody.TryGetComponent<Bomb>(out Bomb bomb))
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius, _upwardsModifier);

                if (target)
                    target.StartDestroyWithDelay();
            }

        }
        ParticleSystem explotion = Instantiate(_explotionTemplate, transform);
        explotion.transform.parent = null;
        explotion.Play();
    }
}
