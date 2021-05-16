using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] GameObject cheese;
    public int score;
    bool isCarryingCheese;

    private void Start()
    {
        cheese.GetComponent<MeshRenderer>().enabled = false;
        isCarryingCheese = false;
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
