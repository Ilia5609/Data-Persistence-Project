using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandlerX : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartNew()
    {
        string newName = inputField.GetComponent<TMP_InputField>().text;

        gameManager.GetComponent<GameManager>().NameSaved(newName);
        
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
      //  MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
