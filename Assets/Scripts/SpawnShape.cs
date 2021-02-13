using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @Author Ethan Baker - 986237
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