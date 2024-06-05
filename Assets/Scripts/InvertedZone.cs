using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !collision.isTrigger)
        {
            print("Player in invert Zone");
            collision.GetComponent<CharacterController>().Invoke("InvertMove", 0.2f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Player" && !collision.isTrigger)
        {
            print("Player out of invert Zone");
            collision.GetComponent<CharacterController>().Invoke("InvertMove",0.2f);
        }
    }
}
