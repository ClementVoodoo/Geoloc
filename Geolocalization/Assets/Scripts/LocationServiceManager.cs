using UnityEngine;
using System.Collections;

public class LocationServiceManager
{
    public static LocationServiceManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new LocationServiceManager();
            }
            return m_Instance;
        }
    }

    public delegate void Callback(Vector2 location);
    private int m_maxWait = 20;
    private static LocationServiceManager m_Instance;

    public IEnumerator GetLocation(Callback callback)
    {
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        Input.location.Start();

        int wait = 0;
        while (Input.location.status == LocationServiceStatus.Initializing && wait < m_maxWait)
        {
            yield return new WaitForSeconds(1);
            wait++;
        }

        if (wait >= m_maxWait)
        {
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;
        }
        else
        {
            callback(new Vector2(Input.location.lastData.latitude, Input.location.lastData.latitude));
        }

        Input.location.Stop();
    }
}