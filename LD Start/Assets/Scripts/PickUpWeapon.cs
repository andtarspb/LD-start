using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpWeapon : MonoBehaviour
{
    public string weaponName;

    [SerializeField]
    int weaponID;

    [SerializeField]
    float pickupDuration = 1;

    [SerializeField]
    Vector3 pickupPosition = new Vector3(0.5f, 0.5f, 0.25f);
    [SerializeField]
    Vector3 pickupRotation = new Vector3(0.5f, 0.7830009f, 0.25f);

    WeaponSwitching weaponManager;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);

        weaponManager = FindObjectOfType<WeaponSwitching>();
    }

    public void PickUp()
    {
        weaponManager.selectedWeapon = 0;
        weaponManager.SelectWeapon();

        transform.parent = weaponManager.transform;
        transform.DOLocalRotate(pickupRotation, pickupDuration / 2).SetUpdate(true);
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOLocalMove(pickupPosition, pickupDuration));
        mySequence.AppendCallback(() => Destroy(gameObject));

        weaponManager.avaiableWeapons = weaponID;
        weaponManager.selectedWeapon = weaponID;
        mySequence.AppendCallback(() => weaponManager.SelectWeapon());
        
    }
}
