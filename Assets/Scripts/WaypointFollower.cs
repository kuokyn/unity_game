using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    public GameObject[] wp;
    private int currentWpIndex = 0;
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        // если платформа достигла вэйпоинта
        if (Vector2.Distance(wp[currentWpIndex].transform.position, transform.position) < .1f)
        {
            currentWpIndex++;
            if (currentWpIndex >= wp.Length)
            {
                currentWpIndex = 0;
            }
		}
		transform.position = Vector2.MoveTowards(transform.position, wp[currentWpIndex].transform.position, Time.deltaTime * speed);
	}
}
