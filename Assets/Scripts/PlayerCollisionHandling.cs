using System;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollisionHandling : MonoBehaviour
{
    public Image progressBar;
    public float recoveryRate = 0.03f;
    
    private void Start()
    {
        progressBar.fillAmount = 0;
    }
    private void Update()
    {
        progressBar.fillAmount -= recoveryRate * Time.deltaTime;
    }

    public void WhenHit()
    {
        progressBar.fillAmount += 0.5f;
        Debug.Log("Ouch");
    }

}
