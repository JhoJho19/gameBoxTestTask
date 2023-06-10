
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Merges;
/// <summary>
/// Use this script to fill ONE gamefield by ONE random object.
/// </summary>
public class ItemLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects; // Massive of objects. One of them will be created.
    [SerializeField] private Transform[] fieldParent; // Parent object where random gameObject will be created.
    [SerializeField] private Button generateButton; // button for generation.

    private void Start()
    {
        generateButton.onClick.AddListener(GenerateField);
    }

    private void GenerateField()
    {
        ClearField();

        for (int i = 0; i < fieldParent.Length; i++)
        {
            // Получаем случайный объект и помещаем его в каждое поле.
            int randomIndex = Random.Range(0, 4);
            GameObject clone = Instantiate(gameObjects[randomIndex], Vector3.zero, Quaternion.identity, fieldParent[i]);
            clone.transform.localPosition = Vector3.zero;
        }
    }

    private void ClearField()
    {
        for (int i = 0; i < fieldParent.Length; i++)
        {
            foreach (Transform child in fieldParent[i])
            {
                if (child != null)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}