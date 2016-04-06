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
+ 1 Verificar quais tags sofrerão parsing no html da página.

+ 2 Implementar o método ExtractNoticias.
  - Escrever a configuração do XPath para parsing das notícias.
  - Iterar sobre a coleção de nós retornadas da chamada de método, afim pegar as duas útimas notícias.
  - Retornar um List<Informacoes> contendo as informações requisitadas.
+ 3 Implementar o método ExtractInformacoesInstitucionais.
  - Escrever a 
  



Atividade Prática Supervisionada <br/>
Disciplina:Linguagem de Progamação <br/>
Curso: Ciência da Computação - UTFPR-CM
