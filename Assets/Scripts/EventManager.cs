using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Image progressBar;

    [Header("Obstacles")]
    public float obstacleSpeed;
    
    [Header("Player")]
    public GameObject mainBody;
    public GameObject Invisi1;
    public GameObject Invisi2;
    public GameObject KojimaSan;
    public AudioSource audioSource;
    public bool isInvisible = false;
    
    [Header("Camera event")]
    public GameObject camera;
    public float rotationSpeed;
    public bool isRotating = false;

    // Update is called once per frame

    private void Start()
    {
        audioSource.Play();
        audioSource.Stop();
    }

    void Update()
    {
        RotateCamera();
        if (progressBar.fillAmount >= 0.1f) isRotating = true;
        if (progressBar.fillAmount >= 0.2f && !isInvisible) Invisible();
    }

    private void RotateCamera()
    {
        if (isRotating)
            camera.transform.localRotation *= Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void Invisible()
    {
        isInvisible = true;
        mainBody.SetActive(false);
        Invisi1.SetActive(true);
        Invisi2.SetActive(true);
        KojimaSan.SetActive(true);
        audioSource.Play();
    }
}
