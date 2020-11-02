using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAttacks : MonoBehaviour
{
    public Animation anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
		{
			PlayAnimation();
		}
    }

    void PlayAnimation(){
        anim.Play("Guard1SwordAttack");
    }
}
