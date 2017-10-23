using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    [SerializeField] private GameObject m_camera;
    [SerializeField] private GameObject m_referee;
    [SerializeField] private GameObject m_Mainmenu;

    // Use this for initialization
    void Start () {
        StartCoroutine(PlayIntro());
	}
	
    private IEnumerator PlayIntro()
    {
        FadeBehavior.FadeOut(1f);

        yield return new WaitForSeconds(1.5f);
        m_referee.GetComponent<Animator>().SetTrigger("HandUp_Both");

        yield return new WaitForSeconds(0.8f);
        m_camera.GetComponent<Animator>().SetTrigger("On_Intro");
        
        yield return new WaitForSeconds(0.8f);
        m_Mainmenu.SetActive(true);

        Destroy(gameObject);
    }
}
