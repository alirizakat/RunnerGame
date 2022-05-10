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

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = currentMoney + "K";
        StartCoroutine("Firing");
    }

    // Update is called once per frame
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
    /*
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Collect"))
        {
            MoneyFixer();
        }
    }
    */
    IEnumerator Firing()
    {
        yield return new WaitForSeconds(0.5f);
        Rigidbody clone;
        clone = Instantiate(projectile, spawnPoint.transform.position, transform.rotation);
        clone.velocity = transform.TransformDirection(Vector3.forward * atkSpeed);
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
