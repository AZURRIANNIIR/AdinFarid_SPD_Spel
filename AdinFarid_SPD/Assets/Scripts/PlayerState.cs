using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public int healthPoints = 2;
    public int initialHealthPoints;
    public int coinAmount = 0;
    public int killedAmount = 0;

    private GameObject respawnPosition;
    [SerializeField] private GameObject startPosition;
    [SerializeField] private bool useStartPosition = true;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float hurtVolume;
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        coinAmount = PlayerPrefs.GetInt("CoinAmount");
        healthPoints = initialHealthPoints;
        if(useStartPosition == true)
        {
            gameObject.transform.position = startPosition.transform.position;
        }
        respawnPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }


    public void DoHarm(int doHarmByThisMuch)
    {
        audioSource.volume = hurtVolume;
        audioSource.PlayOneShot(audioClip);
        healthPoints -= doHarmByThisMuch;
        if(healthPoints <= 0)
        {
            if(scene.name == "BossBattle")
            {
                SceneManager.LoadScene(3);
            }
            Respawn();
        }
    }

    public void Respawn()
    {
        healthPoints = initialHealthPoints;
        gameObject.transform.position = respawnPosition.transform.position;
    }

    public void CoinPickup()
    {
        coinAmount++;
        //healthPoints = healthPoints + 1; det g?r att g?ra en if sats som s?ger om healthpoints < initial healthpoints s? healthpoints + 1 
    }

    public void ChangeRespawnPosition(GameObject newRespawnPosition)
    {
        respawnPosition = newRespawnPosition;
    }
}
