using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StartZone : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private FollowingCamera _camera;
    [SerializeField] private CameraTarget _gameScreenCameraTarget;

    private CameraTarget _playerCameraTarget;

    private void Start()
    {
        _playerCameraTarget = _player.GetComponent<CameraTarget>();
        _camera.SetTarget(_gameScreenCameraTarget);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _gameScreen.SetActive(true);
        _startScreen.SetActive(false);
        _player.StartLevel();
        _camera.SetTarget(_playerCameraTarget);
    }
}
