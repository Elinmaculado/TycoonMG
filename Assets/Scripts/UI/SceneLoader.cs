using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Image BlackBG;

    private void Start()
    {
        StartCoroutine(fadeIn());
    }

    public void CargarEscena(int _scene)
    {
        StartCoroutine(fadeOut(_scene));
    }

    public void Salir()
    {
        Application.Quit();
    }

    IEnumerator fadeIn()
    {
        Color c = BlackBG.color;
        for (float alpha = 1f; alpha >= 0f; alpha -= 2f*Time.deltaTime) 
        {
            c.a = alpha;
            BlackBG.color = c;
            yield return null;
        }
    }
    IEnumerator fadeOut(int _scene)
    {
        Color c = BlackBG.color;
        for (float alpha = 0f; alpha <= 1f; alpha += 2f*Time.deltaTime) 
        {
            c.a = alpha;
            BlackBG.color = c;
            yield return null;
        }
        //Cambio de escena
        SceneManager.LoadScene(_scene);
    }
}
