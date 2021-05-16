using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 7.5f;
    //[SerializeField] float RotationSpeed = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;

        transform.Translate(xValue, 0, zValue);
    }

    void RotatePlayer()
    {
        float xValue = Input.GetAxis("Mouse Y");
        float yValue = Input.GetAxis("Mouse X");

        transform.Rotate(0, yValue, 0);
    }
}
