## ViewData

ViewData and ViewBag are used for the same purpose --  to transfer data from controller to view.  ViewData is nothing but a dictionary of objects and it is accessible by string as key. ViewData is a property of controller that exposes an instance of the ViewDataDictionary class. ViewBag is very similar to ViewData. 

```C#
	//Controller Code  
	public ActionResult Index()  
	{  
	      List<string> Student = new List<string>();  
	      Student.Add("Jignesh");  
	      Student.Add("Tejas");  
	      Student.Add("Rakesh");  
	   
	      ViewData["Student"] = Student;  
	      return View();  
	}  
	//page code  
	<ul>  
	    <% foreach (var student in ViewData["Student"] as List<string>)  
	        { %>  
	    <li><%: student%></li>  
	    <% } %>  
	</ul>  
```

## ViewBag

ViewBag is a dynamic property (dynamic keyword which is introduced in .net framework 4.0). ViewBag is able to set and get value dynamically and able to add any number of additional fields without converting it to strongly typed. ViewBag is just a wrapper around the ViewData.

```C#
	//Controller Code  
	public ActionResult Index()  
	{  
	      List<string> Student = new List<string>();  
	      Student.Add("Jignesh");  
	      Student.Add("Tejas");  
	      Student.Add("Rakesh");  
	   
	      ViewBag.Student = Student;  
	      return View();  
	}   
	//page code  
	<ul>  
	    <% foreach (var student in ViewBag.Student)  
	        { %>  
	    <li><%: student%></li>  
	    <% } %>  
	</ul>  
	//Controller Code  
	public ActionResult Index()  
	{  
	      List<string> Student = new List<string>();  
	      Student.Add("Jignesh");  
	      Student.Add("Tejas");  
	      Student.Add("Rakesh");  
	   
	      ViewBag.Student = Student;  
	      return View();  
	}   
	//page code  
	<ul>  
	    <% foreach (var student in ViewBag.Student)  
	        { %>  
	    <li><%: student%></li>  
	    <% } %>  
	</ul>  
```

## TempData

TempData is a dictionary which is derived from TempDataDictionary class. TempData is stored data just like live session for short time. TempData keeps data for the time of HTTP Request, which means that it holds data between two consecutive requests. TempData helps us to transfer data between controllers or between actions. TempData internally use Session variables. Note that TempData is only work during the current and subsequent request. It is generally used to store one time messages. With the help of the TempData.Keep() method we can keep value in TempData object after request completion.

```C#
	//Controller Code  
	  
        public ActionResult Index()  
        {  
            List<string> Student = new List<string>();  
            Student.Add("Jignesh");  
            Student.Add("Tejas");  
            Student.Add("Rakesh");  
   
            TempData["Student"] = Student;  
             return View();  
        }  
       //page code  
       <ul>  
          <% foreach (var student in TempData["Student"] as List<string>)  
          { %>  
       <li><%: student%></li>  
       <% } %>  
       </ul>  
```

