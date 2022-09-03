using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {

    private WeaponManager weaponManager;

    [HideInInspector]
    public bool canShoot;
    private bool attack;
    private bool weaponswitch;
    private bool isHoldAttack;



    void start()
    {
        attack = false;
        weaponswitch = false;
    }



    public void PointerDown()
    {

        attack = true;
    }

    public void PointerUp()
    {
        attack = false;
    }


    public void PointerDownswitch()
    {

        weaponswitch = true;
    }

    public void PointerUpswitch()
    {
        weaponswitch = false;
    }




    void Awake () {
        weaponManager = GetComponent<WeaponManager>();
        canShoot = true;
	}
	
	void Update () {
	
        if(weaponswitch) {
            weaponManager.SwitchWeapon();
        }


        if (attack)
        {
            isHoldAttack = true;
        }
           

         else {

            weaponManager.ResetAttack();
            isHoldAttack = false;
        }

        if(isHoldAttack && canShoot) {
            weaponManager.Attack();
        }

	}

    public void shoot()
    {

        isHoldAttack = true;
    }
} // class





























