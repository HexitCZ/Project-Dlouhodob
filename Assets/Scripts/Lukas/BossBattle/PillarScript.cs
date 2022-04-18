using UnityEngine;
using UnityEngine.VFX;

public class PillarScript : MonoBehaviour
{
    [SerializeField]
    [Space]
    private Transform pillar_piece_1;

    [SerializeField]
    [Space]
    private Transform pillar_piece_2;

    [SerializeField]
    [Space]
    private Transform pillar_piece_3;

    [SerializeField]
    [Space]
    private Transform pillar_orb;

    [SerializeField]
    [Space]
    private Transform pillar_orb_broken;

    [SerializeField]
    [Space]
    private AudioSource sound_source;

    [Space]

    [SerializeField]
    [Space]
    private VisualEffect explode_effect;

    private bool hasExploded;

    Rigidbody p1_rb;
    Rigidbody p2_rb;
    Rigidbody p3_rb;
    Rigidbody orb_rb;
    Rigidbody orbb_rb;

    void Start()
    {
        sound_source.playOnAwake = false;
        p1_rb = pillar_piece_1.GetComponent<Rigidbody>();
        p2_rb = pillar_piece_1.GetComponent<Rigidbody>();
        p3_rb = pillar_piece_1.GetComponent<Rigidbody>();
        orbb_rb = pillar_piece_1.GetComponent<Rigidbody>();

        p1_rb.useGravity = false;
        p2_rb.useGravity = false;
        p3_rb.useGravity = false;
        orbb_rb.useGravity = false;

        pillar_orb_broken.GetComponent<MeshRenderer>().enabled = false;

        hasExploded = false;
    }

    void Update()
    {

    }
    /// <summary>
    /// Zjisti jestli prisel do kontaktu s orbem(projektilem pavouka) a podle toho se zachova
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        string coll_name = collision.transform.name;

        if(coll_name.Contains("orb_"))
        {
            hasExploded = true;
            Destruct();
        }
        else
        {
            hasExploded = false;
        }
    }
    /// <summary>
    /// Zjistuje, zda je efekt exploze nastaveny
    /// </summary>
    /// <returns></returns>
    private bool CheckAssignedExplodeEffect()
    {
        bool isAssigned = false;

        if (explode_effect != null)
        {
            isAssigned = true;
        }
        else
        {
            isAssigned = false;
        }
        return isAssigned;
    }

    /// <summary>
    /// Kontrola, jestli je pilir rozbity
    /// </summary>
    /// <returns></returns>
    public bool IsBroken()
    {
        bool output = false;

        if (hasExploded)
        {
            output = true;
        }
        else
        {
            output = false;
        }
        return output;
    }
    /// <summary>
    /// Znici pilir spolecne s vyuzitim efektu
    /// </summary>
    public void Destruct()
    {
        if (CheckAssignedExplodeEffect())
        {
            explode_effect.Play();           
        }
        else
        {
            explode_effect = null;
        }
        sound_source.Play(0);
        hasExploded = true;

        EnableGravity();

        Invoke("DisableCollision", 3);
    }

    /// <summary>
    /// Vypne kolize objektu
    /// </summary>
    private void DisableCollision()
    {
        this.GetComponent<BoxCollider>().enabled = false;
    }
    /// <summary>
    /// Zapina fyziku pro objekt a podobjekty
    /// </summary>
    private void EnableGravity()
    {
        p1_rb.useGravity = true;
        p2_rb.useGravity = true;
        p3_rb.useGravity = true;
        orbb_rb.useGravity = true;
    }
}
