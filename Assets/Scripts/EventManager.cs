using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Image progressBar;

    [Header("Obstacles")]
    public float obstacleSpeed;
    public ObstacleSpawner spawner;
    
    [Header("Weeds")]
    public GameObject[] weeds = new GameObject[4];
    public bool areWeedsActive = false;
    
    [Header("Player")]
    public GameObject mainBody;
    public GameObject Invisi1;
    public GameObject Invisi2;
    public AudioSource audioSource;
    public bool isInvisible = false;
    
    [Header("Camera event")]
    public GameObject camera;
    public float rotationSpeed;
    public bool isRotating = false;
    
    [Header("Game Over")]
    public GameObject KojimaSan;
    //public GameObject gameOverButton;
    

    // Update is called once per frame

    private void Start()
    {
        spawner = FindObjectOfType<ObstacleSpawner>();
        audioSource.Play();
        audioSource.Stop();
    }

    void Update()
    {
        RotateCamera();
        if (progressBar.fillAmount >= 0.2f && !isInvisible) Invisible();
        if (progressBar.fillAmount >= 0.1 && !areWeedsActive) ActivateWeeds();
        if (progressBar.fillAmount >= 0.5f) obstacleSpeed = 15;
        if (progressBar.fillAmount >= 0.6f) ChangeSpawnSpeed();
        if (progressBar.fillAmount >= 0.8f) isRotating = true;
        if (progressBar.fillAmount >= 1f) GameOver();
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
        audioSource.Play();
    }
    
    private void ActivateWeeds()
    {
        areWeedsActive = true;
        foreach (var weed in weeds) weed.SetActive(true);
    }

    private void GameOver()
    {
        KojimaSan.SetActive(true);
        spawner.isPlaying = false;
        //gameOverButton.SetActive(true);
    }

    private void ChangeSpawnSpeed()
    {
        spawner.easyMode = false;
    }
}
