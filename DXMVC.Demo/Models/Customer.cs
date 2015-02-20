using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;


namespace DXMVC.Demo.Models
{
	 public class Customer
	 {
		  [HiddenInput(DisplayValue = false)]
		  public int ID { get; set; }

		  [Required()]
		  public string FirstName { get; set; }

		  public string MiddleName { get; set; }

		  [Required()]
		  public string LastName { get; set; }

		  [Required()]
		  [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
		  public string Email { get; set; }
	 }
}
