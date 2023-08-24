using NUnit.Framework;

namespace ExampleAllure
{
	[AllureSuite("Глоссарий: создание глоссария")]
	[Parallelizable(ParallelScope.Fixtures)]
	public class GlossaryTests : Base
	{
		[Test]
		public void Should_create_glossary()
		{
			Assert.Pass();
		}
	}
}
