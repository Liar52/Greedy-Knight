using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToStage : MonoBehaviour
{
    public static string sceneToLoad = "SampleScene"; // Default scene to load

    void Start()
    {
        StartCoroutine(LoadStage());
    }

    IEnumerator LoadStage()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneToLoad);
    }
}