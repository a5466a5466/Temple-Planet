using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;

    [SerializeField] WeaponData startingWeapon;
    [SerializeField] WeaponData secondWeapon;

    public List<WeaponBase> weapons;
    public static WeaponManager instance;

    private void Awake()
    {
        instance = this;
        weapons = new List<WeaponBase>();

    }

    private void Start() 
    {
        AddWeapon(startingWeapon);
        AddWeapon(secondWeapon);
    }
    
    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();
        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);

        Level level = GetComponent<Level>();
        if (level != null)
        {
            level.AddUpgradesIntoTheListOfAvailableUpgrades(weaponData.upgrades);
        }
    }

    internal void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.WeaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    } 
}
