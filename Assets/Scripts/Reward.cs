using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _target;
    [SerializeField] private Rewards _rewardType;

    public Rewards RewardType => _rewardType;
    public GameObject Target => _target;

    public int RewardValue { get; private set; }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    public void Initialize(GameObject target, Rewards rewardType, int rewardValue)
    {
        _target = target;
        _rewardType = rewardType;
        RewardValue = rewardValue;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
