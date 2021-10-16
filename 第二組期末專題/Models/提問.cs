﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 提問
    {
        public int Id { get; set; }
        public string 問題 { get; set; }
        public string 回答 { get; set; }
        public int 提問用戶_FK { get; set; }


        public 用戶 Get提問用戶()
        {
            return new 任務SelectById<用戶>(提問用戶_FK).Get();
        }
    }
}