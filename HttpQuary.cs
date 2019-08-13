/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/3/19
 * Time: 17:01
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
using System .Text ;
using Microsoft .Win32 ;
using System .IO ;
using System .Xml ;
using System .Net .Sockets;
using System .Net .NetworkInformation ;
using System .Collections .Generic;
using System.Collections;
namespace P_F_Interface
{
	/// <summary>
	/// Description of HttpQuary.   创建Get请求
	/// </summary>
	public class HttpQuary
	{
		private  string Uristr;
		public string  URIStr
		{
			get {return Uristr ;}
		}
		private string jsonstr;
		public string JsonStr
		{
			get {return jsonstr ;}
		}
		public HttpQuary(string uristr)
		{
			if (uristr.Trim () =="")
			{
				MessageBox .Show ("请输入地址!");
				return ;
			}
			else 
			{
			this .Uristr =uristr ;
			jsonstr =CreatHttpGet ();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		string  CreatHttpGet()
		{
			string str="";
			// 创建一个HTTP请求
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(Uristr);
		    request.Method="GET";	
		    request .ContentType ="application /json;charset=UTF-8";
		    request .AutomaticDecompression =DecompressionMethods .GZip ;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		    Stream 	s = response.GetResponseStream();
		    StreamReader readstr=new StreamReader (s ,Encoding.UTF8);
		    str=readstr.ReadToEnd(); 
			readstr .Close ();
			s .Close();
			if (request !=null )
			{
				request .Abort ();
			}
			if (response !=null )
			{
				response .Close ();
			}
			return str ;
		}
		/// <summary>
		/// POST发送请求方式
		/// </summary>
		string  CreatePostHttp()
		{
			if (Uristr =="")
			{
				MessageBox .Show ("请输入地址");
				//return ;
			}
			string strURL = this .Uristr ;
			System.Net.HttpWebRequest request;
			request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
			//Post请求方式
			request.Method="POST";
			// 内容类型
			request.ContentType="application/x-www-form-urlencoded";
			// 参数经过URL编码
			string paraUrlCoded = System.Web.HttpUtility.UrlEncode("keyword");
			paraUrlCoded += "=" + System.Web.HttpUtility.UrlEncode(this.Uristr .Trim ());
			byte[] payload;
			//将URL编码后的字符串转化为字节
			payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
			//设置请求的 ContentLength 
			request.ContentLength = payload.Length;
			//获得请 求流
			Stream writer = request.GetRequestStream();
			//将请求参数写入流
			writer.Write(payload,0,payload.Length);
			// 关闭请求流
			writer.Close();
			System.Net.HttpWebResponse response;
			// 获得响应流
			response = (System.Net.HttpWebResponse)request.GetResponse();
	
			Stream s = response.GetResponseStream();
		    StreamReader readstr=new StreamReader (s );
		    string str=readstr.ReadToEnd() ;
		  // msgreceived .Items .Add (str );
		    if (request !=null )
			{
				request .Abort ();
			}
			if (response !=null )
			{
				response .Close ();
			}
			return str ;
			
		
            //* 何问起 hovertree.com */
		}
		
	}
}
