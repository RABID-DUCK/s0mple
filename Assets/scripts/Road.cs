using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public static gameManager manager;
    static Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name != "road (2)") return;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        var disToCamera = Camera.main.transform.position - transform.position;
        if (disToCamera.y < manager.resetDistanceY) return;
        OvertakePlayer(); // обгоняем игрока
    }
    private void OvertakePlayer()
    {
        transform.position += manager.resetDistanceY * Vector3.up + startPosition;
    }
}
