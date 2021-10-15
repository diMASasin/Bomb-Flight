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
    [SerializeField] private float _minimumBatterySize = 0.1f;
    [SerializeField] private GradualAccrualOf—urrency _accrualOf—urrency;
    [SerializeField] private GameObject _aim;

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
            _battery.LandingAnimation.StartLanding();
            _aim.SetActive(false);
        }
    }

    private void OnBatteryLandingFinished()
    {
        Vector3 targetScale = LightningsToScale();

        _battery.IncreaseSizeAnimation.StartIncreaseSizeWithDelay(targetScale);
        SetCameraOnBattery();
        SpawnReward();
        _accrualOf—urrency.Add(-_wallet.Lightnings, Rewards.lightnings, true);
    }

    private void OnIncreaseSizeFinished()
    {
        _animator.SetTrigger("Explode");
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
        float divider = 25;

        if (_wallet.Lightnings / divider < _minimumBatterySize)
            newSize = Vector3.one * _minimumBatterySize;

        newSize.x = _wallet.Lightnings / divider;
        newSize.y = newSize.x;
        newSize.z = newSize.x;

        return newSize;
    }
}
