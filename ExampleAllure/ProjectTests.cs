using NUnit.Framework;

namespace ExampleAllure
{
	[AllureSuite("������: �������� �������")]
	[Parallelizable(ParallelScope.Fixtures)]
	public class ProjectTests : Base
	{
		[OneTimeSetUp]
		public async Task Setup()
		{
			await SetUpAsync(async () =>
			{
				// ������, ��� ��� �������� � allure report https://skrinshoter.ru/sLTOvx2R0Yo?a - ��� ������
				// ����� ������� ����������� � TestOps https://skrinshoter.ru/sLTa2KpLBeu?a - �����, ������ ����� �������� ������ unknown
				throw new Exception("��������� ������ � onetime");
			});
		}

		[Test]
		public void Should_create_project()
		{
			Assert.Pass();
		}

	}
}