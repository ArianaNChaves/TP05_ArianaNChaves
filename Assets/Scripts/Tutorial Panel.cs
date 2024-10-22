using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    private const float TimeToDeactivate = 8.0f;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        DeactivatePanel();

    }

    private void DeactivatePanel()
    {
        if (_timer >= TimeToDeactivate)
        {
            gameObject.SetActive(false);
        }
    }
}
