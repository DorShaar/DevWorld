namespace CaptureVariableInLambda;

public class SomeObject
{
	public int Number { get; set; }

	public SomeObject Clone()
	{
		return new SomeObject
		{
			Number = Number
		};
	}
}