using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class LoseButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Canvas canvas;

        private void Start()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            canvas.gameObject.SetActive(true);
            DisableLayerObjects("Player");
            DisableLayerObjects("UI");
        }


        private void DisableLayerObjects(string layerName)
        {
            GameObject[] layerObjects = GameObject.FindGameObjectsWithTag(layerName);

            foreach (GameObject layerObject in layerObjects)
            {
                layerObject.SetActive(false);
            }
        }
    }
