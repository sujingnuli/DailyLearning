1.1 ��c# д Product���͡�
1.2 ����͹���
1.3 ����δ֪����
1.4 linq���
1.5 COM�Ͷ�̬����
1.6 ����.Netƽ̨
1.7 ����д�����ŵĴ���
1.8С��

1.2����͹���
ʹ�ò�Ʒ�б������������ҳ����Ĳ�Ʒ��
-�����ƶԲ�Ʒ����
  �Բ�Ʒ������ ��ӡ������
	 ArrayList.Sort			IComparerʵ�֡�
	 ��Product����ʵ��ICommparable,������ֻ�ܶ���һ������
  ʵ��IComparable
     ʵ�ʻᴴ��һ��ί��ʵ������ί���ṩ��sort������ִ�У�
	 public class ProductNameCompare
	 {
		 List<Product> pros=Product.GetSampleProducts();
		 pros.Sort((x,y)=>x.Name.CompareTo(y.Name));
		 foreach(Product product in pros)	 
		 {
			Console.WriteLine(product.ToString());
		 }
	 }
	 �﷨�� lambda���ʽ����Ȼ�ᴴ��һ��Comparison<Product>�﷨��delegate
	 ʹ����չ��������
	 foreach(Product product in pros.OrderBy(p=>p.Name))
	 {
		Console.WriteLine(product);
	 }
	 ������List�� OrderBy����(��չ����)
-��ѯ����
	�ҳ��б��з����ض�����������Ԫ�ء�
	�ҳ��۸����10��Ԫ�Ĳ�Ʒ��
	-c#1
		List<Product> pros=Product.GetSampleProducts();
		foreach(Product pro in pros)
		{
			if(pro.Price>10m)
			{
				Console.WriteLine(pro);
			}
		}
	    ȱ�㣺forѭ����if�жϣ�Console.��ʾ���Ǿ�����һ��ġ�
	-c#3
		List<Product> pros=Product.GetSampleProducts();
		foreach(Product pro in pros.Where(p=>p.Price>10m))
		{
			Console.WriteLine(pro);
		}
	�ܽ᣺ ʹ�����������������ɱ�дһ��ί�У�lambda���ʽ����һ����
	     ��foreach�ĵ�һ�����ְ�����ѯ�������������ͬʱ��Ӱ��ɶ��ԡ�
		 foreach(Product pro in pros.OrderBy(p=>p.Name)){
			Console.WriteIine(pro);
		 }
		 foreach(Product pro in pros.Where(p=>p.Price>10m)){
			Console.WriteLine(pro);
		 ��

1.3 ����δ֪����
	δ֪����1�� ȷʵû��������Ϣ
	δ֪����2�� �ӷ����������Ƴ���Ϣ��ʹ��Ĭ��ֵ������
-��ʾδ֪�ļ۸�
	�ٶ� ��Ʒ�б������������۲�Ʒ��������δ������Ʒ��decimalֵ����
-��ѡ������Ĭ��ֵ
	��ͳ�������������ء����������ѡ��������c#4֮ǰ��ֻ�����ع��캯����
	c#4��������Ĭ��ֵ
	public Product(string name,decimal ? price=null)
	{
		this.name=name;
		this.price=price;
	}
-1.4 linq���
	linq: language Integrated Query,���Լ��ɲ�ѯ��
-��ѯ���ʽ �ͽ����ڲ�ѯ
	ɸѡ����
	List<Product> products=Product.GetSampleProducts();
	var filtered=from Product p in products
				 where p.Price>10
				 select p;
	foreach(Product p in filtered)
	{
		Console.WriteLine(p);
	}
	��ѯ���ʽ�� where����Եĸ��򵥡�
	�۸����10��Ԫ���Ȱ��չ����������������ٰ���Ʒ��������
	����ӡÿ��ƥ����Ĺ��������ƺͲ�Ʒ���ơ�
	linqʵ��
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
	linq��sql���Ժ��񣬵���ֻ�ǽ�����sql���﷨��˼·�������ݿ�û���κι�����
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
  ��SQL���ݿ�Ӧ�ò�ѯ���ʽ
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

--1.5 COM�Ͷ�̬����
	linq��c#3�����ݣ�����������c#4�����⣬��������ɵ�COM��������ȫ�µ�ִ����
	DLR�Ķ�̬������(Dynamic Language Runtime)
	����Ʒ�б�������һ��Excel���ݱ���
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
  -�붯̬���Ի�����
	���� ������û�д������ݿ⣬�ڴ棬xml�У�����ͨ��Web�����ʡ�
	��IronPython�л�ȡ �б�����ӡ������
	ScriptEngine engine=Python.CreateEngine();
	ScriptScope scope=engine.ExecuteFile("FindProducts.py");
	dynamic products=scope.GetVaraibale("products");
	foreach(dynamic product in products){
		Console.WriteLine("{0}:{1}",product.ProductName,Product.Price);
	}
	product,productsΪ��̬���ͣ����������������ǶԲ�Ʒ���е���������ӡ
	������ִ���ֻ����ִ��ʱ����ֱ������
	dynamic ,һ���µ����ͣ����һ�����ʽΪdynamic���ͣ����Ե����䷽��
	���������ԣ�������Ϊ�����Ĳ��������д��ݣ����Ҵ�����󶨶�����������ʱ���������ڱ���ʱ
	������ִ���ֻ����ִ��ʱ����֪�� ��
	dynamic products=Product.GetSampleProducts();
	foreach(dynamic product in products){
		Console.WriteLine("{0}:{1}",product.productName,product.Price);
	}
--1.6 ����.NETƽ̨
	c#���Ա�������ԣ�����ʱ���ԣ�.net��ܿ������
	c#��������
	����ʱ����
		�����ί�ж�IDisposable�ӿڣ�û���κ����⺬�壬��������ʱ����Ҫ��
		ö��enumerator������������ʱ�����壬ȴ�����Ӱ�����ʱ����
		����ʱȷ��ILд�ĳ��򣬷���CLI�淶��CLI������ʱ���ֳ�ΪCLR,
		CLI: Common Language Infrastructure.�������Ի�����ʩ��
	.NET��ܿ�����
		.Net����Ҫ��IL��ʽ������
--1.7 �Ż�����
	char[] chars=input.ToCharArray();
	Array.Reverse(chars);
	return new string(chars);
