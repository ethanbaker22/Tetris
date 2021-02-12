using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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