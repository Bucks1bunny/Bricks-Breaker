using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance
    {
        get;
        private set;
    }

    [SerializeField]
    private string fileName;
    private FileDataHandler dataHandler;
    private GameData gameData;
    private HashSet<IDataPersistence> dataPersistenceObjects;

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No data was found");
            return;
        }

        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            obj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            obj.SaveData(gameData);
        }

        dataHandler.Save(gameData);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjcts();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private HashSet<IDataPersistence> FindAllDataPersistenceObjcts()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new HashSet<IDataPersistence>(dataPersistenceObjects);
    }
}
