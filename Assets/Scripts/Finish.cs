using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private RewardSpawner _rewardSpawner;
    [SerializeField] private FollowingCamera _camera;
    [SerializeField] private Battery _battery;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private TMP_Text _crystalMultiplierText;
    [SerializeField] private Wallet _wallet;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _battery.LandingAnimation.BatteryLandingFinished += OnBatteryLandingFinished;
        _battery.IncreaseSizeAnimation.IncreaseSizeFinished += OnIncreaseSizeFinished;
    }

    private void OnDisable()
    {
        _battery.LandingAnimation.BatteryLandingFinished -= OnBatteryLandingFinished;
        _battery.IncreaseSizeAnimation.IncreaseSizeFinished -= OnIncreaseSizeFinished;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.FinishLevel();
            _animator.SetTrigger("LevelFinished");
            _battery.LandingAnimation.StartChangePosition();
        }
    }

    private void OnBatteryLandingFinished()
    {
        Vector3 targetScale = LightningsToScale();

        _battery.IncreaseSizeAnimation.StartIncreaseSizeWithDelay(targetScale);
        SetCameraOnBattery();
        SpawnReward();
    }

    private void OnIncreaseSizeFinished()
    {
        Invoke("ExplodeBoss", 0.2f);
    }

    public void SetCameraOnBattery()
    {
        _camera.SetTarget(_battery.CameraTarget);
    }

    public void SpawnReward()
    {
        _rewardSpawner.SpawnReward();
    }

    public void ExplodeBoss()
    {
        _camera.SetTarget(_boss.CameraTarget);
        _boss.Explode();
        _gameScreen.SetActive(false);
        _crystalMultiplierText.gameObject.SetActive(true);
    }

    public Vector3 LightningsToScale()
    {
        Vector3 newSize;
        if (_wallet.Lightnings / 25 < 0.1f)
            newSize = new Vector3(0.1f, 0.1f, 0.1f);

        newSize.x = _wallet.Lightnings / 25;
        newSize.y = newSize.x;
        newSize.z = newSize.x;

        return newSize;
    }
}
