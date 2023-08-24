using NUnit.Framework;

namespace ExampleAllure
{
	[AllureSuite("Проект: создание проекта")]
	[Parallelizable(ParallelScope.Fixtures)]
	public class ProjectTests : Base
	{
		[OneTimeSetUp]
		public async Task Setup()
		{
			await SetUpAsync(async () =>
			{
				// пример, как это выглядит в allure report https://skrinshoter.ru/sLTOvx2R0Yo?a - все хорошо
				// после импорта результатов в TestOps https://skrinshoter.ru/sLTa2KpLBeu?a - плохо, вместо имени упавшего класса unknown
				throw new Exception("Произошла ошибка в onetime");
			});
		}

		[Test]
		public void Should_create_project()
		{
			Assert.Pass();
		}

	}
}