using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    public float rotationSpeed;
    public float lightOffset;
    float timeCounter;

    void Start()
    {
        timeCounter = 0.0f;
    }

    void Update()
    {
        //remember to add collider and particle system to the 3D object!!!
        Collider coll = GetComponent<Collider>();
        ParticleSystem prettyLights = GetComponent<ParticleSystem>();
        if (Input.GetKey("mouse 0"))
        {
            StartCoroutine(Dragging());
        }
        else
        {
            StopCoroutine(Dragging());
        }
        if (Input.GetKey("mouse 1"))
        {
            StartCoroutine(DraggingMinus());
        }
        else
        {
            StopCoroutine(DraggingMinus());
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (coll.Raycast(ray, out hit, Mathf.Infinity))
        {
            prettyLights.Play();
            if (GameObject.Find("Backlight"))
            {
                //if previous coroutine hasn't finished, then kill old light before making a new one
                Destroy(GameObject.Find("Backlight"));
            }
            GameObject backlight = new GameObject("Backlight");
            Light lightComponent = backlight.AddComponent<Light>();
            lightComponent.colorTemperature = 5000;
            lightComponent.intensity = 2;
            //lightComponent.shadowAngle = 10;
            lightComponent.shadows = LightShadows.Soft;
            lightComponent.type = LightType.Directional;
            backlight.transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z + lightOffset));
            backlight.transform.rotation = Quaternion.Euler(Vector3.forward);
        }
        else
        {
            prettyLights.Stop();
            if (GameObject.Find("Backlight"))
            {
                StartCoroutine(FadeandKill());
            }
        }
    }

    IEnumerator Dragging()
    {
        float rotationX = (Input.GetAxis("Mouse X") + 90.0f) * rotationSpeed * Mathf.Deg2Rad;
        float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, rotationX);
        transform.Rotate(Vector3.right, rotationY); 
        yield return null;
    }
    IEnumerator DraggingMinus()
    {
        float rotationX = (Input.GetAxis("Mouse X") - 90.0f) * rotationSpeed * Mathf.Deg2Rad;
        float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, rotationX);
        transform.Rotate(Vector3.left, rotationY);
        yield return null;
    }
    IEnumerator FadeandKill()
    {
        //fade the backlight over 2 seconds on mouse off, instead of just killing
        timeCounter += Time.deltaTime;
        if (GameObject.Find("Backlight"))
        {
            Light lig = GameObject.Find("Backlight").GetComponent<Light>();
            float startInt = lig.intensity;
            if (lig.intensity > 0)
            {
                lig.intensity -= (timeCounter * startInt / 2);
            }
            else
            {
                Destroy(GameObject.Find("Backlight"));
            }
        }
        yield return null;
    }
}

