using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/**
 * Tutorial Manager.cs
 * @author Ethan Baker - 986237
 *
 * Deals with the Tutorial Manager system
 */
public class TutorialManager : MonoBehaviour
{
    public GameObject[] steps;
    public float waitTime = 3f;
    private int _stepsIndex;

    public GameObject[] shapes;
    private int _shapesIndex;
    public GameObject _firstShape;
    public Button playAgain, menu, startGame;
    private GameObject _nextShape;
    private TutorialSpawn _tutorialSpawn;

    private bool _isSpawnTime = false;

    void Start()
    {
        _tutorialSpawn = FindObjectOfType<TutorialSpawn>();
    }

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
            if (waitTime <= 0)
            {
                _stepsIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (_stepsIndex == 5)
        {
            _isSpawnTime = true;
            _firstShape.SetActive(false);
            _nextShape.SetActive(true);
        }
        else if (_stepsIndex == 6)
        {
            
        }
    }

    public void SpawnNext()
    {
        // _nextShape = (GameObject) Instantiate(shapes[1], new Vector2(3.0f, 6.0f), Quaternion.identity);
        
        _nextShape = (GameObject) Instantiate(Resources.Load(GetRandomShape(), typeof(GameObject)),
            new Vector2(3.0f, 6.0f), Quaternion.identity);
        // if (_isSpawnTime == false)
        // {
        //     _nextShape.SetActive(false);
        // }
        // else
        // {
        //     _nextShape.SetActive(true);
        // }
    }

    private static string GetRandomShape()
    {
        var randomShape = Random.Range(1, 4);

        var randomShapeName = "Prefabs/Tutorial/L-block2";

        switch (randomShape)
        {
            case 1:
                randomShapeName = "Prefabs/Tutorial/L-block2";
                break;
            case 2:
                randomShapeName = "Prefabs/Tutorial/L-block3";
                break;
            case 3:
                randomShapeName = "Prefabs/Tutorial/L-block4";
                break;
        }

        return randomShapeName;
    }

    public bool SpawnTime()
    {
        if (_isSpawnTime == false)
        {
            return false;
        }

        return true;
    }

    public void ClearLine()
    {
        _stepsIndex = 7;
    }

    public void GridFull()
    {
        _stepsIndex = 6;
    }
}