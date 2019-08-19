using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;
    private static SceneTransition instance;
    private GameObject player;
    private Vector3 playerPos;
    private int levelToLoad;
    public int levelToChangeToo;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            FadeToLevel(levelToChangeToo, player.transform.position);
        }
    }

    public void FadeToLevel(int levelIndex, Vector3 playerTransform)
    {        
        levelToLoad = levelIndex;
        playerPos = playerTransform;
        animator.SetBool("FadeOut", true);
    }

    public void OnFadeComplete()
    {
        
        while (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        player.transform.position = playerPos;
        //animator.SetBool("FadeOut", false);
        SceneManager.LoadScene(levelToLoad);
    }


}

