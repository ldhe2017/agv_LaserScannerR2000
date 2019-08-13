/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/3/18
 * Time: 22:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft .Json ;
using System.Data ;
using System .Linq ;
using System .Net .Sockets  ;
using System .Net ;
using System .Web;
using Microsoft .Win32 ;
using System .IO ;
using System .Resources ;
using System .Xml ;
using System .Net .Sockets;
using System .Net .NetworkInformation ;
using System .Collections .Generic;

namespace P_F_Interface
{
	/// <summary>
	/// Description of ExampleClass.
	/// </summary>
	public class ExampleClass
	{
		public int ID {get ; set ;}
		public string Name{get ;set ;}
		public string CardID {get ;set; }
		public InforClass msgclass{get ;set ;}
		public ExampleClass(int index )
		{
			this .ID =index ;
		}
	}
	public class InforClass
	{
		public int ID{get ;set ;}
		public string Name{get ;set ;}
		
	}
}
