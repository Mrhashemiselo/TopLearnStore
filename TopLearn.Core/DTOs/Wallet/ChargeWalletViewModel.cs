using System.ComponentModel.DataAnnotations;

namespace TopLearn.Core.DTOs.Wallet;
public class ChargeWalletViewModel
{
    [Display(Name = "مبلغ شارژ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int Amount { get; set; }
}
