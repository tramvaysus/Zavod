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
    
    public partial class ПокупкаТовара
    {
        public long ID { get; set; }
        public long IDКлиента { get; set; }
        public long IDТовара { get; set; }
        public double Стоимость { get; set; }
        public int Количество { get; set; }
        public Nullable<double> Скидка { get; set; }
        public double ИтоговаяСтоимость { get; set; }
        public System.DateTime ДатаВремя { get; set; }
        public long IDСотрудника { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Продукт Продукт { get; set; }
    }
}
