using UnityEngine;
using UnityEngine.SceneManagement;

public class BossTeleporter : MonoBehaviour
{
    [SerializeField]
    [Space]
    private string sceneName;

    [SerializeField]
    [Space]
    private AI_Walker aiWalker;

    private MeshCollider meshCollider;

    private Rigidbody aiW_rb;

    void Start()
    {
        try
        {
            meshCollider = this.GetComponent<MeshCollider>();
            meshCollider.enabled = false;
            aiW_rb = aiWalker.GetComponent<Rigidbody>();

            if (sceneName != "Hub")
            {
                sceneName = "Hub";
            }
        }
        catch (UnassignedReferenceException)
        {

        }
    }


    void Update()
    {
        if (!aiWalker.gameObject.activeSelf)
        {
            meshCollider.enabled = true;
        }
    }

    //Metoda nacte finalni scenu co kontaktu s hracem, coz je hub(hlavni mistnost)

    public void OnCollisionEnter(Collision collision)
    {
        try
        {
            string coll_name = collision.transform.name;
            bool isPlayer = false;

            if (coll_name == "Body")
            {
                isPlayer = true;
            }
            else if (coll_name == "MidBody")
            {
                isPlayer = true;
            }
            else if (coll_name == "Head")
            {
                isPlayer = true;
            }

            if (isPlayer)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        catch (UnassignedReferenceException)
        {

        }
    }
}
