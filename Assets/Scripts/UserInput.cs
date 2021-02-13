// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class UserInput : MonoBehaviour
// {
//     private float _prevTime;
//     private const int Width = 10, Height = 25;
//
//     [SerializeField] public float fallTime;
//     [SerializeField] public Vector3 rotation;
//     
//     private Tetris _tetris;
//     private SpawnShape _spawnShape;
//     
//     private static Transform[,] _grid = new Transform[Width, Height];
//
//     void Start()
//     {
//         CheckUserInput();
//         _spawnShape = FindObjectOfType<SpawnShape>();
//         _tetris = FindObjectOfType<Tetris>();
//     }
//
//     public void CheckUserInput()
//     {
//         if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
//         {
//             transform.position += new Vector3(-1, 0, 0);
//             if (!IsValidMove())
//             {
//                 transform.position -= new Vector3(-1, 0, 0);
//             }
//         }
//         //
//         else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
//         {
//             transform.position += new Vector3(1, 0, 0);
//             if (!IsValidMove())
//             {
//                 transform.position -= new Vector3(1, 0, 0);
//             }
//         }
//         //
//         else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
//         {
//             transform.RotateAround(transform.TransformPoint(rotation), new Vector3(0, 0, 1), 90);
//             if (!IsValidMove())
//             {
//                 transform.RotateAround(transform.TransformPoint(rotation), new Vector3(0, 0, 1), -90);
//             }
//         }
//
//         //
//         if (Time.time - _prevTime >
//             ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? fallTime / 10 : fallTime))
//         {
//             transform.position += new Vector3(0, -1, 0);
//             if (!IsValidMove())
//             {
//                 transform.position -= new Vector3(0, -1, 0);
//                 AddToGrid();
//                 DeleteLinesUponComplete();
//
//                 this.enabled = false;
//                 _spawnShape.NewTetrisShape();
//             }
//
//             _prevTime = Time.time;
//         }
//     }
//     
//     public bool IsValidMove()
//     {
//         foreach (Transform children in transform)
//         {
//             var position = children.transform.position;
//             var x = Mathf.RoundToInt(position.x);
//             var y = Mathf.RoundToInt(position.y);
//
//             if (x < 0 || x >= Width || y < 0 || y >= Height)
//             {
//                 return false;
//             }
//
//             if (_grid != null && _grid[x, y] != null)
//             {
//                 return false;
//             }
//         }
//
//         return true;
//     }
//     
//     
//     public void DeleteLinesUponComplete()
//     {
//         for (int i = Height - 1; i >= 0; i--)
//         {
//             if (LineFull(i))
//             {
//                 DeleteFullLine(i);
//                 MoveRowDown(i);
//             }
//         }
//     }
//
//
//     bool LineFull(int i)
//     {
//         for (int j = 0; j < Width; j++)
//         {
//             if (_grid[j, i] == null)
//             {
//                 return false;
//             }
//         }
//
//         return true;
//     }
//
//     void DeleteFullLine(int i)
//     {
//         for (int j = 0; j < Width; j++)
//         {
//             Destroy(_grid[j, i].gameObject);
//             _grid[j, i] = null;
//         }
//     }
//
//
//     void MoveRowDown(int i)
//     {
//         for (int y = i; y < Height; y++)
//         {
//             for (int j = 0; j < Width; j++)
//             {
//                 if (_grid[j, y] != null)
//                 {
//                     _grid[j, y - 1] = _grid[j, y];
//                     _grid[j, y] = null;
//                     _grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
//                 }
//             }
//         }
//     }
//
//     /**
//      * 
//      */
//     public void AddToGrid()
//     {
//         foreach (Transform children in transform)
//         {
//             var position = children.transform.position;
//             var x = Mathf.RoundToInt(position.x);
//             var y = Mathf.RoundToInt(position.y);
//
//             if (y <= Height - 5)
//             {
//                 _grid[x, y] = children;
//             }
//         }
//     }
// }
