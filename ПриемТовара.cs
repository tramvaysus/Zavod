//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp3
{
    using System;
    using System.Collections.Generic;
    
    public partial class ПриемТовара
    {
        public long ID { get; set; }
        public long IDСотрудника { get; set; }
        public int Количество { get; set; }
        public System.DateTime ДатаВремя { get; set; }
        public long IDПоставщика { get; set; }
        public long IDРасходника { get; set; }
    
        public virtual Поставщик Поставщик { get; set; }
    }
}
