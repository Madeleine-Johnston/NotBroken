using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour {

    public bool isColored = false;
    Color originalColor;
    public Color altColor;
    Renderer myRenderer;
    public Collider coll;
    public GameObject InfoText;
    public bool click = false;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        //gets oringinal colour of model parts
        originalColor = myRenderer.material.color;
        coll = GetComponent<Collider>();
        //'removes' colour of object parts to be coloured on click
        removeColour();
    }

    public void removeColour()
    {
        //applies black colour to model
        myRenderer.material.color = altColor;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && click == false)
        {
            //send raycast to detect collision
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if collision by raycast and object
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                //colours object original colour
                myRenderer.material.color = originalColor;
                //displays info about model part
                InfoText.SetActive(true);
                click = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && click == true)
            {
                //removes info text on screen
                InfoText.SetActive(false);
            }
        }
    }
}
