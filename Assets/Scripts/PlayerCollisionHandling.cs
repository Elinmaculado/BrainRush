using System;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollisionHandling : MonoBehaviour
{
    public Image progressBar;
    public float recoveryRate;
    public float growthHit;
    
    private void Start()
    {
        progressBar.fillAmount = 0;
    }
    private void Update()
    {
        if (progressBar.fillAmount >= 1) return;
        progressBar.fillAmount -= recoveryRate * Time.deltaTime;
    }

    public void WhenHit()
    {
        progressBar.fillAmount += growthHit;
        Debug.Log("Ouch");
    }

}
