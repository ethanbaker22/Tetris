// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class GhostShape : MonoBehaviour
// {
//     
//     private const int Width = 10;
//     private const int Height = 25;
//
//     public static Transform[,] grid = new Transform[Width, Height];
//     // Start is called before the first frame update
//     void Start()
//     {
//         tag = "ghost";
//         foreach (Transform shape in transform)
//         {
//             shape.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.25f);
//         }
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         ActiveShape();
//     }
//
//     void ActiveShape()
//     {
//         Transform currentActive = GameObject.FindGameObjectWithTag("active").transform;
//         
//         transform.position = currentActive.position;
//         transform.rotation = currentActive.rotation;
//     }
//
//     void PlaceGhost()
//     {
//         
//     }
//
//     Transform GetPosition(Vector2 pos)
//     {
//         if (pos.y > Height - 1)
//         {
//             return null;
//         }
//         else
//         {
//             return grid[(int) pos.x, (int) pos.y];
//         }
//     }
//
//     bool IsInsideGrid(Vector2 pos)
//     {
//         return ((int) pos.x >= 0 && (int) pos.x < Width && (int) pos.y >= 0);
//     }
//     
//     bool IsValidMove()
//     {
//         foreach (Transform shape in transform)
//         {
//             Vector2 pos = shape.position;
//             if (IsInsideGrid(pos))
//             {
//                 return false;
//             }
//
//             if (GetPosition(pos) != null && GetPosition(pos).parent)
//             {
//                 
//             }
//         }
//     }
// }
