//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoGoShare
{
    using System;
    using System.Collections.Generic;
    
    public partial class 圖片
    {
        public int Id { get; set; }
        public int 上傳用戶_FK { get; set; }
        public string 路徑 { get; set; }
    
        public virtual 用戶 用戶 { get; set; }
    }
}
