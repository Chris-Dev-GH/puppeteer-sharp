using System;
using System.Threading.Tasks;
using PuppeteerSharp.Tests.Attributes;
using PuppeteerSharp.Xunit;
using Xunit;
using Xunit.Abstractions;

namespace PuppeteerSharp.Tests.WaitForTests
{
    [Collection(TestConstants.TestFixtureCollectionName)]
    public class PageWaitForTimeoutTests : PuppeteerPageBaseTest
    {
        public PageWaitForTimeoutTests(ITestOutputHelper output) : base(output)
        {
        }

        [PuppeteerTest("waittask.spec.ts", "Page.waitForTimeout", "waits for the given timeout before resolving")]
        [PuppeteerFact]
        public async Task WaitsForTheGivenTimeoutBeforeResolving()
        {
            await Page.GoToAsync(TestConstants.EmptyPage);
            var startTime = DateTime.Now;
            await Page.WaitForTimeoutAsync(1000);
            Assert.True((DateTime.Now - startTime).TotalMilliseconds > 700);
            Assert.True((DateTime.Now - startTime).TotalMilliseconds < 1300);
        }
    }
}
