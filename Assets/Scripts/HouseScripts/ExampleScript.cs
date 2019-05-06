using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    // Create 10 game objects, which will have random Instance IDs
    void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject g = new GameObject("abc" + i.ToString("D3"));
        }
    }

    // Find all the game objects and display their Instance IDs
    void Start()
    {
        Object[] allObjects = Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjects)
        {
            Debug.Log(go + " is an active object " + go.GetInstanceID());
        }
    }
}