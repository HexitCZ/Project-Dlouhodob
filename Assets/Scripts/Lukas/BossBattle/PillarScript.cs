using UnityEngine;
using UnityEngine.VFX;

public class PillarScript : MonoBehaviour, IHittable
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
    }

    void Update()
    {

    }

    public virtual void GetHit()
    {
        pillar_orb_broken.GetComponent<MeshRenderer>().enabled = true;
        pillar_orb.GetComponent<MeshRenderer>().enabled = false;
        Destruct();

        
    }

    private bool CheckAssignedExplodeEffect()
    {
        if (explode_effect != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

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

        EnableGravity();
    }

    private void EnableGravity()
    {
        p1_rb.useGravity = true;
        p2_rb.useGravity = true;
        p3_rb.useGravity = true;
        orbb_rb.useGravity = true;
    }
}
