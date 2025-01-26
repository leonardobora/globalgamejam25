using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float maxY = 10.24f;
    
    private float currentPositionY;

    void Awake (){
        currentPositionY = transform.position.y;
    }

    void Update()
    {
        currentPositionY += GameManager.Instance().vertical_speed * Time.deltaTime;
        
        if(currentPositionY < maxY)
        {
            currentPositionY = 0f;
        }
        transform.position = new Vector3(0, currentPositionY, 0);
    }
}