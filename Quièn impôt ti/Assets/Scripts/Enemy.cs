using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 vitesse;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + vitesse * Time.deltaTime;

        if (transform.position.y <= -2.73f)
        {
            gameManager.GameOver();
        }

    }
    
}
