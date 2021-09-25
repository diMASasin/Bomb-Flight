using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private GameObject _bossBody;
    [SerializeField] private Animator _animator;
    [SerializeField] private RewardSpawner _rewardSpawner;
    [SerializeField] private FollowingCamera _camera;
    [SerializeField] private Battery _battery;
    [SerializeField] private GameObject _gameScreen;

    public void FinishLevel()
    {
        _animator.SetTrigger("Finished");
    }

    public void SetCameraOnTarget()
    {
        _camera.SetOffset(new Vector3(-4.5f, 8.5f, -20));
        _camera.SetTarget(_battery.gameObject);
    }

    public void SpawnReward()
    {
        _rewardSpawner.SpawnReward();
    }

    public void ExplodeBoss()
    {
        _camera.SetTarget(_bossBody);
        _boss.Explode();
        _gameScreen.SetActive(false);
    }
}
