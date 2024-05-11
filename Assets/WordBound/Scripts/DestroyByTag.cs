using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTag : MonoBehaviour
{
    public void DestroyObjectsWithTag()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("puffFX");

        if (objectsToDestroy.Length > 0)
        {
            // Проходим по каждому объекту и уничтожаем его
            foreach (GameObject obj in objectsToDestroy)
            {
                Destroy(obj);
            }
        }
        else
        {
            // Выводим сообщение, если объекты не найдены
            Debug.Log("Объекты с тегом '" + tag + "' не найдены.");
        }

    }

}