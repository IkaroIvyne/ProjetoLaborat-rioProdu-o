using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using DG.Tweening;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System;

public class ItemCollectableBase : MonoBehaviour
{
    public string compateTag = "Player";
    public KeyCode keyCode = KeyCode.E;

    [Header("Notification")]
    public GameObject notification;
    public float tweenDuration = .2f;
    public Ease tweenEase = Ease.OutBack;

    [Header("Sounds")]
    public AudioSource audioSource;


    private float _startScale;



    void Start()
    {
        HideNotification();
        _startScale = notification.transform.localScale.x;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode) && notification.activeSelf)
        {
            Debug.Log("Iteragindo");
            Collect();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compateTag))
        {
            ShowNotification();
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compateTag))
        {
            HideNotification();
        }
    }

    private void ShowNotification()
    {
        notification.SetActive(true);
        notification.transform.DOScale(_startScale, tweenDuration).SetEase(tweenEase);
    }

    private void HideNotification()
    {
        notification.transform.DOScale(0, tweenDuration).SetEase(tweenEase);
        Invoke(nameof(OnHideNotification), tweenDuration);
    }

    private void OnHideNotification()
    {
        notification.SetActive(false);
    }

    protected virtual void Collect()
    {
        HideItems();
        OnCollect();
    }

    protected virtual void HideItems()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (audioSource != null)
        {
            audioSource.transform.SetParent(null);
            audioSource.Play();
        }
    }

  


}
