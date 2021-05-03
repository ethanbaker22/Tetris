﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Tetris.cs
 * @Author Ethan Baker - 986237
 *
 * This class sets out the main user control for the Tetris shapes. Fall time, movement rotation and check valid move is
 * handled here. 
 */
public class Tetris : MonoBehaviour
{
    // Audio clips for the game
    public AudioClip blockRotateSound;
    public AudioClip clearSound;
    public AudioClip fallSound;
    public AudioClip gameOver;
    public AudioClip pause;
    public AudioClip select;
    public AudioClip start;
    public AudioClip success;

    //
    private float _prevTime;
    [SerializeField] public float fallTime;

    // Width & Height of the game area
    private const int Width = 10;
    private const int Height = 25;
    private static int _currentLevel = 0;
    private static int _linesCleared = 0;

    // 
    private AudioSource _audioSource;

    // Rotation x,y,z which can be changed in the editor
    [SerializeField] public Vector3 rotation;

    // Other classes 
    private SpawnShape _spawnShape;
    private static Score _score;

    // Add shapes to grid array to know where they are located
    private static readonly Transform[,] Grid = new Transform[Width, Height];

    // Scoring depending on how many lines are cleared
    [SerializeField] public int oneLineScore, twoLineScore, threeLineScore, fourLineScore;
    private int _rowsCleared = 0;

    // Start is called before the first frame update
    private void Start()
    {
        _spawnShape = FindObjectOfType<SpawnShape>();
        _score = FindObjectOfType<Score>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckUserInput();
        MultiRowClearing();
        Levels();
        FallSpeed();
        // print(_rowsCleared);
    }

    /**
     * Checks to see if the shape can be moved to the position the user wants it too, if not the shape stays where it is
     */
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
            ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? fallTime / 10 : fallTime))
        {
            // If holding
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                _score.AddToScore(1);
            }

            transform.position += new Vector3(0, -1, 0);

            // If not valid then move back
            if (!IsValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                DeleteLinesUponComplete();
                enabled = false;
                _spawnShape.NewTetrisShape();
            }

            _prevTime = Time.time;
        }
        // Mouse click to make shape go to the bottom of the available grid
        else if (Time.time - _prevTime > ((Input.GetMouseButtonDown(0)) ? fallTime / 100 : fallTime))
        {
            // Mouse Click instant down
            while (IsValidMove())
            {
                // Adds however many rows we went down
                _score.AddToScore(1);
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
                _spawnShape.NewTetrisShape();
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
        _rowsCleared++;
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

    /**
     * 
     */
    private void MultiRowClearing()
    {
        if (_rowsCleared <= 0) return;
        switch (_rowsCleared)
        {
            case 1:
                _score.AddToScore(oneLineScore * (_currentLevel + 1));
                _linesCleared += 1;
                // _score.AddToLevel(linesCleared);
                print("one line " + _linesCleared + " " + oneLineScore * (_currentLevel + 1));
                break;
            case 2:
                _score.AddToScore(twoLineScore * (_currentLevel + 1));
                _linesCleared += 2;
                // _score.AddToLevel(linesCleared);
                print("two line " + _linesCleared + " " + twoLineScore * (_currentLevel + 1));
                break;
            case 3:
                _score.AddToScore(threeLineScore * (_currentLevel + 1));
                _linesCleared += 3;
                // _score.AddToLevel(linesCleared);
                print("three line " + _linesCleared + " " + threeLineScore * (_currentLevel + 1));
                break;
            case 4:
                _score.AddToScore(fourLineScore * (_currentLevel + 1));
                _linesCleared += 4;
                // _score.AddToLevel(linesCleared);
                print("four line " + _linesCleared + " " + fourLineScore * (_currentLevel + 1));
                break;
        }
    }

    /**
     * Method to change what Level the Player is on - once every 10 line clears
     */
    private void Levels()
    {
        _currentLevel = _linesCleared / 10;
        _score.AddToLevel(_currentLevel);
        // print("Current Level: " + currentLevel / 10);
    }

    /**
     * Adjust the falling speed of the blocks
     */
    private void FallSpeed()
    {
        fallTime = 0.8f - _currentLevel * 0.1f;
        // print("Fall Time: " + fallTime);
    }

    /**
     * Adds shape to grid when its in its final position 
     */
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

    /**
     * Checks to see if the grid is full. If so - Game Over
     */
    private void CheckIfGameOver()
    {
        for (var j = 0; j < Width; j++)
        {
            if (Grid[j, Height - 1] != null)
            {
                GameOver();
            }
        }
    }

    /**
     * Looks to see if the grid position is already taken
     */
    private bool IsValidMove()
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

    /**
     * Loads Game Over Scene
     */
    private static void GameOver()
    {
        _score.SetFinalScore();
        SceneManager.LoadScene("GameOver");
    }
}