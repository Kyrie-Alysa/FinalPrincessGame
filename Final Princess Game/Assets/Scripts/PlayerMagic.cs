using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{

	public int maxMagic = 100;
	public int currentMagic;

	public MagicBar magicBar;

    // Start is called before the first frame update
    void Start()
    {
		currentMagic = maxMagic;
		magicBar.SetMaxMagic(maxMagic);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if(currentMagic >= 1)
            {
				LoseMagic(20);
			}
		}

    }

	void LoseMagic(int loss)
	{
		currentMagic -= loss;

		magicBar.SetMagic(currentMagic);
	}
}
