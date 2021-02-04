using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tertis : MonoBehaviour
{
    //
    private float _prevTime;
    [SerializeField] public float fallTime;

    // Width & Height of the game area
    private const int Width = 10;
    private const int Height = 16;

    //Rotation x,y,z which can be changed in the editor
    [SerializeField] public Vector3 rotation;
    private SpawnShape _spawnShape;

    // Add shapes to grid array to know where they are located
    private static Transform[,] _grid = new Transform[Width, Height];

    // Start is called before the first frame update
    private void Start()
    {
        _spawnShape = FindObjectOfType<SpawnShape>();
    }

    // Update is called once per frame
    private void Update()
    {
        //
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        //
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        //
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(rotation), new Vector3(0, 0, 1), 90);
            if (!IsValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotation), new Vector3(0, 0, 1), -90);
            }
        }

        //
        if (Time.time - _prevTime >
            ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                this.enabled = false;
                _spawnShape.NewTetrisShape();
            }

            _prevTime = Time.time;
        }
    }

    /**
     * 
     */
    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            var position = children.transform.position;
            int x = Mathf.RoundToInt(position.x);
            int y = Mathf.RoundToInt(position.y);

            _grid[x, y] = children;
        }
    }

    /**
     * 
     */
    bool IsValidMove()
    {
        foreach (Transform children in transform)
        {
            var position = children.transform.position;
            int x = Mathf.RoundToInt(position.x);
            int y = Mathf.RoundToInt(position.y);

            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return false;
            }

            if (_grid[x, y] != null)
            {
                return false;
            }
        }

        return true;
    }
}