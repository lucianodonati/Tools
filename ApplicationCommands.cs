///—————————————————————–
///   File: ApplicationCommands.cs
///   Author: Luciano Donati
///   me@lucianodonati.com	www.lucianodonati.com
///   Last edit: 03-Jun-18
///   Description: Class in charge of providing public methods for common calls on a Unity application. Usefull to load scenes from buttons or callbacks to exit the game, etc.
///—————————————————————–

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class in charge of providing public methods for common calls on a Unity application. Usefull to load scenes from buttons or callbacks to exit the game, etc.
/// </summary>
public class ApplicationCommands : MonoBehaviour
{
    /// <summary>
    /// Loads a scene by Build Index
    /// </summary>
    /// <param name="sceneBuildIndex">The sceneBuildIndex<see cref="int"/></param>
    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    /// <summary>
    /// Call to Application.Quit()
    /// </summary>
    public void QuitApplication()
    {
        Application.Quit();
    }
}
