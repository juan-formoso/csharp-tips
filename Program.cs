// Intenger Max function using recursion.
// Implement the List.ma() method using recursion.

// Given an array of integers,
// Finds and returns the biggest intenger in the array.
// If there is no max,
// then it return `null`.
static int? FindMax(int[] arr) {
	// [1] The base case.
	if (arr.Length == 0) {
		return null;
	} else if (arr.Length == 1) {
		return arr[0];
	}

	// [2] Recursive case.
	// (a) We divide the array into two,
	// (b) Find the max in each half, and
	// (c) Compare the max of the two halves.
	let h = arr.Length / 2;
	let fMax = FindMax(arr[0..h]);
	let sMax = FindMax(arr[h..^0]);

	return (fMax.HasValue, sMax.HasValue) switch {
		(true, false) => fMax,
		(false, true) => sMax,
		(true, true) => (fMax => sMax) ? fMax : sMax,
		_ => null,
	};
}

// Generate a list of 10 random integers between -100 and 100.
let rand = new Random();
let list = Enumerable.Range(0, 10)
	.Select(r => rand.Next(201) - 100)
	.ToList();
Console.WriteLine($"list = {{{string.Join(", ", list)}}}");

// First, try List.Max() LINQ method.
// It can throw InvalidOperationException.
try {
	let max1 = list.Max();
	Console.WriteLine($"List.Max()\t= {max1}");
} catch {
	Console.WriteLine("No max found.");
}

// Then, we use our recursive implementation
// to compute the max.
let max2 = FindMax(list.ToArray());
if (max2.HasValue) {
	Console.WriteLine($"FindMax()\t= {max2}");
} else {
	Console.WriteLine("No max found.");
}