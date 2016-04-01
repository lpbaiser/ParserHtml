using System;
using System.Net;
using HtmlAgilityPack;

namespace ParseHtml{
	class MainClass{


		public static void Main(string[] args){


			ParseHtml p = new ParseHtml ();
			Console.WriteLine ("====== Últimas duas Notícias ======");
			p.printInformacoes (p.extractNoticias());
			Console.WriteLine ("");
			Console.WriteLine ("====== Últimas três Informações Institucionais ======");
			p.printInformacoes (p.extractInformacoesInstitucionais());
			Console.WriteLine ("");
			Console.WriteLine ("====== Apresentação do Campus ======");
			p.extractTextoApresentacao ();
			Console.WriteLine ("");
			Console.WriteLine ("====== Endereço do Campus ======");
			p.extractFooter ();
			Console.WriteLine ("");
		}
	}
}
