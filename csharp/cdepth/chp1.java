1.1 ��c# д Product���͡�
1.2 ����͹���
1.3 ����δ֪����
1.4 linq���

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
-��ѯxml
	���粻�ǽ���Ʒ�͹�����Ӳ�������������ʹ��xml�ļ�
-linq to sql