using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(_nextSceneId);
    }

    private IEnumerator SetActiveClaimButtonWithDelay()
    {
        yield return new WaitForSeconds(_claimButtonDelay);
        _claimButton.SetActive(true);
    }
}
