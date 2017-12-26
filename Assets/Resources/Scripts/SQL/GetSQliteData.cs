using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;


/*此脚本获取数据库数据*/
public class GetSQliteData
{
    #region 单例 
    static GetSQliteData _instance;
    public static GetSQliteData Instance()
    {
        if(_instance == null)
        {
            _instance = new GetSQliteData();
        }
        return _instance;
    }
    private GetSQliteData() { }//私有化构造函数

    #endregion

    SqliteConnection connect;//连接
    SqliteCommand command;//命令
    SqliteDataReader datareader;//数据读取

    /// <summary>
    /// 创建数据库连接, 并打开
    /// </summary>
    /// <param name="path">路径</param>
    public void OpenDB(string path)
    {
        connect = new SqliteConnection(path);
        try
        {
            connect.Open();
        }
        catch (Exception exp)
        {
            Debug.Log(exp.ToString() + "----打开数据库失败");
        }
    }

    /// <summary>
    /// 清空数据库连接
    /// </summary>
    public void CloseDB()
    {
        if(connect != null)
        {
            connect.Dispose();
            connect = null;
        }
    }

    /// <summary>
    /// 创建命令
    /// </summary>
    /// <param name="sqQuery">命令</param>
    public SqliteDataReader CreateCommand(string sqQuery)
    {
        try
        {
            command = connect.CreateCommand();
            command.CommandText = sqQuery;
            datareader = command.ExecuteReader();
        }
        catch (Exception exp)
        {
            Debug.Log(exp.ToString() + "----sq语句错误");
        }       
        return datareader;
    }

    /// <summary>
    /// 读取某一行的数据
    /// </summary>
    /// <param name="tableName">表名</param>
    /// <param name="condition">条件</param>
    /// <param name="value">值</param>
    /// <returns></returns>
    public SqliteDataReader GetDataReader(string tableName, string condition, string value)
    {
        string sqlQuery = "SELECT *FROM " + tableName + " WHERE " + condition + " = " + "'" + value + "'";

        return CreateCommand(sqlQuery);
    }

    /// <summary>
    /// 读取某一列的数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <param name="tableName">表名</param>
    /// <returns></returns>
    public SqliteDataReader GetRowDataReader(string data, string tableName)
    {
        string sqlQuery = "SELECT " + data + " FROM " + tableName;
        return CreateCommand(sqlQuery);
    }


    /// <summary>
    /// 更新某一行数据
    /// </summary>
    /// <param name="tableName">表名</param>
    /// <param name="datas">字段数组</param>
    /// <param name="dataValues">数据数组</param>
    /// <param name="condition">条件</param>
    /// <param name="value">值</param>
    /// <returns></returns>
    public void UpdateDataReader(string tableName, string[] datas, string[] dataValues, string condition, string value)
    {
        string sqlQuery = "UPDATE " + tableName + " SET " + datas[0] + " = " + "'" + dataValues[0] + "'";
        for (int i = 1; i < datas.Length; i++)
        {
            sqlQuery += ", " + datas[i] + " = " + "'" + dataValues[i] + "'";
        }
        sqlQuery += " WHERE " + condition + " = " + "'" + value + "'";
        CreateCommand(sqlQuery);
    }

    /// <summary>
    /// 插入数据
    /// </summary>
    /// <param name="tableName">表名</param>
    /// <param name="dataValues">值数组</param>
    public void InsertDataReader(string tableName, string[] dataValues)
    {
        string sqlQuery = "INSERT INTO " + tableName + " VALUES (" + "'" + dataValues[0] + "'";
        for (int i = 1; i < dataValues.Length; i++)
        {
            sqlQuery += " , " + " ' " + dataValues[i] + " ' ";
        }
        sqlQuery += ")";
        CreateCommand(sqlQuery);
    }
}
