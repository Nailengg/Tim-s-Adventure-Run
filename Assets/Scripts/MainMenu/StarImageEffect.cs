using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarImageEffect : MonoBehaviour
{
    [Header("Images")]
    public List<RectTransform> images = new List<RectTransform>();

    [Header("Effect Settings")]
    public float rotateSpeed = 20f;
    public float scaleSpeed = 0.5f;
    public float minScale = 0f;
    public float maxScale = 1f;

    private bool shrinking = true;

    void Update()
    {
        foreach (var img in images)
        {
            if (img == null) continue;

            img.Rotate(0, 0, rotateSpeed * Time.deltaTime);

            Vector3 scale = img.localScale;

            if (shrinking)
            {
                scale -= Vector3.one * scaleSpeed * Time.deltaTime;

                if (scale.x <= minScale)
                {
                    scale = Vector3.one * minScale;
                    shrinking = false;
                }
            }
            else
            {
                scale += Vector3.one * scaleSpeed * Time.deltaTime;

                if (scale.x >= maxScale)
                {
                    scale = Vector3.one * maxScale;
                    shrinking = true;
                }
            }

            img.localScale = scale;
        }
    }
}