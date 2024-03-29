﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * TutorialSpawn.cs
 * @author Ethan Baker - 986237
 *
 * Deals with the Spawning Tutorial Shapes
 */
public class TutorialSpawn : MonoBehaviour
{
    // Audio clips for the game
    public AudioClip blockRotateSound;
    public AudioClip clearSound;
    public AudioClip fallSound;
    public AudioClip gameOver;
    public AudioClip move;
    public AudioClip pause;
    public AudioClip select;
    public AudioClip start;
    public AudioClip success;

    private const int Width = 9;
    private const int Height = 8;

    private float _prevTime;
    private float fallTime = 100;

    private AudioSource _audioSource;

    private TutorialManager _tutorialManager;

    // Rotation x,y,z which can be changed in the editor
    [SerializeField] public Vector3 rotation;

    private static readonly Transform[,] Grid = new Transform[Width, Height];

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _tutorialManager = FindObjectOfType<TutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckUserInput();
    }

    private void CheckUserInput()
    {
        // Press left arrow to move one block left
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);

            // If not valid then move back
            if (!IsValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }

        // Press right arrow to move one block right
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);

            // If not valid then move back
            if (!IsValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }

        // Press up to rotate the shape 90 degrees
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(rotation), new Vector3(0, 0, 1), 90);

            if (IsValidMove())
            {
                _audioSource.PlayOneShot(blockRotateSound);
            }

            // If not valid then move back
            if (!IsValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotation), new Vector3(0, 0, 1), -90);
            }
        }

        // Press down arrow to move shape down or Hold for it to go faster
        if (Time.time - _prevTime >
            ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? fallTime / 1000 : fallTime))
        {
            // If holding
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                // _score.AddToScore(1);
            }

            transform.position += new Vector3(0, -1, 0);

            // If not valid then move back
            if (!IsValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                DeleteLinesUponComplete();
                enabled = false;
                // if (_tutorialManager.SpawnTime())
                // {
                _tutorialManager.SpawnNext();
                // }

                // _tutorialManager.HitBottom();
                // _spawnShape.NewTetrisShape();
            }

            _prevTime = Time.time;
        }

        // Mouse click to make shape go to the bottom of the available grid
        else if (Time.time - _prevTime > (Input.GetMouseButtonDown(0) ? fallTime / 10000 : fallTime))
        {
            if (!PauseMenu.IsPause)
            {
                // Mouse Click instant down
                while (IsValidMove())
                {
                    // Adds however many rows we went down
                    // _score.AddToScore(1);
                    transform.position += new Vector3(0, -1, 0);
                }

                // If not valid move back
                if (!IsValidMove())
                {
                    _audioSource.PlayOneShot(fallSound);
                    transform.position -= new Vector3(0, -1, 0);
                    AddToGrid();
                    DeleteLinesUponComplete();
                    enabled = false;
                    // if (_tutorialManager.SpawnTime())
                    // {
                    _tutorialManager.SpawnNext();
                    // }
                    // _tutorialManager.HitBottom();
                    // _spawnShape.NewTetrisShape();
                }
            }
        }
    }

    public bool IsValidMove()
    {
        foreach (Transform children in transform)
        {
            var position = children.transform.position;
            var x = Mathf.RoundToInt(position.x);
            var y = Mathf.RoundToInt(position.y);

            if (x < 0 || x >= Width || y < 0)
            {
                return false;
            }

            if (Grid != null && Grid[x, y] != null)
            {
                return false;
            }
        }

        return true;
    }

    private void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            var position = children.transform.position;
            var x = Mathf.RoundToInt(position.x);
            var y = Mathf.RoundToInt(position.y);

            Grid[x, y] = children;
        }

        CheckIfGameOver();
    }

    private void CheckIfGameOver()
    {
        for (var j = 0; j < Width; j++)
        {
            if (Grid[j, Height - 1] != null)
            {
                // GameOver();
                _tutorialManager.GridFull();
            }
        }
    }


    /**
     * Deletes lines when full
     */
    private void DeleteLinesUponComplete()
    {
        for (var i = Height - 1; i >= 0; i--)
        {
            // Checks if Line is full
            if (LineFull(i))
            {
                // _score.AddToScore(100);
                DeleteFullLine(i);
                _tutorialManager.ClearLine();
                MoveRowDown(i);
            }
        }
    }


    /**
     * Goes through the Grid to check for full lines
     */
    private bool LineFull(int y)
    {
        // Checks over x position for if its full
        for (var x = 0; x < Width; x++)
        {
            // If any position is null then row not full
            if (Grid[x, y] == null)
            {
                return false;
            }
        }

        _audioSource.PlayOneShot(clearSound);
        // _rowsCleared++;
        return true;
    }

    /**
     * Deletes Lines when Complete
     */
    private static void DeleteFullLine(int i)
    {
        for (int j = 0; j < Width; j++)
        {
            Destroy(Grid[j, i].gameObject);
            Grid[j, i] = null;
        }
    }


    /**
     * Moves Row down after deleting old one
     */
    private static void MoveRowDown(int i)
    {
        for (var y = i; y < Height; y++)
        {
            for (var j = 0; j < Width; j++)
            {
                if (Grid[j, y] != null)
                {
                    Grid[j, y - 1] = Grid[j, y];
                    Grid[j, y] = null;
                    Grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
}