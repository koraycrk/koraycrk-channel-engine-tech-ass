using ChannelEngineAssessment.Core.Entities;
using ChannelEngineAssessment.Core.Specifications.Base;

namespace ChannelEngineAssessment.Core.Specifications
{
    public class OrderWithStatusSpecification : BaseSpecification<Order>
    {
        public OrderWithStatusSpecification(string status) 
            : base(p => p.Status.ToLower().Contains(status.ToLower()))
        {
            AddInclude(p => p.Status);
        }

        public OrderWithStatusSpecification() : base(null)
        {
            AddInclude(p => p.Status);
        }
    }
}
