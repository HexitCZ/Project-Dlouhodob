using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleTeleporterScript : MonoBehaviour
{
    [Space]
    [SerializeField]
    [Header("Next scene")]
    public string next_scene;

    void Start()
    {
        next_scene = "None";
    }
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(next_scene == "Environment2")
        {
            PlayerPrefs.SetInt("level2unlocked", 1);
        }
        SceneManager.LoadScene(next_scene);
    }
}
