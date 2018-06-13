using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageRadialLoad : MonoBehaviour
{
    [SerializeField]
    Image image = null;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (null == image)
            image = GetComponent<Image>();
        image.type = Image.Type.Filled;
        image.fillMethod = Image.FillMethod.Radial360;
    }
#endif

    public void UpdateProgress(float progress, float from, float to)
    {
        image.fillAmount = Mathf.Lerp(from, to, progress);
    }

    public void UpdateProgress(float progress)
    {
        UpdateProgress(progress, 0, 1);
    }

}
