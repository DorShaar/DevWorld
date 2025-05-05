namespace CaptureVariableInLambda;

public static class LambdaTest
{
	/// <summary>
	/// Here the captured variable is not the cloned object but the clone method, so it will clone, after the change of Number from 1 to 2, the object with value 2.
	/// So at the end we will print 2.
	/// </summary>
	/// <param name="changeAfter"></param>
	public static async Task TestLambda1(TimeSpan changeAfter)
	{
		TimeSpan cancelAfter = changeAfter.Add(TimeSpan.FromSeconds(3));
		CancellationTokenSource cancellationTokenSource = new();
		cancellationTokenSource.CancelAfter(cancelAfter);

		SomeObject someObject = new()
		{
			Number = 1
		};

		Task.Run(() => RunLong(() => someObject.Clone(), cancellationTokenSource.Token));
		
		await Task.Delay(changeAfter, CancellationToken.None);

		someObject.Number = 2;
		Console.WriteLine("Changed Number from 1 to 2");
		
		await Task.Delay(cancelAfter - changeAfter, CancellationToken.None);
	}
	
	/// <summary>
	/// Where the captured variable is the cloned object, so the cloned object that is passed has value 1 even after the change of Number from 1 to 2.
	/// So at the end we will still print 1.
	/// </summary>
	/// <param name="changeAfter"></param>
	public static async Task TestLambda2(TimeSpan changeAfter)
	{
		TimeSpan cancelAfter = changeAfter.Add(TimeSpan.FromSeconds(3));
		CancellationTokenSource cancellationTokenSource = new();
		cancellationTokenSource.CancelAfter(cancelAfter);

		SomeObject someObject = new()
		{
			Number = 1
		};

		// Here is the change.
		SomeObject clonedObject = someObject.Clone();
		Task.Run(() => RunLong(() => clonedObject, cancellationTokenSource.Token));
		
		await Task.Delay(changeAfter, CancellationToken.None);
		
		someObject.Number = 2;
		Console.WriteLine("Changed Number from 1 to 2");
		
		await Task.Delay(cancelAfter - changeAfter, CancellationToken.None);
	}

	private static async Task RunLong(Func<SomeObject> getSomeObjectFunc, CancellationToken cancellationToken)
	{
		while (cancellationToken.IsCancellationRequested is false)
		{
			Console.WriteLine(getSomeObjectFunc().Number);
			await Task.Delay(TimeSpan.FromMilliseconds(200), CancellationToken.None);
		}
	}
}