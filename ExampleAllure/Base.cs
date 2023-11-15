using NUnit.Allure.Core;
using NUnit.Framework;
using Allure.Net.Commons;

namespace ExampleAllure
{
	[AllureNUnit]
	public class Base
	{
		public async Task SetUpAsync(Func<Task> setUpAction)
		{
			try
			{
				await setUpAction.Invoke();
			}
			catch (Exception e)
			{
				handleException(e, setUpAction.Method.Name);
				throw;
			}
		}
		private void handleException(Exception e, string methodName)
		{
			var allure = AllureLifecycle.Instance;
			var test = TestContext.CurrentContext.Test;
			var testResult = new TestResult
			{

				uuid = test.ID,
				name = test.MethodName,
				fullName = test.FullName,
				descriptionHtml = $"Tests wasn't able to run - an exception occured in setUp methods of <b>{test.ClassName}</b> - {methodName} method",
				labels = new List<Label> {
						Label.Suite(test.ClassName),
						Label.Thread(),
						Label.Host(),
						Label.TestClass(test.ClassName),
						Label.TestMethod(test.MethodName),
						Label.Severity(SeverityLevel.blocker)
					}
			};

			allure.StartTestCase(testResult);
			allure.UpdateTestCase(x => x.statusDetails = new StatusDetails
			{
				message = e.Message,
				trace = e.StackTrace
			});
			allure.StopTestCase(x => x.status = Status.failed);
			allure.WriteTestCase(test.ID);
		}
	}

	public class AllureSuiteAttribute : AllureTestCaseAttribute
	{
		private string Suite { get; }

		public AllureSuiteAttribute(string suite)
		{
			Suite = suite;
		}

		public override void UpdateTestResult(TestResult testResult)
		{
			testResult.labels.Add(Label.Suite(Suite));
		}
	}
	public abstract class AllureTestCaseAttribute : NUnitAttribute
	{
		public abstract void UpdateTestResult(TestResult testResult);
	}
}
