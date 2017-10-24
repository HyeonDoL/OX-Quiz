using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [System.Serializable]
    public struct UIInfo
    {
        public GameObject canvasObject;
        public GameState targetState;
    }

    [SerializeField]
    private UIInfo[] UIInfos;

    private void Awake()
    {
        foreach (var UIInfo in UIInfos)
            UIInfo.canvasObject.SetActive(false);
    }

    // Use this for initialization
    private void OnEnable()
    {
        GameManager.OnStateChange += ChangeUI;
    }

    private void OnDisable()
    {
        GameManager.OnStateChange -= ChangeUI;
    }

    private void ChangeUI(GameState currentGameState)
    {
        foreach (var UIInfo in UIInfos)
            UIInfo.canvasObject.SetActive(UIInfo.targetState == currentGameState);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
