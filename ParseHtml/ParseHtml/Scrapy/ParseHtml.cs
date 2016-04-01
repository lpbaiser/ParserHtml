using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace ParseHtml{
	public class ParseHtml{
		HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument ();

		List<Informacoes> informacoes = new List<Informacoes> ();

		public ParseHtml ()
		{
			html.LoadHtml (new WebClient ().DownloadString ("http://www.utfpr.edu.br/campomourao")); 
		}

		/// <summary>
		/// Extrai noticias da página.
		/// </summary>
		/// <returns>As duas últimas noticias.</returns>
		public List<Informacoes> extractNoticias(){

			HtmlAgilityPack.HtmlDocument htmlTexto = new HtmlAgilityPack.HtmlDocument ();

			var titulos = html.DocumentNode.SelectNodes ("//div[@class='column-block block_1  collage-first-object']" +
			    "//div[@class='collage-item collage_item_1 collage_type_topic collage_view_summary']" +
			    "//div[@class='standard-topic']"+			                                            
				"//div [@class='tileItem visualIEFloatFix']" +
				"//h3[@class='tileHeadline']//a[@href]");

			if (titulos != null) {
				for (int i = titulos.Count-1; i>=titulos.Count-2; i--) {
					Informacoes info = new Informacoes ();
					info.Titulo = titulos [i].InnerText;
					string url = titulos [i].Attributes ["href"].Value;
					htmlTexto.LoadHtml (new WebClient ().DownloadString (url));
					var tagTexto1 = htmlTexto.DocumentNode.SelectSingleNode ("//div[@id='parent-fieldname-description']");
					var tagTexto2 = htmlTexto.DocumentNode.SelectSingleNode ("//div[@id='parent-fieldname-text']//p");
					info.Texto = String.Concat(tagTexto1.InnerText, tagTexto2.InnerText);
					info.Link = url;
					informacoes.Add (info);
				}
			} else {
				return null;
			}
			return informacoes;
		}

		/// <summary>
		/// Extrai informacoes institucionais da pagina.
		/// </summary>
		/// <returns>As três últimas informacoes institucionais.</returns>
		/// Navega para a outra pagina do link correspondente e extrai o texto
		public List<Informacoes> extractInformacoesInstitucionais(){

			HtmlAgilityPack.HtmlDocument htmlTexto = new HtmlAgilityPack.HtmlDocument ();

			var titulos = html.DocumentNode.SelectNodes ("//div[@class='column-block block_2 collage-last-object ']" +
			                                             "//div[@class='collage-item collage_item_1 collage_type_topic collage_view_summary']" +
			                                             "//div[@class='standard-topic']"+			                                            
			                                             "//div [@class='tileItem visualIEFloatFix']" +
			                                             "//h3[@class='tileHeadline']//a[@href]");

			if (titulos != null) {
				for (int i = titulos.Count-1; i>=titulos.Count-3; i--) {
					Informacoes info = new Informacoes ();
					info.Titulo = titulos [i].InnerText;
					string url = titulos [i].Attributes ["href"].Value;
					htmlTexto.LoadHtml (new WebClient ().DownloadString (url));
					var tagTexto = htmlTexto.DocumentNode.SelectSingleNode ("//div[@id='parent-fieldname-text']//p");
					info.Texto = tagTexto.InnerText;
					info.Link = url;
					informacoes.Add (info);
				}
			} else {
				return null;
			}
			return informacoes;
		}

		/// <summary>
		/// Este método procura pelo link da pagina que mostra o texto de apresentação do campus,
		/// navega até ele e imprime o texto correspondente.
		/// </summary>
		public void extractTextoApresentacao(){
			HtmlAgilityPack.HtmlDocument htmlCampus = new HtmlAgilityPack.HtmlDocument ();
			var tag = html.DocumentNode.SelectSingleNode ("//li[@class='navTreeItem visualNoMarker navTreeFolderish section-o-campus'] //a[@href]");
			if (tag != null) {
				string urlCampus = tag.Attributes ["href"].Value;
				htmlCampus.LoadHtml (new WebClient ().DownloadString (urlCampus));
				var tagTexto = htmlCampus.DocumentNode.SelectNodes ("//div[@id='content-core']//p");

				if (tagTexto != null) {
					Console.WriteLine (tagTexto [1].InnerText);
				}
			} else {
				Console.WriteLine ("Tag de texto de apresentaçao não encontrada!");
			}
		}

		/// <summary>Este método extrai as informações de endereço contidas no rodapé da página </summary>
		public void extractFooter(){
			var tags = html.DocumentNode.SelectNodes ("//div[@id='portal-footer']//p");
			if (tags != null) {
				foreach (var link in tags) {
					Console.WriteLine (link.InnerText);
				}
			} else {
				Console.WriteLine ("Tag de rodapé não encontrada!");
			}
		}

		/// <summary>
		/// Imprimi as informacoes.
		/// </summary>
		public void printInformacoes(List<Informacoes> informacoes){
			if (informacoes != null) {
				for (int i = informacoes.Count-1; i>=0; i--) {
					Console.WriteLine ("Titulo: {0}\n", informacoes [i].Titulo);	
					Console.WriteLine ("Texto: {0}\n", informacoes [i].Texto);	
					Console.WriteLine ("Link: {0}\n", informacoes [i].Link);	
				} 
			} else {
				Console.WriteLine ("Tags de informações não encontras!");
			}
		}
	}
}

