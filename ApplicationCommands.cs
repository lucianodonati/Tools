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
    /// <summary>
    /// Defines the <see cref="ProgressEvent"/> class for events with 1 float parameter.
    /// </summary>
    [Serializable]
    public class ProgressEvent : UnityEvent<float>
    {
    }

    /// <summary>
    /// Defines the progressEvent to subscribe to
    /// </summary>
    [SerializeField]
    private ProgressEvent progressEvent = null;

    /// <summary>
    /// Defines the operation of async-loading (for progress)
    /// </summary>
    private AsyncOperation async = null;

    /// <summary>
    /// Loads a scene by Build Index
    /// </summary>
    /// <param name="sceneBuildIndex">The sceneBuildIndex<see cref="int"/></param>
    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    /// <summary>
    /// Loads a scene by Build Index asynchronously
    /// </summary>
    /// <param name="sceneBuildIndex">The sceneBuildIndex<see cref="int"/></param>
    public void LoadSceneAsync(int sceneBuildIndex)
    {
        progressEvent.Invoke(0);
        async = SceneManager.LoadSceneAsync(sceneBuildIndex);
    }

    /// <summary>
    /// Loads a scene by Build Index asynchronously and adds it
    /// </summary>
    /// <param name="sceneBuildIndex">The sceneBuildIndex<see cref="int"/></param>
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

    /// <summary>
    /// The OpenURL
    /// </summary>
    /// <param name="URL">The URL<see cref="string"/></param>
    public void OpenURL(string URL)
    {
        Application.OpenURL(URL);
    }
}
