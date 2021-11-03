using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    [SerializeField] private Rewards _rewardType;
    [SerializeField] private int _rewardCount;
    [SerializeField] private float _rewardValue;
    [SerializeField] private float _spawnRadius = 1f;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Reward _rewardTemplate;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GameObject _rewardTarget;
    [SerializeField] private float _spawnDelay;

    private void Start()
    {
        if (!_spawnPosition)
            _spawnPosition.position = transform.position;
    }

    private void SpawnReward(float radius)
    {
        Reward newReward = Instantiate(_rewardTemplate, _canvas.transform);
        newReward.Initialize(_rewardTarget, _rewardType, _rewardValue);
        newReward.SetPosition(_spawnPosition.position + Random.insideUnitSphere * radius);
    }

    public void SpawnGradually()
    {
        StartCoroutine(SpawnRewardWithDelay(0));
    }

    public void SpawnAtTheSameTime()
    {
        for (int i = 0; i < _rewardCount; i++)
            SpawnReward(_spawnRadius);
    }

    private IEnumerator SpawnRewardWithDelay(float radius)
    {
        for (int i = 0; i < _rewardCount; i++)
        {
            SpawnReward(radius);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
