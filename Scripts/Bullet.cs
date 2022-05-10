using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool init;
    public Vector3 direction;
    public float speed;
    public float timeAlive;
    public GameObject hitVFX;
    public int damage = 1;

    public void Init(Vector3 d, float s)
    {
        direction = d;
        speed = s;
        init = true;
    }

    private void Update()
    {
        if (!init)
            return;
        timeAlive += Time.deltaTime;
        transform.Translate(direction * speed * Time.deltaTime);
        if (timeAlive > 5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        // Avoid friendly fire!
        if (!other.CompareTag("Player"))
        {
            

            if (other.tag == "Enemy")
            {
                other.GetComponent<UbhEnemy>().m_hp -= damage;
                Instantiate(hitVFX, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }else if (other.tag == "Bullet")
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
            else if (other.tag == "wall")
                    Destroy(this.gameObject);
             
        }
    }
}
