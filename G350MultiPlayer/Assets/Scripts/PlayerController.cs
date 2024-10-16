using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float movementSpeed, rotationSpeed;
    private Vector3 movementDirection;
    public InputActionReference movement;

    private bool isJumping = false;
    [SerializeField] private float jumpPower;
    private Vector3 jumpForce;
    public InputActionReference jumping;

    [SerializeField] private GameObject gun;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletLaunchPoint;
    private bool isShooting = false;
    public InputActionReference shooting;
    private bool hasGun = false;
    private int bullets = 0;

    private float score = 0f;
    private float shotsFired = 0f;
    private float currentPercentage;
    [SerializeField] private TextMeshProUGUI scoreCounter;
    [SerializeField] private TextMeshProUGUI shootingPercentage;

    [SerializeField] private TextMeshProUGUI bulletCounter;


    [SerializeField] private GameObject controller;
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = new Vector3(0, jumpPower, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (!isJumping) 
       {
            PlayerJump();
       }
        else 
        {
            if (player.transform.position.y <= 1)
            {
            isJumping = false;
            }
        }


        if (!isShooting && hasGun & bullets > 0 && shooting.action.triggered)
        {
            ShootGun();
        }
    }
    void PlayerMovement()
    {
        movementDirection = movement.action.ReadValue<Vector2>();
        player.transform.Translate(Vector3.forward * movementDirection.y * movementSpeed * Time.deltaTime);
        player.transform.Rotate(Vector3.up * movementDirection.x * rotationSpeed * Time.deltaTime);
    }

    void PlayerJump()
    {
        if (jumping.action.triggered)
        {
            isJumping = true;
            player.GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    public void GunPickedUp()
    {
        if (hasGun)
        {
            bullets += 10;
        }
        else
        {
            hasGun = true;
            gun.SetActive(true);
            bullets = 10;
            ChangeBulletText();
        }
}

    private void ChangeBulletText()
    {
        bulletCounter.text = bullets.ToString();
    }

    private void ShootGun()
    {
        isShooting = true;
        bullets--;
        shotsFired++;
        bullet = controller.GetComponent<ObjectPool>().GetObjectFromPool();
        bullet.transform.position = bulletLaunchPoint.transform.position;
        bullet.transform.rotation = bulletLaunchPoint.transform.rotation;

        bullet.GetComponent<Rigidbody>().AddForce(bulletLaunchPoint.transform.up * 50f, ForceMode.Impulse);
        ChangeBulletText();
        StartCoroutine(ShootingPause());
    }
    IEnumerator ShootingPause()
    {
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }

    public void ShootingScoreIncreased()
    {
        score += 1;
        scoreCounter.text = score.ToString();
        UpdateShootingPercentage(score, shotsFired);
    }

    private void UpdateShootingPercentage(float s, float f)
    {
       currentPercentage = (s/f);
       string tempPercent = currentPercentage.ToString("0.00");
       shootingPercentage.text = tempPercent;
    }
}

