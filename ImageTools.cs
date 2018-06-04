///—————————————————————–
///   File: ImageTools.cs
///   Author: Luciano Donati
///   me@lucianodonati.com	www.lucianodonati.com
///   Last edit: 03-Jun-18
///   Description: Singleton in charge of handling effects between Image canvas objects
///—————————————————————–

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// <see cref="Singleton{T}"/> in charge of handling effects between <see cref="Image"/> canvas objects
/// </summary>
public class ImageTools : Singleton<ImageTools>
{
    /// <summary>
    /// Fade an Image's current color to a given one over a duration
    /// </summary>
    /// <param name="image">The <see cref="Image"/></param>
    /// <param name="fadeTo">The <see cref="Color"/> to fade to</param>
    /// <param name="duration">The duration of the effect</param>
    /// <returns>The <see cref="Coroutine"/> if you need to wait for it to finish.</returns>
    public Coroutine FadeImageTo(Image image, Color fadeTo, float duration)
    {
        return StartCoroutine(FadeImageFromTo(image, image.color, fadeTo, duration));
    }

    /// <summary>
    /// Fade an Image's from a given color to another one over a duration
    /// </summary>
    /// <param name="image">The <see cref="Image"/></param>
    /// <param name="startColor">The <see cref="Color"/> to fade from</param>
    /// <param name="endColor">The <see cref="Color"/> to fade to</param>
    /// <param name="duration">The duration of the effect</param>
    public IEnumerator FadeImageFromTo(Image image, Color startColor, Color endColor, float duration)
    {
        float timeEllapsed = 0;

        image.color = startColor;
        while (timeEllapsed < duration)
        {
            yield return null;
            timeEllapsed += Time.deltaTime;
            image.color = Color.Lerp(startColor, endColor, timeEllapsed / duration);
        }
        image.color = endColor;
    }
}
