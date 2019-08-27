//credit to: https://answers.unity.com/questions/677406/loading-new-scene-after-time.html

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //delay to wait until loading next scene
    public float delay = 1;
    //defines new level to load
    public string NewLevel = "Contraception";

    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        //delay and loads
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel);
    }
}
