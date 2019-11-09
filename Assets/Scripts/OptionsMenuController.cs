using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuController : MonoBehaviour
{
    private bool showConfirmQuit = false;

    private Canvas canvas;
    private GameObject confirmQuit;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        confirmQuit = transform.Find("Confirm Quit").gameObject;
        confirmQuit.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Options Menu"))
        {
            canvas.enabled = !canvas.enabled;
            confirmQuit.SetActive(false);
        }
    }

    public bool isActive()
    {
        return canvas.enabled;
    }

    public void ToggleQuitConfirm()
    {
        confirmQuit.SetActive(!confirmQuit.activeSelf);
    }

    public void Quit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ToggleGrayscale()
    {
        int grayscale = PlayerPrefs.GetInt("use_grayscale", 0);
        if(grayscale == 0)
        {
            PlayerPrefs.SetInt("use_grayscale", 1);
        } else
        {
            PlayerPrefs.SetInt("use_grayscale", 0);
        }
    }
}
