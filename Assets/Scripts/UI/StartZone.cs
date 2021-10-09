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

    public void OnPointerDown(PointerEventData eventData)
    {
        _gameScreen.SetActive(true);
        _startScreen.SetActive(false);
        _player.StartLevel();
    }
}
