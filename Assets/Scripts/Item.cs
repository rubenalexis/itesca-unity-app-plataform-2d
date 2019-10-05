using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("hola");
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("dios");
            ScoreScript.scoreValue += 1;
            Destroy(gameObject);
        }
    }
    
}
