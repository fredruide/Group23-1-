using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public int levelToChangeToo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            FadeToLevel(levelToChangeToo);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        FadeToLevel(levelToLoad);
    //    }        
    //}

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetBool("FadeOut", true);
    }

    public void OnFadeComplete()
    {
        animator.SetBool("FadeOut", false);
        SceneManager.LoadScene(levelToLoad);
    }


}

