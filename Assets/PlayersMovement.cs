using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;// сюда кинуть настройку анимации персонажа
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal")); // считываем значение праметра  Horizontal (1|0|-1), для выбора подходящей анимации
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); 
        transform.position = transform.position + horizontal*Time.deltaTime; // движение = текущая позиция + смещение на 1 (влево/вправо) * промежуток времени игры


    }
}
