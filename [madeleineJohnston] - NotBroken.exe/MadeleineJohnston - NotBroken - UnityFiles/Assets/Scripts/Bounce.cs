using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bounce : MonoBehaviour {

    public Rigidbody ball;
    public Vector3 direction;
    public float min, max;
    public Collider coll;
 
    public ScoreKeeper skeeper;


    void Start()
    {
        ball = GetComponent<Rigidbody>();
        //sets objects velocity between 10 and 100
        ball.velocity = MovementVector(10f, 100f);
        coll = GetComponent<Collider>();
        skeeper = FindObjectOfType<ScoreKeeper>();

    }


    private Vector2 MovementVector(float min, float max)
    {
        //finds random number for veolicty between 10 and 100
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector2(x, y);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if mouse click then send out raycast 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, 1000.0f))
            {
                //if theres a collition then destory gameObject it hit
                Destroy(hit.collider.gameObject);
                Debug.Log("hit");
                //update score
                skeeper.score++;
                skeeper.UpdateScore();
            }
        }
    }



}
