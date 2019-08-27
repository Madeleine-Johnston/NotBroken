using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIStuff : MonoBehaviour {

    public GameObject self;

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        FadeIn(self);
        //check if backspace or start key pressed
		if (Input.GetKeyDown(KeyCode.Backspace))
        {
			  SceneManager.LoadScene(1);
		}
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
	IEnumerator FadeIn(GameObject obj) {
		Image im = obj.GetComponent<Image>();
		Color color = im.color;
		Vector3 endPos = obj.transform.position;
		im.color = new Color(color.r, color.g, color.b, 0);
		float currentPosX = endPos.x - 20;
		Vector3 currentPos = new Vector3 (currentPosX, endPos.y, endPos.z);
		obj.transform.position = currentPos;
		float timeCounter = 0;
		float currentAlpha = 0;
		while (timeCounter <= 1) {
			timeCounter+= Time.deltaTime;
			currentAlpha = color.a * timeCounter;
			currentPosX += timeCounter*20;
			currentPos = new Vector3 (currentPosX, endPos.y, endPos.z);
			im.color = new Color(color.r, color.g, color.b, currentAlpha);
			obj.transform.position = currentPos;
		}
		yield return null;
	}
    public void Consent() {
        TextModuleStuff.modName = "CONSENT";
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    //load different scenes below:

    public void About()
    {
        SceneManager.LoadScene("TextModule");
    }

    public void GameInfo()
    {
        SceneManager.LoadScene("GameInfo");
    }

    public void Contraception()
    {
        SceneManager.LoadScene("BloodVessleModel");
    }

    public void Genitalia()
    {
        SceneManager.LoadScene(7);
    }

    public void MascDiagramme()
    {
        SceneManager.LoadScene("MascDiagramme");
    }

    public void FemmeDiagramme()
    {
        SceneManager.LoadScene("FemmDiagramme");
    }

    public void BodyDiagramme()
    {
        SceneManager.LoadScene(3);
    }

  
}
