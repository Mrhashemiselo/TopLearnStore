using System.ComponentModel.DataAnnotations;
using TopLearn.Web.ParbadOnlinePayment.Enums;

namespace TopLearn.Web.ParbadOnlinePayment.ViewModels;

public class PayViewModel
{
    [Display(Name = "Tracking number")]
    public long TrackingNumber { get; set; }

    [Display(Name = "Generate the Tracking number automatically?")]
    public bool GenerateTrackingNumberAutomatically { get; set; } = true;

    public decimal Amount { get; set; }

    [Display(Name = "Gateway")]
    public Gateways SelectedGateway { get; set; } = Gateways.ParbadVirtual;
}
