本章内容———————委托、类型系统的特征、值/引用类型
2.1 委托
2.2 类型系统的特征
2.3 值类型和引用类型

--2.1 委托
	委托 delegate.不需要直接指定一个要执行的行为，将行为，用某种方式包含在对象中。
	以遗嘱为例：付账单，捐善款，其余财产留给猫。
	委托条件： 声明委托类型，有一个方法包含要执行代码，创建一个委托实例，调用委托实例。
	--声明委托类型
		delegate void StringProcessor(string input); 
		派生关系： System.Delegate————>System.MulticastDelegate—————>StringProcessor
	--为委托实例的操作，找一个恰当的方法
	--创建委托实例
	--调用委托实例
	using System;

	delegate void StringProcessor(string input);
	class Person
	{
		string name;
		public Person(string name){this.name=name;}
		public void say(string message){
			Console.WriteLine("{0} say:{1}",name,message);
		}
	}
	Class Background{
		public static void Note(string note){
			Console.WriteIine("this is just a note");
		}
	}
	class SimpleDelegateUse
	{
		Person json=new Person("json");
		Person tom=new Person("tom");
		StringProcessor josonVoice,tomVoice,backgroundVoice;
		jsonVoice=new StringProcessor(json.say);
		tomVoice=new StringProcessor(tom.say);
		backgroundVoice=new StringProcessor(background.Note);
		jsonVoice.Invoke("hello json");
		tomVoice.Invoke("Hello tom");
		backgroundVoice.Invoke(" only flile");
	}
	委托的实质是间接的执行某事。如在单击按钮时发生某事，但是不想修改代码。
	--合并委托、删除委托
	委托调用列表 invocation list.即委托实例都有一个操作列表与之相关联
	System.Delegate——> Combine、Remove 增加删除委托实例
	--对事件的简单讨论
	发布/订阅模式 （publish/subscribe pattern）
--2.2 类型系统的特征
	类型系统： 强/弱  ，安全/不安全 ， 静态/动态
	c#1 的类型系统 ，是 静态的，显式的，安全的。
	显式和隐式 只有在静态类型的语言中才有意义。

	数组是强类型的 。
	string[] strings=new string[5];
	Object[] objs=strings;
	obj[0]=new Button();
	会抛出ArrayTypeMismatchException ;因为数组在转换时，返回原始引用。
	本质引用同一个数组，拒绝对非字符串的引用。
	弱类型集合：ArrayList,Hashtable;
--2.3 值类型和引用类型
	枚举是值类型
	数组是引用类型。接口是引用类型。委托是引用类型 。