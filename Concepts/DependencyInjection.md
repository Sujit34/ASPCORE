## Dependency Injection (Explained with an example)

#### Requirements
Build an application that allows the user to see the available products and search products by name.

#### First Attempt
We will start by creating a layered architecture. There are multiple benefits using a layered architecture but we are not going to list them in this article since we are focusing on Dependency Injection.


First and foremost, we will start by creating a Product class:

```C#
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
```

Then, we will create the Data Access layer:

```C#
public class ProductDAL
{
    private readonly List<Product> _products;

    public ProductDAL()
    {
        _products = new List<Product>
        {
            new Product { Id = Guid.NewGuid(), Name= "iPhone 9", 
                          Description = "iPhone 9 mobile phone" },
            new Product { Id = Guid.NewGuid(), Name= "iPhone X", 
                          Description = "iPhone X mobile phone" }
        };
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }

    public IEnumerable<Product> GetProducts(string name)
    {
        return _products
            .Where(p => p.Name.Contains(name))
            .ToList();
    }
}
```

Then, we will create the business layer:

```C#
public class ProductBL
{
    private readonly ProductDAL _productDAL;

    public ProductBL()
    {
        _productDAL = new ProductDAL();
    }

    public IEnumerable<Product> GetProducts()
    {
        return _productDAL.GetProducts();
    }

    public IEnumerable<Product> GetProducts(string name)
    {
        return _productDAL.GetProducts(name);
    }
}
```

Finally, we will create the Presentation Layer:

```C#
class Program
{
    static void Main(string[] args)
    {
        ProductBL productBL = new ProductBL();

        var products = productBL.GetProducts();

        foreach (var product in products)
        {
            Console.WriteLine(product.Name);
        }

        Console.ReadKey();
    }
}
```

The code that we have written in the first attempt is working fine but there are few problems:

* We cannot have three different teams working on each layer.
* The business layer is hard to extend because it relies on the implementation of the data access layer.
* The business layer is hard to maintain because it relies on the implementation of the data access layer.
* The source code is very hard to test.


#### Second Attempt
The higher level object should not be dependent on the lower level object. Both have to be dependent on abstraction. So then what is the abstraction?

The abstraction is the definition of the functionality. In our case, the business layer is dependent on the data access layer to retrieve books. In C#, to implement abstraction, we use interfaces. An interface represents an abstraction of the functionality.

So let's create abstractions.

Below is the abstraction of the data access layer:

```C#
public interface IProductDAL
{
    IEnumerable<Product> GetProducts();
    IEnumerable<Product> GetProducts(string name);
}
```

We also need to update the data access layer:

```C#
public class ProductDAL : IProductDAL
```

We also need to update the business layer. Indeed, instead of being dependant on the implementation of the data access layer, we will update the business layer to be dependant on the abstraction of the data access layer:

```C#
public class ProductBL
{
    private readonly IProductDAL _productDAL;

    public ProductBL()
    {
        _productDAL = new ProductDAL();
    }

    public IEnumerable<Product> GetProducts()
    {
        return _productDAL.GetProducts();
    }

    public IEnumerable<Product> GetProducts(string name)
    {
        return _productDAL.GetProducts(name);
    }
}
```

We also have to create an abstraction of the business layer:

```C#
public interface IProductBL
{
    IEnumerable<Product> GetProducts();
    IEnumerable<Product> GetProducts(string name);
}
```

We need to update the business layer too:

```C#
public class ProductBL : IProductBL
```
And finally, we have to update the Presentation Layer:

```C#
class Program
{
    static void Main(string[] args)
    {
        IProductBL productBL = new ProductBL();

        var products = productBL.GetProducts();

        foreach (var product in products)
        {
            Console.WriteLine(product.Name);
        }

        Console.ReadKey();
    }
}
```

The code that we have done in the second attempt works but we are still dependant on the concrete implementation of the data access layer:

```C#
public ProductBL()
{
    _productDAL = new ProductDAL();
}
```

So, how to solve this? This is where the Dependency Injection pattern comes into play.

#### Final Attempt

All the work we have done so far is not about Dependency Injection.

In order for the business layer which is the higher level object to be dependent on the functionality of the lower level object without the concrete implementation, someone else has to create the class. Someone else has to provide the concrete implementation of the lower level object and that's what we call Dependency Injection. It literally means we're injecting the dependant object into the higher level object. One of the ways to implement Dependency Injection is to use Constructor Dependency Injection.

So let's update the business layer:

```C#
public class ProductBL : IProductBL
{
    private readonly IProductDAL _productDAL;

    public ProductBL(IProductDAL productDAL)
    {
        _productDAL = productDAL;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _productDAL.GetProducts();
    }

    public IEnumerable<Product> GetProducts(string name)
    {
        return _productDAL.GetProducts(name);
    }
}
```

The infrastructure has to provide the dependency to the implementation:

```C#
class Program
{
    static void Main(string[] args)
    {
        IProductBL productBL = new ProductBL(new ProductDAL());

        var products = productBL.GetProducts();

        foreach (var product in products)
        {
            Console.WriteLine(product.Name);
        }

        Console.ReadKey();
    }
}
```

The control of creating the data access layer is invereted into the infrastructure. This is also called Inversion of Control. Instead of creating the instance of the data access layer in the business layer, we are creating it inside of the infrastructure which is the Main method. The Main method will inject the instance into the business logic layer. So we are injecting the instance of the lower level object into the instance of the higher level object. So, that's called Dependency Injection.

Now if we look at the code, we only have dependency on the abstraction of the data access layer in the business access layer which is the interface that the data access layer implements. Therefore, we are following the principles of both higher level objects and lower level objects are dependant on abstraction which is a contract between the higher level object and the lower level object.

Now, we can have different teams working on different layers. We can have one team working on the data access layer, one team working on the business layer and one team working on the UI.

And then it comes to the benefits of maintainability and extensibility. If we want for example to create a new data access layer for SQL Server, we only have to implemlent the abstraction of the data access layer and inject the instance in the infrastructure.


#### Source: Code Project