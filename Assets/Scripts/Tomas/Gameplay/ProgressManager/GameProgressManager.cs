using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameProgressManager : MonoBehaviour
{

    #region Singleton
    public static GameProgressManager instance;
    #endregion

    public Category[] categories;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    /// <summary>
    /// Returns status of event with argument <paramref name="name"/> from a <paramref name="category"/>.
    /// </summary>
    /// <param name="category">Name of category of events</param>
    /// <param name="name">Name of event</param>
    /// <returns>bool</returns>
    public bool GetEventProgress(string category, string name)
    {
        int categoryIndex;
        int eventIndex;
        GetEventIndex(category, name, out categoryIndex, out eventIndex);
        return categories[categoryIndex].progressEvents[eventIndex].finished;

    }


    /// <summary>
    /// Finishes event with <paramref name="name"/> from a <paramref name="category"/> and executes its UnityEvents.
    /// </summary>
    /// <param name="category">Name of category of events</param>
    /// <param name="name"></param>
    public void FinishEventProgress(string category, string name)
    {
        int categoryIndex;
        int eventIndex;
        GetEventIndex(category, name, out categoryIndex, out eventIndex);
        categories[categoryIndex].progressEvents[eventIndex].FinishEvent();

    }


    private void GetEventIndex(string category, string name, out int categoryIndex, out int eventIndex)
    {
        categoryIndex = -1;
        eventIndex = -1;
        try
        {

            for (int i = 0; i < categories.Length; i++)
            {
                if (categories[i].name == category)
                {
                    categoryIndex = i;
                    

                }

            }
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogWarning("Category with the name \"" + category + "\" does not exist." + e);
            return;
        }

        try
        {

            for (int j = categoryIndex; j < categories[categoryIndex].progressEvents.Length; j++)
            {
                if (categories[categoryIndex].progressEvents[j].name == name)
                {
                    eventIndex = j;
                    return;
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogWarning("Event with the name \"" + name + "\" does not exist." + e);
            return;
        }
        

    }

    [System.Serializable]
    public class Category
    {
        public string name;
        public ProgressEvent[] progressEvents;
    }

    [System.Serializable]
    public class ProgressEvent
    {
        public string name;
        public bool finished;
        public UnityEvent OnFinished;

        public void FinishEvent()
        {
            finished = true;
            OnFinished.Invoke();
        }
    }
}
