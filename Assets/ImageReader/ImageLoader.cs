using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImageLoader : MonoBehaviour {

    [SerializeField] private string fakeImagePath = "fakes/";
    [SerializeField] private string realImagePath = "real/";

    private List<Texture2D> fakeImages = new List<Texture2D>();
    private List<Texture2D> realImages = new List<Texture2D>();
    private List<Texture2D> doneImages = new List<Texture2D>();

    // Start is called before the first frame update
    void Awake() {
        //Adding the fake images to the array
        foreach(Texture2D file in Resources.LoadAll(fakeImagePath, typeof(Texture2D))) {
            fakeImages.Add(file);
        }

        //Adding the real images to the array
        foreach(Texture2D file in Resources.LoadAll(realImagePath, typeof(Texture2D))) {
            realImages.Add(file);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void LoadImageToShower(GameObject imageShower, int level) {
        bool fake = Random.Range(0, 2) == 1;
        Texture2D image = LoadRandomImage(fake);

        // using the method
        string[] strlist = Path.GetFileName(image.name).Split(new char[] { '_', '.' }, 5,
               System.StringSplitOptions.None);

        int index = 1;
        while(level != int.Parse(strlist[0]) || doneImages.Contains(image)) {
            if(level >= 100)
                break;
            if((fake && index >= fakeImages.Count) || (!fake && index >= realImages.Count)) {
                level++;
                index = 0;
                continue;
            }

            image = LoadRandomImage(fake);
            strlist = Path.GetFileName(image.name).Split(new char[] { '_', '.' }, 5,
               System.StringSplitOptions.None);

            index++;
        }

        doneImages.Add(image);
        imageShower.GetComponent<SpriteRenderer>().sprite = Sprite.Create(image, new Rect(0.0f, 0.0f, image.width, image.height), new Vector2(0, 0), 100.0f);
        imageShower.GetComponent<Person>().Init(level, fake, strlist[1], strlist[2], int.Parse(strlist[3]));
    }

    private Texture2D LoadRandomImage(bool fake) {
        if(fake)
            return fakeImages[Random.Range(0, fakeImages.Count)];
            
        return realImages[Random.Range(0, realImages.Count)];
    }
}
