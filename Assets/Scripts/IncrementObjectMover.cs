using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class IncrementObjectMover : MonoBehaviour, IObjectMover, ICaudateObject
{
    public GameMenu paused;
    public GameObject Apple123;
    [SerializeField]
    public float _delay = 0.5f;

    [SerializeField]
    private RecursivePositionRepeater _tale;

    public float speed => _renderer.bounds.size.x / _delay;

    public float Apple;
    
void Update(){
Apple = Apple123.GetComponent<EatPositionChanger>().Apple_count;
//paused2 = paused123.GetComponent<GameMenu>().paused123;


Debug.Log (paused.paused);

}
    public IPositionRepeater tale
    {
        get => _tale;
        set
        {
            if ((IPositionRepeater)_tale != value && value is RecursivePositionRepeater)
            {
                var temp = _tale;
                _tale = (RecursivePositionRepeater)value;
                _tale.SetNextRepeater(temp);
            }
        }
    }

    public void MoveForward()
    {
        if (_renderer == null)
            return;

        Stop();
        _moveRoutine = StartCoroutine(MoveRoutine());
    }

    public void Stop()
    {
        if (_renderer == null)
            return;

        if (_moveRoutine != null)
            StopCoroutine(_moveRoutine);
    }

    public void Rotate(Quaternion quaternion)
    {
        if (_renderer == null)
            return;

        transform.rotation = quaternion;
    }

    private Coroutine _moveRoutine;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        if (_renderer == null)
            Debug.LogError("Для корректного использования IncrementObjectMover требуется SpriteRenderer!");
    }

    private IEnumerator MoveRoutine() //Движение?
    {
        //transform.position = new Vector3(9.2f, 0, 0); //TODO: Сделать рандомный телепорт каждый раз при начале игры
        //_delay = _delay - (Apple/10f);
        while (true)
        {
                //Debug.Log(paused);
                var lastPosition = transform.position;
                //transform.position += transform.right * _renderer.bounds.size.x;
                if (paused.paused == false)   
                    transform.position = transform.position + transform.right * _renderer.bounds.size.x;
                 //(тоже самое что и выше, но записано по другому)
                //Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);
                //Debug.Log (_renderer.bounds.size.x);
                    if (transform.position.x > 9.2f || transform.position.x < -9.2f) //Если вышел по Х за пределы экрана. В иделае бы, чтобы граница от разрешения высчитывалась.
                    {
                        var X_TeleportPosition = transform.position.x;
                        var Y_TeleportPosition = transform.position.y;
                        X_TeleportPosition = -X_TeleportPosition; // Чтобы телепортировало в другую сторону
                        transform.position = new Vector3(X_TeleportPosition, Y_TeleportPosition, 0);
                    }

                    else if (transform.position.y > 4.68f || transform.position.y < -4.68f) //Если вышел по Y за пределы экрана. В иделае бы, чтобы граница от разрешения высчитывалась.
                    {
                        var X_TeleportPosition = transform.position.x;
                        var Y_TeleportPosition = transform.position.y;
                        Y_TeleportPosition = -Y_TeleportPosition;
                        transform.position = new Vector3(X_TeleportPosition, Y_TeleportPosition, 0);
                     }
            
            

            
                if (_tale != null)
                    _tale.SetPosition(lastPosition);
            
            
                yield return new WaitForSecondsRealtime(_delay); 
            
                 
        }
    }
    
}

public interface IObjectMover
{
    float speed { get; }
    void MoveForward();

    void Stop();

    void Rotate(Quaternion quaternion);
}

public interface ICaudateObject
{
    IPositionRepeater tale { get; set; }
}
