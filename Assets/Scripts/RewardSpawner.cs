using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    [SerializeField] private Rewards _rewardType;
    [SerializeField] private int _rewardCount;
    [SerializeField] private float _rewardValue;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Reward _rewardTemplate;
    [SerializeField] private Transform _rewardStartPosition;
    [SerializeField] private GameObject _rewardTarget;
    [SerializeField] private float _spawnDelay;

    private void Start()
    {
        if (!_rewardStartPosition)
            _rewardStartPosition.position = transform.position;
    }

    public void SpawnReward()
    {
        StartCoroutine(SpawnRewardWithDelay(_rewardTarget));
    }

    private IEnumerator SpawnRewardWithDelay(GameObject rewardTarget)
    {
        for (int i = 0; i < _rewardCount; i++)
        {
            Reward newReward = Instantiate(_rewardTemplate, _canvas.transform);
            newReward.Initialize(rewardTarget, _rewardType, _rewardValue);
            newReward.SetPosition(_rewardStartPosition.position);

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
