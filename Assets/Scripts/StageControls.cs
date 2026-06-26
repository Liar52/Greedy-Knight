using UnityEngine;
using UnityEngine.SceneManagement;

public class StageControls : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayBosque()
    {
        LoadToStage.sceneToLoad = "SampleScene"; 
        SceneManager.LoadScene("Loading");
    }

    public void PlayCastillo()
    {
        LoadToStage.sceneToLoad = "Level2"; 
        SceneManager.LoadScene("Loading");
    }
}
