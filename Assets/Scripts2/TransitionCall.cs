using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCall : MonoBehaviour
{
    SceneTransition sceneTransition;
    public int levelToChangeToo;

    private void Start()
    {
        sceneTransition = GameObject.FindObjectOfType<SceneTransition>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Dette skal ændres hvert gang det er et nyt level            
            sceneTransition.FadeToLevel(levelToChangeToo);
        }
    }
}
