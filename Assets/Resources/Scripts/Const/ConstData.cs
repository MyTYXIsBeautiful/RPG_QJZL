using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstData
{

    //-----数据库名
    public const string dataBase = "RPG_GAME_DATA.db";

    //-----表名
    //--怪物表
    public const string T_lowMonster = "T_lowMonster";
    public const string T_middleMonster = "T_middleMonster";
    public const string T_highMonster = "T_highMonster";
    public const string T_finalBossMonster = "T_finalBossMonster";
    //--角色表
    public const string T_hero = "T_hero";
    //--用户表
    public const string T_user = "T_user";

}

public class ConstUserData
{
    //---用户名
    //--用户属性
    public const string user_name = "user_name";
    public const string user_password = "user_password";
}

public class ConstMonsterData
{
    //-----属性名
    //--怪物属性
    public const string level = "level";
    public const string empiricValue = "empiricValue";
    public const string name = "name";
    public const string hp = "hp";
    public const string physicsAttack = "physicsAttack";
    public const string magicAttack = "magicAttack";
    public const string armor = "armor";
    public const string magicResist = "magicResist";
    public const string attackRate = "attackRate";
    public const string recoverRate = "recoverRate";
    public const string speed = "speed";
    public const string evade = "evade";
    public const string critOdd = "critOdd";
    public const string critTimes = "critTimes";
    public const string skillColdTime = "skillColdTime";
}

public class ConstHeroData
{
    //-----属性名
    //--角色属性
    public const string money = "money";
    public const string level = "level";
    public const string expCeiling = "expCeiling";
    public const string max_Hp = "max_Hp";
    public const string max_Mp = "max_Mp";
    public const string attack = "attack";
    public const string magicDamage = "magicDamage";
    public const string armor = "armor";
    public const string magicInvocation = "magicInvocation";
    public const string physicalVampire = "physicalVampire";
    public const string magicVampire = "magicVampire";
}
public class ConstScript
{
    public const string PlayerSelect = "PlayerSelect";
    public const string Login = "Login_Interface";
    public const string loadingScene = "loadingScene";
    public const string GameMainScene = "GameMainScene";
}
