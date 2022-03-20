using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    #region Singleton
    public static ExperienceSystem instance;
    #endregion

    [Range(0, 100)]
    public int level;
    
    public int xp;
    [Space]
    public int xpPerLevel;


    void Start()
    {
        instance = this;

    }

    private void Update()
    {
        ResolveXPLevels();
    }

    public void Add(int xp)
    {
        instance.xp += xp;
        ResolveXPLevels();
    }

    private void ResolveXPLevels()
    {
        level += (int) xp / xpPerLevel;
        xp = xp % xpPerLevel;

    }

}
