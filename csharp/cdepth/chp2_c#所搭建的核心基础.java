�������ݡ�������������ί�С�����ϵͳ��������ֵ/��������
2.1 ί��
2.2 ����ϵͳ������
2.3 ֵ���ͺ���������
2.4 c#1֮�⣬�����ڼ�ʵ�Ļ���֮�ϵ�������

--2.1 ί��
	ί�� delegate.����Ҫֱ��ָ��һ��Ҫִ�е���Ϊ������Ϊ����ĳ�ַ�ʽ�����ڶ����С�
	������Ϊ�������˵������ƿ����Ʋ�����è��
	ί�������� ����ί�����ͣ���һ����������Ҫִ�д��룬����һ��ί��ʵ��������ί��ʵ����
	--����ί������
		delegate void StringProcessor(string input); 
		������ϵ�� System.Delegate��������>System.MulticastDelegate����������>StringProcessor
	--Ϊί��ʵ���Ĳ�������һ��ǡ���ķ���
	--����ί��ʵ��
	--����ί��ʵ��
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
	ί�е�ʵ���Ǽ�ӵ�ִ��ĳ�¡����ڵ�����ťʱ����ĳ�£����ǲ����޸Ĵ��롣
	--�ϲ�ί�С�ɾ��ί��
	ί�е����б� invocation list.��ί��ʵ������һ�������б���֮�����
	System.Delegate����> Combine��Remove ����ɾ��ί��ʵ��
	--���¼��ļ�����
	����/����ģʽ ��publish/subscribe pattern��
--2.2 ����ϵͳ������
	����ϵͳ�� ǿ/��  ����ȫ/����ȫ �� ��̬/��̬
	c#1 ������ϵͳ ���� ��̬�ģ���ʽ�ģ���ȫ�ġ�
	��ʽ����ʽ ֻ���ھ�̬���͵������в������塣

	������ǿ���͵� ��
	string[] strings=new string[5];
	Object[] objs=strings;
	obj[0]=new Button();
	���׳�ArrayTypeMismatchException ;��Ϊ������ת��ʱ������ԭʼ���á�
	��������ͬһ�����飬�ܾ��Է��ַ��������á�
	�����ͼ��ϣ�ArrayList,Hashtable;
--2.3 ֵ���ͺ���������
	ö����ֵ����
	�������������͡��ӿ����������͡�ί������������ ��
    --ֵ���ͺ��������͵Ļ���
	�ṹ��ֵ���͡�
	�ֲ�������������ջ��stack,
	��������ʵ��������ڶ���,heap,��̬���������ڶ��С�
    --�߳�����
	DateTime�ǽṹ�壬�ṹ�嶼��ֵ���͡�
	�������Ͷ����ڶ��ϡ�
	
    --�����װ��
	
	װ��:boxing;
	װ��Ͳ�����ʲôʱ����������������Կ�����(ǿ������ת��),װ�����͵͵���С�
	���͵�ֵ �����û�и��ǣ�toString,equals,GetHashCode������Ҳ�ᷢ��װ�䡣
	Ƶ���Ĳ�װ���Ӱ�����ܣ������������ڶ�Ķ���
	CLR,C#3��ȡ�˸���ĺ�������ί�еĴ���ʽ��
	����ʹ�þ���ǩ���ķ���������ί��ʵ����
	c#3  lambda
	.net3.5 Func����ί������
	Func<int,int,String>  func=(x,y)=>(x*y).ToString();
	Console.WriteLine(func(5,4));
	���͡���������c#2����������Ҫ�����ԡ�
	linq,�������ͣ���ʽ���ͣ���ʽ���͵ľֲ���������չ������----c#3��Ҫ����
	
	c#3 �Ǿ�̬���ԡ�
	c#4��������ϵͳ���ԡ�����ί�кͽӿڵ�Э�����䣬(.net2.0)
			     ��̬���͡�
	