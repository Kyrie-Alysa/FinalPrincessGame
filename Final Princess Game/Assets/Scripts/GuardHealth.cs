using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHealth : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;
    private bool fadeOut;
    public float fadeSpeed;

    public GameObject sword;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            FadeOutObject();
        }

        if (fadeOut)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a <= 0)
            {
                sword.SetActive(false);
                enemy.SetActive(false);
                fadeOut = false;
            }
        }
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;
	}

    void FadeOutObject()
    {
        fadeOut = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PrincessSword")
        {
            TakeDamage(20);
        }
    }
}
