using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Tetris.cs
 * @Author Ethan Baker - 986237
 *
 * This class sets out the main user control for the Tetris shapes. Fall time, movement rotation and check valid move is
 * handled here. 
 */
public class Tetris : MonoBehaviour
{
    //
    private float _prevTime;
    [SerializeField] public float fallTime;

    // Width & Height of the game area
    private const int Width = 10;
    private const int Height = 25;

    //Rotation x,y,z which can be changed in the editor
    [SerializeField] public Vector3 rotation;

    // Other classes 
    private SpawnShape _spawnShape;
    private Score _score;

    // Add shapes to grid array to know where they are located
    private static readonly Transform[,] Grid = new Transform[Width, Height];

    // Scoring depending on how many lines are cleared
    public int oneLineScore = 40, twoLineScore = 100, threeLineScore = 300, fourLineScore = 1200;
    private int _rowsCleared = 0;

    // Start is called before the first frame update
    private void Start()
    {
        _spawnShape = FindObjectOfType<SpawnShape>();
        _score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckUserInput();
        MultiRowClearing();
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
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);

            // If not valid then move back
            if (!IsValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        // Press up to rotate the shape 90 degrees
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(rotation), new Vector3(0, 0, 1), 90);

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
                _score.AddToScore(oneLineScore);
                print("one line");
                break;
            case 2:
                _score.AddToScore(twoLineScore);
                print("two line");
                break;
            case 3:
                _score.AddToScore(threeLineScore);
                print("three line");
                break;
            case 4:
                _score.AddToScore(fourLineScore);
                print("four line");
                break;
        }
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
    private static void CheckIfGameOver()
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
        SceneManager.LoadScene("GameOver");
    }
}