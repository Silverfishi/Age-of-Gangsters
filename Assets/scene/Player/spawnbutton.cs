using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnbutton : MonoBehaviour
{
    public Scrollbar scrollbar;
    public GameObject buttonPrefab;
    public List<string> itemList; // Ваш список элементов

    void Start()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        if (scrollbar == null || buttonPrefab == null || itemList == null)
        {
            Debug.LogError("Scrollbar, Button Prefab, or Item List not assigned.");
            return;
        }

        // Удаляем все текущие кнопки на Scrollbar
        foreach (Transform child in scrollbar.transform)
        {
            Destroy(child.gameObject);
        }

        // Создаем кнопки для каждого элемента в списке
        foreach (string item in itemList)
        {
            GameObject button = Instantiate(buttonPrefab, scrollbar.transform);
            button.GetComponentInChildren<Text>().text = item;

            // Добавляем обработчик события кнопки (если необходимо)
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(item));
        }
    }

    // Дополнительная логика, которую вы хотите выполнить при нажатии на кнопку
    void OnButtonClick(string item)
    {
        Debug.Log("Button Clicked: " + item);
        // Ваш код обработки нажатия на кнопку
    }
}
