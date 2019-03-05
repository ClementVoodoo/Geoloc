using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationServiceTest : MonoBehaviour
{
    [SerializeField] private int m_maxWait;
    [SerializeField] private Text textComponent;

    IEnumerator Start()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            textComponent.text = "No location services detected on this device.";
            yield break;
        }

        // Start service before querying location
        Input.location.Start();
        textComponent.text = "Location service initializing...";

        // Wait until service initializes
        int wait = 0;
        while (Input.location.status == LocationServiceStatus.Initializing && wait < m_maxWait)
        {
            yield return new WaitForSeconds(1);
            wait++;
        }

        // Service didn't initialize in 20 seconds
        if (wait >= m_maxWait)
        {
            textComponent.text = "Initialization : Timed out.";
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            textComponent.text = "Initialization : Unable to determine device location.";
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            textComponent.text = "Location : " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
}