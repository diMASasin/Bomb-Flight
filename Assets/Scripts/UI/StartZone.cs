using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StartZone : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _gameScreen;

    public event UnityAction GameStarted;

    public void OnPointerDown(PointerEventData eventData)
    {
        _gameScreen.SetActive(true);
        GameStarted?.Invoke();
        _startScreen.SetActive(false);
    }
}
