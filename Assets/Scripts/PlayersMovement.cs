using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;// сюда кинуть настройку анимации персонажа

    private bool isFacingRight;
    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }
    // Update is called once per frame

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        if (!isFacingRight && moveX > 0)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (moveX < 0 && isFacingRight)
           Flip();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        animator.SetFloat("Horizontal", movement.x); // считываем значение праметра  Horizontal и Vertical (1|0|-1) для выбора подходящей анимации
        animator.SetFloat("Vertical", movement.y); // считываем значение праметра  Horizontal и Vertical (1|0|-1) для выбора подходящей анимации
        animator.SetFloat("Magnitude", movement.magnitude); // считываем значение праметра  Horizontal и Vertical (1|0|-1) для выбора подходящей анимации

        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal")); // считываем значение праметра  Horizontal и Vertical (1|0|-1) для выбора подходящей анимации
        //animator.SetFloat("Vertical", Input.GetAxis("Vertical")); // 

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        Vector3 vertical = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
       transform.position = transform.position + movement*Time.deltaTime; // движение = текущая позиция + смещение на 1 (влево/вправо) * промежуток времени игры
        //transform.position = transform.position + horizontal*Time.deltaTime; // движение = текущая позиция + смещение на 1 (влево/вправо) * промежуток времени игры
        //transform.position = transform.position + vertical * Time.deltaTime; // вверх/ вниз

    }
}
