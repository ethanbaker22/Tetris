using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    //
    private float _prevTime;
    private SpawnShape _spawnShape;
    private Tetris _tetris;
    [SerializeField] public float fallTime;

    //Rotation x,y,z which can be changed in the editor
    [SerializeField] public Vector3 rotation;
    
    void Start()
    {
        _spawnShape = FindObjectOfType<SpawnShape>();
        _tetris = FindObjectOfType<Tetris>();
    }
    
    void Update()
    {
        CheckUserInput();
    }

    /**
     * 
     */
    void CheckUserInput()
    {
        //
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
            else if (IsValidMove())
            {
                _tetris.AddToGrid(this);
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
            else if (IsValidMove())
            {
                _tetris.AddToGrid(this);
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
            else if (IsValidMove())
            {
                _tetris.AddToGrid(this);
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
                this.enabled = false;
                 _spawnShape.NewTetrisShape();
            }
            else if (IsValidMove())
            {
                _tetris.AddToGrid(this);
            }

            _prevTime = Time.time;
        }
    }

    /**
     * 
     */
    private bool IsValidMove()
    {
        foreach (Transform children in transform)
        {
            var position = children.transform.position;

            if (_tetris.IsInGrid(position) == false)
            {
                return false;
            }

            if (_tetris.GetGridPosition(position) != null && _tetris.GetGridPosition(position).parent !=transform)
            {
                return false;
            }
        }

        return true;
    }
}