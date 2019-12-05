using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImageSwipe : MonoBehaviour {

    [SerializeField] private float xOffset = 5;
    [SerializeField] private float yOffset = 5;
    [SerializeField] private float xMin = -10;
    [SerializeField] private float xMax = 0;

    private GameManager gameManager;

    public void Init(GameManager gameManager) {
        this.gameManager = gameManager;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButton(0)) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - xOffset, this.transform.position.y, this.transform.position.z), 1);
        } else if(this.transform.position.x < xMin || this.transform.position.x > xMax) {
            gameManager.Swiped(this.transform.position.x > xMax);
        }
    }
}
