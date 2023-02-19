using System.Collections.Generic;
using UnityEngine;

public class Pickup_Speed : MonoBehaviour
{
    [SerializeField] private float multiplySpeedBy = 1.5f;
    [SerializeField] private float timeBeforeReset;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private PlayerController playerController;
    private float originalSpeed;
    private bool isUsingMovementSpeed = false;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isUsingMovementSpeed == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeReset)
            {
                playerController.speed = originalSpeed;
                timer = 0f;
                isUsingMovementSpeed = false;
                spriteRenderer.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsingMovementSpeed == false)
        {
            if (collision.CompareTag("Player") == true)
            {
                if (playerController == null)
                {
                    playerController = collision.GetComponent<PlayerController>();
                }
                isUsingMovementSpeed = true;
                originalSpeed = playerController.speed;
                playerController.speed *= multiplySpeedBy;
                audioSource.PlayOneShot(audioClip);
                spriteRenderer.enabled = false;
            }
        }
    }
}

