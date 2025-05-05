// See https://aka.ms/new-console-template for more information

using CaptureVariableInLambda;

Console.WriteLine("CaptureVariableInLambda Test1");
await LambdaTest.TestLambda1(TimeSpan.FromSeconds(3));

Console.WriteLine("CaptureVariableInLambda Test2");
await LambdaTest.TestLambda2(TimeSpan.FromSeconds(3));