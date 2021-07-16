using System;
using System.Collections.Generic;

public class Cache
{
	int[] stack;
	Dictionary<int, int> CacheDictionary = new Dictionary<int, int>();
	public Cache(int number)
	{
		this.stack = new int[number];
		for (int i = 0; i < stack.Length; i++)
		{
			this.stack[i] = 0;
		}
	}

	public void Put(int key, int value)
	{
		if (Get(key) == -1)
		{
			if (stack[0] == 0)
			{
				CacheDictionary.Add(key, value);
			}
			else
			{
				CacheDictionary.Add(key, value);
				CacheDictionary.Remove(stack[0]);
			}

			StackAdd(key);
		}
	}

	public int Get(int key)
	{
		try
		{
			Console.WriteLine(" ", CacheDictionary[key]);
			StackAdd(key);
			return CacheDictionary[key];
		}
		catch (KeyNotFoundException)
		{
			return -1;
		}
	}

	public void StackAdd(int key)
	{
		for (int i = 0; i < stack.Length; i++)
		{
			if (stack[i] == key)
			{
				StackUdate(key, i);
				return;
			}
		}

		StackUdate(key, 0);
	}

	public void StackUdate(int key, int iStart)
	{
		for (int i = iStart; i < stack.Length; i++)
		{
			if (i != stack.Length - 1)
			{
				stack[i] = stack[i + 1];
			}
			else
			{
				stack[stack.Length - 1] = key;
			}
		}
	}

	// for debug
	public void stackCheck()
	{
		for (int i = 0; i < stack.Length; i++)
		{
			Console.WriteLine("Cache element in " + i + " = " + stack[i]);
		}

		Console.WriteLine("\n");
	}

	public static void Main(String[] args)
	{
		Cache newCache = new Cache(2);
		
		// test 1 (task example)
		newCache.Put(1, 1);
		newCache.Put(2, 2);
		Console.WriteLine(newCache.Get(1));
		newCache.Put(3, 3);
		Console.WriteLine(newCache.Get(2));
		newCache.Put(4, 4);
		Console.WriteLine(newCache.Get(1));
		Console.WriteLine(newCache.Get(3));
		Console.WriteLine(newCache.Get(4));
		
		// test 2 (overwriting key\value)
		Console.WriteLine(newCache.Get(3));
		Console.WriteLine(newCache.Get(3));
		Console.WriteLine(newCache.Get(4));
	}
}