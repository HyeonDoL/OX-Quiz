using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    [SerializeField] private GameObject m_fadePanel;
    [SerializeField] private GameObject m_camera;
    [SerializeField] private GameObject m_referee;

	// Use this for initialization
	void Start () {
        StartCoroutine(PlayIntro());
	}
	
    private IEnumerator PlayIntro()
    {
        m_fadePanel.GetComponent<Animation>().Play();

        yield return new WaitForSeconds(1f);
        m_camera.GetComponent<Animation>().Play();


    }
}
