using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Slider loadingSlider;

    public Text loadingText, loadedText;
    // public GameObject profile;

    public void Loader(int scene)
    {
        StartCoroutine(LoadAsynchronously(scene));
    }

    public void AnyKeyLoader(int scene)
    {
        loadingSlider.gameObject.SetActive(true);
        StartCoroutine(LoadAsynchronously(scene));
    }

    IEnumerator LoadAsynchronously(int scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;
            loadingText.text = progress * 100f + "%";
            yield return null;
        }
    }
}