using System.Collections;
using UnityEngine;


namespace Luciano
{
    /// <summary>
    /// Class in charge of defining extension methods and miscellaneous tools.
    /// </summary>
    public static class MiscTools
    {
        #region Transform
        /// <summary>
        /// Resets a Transform (zero out)
        /// </summary>
        /// <param name="transform">Transform to Reset</param>
        public static void Reset(this Transform transform)
        {
            if (transform != null)
            {
                transform.position = Vector3.zero;
                transform.localScale = Vector3.zero;
                transform.rotation = Quaternion.identity;
            }
        }
        #endregion

        #region RectTransform
        /// <summary>
        /// Set the offsets of a RectTransform's rectangle
        /// </summary>
        /// <param name="rectTransform">RectTransform to modify</param>
        /// <param name="left">Left Offset</param>
        /// <param name="top">Top Offset</param>
        /// <param name="right">Right Offset</param>
        /// <param name="bottom">Bottom Offset</param>
        public static void SetOffsets(this RectTransform rectTransform, float left, float top, float right, float bottom)
        {
            if (rectTransform != null)
            {
                rectTransform.offsetMin = new Vector2(left, bottom);
                rectTransform.offsetMax = new Vector2(-right, -top);
            }

        }

        /// <summary>
        /// Resets a RectTransform (zero out)
        /// </summary>
        /// <param name="rectTransform">RectTransform to Reset</param>
        public static void Reset(this RectTransform rectTransform)
        {
            if (rectTransform != null)
            {
                rectTransform.offsetMin = Vector2.zero;
                rectTransform.offsetMax = Vector2.zero;
                rectTransform.sizeDelta = Vector2.zero;
            }

        }

        /// <summary>
        /// Expands a RectTransform to fill all of the available space
        /// </summary>
        /// <param name="rectTransform">RectTransform to Expand</param>
        public static void Expand(this RectTransform rectTransform)
        {
            if (rectTransform != null)
            {
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;

                rectTransform.pivot = Vector2.one * .5f;

                rectTransform.Reset();
            }
        }
        #endregion

        #region ICollection
        /// <summary>
        /// Checks if a collection is null or empty
        /// </summary>
        /// <param name="collection">The collection to check</param>
        /// <returns>Whether the collection is null or empty</returns>
        public static bool IsNullOrEmpty(this ICollection collection)
        {
            return null == collection || collection.Count == 0;
        }
        #endregion

    }
}
