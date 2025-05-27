using System.Collections;
using UnityEngine;

public class MovingIntroductionText : MonoBehaviour
{
    public GameObject text;
    public GameObject background;
    public float endYPosition = 1000f;
    public float animationDuration = 1f;
    public float stayingTime = 2f;

    private bool isAnimating = false;
    private bool timeIsUp = false;

    private void Start()
    {
        
        StartCoroutine(TimerCoroutine());
    }

    private void Update()
    {
        if (timeIsUp && !isAnimating)
        {
            
            StartCoroutine(AnimateObjects());
        }
    }

    private IEnumerator AnimateObjects()
    {
        isAnimating = true;

        
        if (text == null || background == null) yield break;

        
        RectTransform textRectTransform = text.GetComponent<RectTransform>();
        Transform backgroundTransform = background.GetComponent<Transform>();
        Vector2 textStartPosition = textRectTransform.anchoredPosition;
        Vector3 backgroundStartPosition = backgroundTransform.position;

        
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
           
            float t = elapsedTime / animationDuration;

            
            textRectTransform.anchoredPosition = Vector2.Lerp(textStartPosition, new Vector2(textStartPosition.x, endYPosition), t);
            backgroundTransform.position = Vector3.Lerp(backgroundStartPosition, new Vector3(backgroundStartPosition.x, endYPosition, backgroundStartPosition.z), t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        textRectTransform.anchoredPosition = new Vector2(textRectTransform.anchoredPosition.x, endYPosition);
        backgroundTransform.position = new Vector3(backgroundTransform.position.x, endYPosition, backgroundTransform.position.z);

        isAnimating = false; 
    }

    private IEnumerator TimerCoroutine()
    {
       
        yield return new WaitForSeconds(stayingTime);
        timeIsUp = true;
    }
}

