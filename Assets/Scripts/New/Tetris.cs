using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris : MonoBehaviour
{
    private const int Width = 10;
    private const int Height = 25;
    
    private SpawnShape _spawnShape;
    
    // Add shapes to grid array to know where they are located
    private static Transform[,] _grid = new Transform[Width, Height];
    
    /**
     * 
     */
    void Start()
    {
        _spawnShape = FindObjectOfType<SpawnShape>();
    }

    /**
     * 
     */
    public bool IsInGrid(Vector2 position)
    {
        return ((int)position.x >= 0 && (int)position.x< Width && (int)position.y >= 0);
    }

    /**
     * 
     */
    public void AddToGrid(Shape shape)
    {
        //
        for (var y = 0; y < Height; ++y)
        {
            for (var x = 0; x < Width; ++x)
            {
                if (_grid[x, y] != null)
                {
                    if (_grid[x, y].parent == shape.transform)
                    {
                        _grid[x, y] = null;
                    }
                }
            }
        }

        //
        foreach (Transform children in shape.transform)
        {
            var position = children.transform.position;

            if (position.y < Height)
            {
                _grid[(int) position.x, (int) position.y] = children;
            }
        }
    }
    
    /**
     * 
     */
    public Transform GetGridPosition(Vector2 position)
    {
        if (position.y > Height - 1)
        {
            return null;
        }
        else
        {
            return _grid[(int) position.x, (int) position.y];
        }
    }
}