using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public GameObject enemy;
    public Slider healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        healthBar.value = enemy.GetComponent<UbhEnemy>().m_hp;
    }
}
