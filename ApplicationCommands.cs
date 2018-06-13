///—————————————————————–
///   File: ApplicationCommands.cs
///   Author: Luciano Donati
///   me@lucianodonati.com	www.lucianodonati.com
///   Last edit: 03-Jun-18
///   Description: Class in charge of providing public methods for common calls on a Unity application. Usefull to load scenes from buttons or callbacks to exit the game, etc.
///—————————————————————–

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// Class in charge of providing public methods for common calls on a Unity application. Usefull to load scenes from buttons or callbacks to exit the game, etc.
/// </summary>
public class ApplicationCommands : MonoBehaviour
{
    [Serializable]
    public class ProgressEvent : UnityEvent<float> { }

    [SerializeField]
    private ProgressEvent progressEvent = null;

    private AsyncOperation async = null;

    /// <summary>
    /// Loads a scene by Build Index
    /// </summary>
    /// <param name="sceneBuildIndex">The sceneBuildIndex<see cref="int"/></param>
    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void LoadSceneAsync(int sceneBuildIndex)
    {
        progressEvent.Invoke(0);
        async = SceneManager.LoadSceneAsync(sceneBuildIndex);
    }

    public void LoadSceneAsyncAdd(int sceneBuildIndex)
    {
        progressEvent.Invoke(0);
        async = SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (null != async)
        {
            progressEvent.Invoke(async.progress);
        }
    }
    /// <summary>
    /// Call to Application.Quit()
    /// </summary>
    public void QuitApplication()
    {
        Application.Quit();

    }

    public void OpenURL(string URL)
    {
        Application.OpenURL(URL);
    }
}
