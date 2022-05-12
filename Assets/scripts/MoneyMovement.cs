using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyMovement : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalSpeed;
    float horizontal;
    public Text moneyText;
    [HideInInspector] public float currentMoney;
    [HideInInspector] public float moneyValue = 0.1f;
    public GameObject[] enemies;
    public Rigidbody projectile;
    public GameObject spawnPoint;
    public float atkSpeed;
    public GameObject[] missiles;
    bool dieOnce, canShoot;
    void Start()
    {
        moneyText.text = currentMoney + "K";
        StartCoroutine("Firing");
    }
    void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Move();
    }
    void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontal * horizontalSpeed * Time.deltaTime, 0, movementSpeed * Time.deltaTime));
    }
    IEnumerator Firing()
    {
        if(!canShoot)
        {
            yield return new WaitForSeconds(0.5f);
            Rigidbody clone;
            clone = Instantiate(projectile, spawnPoint.transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * atkSpeed);
        }
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Enemy") && !dieOnce)
        {
            gameObject.GetComponentInChildren<Animator>().SetTrigger("death");
            horizontalSpeed = 0;
            movementSpeed = 0;
            canShoot = true;
            dieOnce = true;
        }
    }
    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("Firing");
    }
    public void MoneyFixer()
    {
        currentMoney = moneyValue + currentMoney;
        currentMoney = Mathf.Round(currentMoney * 100f) / 100f;
        moneyText.text = currentMoney + "K";
    }
    public void LoseMoney()
    {
        currentMoney = currentMoney - moneyValue;
        currentMoney = Mathf.Round(currentMoney * 100f) / 100f;
        moneyText.text = currentMoney + "K";
    }
}
