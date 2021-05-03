using UnityEngine;

/**
 * SpawnShape.cs
 * @Author Ethan Baker - 986237
 *
 * Handles spawning new shapes
 */
public class SpawnShape : MonoBehaviour
{
    // public GameObject[] tetrisShape;

    public GameObject tetrisShape, nextShape;

    private bool _gameStarted = false;

    private readonly Vector3 _nextShapePosition = new Vector3(-6f, 20f, 0f);

    public void Start()
    {
        NewTetrisShape();
    }

    /**
     * 
     */
    public void NewTetrisShape()
    {
        if (!_gameStarted)
        {
            _gameStarted = true;

            tetrisShape = (GameObject) Instantiate(Resources.Load(GetRandomShape(), typeof(GameObject)),
                new Vector2(5.0f, 23.0f), Quaternion.identity);
            nextShape = (GameObject) Instantiate(Resources.Load(GetRandomShape(), typeof(GameObject)),
                _nextShapePosition, Quaternion.identity);
            nextShape.GetComponent<Tetris>().enabled = false;
        }
        else
        {
            nextShape.transform.localPosition = new Vector2(5.0f, 23.0f);
            tetrisShape = nextShape;
            tetrisShape.GetComponent<Tetris>().enabled = true;
            
            nextShape = (GameObject) Instantiate(Resources.Load(GetRandomShape(), typeof(GameObject)),
                _nextShapePosition, Quaternion.identity);
            nextShape.GetComponent<Tetris>().enabled = false;
        }
    }

    private static string GetRandomShape()
    {
        var randomShape = Random.Range(1, 8);

        var randomShapeName = "Prefabs/Blocks/O-block";

        switch (randomShape)
        {
            case 1:
                randomShapeName = "Prefabs/Blocks/I-block";
                break;
            case 2:
                randomShapeName = "Prefabs/Blocks/J-block";
                break;
            case 3:
                randomShapeName = "Prefabs/Blocks/L-block";
                break;
            case 4:
                randomShapeName = "Prefabs/Blocks/O-block";
                break;
            case 5:
                randomShapeName = "Prefabs/Blocks/S-block";
                break;
            case 6:
                randomShapeName = "Prefabs/Blocks/T-block";
                break;
            case 7:
                randomShapeName = "Prefabs/Blocks/Z-block";
                break;
        }

        return randomShapeName;
    }
}