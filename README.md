##ParserHtml
Parser do site http://www.utfpr.edu.br/campomourao em C#

Parser de algumas tags do site da UTFPR utilizando a biblioteca Html Agility Pack disponível em: https://htmlagilitypack.codeplex.com/


####Requisitos
+ As últimas 2 notícias (coluna do meio) (Título, texto (subpágina) e data de publicação/atualização de cada uma (subpágina));
+ As três últimas informações institucionais (coluna da direita) (título, texto (subpágina) e link para a informação);
+ Texto de apresentação que está dentro do link "O CÂMPUS";
+ Endereço completo do câmpus (rodapé).

#####Ferramentas e bibliotecas utilizadas

Neste programa utilizamos a linguagem de programação C# com o compilador mono, para construir o XPath da página nós utilizamos a biblioteca HtmlAgilityPack.

#####Passos
+ 1 Verificar quais tags vão sofrer parsing no html da página.

+ 2 Implementar o método ExtractNoticias.
  - Escrever a configuração do XPath para parsing das notícias.
  - Iterar sobre a coleção de nós retornadas da chamada de método, afim de pegar as duas útimas notícias.
  - Retornar um List<Informacoes> contendo as informações requisitadas.
+ 3 Implementar o método ExtractInformacoesInstitucionais.
  - Escrever a configuração do XPath para parsing das informações institucionais.
  - Iterar sobre a coleção de nós retornados da chamada de método, afim de pegar as três últimas notícias.
  - Retornar um List<Informacao> contenrdo as informações requisitadas.
+ 4 Implementar o método ExtractTextoApresentacao 
  - Escrever a configuração do XPath para parsing do texto e link onde se encontra o texto de apresentação.
  - Carregar o html da outra página com base no link.
  - Pegar o texto de apresentação e imprimir.
+ 5 Implementar o método ExtractFooter
  - Escrever a configuração do XPath para parsing dos dados no rodapé da página.
  - Imprimir os dados de endereço do rodapé.
  



Atividade Prática Supervisionada <br/>
Disciplina:Linguagem de Progamação <br/>
Curso: Ciência da Computação - UTFPR-CM
