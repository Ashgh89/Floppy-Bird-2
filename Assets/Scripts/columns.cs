using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columns : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameController.instance.BirdScore();
            GameController.instance.UpdateAddScore();



        }
    }
}
