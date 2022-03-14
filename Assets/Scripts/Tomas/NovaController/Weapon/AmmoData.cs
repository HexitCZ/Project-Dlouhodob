using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoData : MonoBehaviour
{
    [System.Serializable]
    public class AmmoPack
    {
        public string weapon;
        //[Tooltip("Bullets currently in a magazine")]
        //public int bullets_in_magazine;
        //[Tooltip("How many bullets can a magazine handle.")]                                  UNCOMMENT FOR RELOADING
        //public int magazine_size;
        [Tooltip("Total bullets left in a magic pouch of bullets for this gun.")]
        public int bullets_left;
        /*
        public override string ToString()                                                       UNCOMMENT FOR RELOADING
        {
            return $"Pack: bullets_in_magazine: {bullets_in_magazine}, magazine_size: {magazine_size}, bullets_left: {bullets_left}";
        }*/
    }


    public List<AmmoPack> ammoList;

    public AmmoPack GetAmmoPack(int index)
    {
        if (index >= 0 && index < ammoList.Count)
        {
            return ammoList[index];
        }
        Debug.LogError($"Wrong ammo index: {index}, pack: {ammoList[index]}");
        return null;
    }


    public void SetAmmoPack(int index, AmmoPack pack)
    {        
        if (index >= 0 && index < ammoList.Count)
        {
            ammoList[index] = pack;
            return;
        }
        Debug.LogError($"Wrong ammo index: {index}, new pack: {pack}");
        return;
        
    }

}
