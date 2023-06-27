using Dapper.Contrib.Extensions;
using Katalog.Discount.Types;

namespace Katalog.Discount.Entities
{
    [Dapper.Contrib.Extensions.Table("discount")]
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public decimal CertainValue { get; set; }
        public decimal MinCartValue { get; set; } = 0;
        public decimal MaxCartValue { get; set; } = 0;
        public decimal MaxDiscount { get; set; } = 0;
        public DiscountType DiscountType { get; set; }
        //public string[] StoreIds { get; set; } = new string[0];
        //public string[] CategoryIds { get; set; } = new string[0];
        //public string[] ProductIds { get; set; } = new string[0];
        public DateTime CreatedTime { get; set; }
        public bool IsLimited { get; set; }
        public int Amount { get; set; } = 0;
        public DateTime ValidityDate { get; set; }
        public StatusType StatusType { get; set; }
        public string CreatedById { get; set; } = string.Empty;

    }
}
