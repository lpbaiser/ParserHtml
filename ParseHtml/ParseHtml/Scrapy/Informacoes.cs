using System;

namespace ParseHtml{
	public class Informacoes{

		private String titulo;
		private String texto;
		private String link;

		public Informacoes (){}


		public string Titulo {
			get {
				return this.titulo;
			}
			set {
				titulo = value;
			}
		}

		public string Texto {
			get {
				return this.texto;
			}
			set {
				texto = value;
			}
		}

		public string Link {
			get {
				return this.link;
			}
			set {
				link = value;
			}
		}

	}
}

