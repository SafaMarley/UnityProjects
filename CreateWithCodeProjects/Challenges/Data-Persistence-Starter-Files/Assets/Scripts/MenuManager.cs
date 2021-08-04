using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
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

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            MainManager.SaveData data = JsonUtility.FromJson<MainManager.SaveData>(json);

            DataPersistence.Instance.name = data.bestScorersName;
            DataPersistence.Instance.bestScore = data.bestScore;
        }
    }
}
