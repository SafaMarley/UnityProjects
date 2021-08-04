using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void setName(string playerName)
    {
        if (DataPersistence.Instance.name == "")
        {
            DataPersistence.Instance.name = playerName;    
        }
        else
        {
            DataPersistence.Instance.trierName = playerName;
        }
    }
}
