using System.Collections;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField]
    private float minPeriodicTime;

    [SerializeField]
    private float maxPeriodicTime;

    [SerializeField]
    private float appearTime;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private SpriteRenderer panelSpriteRender;

    [SerializeField]
    private TextMesh commentText;

    [SerializeField]
    private AiCommentSheet commentSheet;

    private const float LetterBlank = 0.9f;
    private const float LetterSize = 1.25f;

    private void Start()
    {
        StartCoroutine(AppearSpeechBubble());
    }

    private void Update()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    private IEnumerator AppearSpeechBubble()
    {
        while(true)
        {
            float periodicTime = Random.Range(minPeriodicTime, maxPeriodicTime);

            yield return new WaitForSeconds(periodicTime);

            string comment = commentSheet.m_data[Random.Range(0, commentSheet.m_data.Count)].comment;

            panelSpriteRender.size = new Vector2(LetterBlank + (comment.Length * LetterSize), panelSpriteRender.size.y);

            commentText.text = comment;

            panel.SetActive(true);

            yield return new WaitForSeconds(appearTime);

            commentText.text = "";

            panel.SetActive(false);
        }
    }
 }