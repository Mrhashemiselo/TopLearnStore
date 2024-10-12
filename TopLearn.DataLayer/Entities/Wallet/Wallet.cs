using System.ComponentModel.DataAnnotations;

namespace TopLearn.DataLayer.Entities.Wallet;
public class Wallet
{
    public Wallet()
    {

    }

    [Key]
    public int Id { get; set; }

    [Display(Name = "نوع تراکنش")]
    [Required(ErrorMessage = "لطفا {1} را وارد کنید")]
    public int WalletTypeId { get; set; }

    [Display(Name = "کاربر")]
    [Required(ErrorMessage = "لطفا {1} را وارد کنید")]
    public int UserId { get; set; }

    [Display(Name = "مبلغ")]
    [Required(ErrorMessage = "لطفا {1} را وارد کنید")]
    public int Amount { get; set; }

    [Display(Name = "پرداخت شده")]
    public bool IsPay { get; set; }

    [Display(Name = "شرح")]
    [MaxLength(500, ErrorMessage = "تعداد حروف مجاز {1} حرف است")]
    public string Description { get; set; }

    [Display(Name = "تاریخ و ساعت")]
    public DateTime CreateDate { get; set; }

    public virtual Users.User User { get; set; }
    public virtual WalletType WalletType { get; set; }
}
