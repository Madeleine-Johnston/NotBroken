using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;  
using System.Xml.Linq;  
using System.Xml.Schema;  
using System.Xml.XPath;  
using System.Xml.Xsl;

public class TextModuleStuff : MonoBehaviour {
    public static string modName;
    List<string> GUILines = new List<string>();
	private int numOfLines;
    private int currentLine;
    private Text txt;
    private Text txtTitle;
	private GameObject textPanel;
    private GameObject headingPanel;
    public GameObject nextButton;
    public GameObject prevButton;
	void Awake() {
		currentLine = 0;
	}
	public void GoHome() {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void Start()
    {
        LoadXML(modName);
        prevButton.SetActive(false);
    }
    public void LoadXML(string moduleName)
    {
        textPanel = GameObject.Find("TextPanel");
        headingPanel = GameObject.Find("Title");
        XElement root = XElement.Load(Application.dataPath + "/textmodules.xml");
        IEnumerable<XElement> tree =
            from node in root.Elements("Module")
            where node.Attribute("name").Value == moduleName
            select node;
        var screen = (from node in tree.Elements("Screen") select node.Value).ToList();
        GUILines = screen;
        numOfLines = screen.Count;
        txt = textPanel.GetComponent<Text>();
        txtTitle = headingPanel.GetComponent<Text>();
        txt.text = GUILines[currentLine];
        txtTitle.text = moduleName;
    }
    public void NextText() {
        currentLine++;
        if (currentLine != 0)
        {
            if (!prevButton.activeSelf)
            {
                prevButton.SetActive(true);
            }
        }
        if (currentLine == numOfLines)
        {
            if (nextButton.activeSelf)
            {
                nextButton.SetActive(false);
            }
        }
        else
        {
            txt = textPanel.GetComponent<Text>();
            txt.text = GUILines[currentLine];
            if (!nextButton.activeSelf)
            {
                nextButton.SetActive(true);
            }
        }
    }
    public void PreviousText() {
        currentLine--;
        if (currentLine != numOfLines)
        {
            if (!nextButton.activeSelf)
            {
                nextButton.SetActive(true);
            }
        }
        if (currentLine == -1)
        {
            if (prevButton.activeSelf)
            {
                prevButton.SetActive(false);
            }
        }
        else
        {
            txt = textPanel.GetComponent<Text>();
            txt.text = GUILines[currentLine];
            if (!prevButton.activeSelf)
            {
                prevButton.SetActive(true);
            }
        }
    }
}