using Polkanalysis.Components.Components.Display;
using Polkanalysis.Components.Test;
using System;
using static Polkanalysis.Components.Shared.GlobalSettings;

namespace Polkanalysis.Components.Tests.Display
{
    public class ViewSelectorTests : BunitTestContext
    {
        [Test, Ignore("Todo debug")]
        public void ViewSelector_SwitchBetweenView_ShouldSuceed()
        {
            ViewDisplayType? currentViewTypeSelected = null;
            Action<ViewDisplayType> onViewChangedHandler = (ViewDisplayType viewType) => { currentViewTypeSelected = viewType; };

            var viewSelectorComponent = TestContext!.RenderComponent<ViewSelector>(p => p
            .Add(x => x.OnViewSelected, onViewChangedHandler)
            );

            viewSelectorComponent.Find(".btn-card-element").Click();

            Assert.That(currentViewTypeSelected, Is.Not.Null);
            Assert.That(currentViewTypeSelected, Is.EqualTo(ViewDisplayType.CardElement));

            viewSelectorComponent.Find(".btn-table-element").Click();

            Assert.That(currentViewTypeSelected, Is.Not.Null);
            Assert.That(currentViewTypeSelected, Is.EqualTo(ViewDisplayType.TableRaw));
        }
    }
}
