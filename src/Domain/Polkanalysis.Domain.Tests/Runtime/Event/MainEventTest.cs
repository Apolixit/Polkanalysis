using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;

namespace Polkanalysis.Domain.Tests.Runtime.Event
{
    public class MainEventTest
    {
        protected void PrerequisiteEvent(INode node, Phase phase = Phase.ApplyExtrinsic)
        {
            Assert.That(node, Is.Not.Null);

            Assert.That(node.Children, Is.Not.Empty);

            // 3 children : Phase / Events / Topic
            Assert.That(node.Children.Count, Is.EqualTo(3));

            Assert.That(node.Has(phase));
        }
    }
}
