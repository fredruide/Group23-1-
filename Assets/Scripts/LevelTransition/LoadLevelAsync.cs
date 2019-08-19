using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelAsync : MonoBehaviour
{
    private TransitionCall trans;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trans = GetComponentInParent<TransitionCall>();
    }

}
