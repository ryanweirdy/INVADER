using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay elements")]
    public BoxCollider spawnBoundBox;
    public GameObject alienPrefab;
    public GameObject burgerPrefab;
    public GameObject sodaPrefab;
    public GameObject potatoesPrefab;



    //public Transform shootPoint;
    public GameObject hitParticle;
    public Transform player;
    //public GameObject laser;
    public GameObject boogerBall;
    public GameObject babyPram;
    public GameObject window;

    [Header("Shooting")]
    public GameObject projectilePrefab;
    public float projectileSpeed;
    public float shootRate;
    private float lastShootTime;

    [Header("UI")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public GameObject GameOverUI;
    public GameObject GameplayUI;

    [Header("Audio")]
    public AudioSource gunAudio;
    public AudioSource explosionAudio;
    public AudioSource clickAudio;

    public AudioClip gun, explosion, click;

    private int Score;
    private int Health;
    private bool isRunning;

    RaycastHit hit;

    //CORE PLACEMENT
    public Camera cam;
    public GameObject core;
    public GameObject placeCoreButton;
    private PlacementIndicator placementIndicator;
    public GameObject startButton;



    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;

        cam = Camera.main;
        core.SetActive(false);
        startButton.SetActive(false);
        placeCoreButton.SetActive(true);
        placementIndicator = FindObjectOfType<PlacementIndicator>();

    }


    public void SetUpGame()

        // called when the "Place Core" button is pressed
        // places down the core and begins the game

    {
        core.SetActive(true);
        core.transform.position = placementIndicator.transform.position;
        placementIndicator.gameObject.SetActive(false);
        placeCoreButton.SetActive(false);
        startButton.SetActive(true);

    }

    public void StartGame()
    {
        GameplayUI.SetActive(true);

        //cam = Camera.main;

        //laser.SetActive(false);
        Score = 0;
        Health = 10;
        isRunning = true;
        StartCoroutine(spawnEnemy());


        healthText.text = "HEALTH\n" + Health; 
    }

    IEnumerator spawnEnemy()
    {
        while (isRunning)
        {
            // Get a random position using the bounds of the box collider
            var randomPosition = new Vector3
                (Random.Range(spawnBoundBox.bounds.min.x, spawnBoundBox.bounds.max.x),
                Random.Range(spawnBoundBox.bounds.min.y, spawnBoundBox.bounds.max.y),
                Random.Range(spawnBoundBox.bounds.min.z, spawnBoundBox.bounds.max.z));
            
            // Spawn a new enemy
            GameObject alien = Instantiate(alienPrefab, randomPosition, Quaternion.identity);
            alien.GetComponent<Alien>().SetPlayer(player, this);

            // Wait for some time before spawning again
            yield return new WaitForSeconds(2.0f);
            
            // Spawn a new enemy
            GameObject burgerGhost = Instantiate(burgerPrefab, randomPosition, Quaternion.identity);
            burgerGhost.GetComponent<BurgerGhost>().SetPlayer(player, this);

            // Wait for some time before spawning again
            yield return new WaitForSeconds(3.0f);

            /*
            // Spawn a new enemy
            GameObject sodaGhost = Instantiate(sodaPrefab, randomPosition, Quaternion.identity);
            sodaGhost.GetComponent<BurgerGhost>().SetPlayer(player, this);

            // Wait for some time before spawning again
            yield return new WaitForSeconds(4.0f);
            */
        }
    }

    // IEnumerator dropBoogerBall()
    // wait 45 seconds - 1 minute then instantiate and drop ball
    // seprate method for door opening???
    //


    // IEnumerator randomWindow
    // sets random window colliosion box and lights up window 
    // + score if hit while active
    // separate script like ALIEN???

    /*--------------------------------------------------------------------------------------------------------*/

    /*public void ShootLasers()

        // change to ZENVA shooter balls
    {
        //Play the shoot sound
        gunAudio.PlayOneShot(gun);

        //Show the laser and hide it quickly
        laser.SetActive(true);
        Invoke("HideLaser", 0.1f);


        if(Physics.Raycast(shootPoint.position, shootPoint.forward, out hit))
        {
            if (hit.collider.CompareTag("alien"))
            {
                Score++;
        
                //Update score UI
                scoreText.text = "SCORE\n" + Score;
        
                //Destroy the alien
                Destroy(hit.collider.gameObject);
        
                //Create an explosion particle
                Instantiate(hitParticle, hit.transform.position, Quaternion.identity);
        
                //Play the sound boom!
                explosionAudio.PlayOneShot(explosion);
            }
        }
    }

    void HideLaser()
    {
        laser.SetActive(false);
    }

    */

    // shoots a new projectile out from the camera
    public void Shoot()
    {
        //Play the shoot sound
        gunAudio.PlayOneShot(gun);

        lastShootTime = Time.time;

        GameObject proj = Instantiate(projectilePrefab, cam.transform.position, Quaternion.identity);

        proj.GetComponent<Rigidbody>().velocity = cam.transform.forward * projectileSpeed;
        Destroy(proj, 3.0f);


        /*

        if (hit.collider.CompareTag("alien"))
        {
            Score++;

            //Update score UI
            scoreText.text = "SCORE\n" + Score;

            //Destroy the alien
            Destroy(hit.collider.gameObject);

            //Create an explosion particle
            Instantiate(hitParticle, hit.transform.position, Quaternion.identity);

            //Play the sound boom!
            explosionAudio.PlayOneShot(explosion);
        }

        */
    }

    // DESTROY ENEMY IF HIT
    public void DestroyEnemy()
    {
        
    }

    public void GetDamage()
    {
        Health--;
        //Update health UI
        healthText.text = "HEALTH\n" + Health;

        if (Health <= 0)
        {
            //Game Over
            isRunning = false;
            StopAllCoroutines();

            //Show the gameover UI;
            GameplayUI.SetActive(false);
            GameOverUI.SetActive(true);
            finalScoreText.text = "SCORE\n" + Score;
        }
    }

    
}
