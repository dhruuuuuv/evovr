using System;
using Combinatorial;
using System.Collections;

namespace MainNamespace {

class MainClass {

	// For statistical purposes.
	[System.Runtime.InteropServices.DllImport("Kernel32.dll")]
	static extern bool QueryPerformanceCounter(ref long freq);

	[System.Runtime.InteropServices.DllImport("Kernel32.dll")]
	extern static short QueryPerformanceFrequency(ref long n);
	
	public static void Main() 
	{
		Console.WriteLine("Welcome to Combinatorial Demo/Test Program");

		// Fill an array of objects from 1 to 35;
//		Array myIntArray = Array.CreateInstance(Type.GetType("System.Int32"), 35);
//		for (int j = 0; j < myIntArray.Length; j++)
//			myIntArray.SetValue(j, j);

//		double[] myIntArray = new double[10];
//		for (int j = 0; j < myIntArray.Length; j++)
//			myIntArray[j] = (double)j;

//		ArrayList myArrayList = new ArrayList(15);
//		for (int j = 0; j < 10; j++)
//			myArrayList.Add("str"+j.ToString());

		string myString = "0123456789";

		// Create various combinatorial objects;
//		Combinations combs = new Combinations(myIntArray.GetEnumerator(), 3);
//		Combinations combs = new Combinations(myArrayList, 5);
//		Combinations combs = new Combinations(myString.GetEnumerator(), 10);
		Permutations combs = new Permutations(myString.GetEnumerator());
//		Permutations combs = new Permutations(myArrayList);
//		Variations combs = new Variations(myString.GetEnumerator(), 10);

		// Prepare the counter.
		long t1 = 0, t2 = 0;
		QueryPerformanceCounter(ref t1);

		// Access the combinations.
		int nCounter = 0;
//		combs.Reset();		// The CombinatorialAlgo are Reset() by default when created.
		while(combs.MoveNext()) {
			Array thisComb = (Array)combs.Current;
			nCounter++;
			for (int i = 0; i < thisComb.Length; i++) {
//				int nVal = (int)thisComb.GetValue(i);	// Just access the value. This requres boxing.
//				Object nVal = thisComb.GetValue(i);		// Just access the value. This requres no boxing.
//				Console.Write("{0}, ", nVal); 
			}

			if (nCounter % 40000 == 0)
				Console.WriteLine(nCounter);

//			Console.WriteLine();
		}

		QueryPerformanceCounter(ref t2);
		
		long freq = 0;
		QueryPerformanceFrequency(ref freq);
		Console.WriteLine("Combinations : {0}", nCounter);
		Console.WriteLine("Counter : {0}", t2 - t1);
		Console.WriteLine("Frequency : {0}",freq);
		Console.WriteLine("Time to execute : {0}", (double)(t2-t1) / freq);

	}

} // End of class MainClass

} // End Of namespace MainNamespace
