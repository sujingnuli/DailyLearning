1.1 用c# 写 Product类型。
1.2 排序和过滤
1.3 处理未知数据
1.4 linq简介
1.5 COM和动态类型
1.6 剖析.Net平台
1.7 怎样写出超炫的代码
1.8小结

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
		XmlDocument doc=XDocument.Load("data.xml");
		var fil=from p in doc.Descendants("Product")
				 join s in doc.Descendants("Supplier")
					on (int)p.Attribute("SupplierId") equals (int)s.Attibute("SupplierID")
				where (decimal)p.Attribute("Price")>10
				orderby (string)s.Attribute("Name").
				(string)p.Attribute("Name")
				select new{SupplierName=(string)s.Attribute("Name"),ProductName=(string)p.Attribute("Name")};
		foreach(var v in fil){
			Console.WriteLine("Supplier={0},Product={1}",v.SupplierName,v.ProductName);
		}
--linq to sql
  对SQL数据库应用查询表达式
  using(LinqDemoDataContext db=new LinqDemoDataContext()){
	var fil=from p in db.Products
			 join s in db.Suppliers
				on p.SupplierId equals s.SupplierId
			 where p.Price>10
			orderby s.Name,p.Name
			select new{SupplierName=s.Name,ProductName=p.Name};
	foreach(var v in fil){
		Console.WriteLine("supplier={0},product={1}",v.SupplierName,v.ProductName);
	}
	}

--1.5 COM和动态类型
	linq是c#3的内容，互操作性是c#4的主题，包括处理旧的COM技术，和全新的执行在
	DLR的动态语言上(Dynamic Language Runtime)
	将产品列表，导出到一个Excel数据表中
	var app=new Application{Visible=false};
	Workbook workbook=app.Workbooks.Add();
	Worksheet worksheet=app.ActiveSheet;
	int row=1;
	foreach(Product product in Product.GetSampleProducts().Where(p=>p.Price!=null)){
		worksheet.Cells[row,1].Value=product.Name;
		worksheet.Cells[row,2].Value=product.Price;
		row++;
	}
	workbook.SaveAs(FileName:"demo.xls",FileFormat:xlFileFormat.xlWorkbookNormal);
	app.Application.Quit();
  -与动态语言互操作
	假设 ，数据没有存在数据库，内存，xml中，可以通过Web来访问。
	从IronPython中获取 列表，并打印出来。
	ScriptEngine engine=Python.CreateEngine();
	ScriptScope scope=engine.ExecuteFile("FindProducts.py");
	dynamic products=scope.GetVaraibale("products");
	foreach(dynamic product in products){
		Console.WriteLine("{0}:{1}",product.ProductName,Product.Price);
	}
	product,products为动态类型，编译器，允许我们对产品进行迭代，并打印
	如果出现错误，只有在执行时，才直到错误。
	dynamic ,一个新的类型，如果一个表达式为dynamic类型，可以调用其方法
	访问其属性，将其作为方法的参数，进行传递，并且大多数绑定都发生在运行时，而不是在编译时
	如果出现错误，只有在执行时，才知道 。
	dynamic products=Product.GetSampleProducts();
	foreach(dynamic product in products){
		Console.WriteLine("{0}:{1}",product.productName,product.Price);
	}
--1.6 剖析.NET平台
	c#语言本身的特性，运行时特性，.net框架库的特性
	c#语言特性
	运行时特性
		数组和委托对IDisposable接口，没有任何特殊含义，对于运行时很重要。
		枚举enumerator，不是在运行时级别定义，却出现子啊运行时级别。
		运行时确保IL写的程序，符合CLI规范。CLI的运行时部分称为CLR,
		CLI: Common Language Infrastructure.公共语言基础设施。
	.NET框架库特性
		.Net库主要以IL形式构建，
--1.7 优化代码
	char[] chars=input.ToCharArray();
	Array.Reverse(chars);
	return new string(chars);
