using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour
{
    public GameObject healthBar;

    void Start()
    {
        
    }

    public void Clear(){

        for(int i=0; i<transform.childCount; i++){

            GameObject child = transform.GetChild(i).gameObject;
            if(child.name != "HealthBar"){

                GameObject.Destroy(child);
            }
        }
    }

    public void CreateBar(GameObject enemy, Camera playerCamera){


        GameObject bar = Instantiate(healthBar, transform);
        

        float health = enemy.gameObject.GetComponent<Health>().getHealth() / enemy.gameObject.GetComponent<Health>().maxHealth;

        Vector3 colliderSize = enemy.GetComponent<BoxCollider>().size;
        Vector3 enemyPos = enemy.transform.position;

        float colliderHeight = colliderSize.y * enemy.transform.lossyScale.y;

        Vector3 enemyScreenPoint = playerCamera.WorldToScreenPoint(enemy.transform.position);
        Vector3 colliderTopScreenPoint = playerCamera.WorldToScreenPoint(new Vector3(enemyPos.x, colliderHeight, enemyPos.z));

        Vector3 barPos = new Vector3(
                        enemyScreenPoint.x,
                        colliderTopScreenPoint.y + (colliderTopScreenPoint.y - enemyScreenPoint.y)/2,
                        enemyScreenPoint.z
                        );


        Image healthImage = bar.transform.Find("HealthAmount").gameObject.GetComponent<Image>();
        healthImage.fillAmount = health;
        bar.transform.position = barPos;
        bar.SetActive(true);
        
    }
}
