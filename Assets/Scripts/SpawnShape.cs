using UnityEngine;

/**
 * SpawnShape.cs
 * @Author Ethan Baker - 986237
 *
 * Handles spawning new shapes
 */
public class SpawnShape : MonoBehaviour
{
    private GameObject _tetrisShape, _nextShape, _ghostShape;

    private static string _currentShape;

    private bool _gameStarted = false;

    private readonly Vector3 _nextShapePosition = new Vector3(-6f, 20f, 0f);

    public void Start()
    {
        NewTetrisShape();
    }
    
    /**
     * Spawns New Shape
     */
    public void NewTetrisShape()
    {
        if (!_gameStarted)
        {
            // GhostShape(); - Not ready to be implemented
            _gameStarted = true;

            // Adds a start shape and a Next Shape
            _tetrisShape = (GameObject) Instantiate(Resources.Load(GetRandomShape(), typeof(GameObject)),
                new Vector2(5.0f, 23.0f), Quaternion.identity);
            _nextShape = (GameObject) Instantiate(Resources.Load(GetRandomShape(), typeof(GameObject)),
                _nextShapePosition, Quaternion.identity);
            _nextShape.GetComponent<Tetris>().enabled = false;
        }
        else
        {
            // Moves Next Shape to Current Shape
            _nextShape.transform.localPosition = new Vector2(5.0f, 23.0f);
            _tetrisShape = _nextShape;
            _tetrisShape.GetComponent<Tetris>().enabled = true;

            // Adds a new next Shape
            _nextShape = (GameObject) Instantiate(Resources.Load(GetRandomShape(), typeof(GameObject)),
                _nextShapePosition, Quaternion.identity);
            _nextShape.GetComponent<Tetris>().enabled = false;
        }
    }

    /**
     * Gets Random Shape
     */
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

        SetCurrentShape(randomShapeName);
        return randomShapeName;
    }

    /**
     * Sets the Current Shape
     */
    private static void SetCurrentShape(string shape)
    {
        _currentShape = shape;
    }

    /**
     * Gets the Current Shape
     */
    private static string GetCurrentShape()
    {
        return _currentShape;
    }

    // Not Ready
    public void GhostShape()
    {
        _ghostShape = (GameObject) Instantiate(_nextShape,
            new Vector2(5f, 20f), Quaternion.identity);
        // Destroy(_ghostShape.GetComponent<);
        _ghostShape = _tetrisShape;
        _ghostShape.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.25f);
    }
}