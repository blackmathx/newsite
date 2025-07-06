using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{

	// GET: /HelloWorld 
	// Requires using System.Text.Encodings.Web;
	public string Index(string name, int numTimes = 1, int ID = 1)
	{
		if (string.IsNullOrEmpty(name))
		{
			name = "Guest";
		}

		return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}. ID: {ID}");
	}
}