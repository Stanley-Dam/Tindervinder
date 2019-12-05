using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private int HP = 3;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Text text;
    [SerializeField] private Sprite healthSprite;
    [SerializeField] private GameObject playerPrefab;

    private int level = 0;
    private GameObject currentImage;
    private int score = 0;

    // Start is called before the first frame update
    private void Start() {
        GenerateImage();
    }

    private void OnGUI() {
        for(int i = 0; i < HP; i++) {
            GUI.DrawTexture(new Rect((Screen.width/32)*21 + (i* (Screen.width / 9)), Screen.height / 20, (Screen.width / 10), (Screen.width / 10)), healthSprite.texture, ScaleMode.ScaleToFit, true, 0);
        }
    }

    public void Swiped(bool swipedRight) {
        if(currentImage.GetComponent<Person>().GetIfFake() == swipedRight) {
            score++;
            text.text = "" + score;
        } else {
            HP--;

            if(HP <= 0)
                Death();
        }

        this.level = currentImage.GetComponent<Person>().GetLevel();

        Destroy(currentImage);
        GenerateImage();
    }

    private void GenerateImage() {
        currentImage = Instantiate(playerPrefab);
        currentImage.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y);
        currentImage.GetComponent<PlayerImageSwipe>().Init(this);
        this.gameObject.GetComponent<ImageLoader>().LoadImageToShower(currentImage, level);
    }

    private void Death() {
        SceneManager.LoadScene(0);
    }

}
