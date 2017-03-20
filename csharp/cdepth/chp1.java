1.1 用c# 写 Product类型。
1.2 排序和过滤
1.3 处理未知数据
1.4 linq简介

1.2排序和过滤
使用产品列表，按名称排序，找出最贵的产品。
-按名称对产品排序
  对产品排序，再 打印出来。
	 ArrayList.Sort			IComparer实现。
	 让Product类型实现ICommparable,但这样只能定义一种排序。
  实现IComparable
     实际会创建一个委托实例，将委托提供给sort方法来执行，
	 public class ProductNameCompare
	 {
		 List<Product> pros=Product.GetSampleProducts();
		 pros.Sort((x,y)=>x.Name.CompareTo(y.Name));
		 foreach(Product product in pros)	 
		 {
			Console.WriteLine(product.ToString());
		 }
	 }
	 语法： lambda表达式，仍然会创建一个Comparison<Product>语法，delegate
	 使用扩展方法排序
	 foreach(Product product in pros.OrderBy(p=>p.Name))
	 {
		Console.WriteLine(product);
	 }
	 调用了List的 OrderBy方法(扩展方法)
-查询集合
	找出列表中符合特定条件的所有元素。
	找出价格高于10美元的产品。
	-c#1
		List<Product> pros=Product.GetSampleProducts();
		foreach(Product pro in pros)
		{
			if(pro.Price>10m)
			{
				Console.WriteLine(pro);
			}
		}
	    缺点：for循环，if判断，Console.显示，是纠缠在一起的。
	-c#3
		List<Product> pros=Product.GetSampleProducts();
		foreach(Product pro in pros.Where(p=>p.Price>10m))
		{
			Console.WriteLine(pro);
		}
	总结： 使用匿名方法可以轻松编写一个委托，lambda表达式更进一步，
	     在foreach的第一个部分包含查询或者排序操作，同时不影响可读性。
		 foreach(Product pro in pros.OrderBy(p=>p.Name)){
			Console.WriteIine(pro);
		 }
		 foreach(Product pro in pros.Where(p=>p.Price>10m)){
			Console.WriteLine(pro);
		 ｝

1.3 处理未知数据
	未知数据1： 确实没有数据信息
	未知数据2： 从方法调用中移除信息，使用默认值来代替
-表示未知的价格
	假定 产品列表，不仅包含现售产品，还包含未面世产品。decimal值类型
-可选参数和默认值
	传统方法，引入重载。现在引入可选参数。在c#4之前，只能重载构造函数。
	c#4可以声明默认值
	public Product(string name,decimal ? price=null)
	{
		this.name=name;
		this.price=price;
	}
-1.4 linq简介
	linq: language Integrated Query,语言集成查询。
-查询表达式 和进程内查询
	筛选集合
	List<Product> products=Product.GetSampleProducts();
	var filtered=from Product p in products
				 where p.Price>10
				 select p;
	foreach(Product p in filtered)
	{
		Console.WriteLine(p);
	}
	查询表达式： where语句显的更简单。
	价格高于10美元，先按照供货商名称来排序，再按产品名称排序
	最后打印每个匹配项的供货商名称和产品名称。
	linq实现
	List<Product> pros=Product.GetSampleProduct();
	List<Supplier> supps=Supplier.GetSampleSupplier();
	var fil=from p in pros
			join s in suppliers
			on p.SupplierId equals s.SupplierId
		    where p.Price>10
		    orderby s.Name,p.Name
			select new {SupplierName=s.name,ProductName=p.Name};
	foreach(var v in fil)
	 {
			Console.WriteLine("Supplier={0};Product={1}",v.SupplierName,v.ProductName);
	}
	linq与sql语言很像，但是只是借用了sql的语法和思路，与数据库没有任何关联。
-查询xml
	假如不是将产品和供货商硬编码过来，而是使用xml文件
-linq to sql