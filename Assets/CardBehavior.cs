using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardBehavior : MonoBehaviour
{
    private Vector3 originalScale;
    public Transform cameraTransform;
    private bool cardFlipped = false;
    private Sequence cardSequence;

    private void Start()
    {  
        originalScale = transform.localScale;
        cardSequence = DOTween.Sequence();
    }
    private void OnMouseOver()
    {
        transform.DOScale(originalScale * 1.25f, 0.2f);
        Debug.Log("Card is hovered.");
    }

    private void OnMouseExit()
    {
        transform.DOScale(originalScale, 0.2f);
    }

    private void OnMouseDown()
    {
        if (cardFlipped == false)
        {
            cardSequence.Append(transform.DORotate(new Vector3(0, 0, 0), 0.1f));
            cardSequence.Join(cameraTransform.DOShakePosition(0.4f, new Vector3(0.01f, 0.01f, 0.01f), 25, 10));
            cardFlipped = true;
        }
    }
}
