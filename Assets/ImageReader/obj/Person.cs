using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Person : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textAge;
    [SerializeField] private TextMeshProUGUI textLevel;

    private int level;
    private bool isFake;
    private string firstName;
    private string lastName;
    private int age;

    public void Init(int level, bool isFake, string firstName, string lastName, int age) {
        this.level = level;
        this.isFake = isFake;
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;

        textName.text = this.firstName + " " + this.lastName;
        textAge.text = age + " jaar oud.";
        textLevel.text = "Level: " + this.level;
    }

    /* Getters & Setters
     */
     
    public int GetLevel() {
        return this.level;
    }

    public bool GetIfFake() {
        return this.isFake;
    }

    public string GetFirstName() {
        return this.firstName;
    }

    public string GetLastName() {
        return this.lastName;
    }

    public int GetAge() {
        return this.age;
    }

}
