using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroModel
{
    //----属性
    string name;//英雄名称
    public string Name { get { return name; } set { name = value; } }
    string user_name;//用户名
    public string User_name { get { return user_name; } set { user_name = value; } }
    int money;//金币
    public int Money { get { return money; } set { money = value; } }
    int level;//等级
    public int Level { get { return level; } set { level = value; } }
    int expCeiling;//经验上限
    public int ExpCeiling { get { return expCeiling; } set { expCeiling = value; } }
    int max_Hp;//英雄最大血量
    public int Max_Hp { get { return max_Hp; } set { max_Hp = value; } }
    int max_Mp;//英雄最大蓝量上限
    public int Max_Mp { get { return max_Mp; } set { max_Mp = value; } }
    int attack;//英雄攻击力
    public int Attack { get { return attack; } set { attack = value; } }
    int magicDamage;//魔法伤害
    public int MagicDamage { get { return magicDamage; } set { magicDamage = value; } }
    int armor;//护甲
    public int Armor { get { return armor; } set { armor = value; } }
    int magicInvocation;//魔抗
    public int MagicInvocation { get { return magicInvocation; } set { magicInvocation = value; } }
    double physicalVampire;//物理吸血
    public double PhysicalVampire { get { return physicalVampire; } set { physicalVampire = value; } }
    double magicVampire;//法术吸血
    public double MagicVampire { get { return magicVampire; } set { magicVampire = value; } }


}
