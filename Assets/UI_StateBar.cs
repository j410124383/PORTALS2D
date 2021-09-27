using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StateBar : FindMG
{
    public Text T_hp;
    public Image I_hpfill;

    private void Update()
    {
        HPrefresh();
    }

    void HPrefresh()
    {
        I_hpfill.fillAmount = PS.HP / PS.MaxHP;
        T_hp.text = "HP:" + PS.HP+"/"+PS.MaxHP;

    }

}
