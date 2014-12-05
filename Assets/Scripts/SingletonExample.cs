using System.Collections;

public sealed class SingletonExample {
	private static SingletonExample instance;
	
	private SingletonExample() {}
	
	public static SingletonExample Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new SingletonExample();
			}
			return instance;
		}
	}
}
