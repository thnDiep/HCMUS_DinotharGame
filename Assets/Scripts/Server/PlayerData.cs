﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class PlayerData
{
    public int level;
    public int[] stars; // mỗi level có 3 sao 
    public int money;
    public int diamond;
    public int[] clue; // bộ sưu tập (có 15 manh mối)

    // chỉ số chiến đấu
    public int atkIndex;
    public int hpIndex;
    public int attackSpeedIndex;
    public int defIndex;

    // kĩ năng
    public bool singleSkill1;
    public bool singleSkill2;
    public bool combineSkill;

    public PlayerData()
    {
        level = 1;
        stars = new int[] {-1, -1, -1, -1, -1}; // có 5 level
        money = 500;
        diamond = 30;
        atkIndex = 1;
        hpIndex = 1;
        attackSpeedIndex = 1;
        defIndex = 0;
        clue = new int[15];
        singleSkill1 = false;
        singleSkill2 = false;
        combineSkill = false;
    }
}