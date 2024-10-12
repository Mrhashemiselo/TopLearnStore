using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopLearn.DataLayer.Entities.Wallet;
public class WalletType
{
    public WalletType()
    {

    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; }

    public virtual List<Wallet> Wallets { get; set; }
}
