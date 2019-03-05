using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Voodoo.Mapbox.Utils;
using UnityEngine;

[RequireComponent(typeof(AbstractMap))]
public class UserLocalization : MonoBehaviour
{
    AbstractMap m_AbstractMap;
    
    void Awake()
    {
        m_AbstractMap = GetComponent<AbstractMap>();
    }

    [ContextMenu("Center Map on User")] 
    public void SetMapToPlayerLocation()
    {
        double x = 48.866667;
        double y = 2.333333;
        
        Vector2d coordinates = new Vector2d(x,y);
        
        Debug.Log("Center Map on user : " + coordinates);
        m_AbstractMap.UpdateMap(coordinates);
    }
}