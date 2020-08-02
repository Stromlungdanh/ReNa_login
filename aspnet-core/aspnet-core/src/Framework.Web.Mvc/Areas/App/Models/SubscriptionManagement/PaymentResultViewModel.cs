using Abp.AutoMapper;
using Framework.Editions;
using Framework.MultiTenancy.Payments.Dto;

namespace Framework.Web.Areas.App.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}