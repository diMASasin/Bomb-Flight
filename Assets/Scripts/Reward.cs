using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _rewardTarget;
    [SerializeField] private Rewards _rewardType;
    [SerializeField] private int _rewardValue = 1;

    public Rewards RewardType => _rewardType;
    public int RewardValue => _rewardValue;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _rewardTarget.transform.position, _speed * Time.deltaTime);
    }

    public void Initialize(GameObject target, Rewards rewardType)
    {
        _rewardTarget = target;
        _rewardType = rewardType;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
