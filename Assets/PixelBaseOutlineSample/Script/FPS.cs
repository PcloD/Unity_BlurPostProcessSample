using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour {

    static int sampleCount = 60;
    static int[] fpsData = new int[sampleCount];
    static int index;

    static int highestFPS;
    static int averageFPS;
    static int lowestFPS = int.MaxValue;

    void Start () {
		
	}

    void Update()
    {
        //reset fps data
        if (index >= sampleCount)
        {
            index = 0;
            highestFPS = 0;
            lowestFPS = int.MaxValue;
        }
        //caculate fps
        fpsData[index++] = (int)(1f / Time.unscaledDeltaTime);

        int sum = 0;
        for (int i = 0; i < sampleCount; i++)
        {

            sum += fpsData[i];
            if (fpsData[i] > highestFPS)
                highestFPS = fpsData[i];
            if (fpsData[i] < lowestFPS)
                lowestFPS = fpsData[i];
        }
        averageFPS = sum / sampleCount;
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, 150, 120));
        GUI.color = Color.green;
        GUILayout.Label(string.Format("Highest FPS:{0}", highestFPS));

        GUI.color = Color.yellow;
        GUILayout.Label(string.Format("Average FPS:{0}", averageFPS));

        GUI.color = Color.red;
        GUILayout.Label(string.Format("Lowest FPS:{0}", lowestFPS));

        GUILayout.EndArea();
    }
}
