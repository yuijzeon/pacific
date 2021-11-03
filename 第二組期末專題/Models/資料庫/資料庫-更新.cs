﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using 第二組期末專題.Models;

namespace 第二組期末專題
{
    public static partial class 資料庫
    {
        public static void 刪除<某類別>(object ID) where 某類別 : Dictionary<string, object>, new()
        {
            string 查詢字串 = $"DELETE FROM [{typeof(某類別).Name}] WHERE [Id]=@ID;";

            new Sql任務(查詢字串, new { ID }).執行();
        }

        public static void 更新<某類別>(某類別 字典) where 某類別 : Dictionary<string, object>, new()
        {

            var 欄位名稱 = new List<string>();

            Dictionary<string, object> Sql指令字典 = new Dictionary<string, object>();

            foreach (var 欄位 in 字典)
            {
                Sql指令字典.Add(欄位.Key, 欄位.Value);

                if (欄位.Key == "Id") continue;

                欄位名稱.Add($"[{欄位.Key}]=@{欄位.Key}");
            }

            string 查詢字串 = $"UPDATE [{typeof(某類別).Name}] SET {string.Join(", ", 欄位名稱)} WHERE [Id]=@Id;";

            new Sql任務(查詢字串, Sql指令字典).執行();
        }
    }
}