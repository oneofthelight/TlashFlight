using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject[] weapons;
    private int weaponIndex = 0;
    public Transform shootTransform;
    public float shootInterval = 0.05f;
    public float lastShotTime = 0f;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);
        Shoot();

    }
    void Shoot()
    {
        if(Time.time - lastShotTime> shootInterval)
        {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }
    private void OnTriggerEnter2D(Collider2D ohter)
    {
        if(ohter.gameObject.tag == "Enemy" || ohter.gameObject.tag == "Boss")
        {
            GameManager.instance.SetGameOver();
            Destroy(gameObject);
        }
        else if (ohter.gameObject.tag == "Coin")
        {
            GameManager.instance.IncreaseCoin();
            Destroy(ohter.gameObject);
        }
    }
    public void Upgrade()
    {
        weaponIndex += 1;
        if(weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
    }
}
