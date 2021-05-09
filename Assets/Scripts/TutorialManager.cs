using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] steps;
    private int _stepsIndex;
    public float waitTime = 3f;

    public GameObject initalShape, secondShape;
    

    void Update()
    {
        UpdateTutortial();
    }

    private void UpdateTutortial()
    {
        for (int i = 0; i < steps.Length; i++)
        {
            if (i == _stepsIndex)
            {
                steps[i].SetActive(true);
            }
            else
            {
                steps[i].SetActive(false);
            }
        }

        if (_stepsIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))

            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
                    Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    _stepsIndex++;
                }
            }
        }
        else if (_stepsIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                _stepsIndex++;
            }
        }
        else if (_stepsIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                _stepsIndex++;
            }
        }
        else if (_stepsIndex == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _stepsIndex++;
            }
        }
        else if (_stepsIndex == 4)
        {
            // float loading = Mathf.Clamp01(waitTime);
            // loadingSlider.value = loading;
            // loadingText.text = loading * 100f + "%";
            if (waitTime <= 0)
            {
                _stepsIndex++;
                initalShape.SetActive(false);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }


}