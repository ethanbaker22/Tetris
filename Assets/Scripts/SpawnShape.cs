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
    
    public void Start()
    {
        NewTetrisShape();
    }

    /**
     * 
     */
    public void NewTetrisShape()
    {
        Instantiate(tetrisShape[Random.Range(0, tetrisShape.Length)], transform.position, Quaternion.identity);
    }
}