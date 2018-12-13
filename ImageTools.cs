///—————————————————————–
///   File: ImageTools.cs
///   Author: Luciano Donati
///   me@lucianodonati.com	www.lucianodonati.com
///—————————————————————–

using System.Collections;
using UnityEngine;
using UnityEngine.UI;



namespace Luciano.Tools
{
    /// <summary>
    /// <see cref="Singleton{T}"/> in charge of handling effects between <see cref="Image"/> canvas objects
    /// </summary>
    public class ImageTools : Singleton<ImageTools>
    {

        #region FadeTo

        /// <summary>
        /// Fade an Image's current color to a given one over a duration
        /// </summary>
        /// <param name="image">The <see cref="Image"/></param>
        /// <param name="fadeTo">The <see cref="Color"/> to fade to</param>
        /// <param name="duration">The duration of the effect</param>
        /// <returns>The <see cref="Coroutine"/> if you need to wait for it to finish.</returns>
        public Coroutine FadeImageTo(Image image, Color fadeTo, float duration)
        {
            return StartCoroutine(FadeImageFromToRoutine(image, image.color, fadeTo, duration));
        }

	    private IEnumerator FadeImageFromToRoutine(Image image, Color startColor, Color endColor, float duration)
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
        #endregion

        #region RadialFill
	    /// <summary>
	    /// Radial fill an image over time.
	    /// </summary>
	    /// <param name="image">The image to fill</param>
	    /// <param name="duration">Over how long should it be filled</param>
	    /// <param name="fillMethod">Fill method used. (Default: Radial360)</param>
        public void RadialFillOverTime(Image image, float duration, Image.FillMethod fillMethod = Image.FillMethod.Radial360)
        {
            image.type = Image.Type.Filled;
            image.fillMethod = fillMethod;

            StartCoroutine(RadialFillRoutine(image, duration));
        }

        private IEnumerator RadialFillRoutine(Image image, float duration)
        {
            float t = 0;

            image.fillAmount = 0;

            while (t < duration)
            {
                yield return null;
                t += Time.deltaTime;
                image.fillAmount = t / duration;
            }

            image.fillAmount = 1;
        }
        #endregion
    }
}