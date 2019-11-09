using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Grayscale : MonoBehaviour
{
    public Shader shader;
    private Material material;

    private void Awake()
    {
        material = new Material(shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(PlayerPrefs.GetInt("use_grayscale", 0) != 0) {
            Graphics.Blit(source, destination, material);
        } else
        {
            Graphics.Blit(source, destination);
        }
    }
}
