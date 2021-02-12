// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class DeleteLines : MonoBehaviour
// {
//     // Width & Height of the game area
//     private const int Width = 10;
//     private const int Height = 25;
//     
//     private static Transform[,] _grid = new Transform[Width, Height];
//     
//     // Start is called before the first frame update
//     public void Start()
//     {
//         DeleteLinesUponComplete();
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
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
// }
