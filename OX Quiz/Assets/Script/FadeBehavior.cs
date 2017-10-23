using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBehavior : MonoBehaviour {

    private static FadeBehavior instance = null;
    public static FadeBehavior Instance
    {
        get
        {
            return instance;
        }
    }

    private UnityEngine.UI.Image image;

	// Use this for initialization
	void Awake () {
        if (!instance)
            instance = this;

        image = GetComponent<UnityEngine.UI.Image>();
	}
	
	// Update is called once per frame
	public static void FadeIn(float t)
    {
        Instance.StartCoroutine(Instance._FadeIn(t));
    }

    private IEnumerator _FadeIn(float t)
    {
        for (float f = 0f; f < t; f += Time.deltaTime)
        {
            Color color = image.color;
            SetColorAlpha(f / t);
            image.color = color;
            yield return null;
        }

        SetColorAlpha(1f);
    }

    public static void FadeOut(float t)
    {
        Instance.StartCoroutine(Instance._FadeOut(t));
    }

    private IEnumerator _FadeOut(float t)
    {
        for (float f = 0f; f < t; f += Time.deltaTime)
        {
            SetColorAlpha(1f - f / t);
            yield return null;
        }

        SetColorAlpha(0f);
    }

    private void SetColorAlpha(float a)
    {
        Color color = image.color;
        color.a = a;
        image.color = color;
    }
}
