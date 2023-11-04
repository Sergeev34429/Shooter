using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Pistol
{
    void Start()
    {
        //Задержка между выстрелами(можно указать собственную)
        cooldown = 0.2f;
        //Стрельба автоматическая, значит при зажатой клавише мыши оружие будет стрелять непрерывно учитывая задержку
        auto = true; 
        ammoCurrent = 30;
        ammoMax = 30;
        ammoBackPack = 60;
    }

}
