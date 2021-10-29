﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶CRUD
    {
        public void 註冊(用戶 x)
        {
            string sql = "INSERT INTO 用戶 (帳號, 密碼, 名字, 手機, 註冊日期, 點數) VALUES (";
            sql += "N'" + x.帳號 + "', ";
            sql += "'" + x.密碼 + "', ";
            sql += "N'" + x.名字 + "', ";
            sql += "'" + x.手機 + "', ";
            sql += "N'" + x.註冊日期 + "', ";
            sql += x.點數 + ")";

            new 資料庫任務(sql).Set();
        }

        //用戶表格讀取字串
        private List<用戶> queryBySql(string sql)
        {
            List<用戶> list = new List<用戶>();

            new 資料庫任務(sql)
            {
                When讀取到一筆資料 = (reader) =>
                {
                    list.Add(new 用戶()
                    {
                        Id = (int)reader["Id"],
                        帳號 = reader["帳號"].ToString(),
                        密碼 = reader["密碼"].ToString(),
                        名字 = reader["名字"].ToString(),
                        手機 = reader["手機"].ToString(),
                        //註冊日期 = (DateTime)reader["註冊日期"],
                        大頭貼 = reader["大頭貼"].ToString(),
                        點數 =(int)reader["點數"]
                    }); 
                }
            }.讀取資料庫();

            return list;
        }

        //登入比對
        public List<用戶> 登入(string 帳號,string 密碼)
        {
            return queryBySql("SELECT *  FROM 用戶 WHERE 帳號 LIKE"+" '"+帳號 +"' " +"AND 密碼  LIKE"+" '"+密碼+"'");
        }

        //會員資料編輯
        public 用戶 queryById(int fid)
        {
            string sql = "SELECT * FROM 用戶 WHERE Id = " + fid;
            List<用戶> x = queryBySql(sql);
            if (x.Count == 0)
                return null;
            return x[0];
        }
    }
}