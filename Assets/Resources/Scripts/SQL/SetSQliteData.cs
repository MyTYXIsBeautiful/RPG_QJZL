using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;

/*此脚本用来处理数据库数据*/
public class SetSQliteData
{
    static SetSQliteData _instance;
    public static SetSQliteData Instance()
    {
        if (_instance == null)
        {
            _instance = new SetSQliteData();
        }
        return _instance;
    }
    //私有化构造函数
    private SetSQliteData()
    {
        getSQliteData = GetSQliteData.Instance();
    }

    GetSQliteData getSQliteData;//连接数据库类的引用

   

    /// <summary>
    /// 给小怪模型类赋值
    /// </summary>
    /// <param name="conditon">小怪等级</param>
    /// <param name="value">值</param>
    /// <returns></returns>
    public LowMonsterModel LowMonster(string conditon, string value)
    {
        getSQliteData.OpenDB("Data Source=" + Path.Combine(Application.persistentDataPath, ConstData.dataBase));//根据路径打开数据库
        LowMonsterModel lowMonster = new LowMonsterModel();//创建小怪模型类对象
        SqliteDataReader reader =  getSQliteData.GetDataReader(ConstData.T_lowMonster, conditon, value);
        //读取数据
        while (reader.Read())
        {
            lowMonster.Level = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.level)));
            lowMonster.EmpiricValue = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.empiricValue)));
            lowMonster.Name = reader.GetString(reader.GetOrdinal(ConstMonsterData.name));
            lowMonster.Hp = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.hp)));
            lowMonster.PhysicsAttack = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.physicsAttack)));
            lowMonster.MagicAttack = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.magicAttack)));
            lowMonster.Armor = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.armor)));
            lowMonster.MagicResist = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.magicResist)));
            lowMonster.AttackRate = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.attackRate)));
            lowMonster.RecoverRate = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.recoverRate)));
            lowMonster.Speed = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.speed)));

        }
        getSQliteData.CloseDB();//关闭数据库
        return lowMonster;

    }

    /// <summary>
    /// 给中级怪模型类赋值
    /// </summary>
    /// <param name="conditon">中级怪等级</param>
    /// <param name="value">值</param>
    /// <returns></returns>
    public MiddleMonsterModel MiddleMonster(string conditon, string value)
    {
        getSQliteData.OpenDB("Data Source=" + Path.Combine(Application.persistentDataPath, ConstData.dataBase));//根据路径打开数据库
        MiddleMonsterModel middleMonster = new MiddleMonsterModel();//创建小怪模型类对象
        SqliteDataReader reader = getSQliteData.GetDataReader(ConstData.T_middleMonster, conditon, value);
        //读取数据
        while (reader.Read())
        {
            middleMonster.Level = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.level)));
            middleMonster.EmpiricValue = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.empiricValue)));
            middleMonster.Name = reader.GetString(reader.GetOrdinal(ConstMonsterData.name));
            middleMonster.Hp = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.hp)));
            middleMonster.PhysicsAttack = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.physicsAttack)));
            middleMonster.MagicAttack = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.magicAttack)));
            middleMonster.Armor = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.armor)));
            middleMonster.MagicResist = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.magicResist)));
            middleMonster.AttackRate = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.attackRate)));
            middleMonster.RecoverRate = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.recoverRate)));
            middleMonster.Speed = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.speed)));
            middleMonster.Evade = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.evade)));
            middleMonster.CritOdd = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.critOdd)));
            middleMonster.CritTimes = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.critTimes)));
        }
        getSQliteData.CloseDB();//关闭数据库
        return middleMonster;

    }

    /// <summary>
    /// 给高级怪模型类赋值
    /// </summary>
    /// <param name="conditon">高级怪等级</param>
    /// <param name="value">值</param>
    /// <returns></returns>
    public HighMonsterModel HighMonster(string conditon, string value)
    {
        getSQliteData.OpenDB("Data Source=" + Path.Combine(Application.persistentDataPath, ConstData.dataBase));//根据路径打开数据库
        HighMonsterModel highMonster = new HighMonsterModel();//创建小怪模型类对象
        SqliteDataReader reader = getSQliteData.GetDataReader(ConstData.T_highMonster, conditon, value);
        //读取数据
        while (reader.Read())
        {
            highMonster.Level = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.level)));
            highMonster.EmpiricValue = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.empiricValue)));
            highMonster.Name = reader.GetString(reader.GetOrdinal(ConstMonsterData.name));
            highMonster.Hp = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.hp)));
            highMonster.PhysicsAttack = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.physicsAttack)));
            highMonster.MagicAttack = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.magicAttack)));
            highMonster.Armor = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.armor)));
            highMonster.MagicResist = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.magicResist)));
            highMonster.AttackRate = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.attackRate)));
            highMonster.RecoverRate = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.recoverRate)));
            highMonster.Speed = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.speed)));
            highMonster.Evade = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.evade)));
            highMonster.CritOdd = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.critOdd)));
            highMonster.CritTimes = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.critTimes)));
            highMonster.SkillColdTime = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.skillColdTime)));
        }
        getSQliteData.CloseDB();//关闭数据库
        return highMonster;

    }

    /// <summary>
    /// 给boss模型类赋值
    /// </summary>
    /// <param name="conditon">给boss模型类赋值等级</param>
    /// <param name="value">值</param>
    /// <returns></returns>
    public FinalBossModel FinalBoss(string conditon, string value)
    {
        getSQliteData.OpenDB("Data Source=" + Path.Combine(Application.persistentDataPath, ConstData.dataBase));//根据路径打开数据库
        FinalBossModel finalBoss = new FinalBossModel();//创建小怪模型类对象
        SqliteDataReader reader = getSQliteData.GetDataReader(ConstData.T_finalBossMonster, conditon, value);
        //读取数据
        while (reader.Read())
        {
            finalBoss.Level = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.level)));
            finalBoss.EmpiricValue = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.empiricValue)));
            finalBoss.Name = reader.GetString(reader.GetOrdinal(ConstMonsterData.name));
            finalBoss.Hp = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.hp)));
            finalBoss.PhysicsAttack = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.physicsAttack)));
            finalBoss.MagicAttack = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.magicAttack)));
            finalBoss.Armor = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.armor)));
            finalBoss.MagicResist = int.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.magicResist)));
            finalBoss.AttackRate = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.attackRate)));
            finalBoss.RecoverRate = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.recoverRate)));
            finalBoss.Speed = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.speed)));
            finalBoss.Evade = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.evade)));
            finalBoss.CritOdd = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.critOdd)));
            finalBoss.CritTimes = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.critTimes)));
            finalBoss.SkillColdTime = float.Parse(reader.GetString(reader.GetOrdinal(ConstMonsterData.skillColdTime)));
        }
        getSQliteData.CloseDB();//关闭数据库
        return finalBoss;

    }


    /// <summary>
    /// 获取角色属性数据
    /// </summary>
    /// <param name="name">名字</param>
    /// <param name="value">值</param>
    /// <param name="hero">Hero对象</param>
    /// <returns></returns>
    public HeroModel GetHeroData(string condition, string value, HeroModel hero)
    {
        //创建HeroModel对象
        if(hero == null)
        {
            hero = new HeroModel();
        }

        getSQliteData.OpenDB("Data Source=" + Path.Combine(Application.persistentDataPath, ConstData.dataBase));//根据路径打开数据库
        SqliteDataReader reader = getSQliteData.GetDataReader(ConstData.T_hero, condition, value);
        //读取数据
        while (reader.Read())
        {
            hero.Money = int.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.money)));
            hero.Level = int.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.level)));
            hero.ExpCeiling = int.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.expCeiling)));
            hero.Max_Hp = int.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.max_Hp)));
            hero.Max_Mp = int.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.max_Mp)));
            hero.Attack = int.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.attack)));
            hero.MagicDamage = int.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.magicDamage)));
            hero.Armor = int.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.armor)));
            hero.MagicInvocation = int.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.magicInvocation)));
            hero.PhysicalVampire = double.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.physicalVampire)));
            hero.MagicVampire = double.Parse(reader.GetString(reader.GetOrdinal(ConstHeroData.magicVampire)));
        }

        return hero;
    }

    /// <summary>
    /// 更新角色表T_hero数据
    /// </summary>
    /// <param name="datas">字段数组</param>
    /// <param name="hero">角色模型（构建数组）</param>
    /// <param name="condition">字段id</param>
    /// <param name="value">值</param>
    public void UpdateDataBase(HeroModel hero, string condition, string value)
    {
        getSQliteData.OpenDB("Data Source=" + Path.Combine(Application.persistentDataPath, ConstData.dataBase));//根据路径打开数据库
        string[] datas = new string[] { ConstHeroData.money, ConstHeroData.level, ConstHeroData.expCeiling,
            ConstHeroData.max_Hp, ConstHeroData.max_Mp, ConstHeroData.attack,ConstHeroData.magicDamage, ConstHeroData.armor, ConstHeroData.magicInvocation,
            ConstHeroData.physicalVampire, ConstHeroData.magicVampire};
        string[] dataValues = new string[] { hero.Money.ToString(), hero.Level.ToString(), hero.ExpCeiling.ToString(),
            hero.Max_Hp.ToString(), hero.Max_Mp.ToString(), hero.Attack.ToString(),hero.MagicDamage.ToString(),
            hero.Armor.ToString(), hero.MagicInvocation.ToString(), hero.PhysicalVampire.ToString(),hero.MagicVampire.ToString()};
        getSQliteData.UpdateDataReader(ConstData.T_hero, datas, dataValues, condition, value);
    }

    /// <summary>
    /// 向用户表T_user插入数据
    /// </summary>
    /// <param name="dataValues">值数组</param>
    public void InsertData(string user_name, string user_password)
    {
        getSQliteData.OpenDB("Data Source=" + Path.Combine(Application.persistentDataPath, ConstData.dataBase));//根据路径打开数据库
        getSQliteData.InsertDataReader(ConstData.T_user, new string[] { user_name, user_password});
    }

    /// <summary>
    /// 检查用户表所有的账户名
    /// </summary>
    /// <param name="user_name">用户名</param>
    /// <returns></returns>
    public bool CheckUserNameData(string user_name)
    {
        getSQliteData.OpenDB("Data Source=" + Path.Combine(Application.persistentDataPath, ConstData.dataBase));//根据路径打开数据库
        SqliteDataReader reader = getSQliteData.GetRowDataReader(ConstUserData.user_name, ConstData.T_user);
        while (reader.Read())
        {
            if(reader.GetString(reader.GetOrdinal(ConstUserData.user_name)) == user_name)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 检查用户表的密码
    /// </summary>
    /// <param name="user_name"></param>
    /// <param name="user_password"></param>
    /// <returns></returns>
    public bool CheckPasswordData(string user_name, string user_password)
    {
        getSQliteData.OpenDB("Data Source=" + Path.Combine(Application.persistentDataPath, ConstData.dataBase));//根据路径打开数据库
        SqliteDataReader reader =  getSQliteData.GetDataReader(ConstData.T_user, ConstUserData.user_name, user_name);
        while (reader.Read())
        {
            if(reader.GetString(reader.GetOrdinal(ConstUserData.user_password)) == user_password)
            {
                return true;
            }
        }
        return false;
    }
}