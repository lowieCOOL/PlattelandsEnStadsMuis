using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    PlayerMovement movementScript;
    public int score;
    bool isCarryingCheese;
    [SerializeField] GameObject cheese;


    private void Start()
    {
        cheese.GetComponent<MeshRenderer>().enabled = false;
        isCarryingCheese = false;

        movementScript = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (movementScript.isFrozen)
        {
            isCarryingCheese = false;
            cheese.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Pantry Pad")
        {
            cheese.GetComponent<MeshRenderer>().enabled = true;
            isCarryingCheese = true;
        }
        else if (collision.collider.tag == "Collect Pad" && isCarryingCheese)
        {
            cheese.GetComponent<MeshRenderer>().enabled = false;
            isCarryingCheese = false;
            score++;
        }
    }
}
