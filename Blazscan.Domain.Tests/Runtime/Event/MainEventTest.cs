using Blazscan.Domain.Contracts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Tests.Runtime.Event
{
    public class MainEventTest
    {
        protected (INode runtimeEvent, INode palletEvent) PrerequisiteEvent(INode node)
        {
            Assert.That(node, Is.Not.Null);

            Assert.That(node.Children, Is.Not.Empty);

            // 3 children : Phase / Events / Topic
            Assert.That(node.Children.Count, Is.EqualTo(3));

            var runtimeEvent = node.Children.ToList()[1];
            Assert.That(runtimeEvent.Name, Is.EqualTo("Event"));

            var palletChild = runtimeEvent.Children.First();
            Assert.IsInstanceOf<Enum>(palletChild.HumanData);

            var palletEvent = palletChild.Children.First();
            Assert.IsInstanceOf<Enum>(palletEvent.HumanData);

            return (palletChild, palletEvent);
        }
    }
}
