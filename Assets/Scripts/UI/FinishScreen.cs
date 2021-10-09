using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private int _nextSceneId;
    [SerializeField] private GameObject _claimButton;
    [SerializeField] private float _claimButtonDelay;

    private void Start()
    {
        StartCoroutine(SetActiveClaimButtonWithDelay());
        
    }

    public void LoadNextScene()
    {
        Level_2.Load(1);
    }

    private IEnumerator SetActiveClaimButtonWithDelay()
    {
        yield return new WaitForSeconds(_claimButtonDelay);
        _claimButton.SetActive(true);
    }
}
