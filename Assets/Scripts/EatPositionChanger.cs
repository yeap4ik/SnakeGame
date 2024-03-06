using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatPositionChanger : MonoBehaviour, IEatDestroyer
{
    public PlayAudio EatAppleSFX;
    public IncrementObjectMover mover;
    [SerializeField]
    private Transform leftUpBound;

    [SerializeField]
    private Transform rightDownBound;

    public void Destroy()
    {
        EatAppleSFX.eatsound();
        GeneratePosition();
    }

    private const int tryCounts = 1000;

    private void GeneratePosition()
    {
        for (int i = 0; i < tryCounts; i++)
        {
            var newPos = new Vector3(Random.Range((int)leftUpBound.position.x,
                (int)rightDownBound.position.x),
                Random.Range((int)leftUpBound.position.y,
                (int)rightDownBound.position.y));

            if (!IsValidPosition(newPos))
                continue;

            transform.position = newPos;
            break;
        }
    }
 public int Apple_count = 0;
    private bool IsValidPosition(Vector3 pos)
    {
        var direction = Camera.main.transform.position - pos;
        if (Physics.Raycast(Camera.main.transform.position, direction, 100)){
            return false;
            }
        if (mover._delay > 0.10f)
        mover._delay = mover._delay - 0.025f;
        Apple_count++;
        //Debug.Log (Apple_count); //Сработает??
        return true;
    }
}

public interface IEatDestroyer
{
    void Destroy();
    
}
