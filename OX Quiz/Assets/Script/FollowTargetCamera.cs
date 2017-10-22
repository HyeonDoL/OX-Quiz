using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetCamera : MonoBehaviour {

    public Transform m_target;

    private Vector3 m_currentPos;

	// Use this for initialization
	void Start () {
        m_currentPos = m_target.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        m_currentPos = Vector3.Lerp(m_currentPos, m_target.position * 0.1f, Time.deltaTime * 2f);
        transform.LookAt(m_currentPos);
    }
}
