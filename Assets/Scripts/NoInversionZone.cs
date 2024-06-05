using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoInversionZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && !collision.isTrigger)
        {
            print("Player in non-invert Zone");
            collision.GetComponent<CharacterController>().canChangeDirection = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player" && !collision.isTrigger)
        {
            print("Player out of non-invert Zone");
            collision.GetComponent<CharacterController>().canChangeDirection = true;
        }
    }
}
