using UnityEngine;

/**
 * SpawnShape.cs
 * @Author Ethan Baker - 986237
 *
 * Handles spawning new shapes
 */
public class SpawnShape : MonoBehaviour
{
    public GameObject[] tetrisShape;

    // private GameObject _nextShape;

    private bool _gameStarted = false;

    private readonly Vector3 _nextShapePosition = new Vector3(-6.5f, 15f, 0f);

    public void Start()
    {
        NewTetrisShape();
    }

    /**
     * 
     */
    public void NewTetrisShape()
    {
        // GameObject nextShape = (GameObject)Instantiate(Resources.Load(GetRandomShape(), typeof(GameObject)),
        //     new Vector2(5.0f, 20.0f), Quaternion.identity);

        // if (!_gameStarted)
        // {
        //     _gameStarted = true;
        Instantiate(tetrisShape[Random.Range(0, tetrisShape.Length)], transform.position, Quaternion.identity);
        //     _nextShape = Instantiate(tetrisShape[Random.Range(0, tetrisShape.Length)], _nextShapePosition, Quaternion.identity);
        //     _nextShape.GetComponent<Tetris>().enabled = false;
        // }
        // else
        // {
        //     _nextShape.transform.localPosition = new Vector2(5.0f, 20.0f);
        //     tetrisShape = _nextShape;
        // }
    }
    //
    // private static string GetRandomShape()
    // {
    //     var randomShape = Random.Range(1, 7);
    //
    //     var randomShapeName = "Prefabs/Blocks/O-block";
    //
    //     switch (randomShape)
    //     {
    //         case 1:
    //             randomShapeName = "Prefabs/Blocks/I-block";
    //             break;
    //         case 2 :
    //             randomShapeName = "Prefabs/Blocks/J-block";
    //             break;
    //         case 3:
    //             randomShapeName = "Prefabs/Blocks/L-block";
    //             break;
    //         case 4:
    //             randomShapeName = "Prefabs/Blocks/O-block";
    //             break;
    //         case 5:
    //             randomShapeName = "Prefabs/Blocks/S-block";
    //             break;
    //         case 6:
    //             randomShapeName = "Prefabs/Blocks/T-block";
    //             break;
    //         case 7:
    //             randomShapeName = "Prefabs/Blocks/Z-block";
    //             break;
    //     }
    //
    //     return randomShapeName;
    // }
}