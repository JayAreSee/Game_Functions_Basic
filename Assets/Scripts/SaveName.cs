using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveName : MonoBehaviour
{

    public InputField textBox;

    public void ClickSaveButton()
    {
        PlayerPrefs.SetString("name", textBox.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Your name is: " + PlayerPrefs.GetString("name"));

    }
}
