//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Praktika
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserActivity
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public System.DateTime loginTime { get; set; }
        public Nullable<System.DateTime> logoutTime { get; set; }
        public string reason { get; set; }
    
        public virtual UserData UserData { get; set; }
    }
}
