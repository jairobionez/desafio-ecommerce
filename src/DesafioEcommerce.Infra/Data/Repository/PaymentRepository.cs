using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Repository;
using DesafioEcommerce.Infra.Data.Context;

namespace DesafioEcommerce.Infra.Data.Repository
{
    class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(EcommerceContext ecommerce, INotifiable notifications) : base(ecommerce, notifications)
        {            

        }
    }
}
