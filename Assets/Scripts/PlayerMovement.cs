using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isVisible1;
    bool isVisible2;
    bool isFrozen;
    int duration;
    int startTime;
    Vector3 startPosition;
    Quaternion startRotation;
    [SerializeField] GameObject visibilityCheck1;
    [SerializeField] GameObject visibilityCheck2;
    [SerializeField] float MovementSpeed = 7.5f;
    [SerializeField] GameObject light;
    [SerializeField] int lightToggleMin = 5;
    [SerializeField] int lightToggleMax = 10;
    //[SerializeField] float RotationSpeed = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        light.GetComponent<Light>().enabled = false;
        isFrozen = false;

        duration = (int)Random.Range(lightToggleMin, lightToggleMax);
        startTime = (int)Time.time;

        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        LightAvoidingSystem visibilityScript1 = visibilityCheck1.GetComponent<LightAvoidingSystem>();
        LightAvoidingSystem visibilityScript2 = visibilityCheck2.GetComponent<LightAvoidingSystem>();
        isVisible1 = visibilityScript1.isVisible;
        isVisible2 = visibilityScript2.isVisible;
        StartCoroutine(CheckIfSeen());
        
        if (!isFrozen) {
            MovePlayer();
            RotatePlayer();
        }

        ToggleLight();
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

    void ToggleLight()
    {
        if (Time.time - startTime! >= duration)
        {
            if (light.GetComponent<Light>().enabled == true)
            {
                light.GetComponent<Light>().enabled = false;
            }
            else if (light.GetComponent<Light>().enabled == false)
            {
                light.GetComponent<Light>().enabled = true;
            }

            duration = (int)Random.Range(lightToggleMin, lightToggleMax);
            startTime = (int)Time.time;
        }
    }

    IEnumerator CheckIfSeen()
    {
        if (light.GetComponent<Light>().enabled == true)
        {
            if (isVisible1 || isVisible2)
            {
                isFrozen = true;
                yield return new WaitForSeconds(1);
                transform.position = startPosition;
                transform.rotation = startRotation;
                yield return new WaitForSeconds(4);
                isFrozen = false;
            }
        }
    }
}
