using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private static FirstPersonController instance;

    private FirstPersonController()
    { }

    public static FirstPersonController getInstance()
    {
        if (instance == null)
            instance = new FirstPersonController();
        return instance;
    }
    // Скорость передвижения игрока
    [SerializeField] private float speed = 10.0f;

    // Компонент CharacterController
    private CharacterController cc;

    void Start()
    {
        // Получаем компонент CharacterController
        cc = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        // Получаем нажатия предустановленных клавиш
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Записываем данные в отдельную переменную
        Vector2 input = new Vector2(horizontal, vertical);
        // Определяем направление движения
        Vector3 desiredMove = transform.forward * input.y + transform.right * input.x;
        Vector3 moveDir = new Vector3(desiredMove.x * speed, 0, desiredMove.z * speed);
        // Передвигаем объект
        cc.Move(moveDir * Time.fixedDeltaTime);
    }
    public void Stop()
    {
        speed = 0f;    
    }
    public void Go()
    {
        speed = 10.0f;
    }
}
