using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] float delay;
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] RectTransform target;
    public Vector2 startPoint;
    public Vector2 finalPoint;
    void Start(){

    }
    public void fadeIn(){
        StopAllCoroutines();
        StartCoroutine(fadeInCoroutine(startPoint,finalPoint));
    }

    public void fadeOut(){
        StopAllCoroutines();
        StartCoroutine(fadeInCoroutine(finalPoint,startPoint));
    }

    IEnumerator fadeInCoroutine(Vector2 a, Vector2 b){

        Vector2 startPoint = a;
        Vector2 finalPoint = b;

        float elapsed = 0;
        while(elapsed<=delay){
            elapsed+=Time.deltaTime;
            yield return null;
        }

        elapsed=0;

        while(elapsed<=duration){
            float porcentaje = elapsed / duration;
            elapsed +=Time.deltaTime;
            Vector2 currentPosition = Vector2.Lerp(startPoint,finalPoint,porcentaje);
            target.anchoredPosition = currentPosition;
            yield return null;
        }
    }
}
