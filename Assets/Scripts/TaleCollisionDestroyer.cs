using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TaleCollisionDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        RecursivePositionRepeater repeater = col.GetComponent<RecursivePositionRepeater>();

        if (repeater != null){
            Debug.LogError("Вы проиграли, очень жаль!");
            GameObject snake = transform.parent.parent.gameObject;
            Destroy(snake);

        }
    }
}
