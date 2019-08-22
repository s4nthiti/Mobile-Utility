using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader_Script : MonoBehaviour {

    public Text progressText;

    [SerializeField]
    public string sceneName;

    void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(LoadAsynchonously(sceneName));
    }

    IEnumerator LoadAsynchonously (string sceneName)
    {
        yield return new WaitForSeconds(1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressText.text = "Loading " + progress * 100f + "%";
            yield return null;
        }
    }
}
