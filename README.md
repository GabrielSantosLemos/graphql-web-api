# Por que voc� precisa do GraphQL?

Menos viagens de ida e volta ao servidor � O GraphQL requer menos viagens de ida e volta, ou seja, menos chamadas de ida e volta para o servidor para obter todos os dados de que voc� precisa.

Sem over-fetching ou under-fetching � Ao contr�rio do REST, voc� nunca ter� poucos ou muitos dados ao usar o GraphQL, pois pode especificar todas as informa��es necess�rias da API antecipadamente.

Sem problemas de versionamento � O GraphQL n�o precisa de versionamento e, se voc� n�o remover os campos dos tipos, os clientes ou consumidores da API n�o ser�o interrompidos.

Largura de banda reduzida � o GraphQL geralmente requer menos solicita��es e menos largura de banda. Voc� pode obter todos os dados necess�rios usando uma �nica chamada de API para o endpoint da API. Como voc� pode especificar os dados necess�rios, em vez de recuperar todos os campos de um tipo, voc� pode recuperar apenas os necess�rios, reduzindo assim a largura de banda e o uso de recursos.

Documenta��o � O GraphQL � adepto da cria��o de documenta��o de endpoints GraphQL, assim como o Swagger faz para endpoints REST.

Apesar de todas as vantagens que o GraphQL tem a oferecer, tamb�m existem algumas desvantagens. O GraphQL � complexo e � dif�cil implementar o cache ou a limita��o de taxa no GraphQL do que no REST.

# Como funciona uma consulta GraphQL?

Cada consulta do GraphQL passa por tr�s fases: an�lise, valida��o e execu��o. Na fase de an�lise, a consulta do GraphQL � tokenizada e analisada em uma representa��o conhecida como �rvore de sintaxe abstrata. Na fase de valida��o, a consulta gr�fica � validada em rela��o ao esquema.

![Graphql Execution Engine](./documents/graphql-execution-engine.png =600x)

Por fim, na fase de execu��o, o runtime do GraphQL percorre a �rvore de sintaxe abstrata da raiz da �rvore, recupera e agrega os resultados e envia os dados de volta ao cliente GraphQL como JSON.

# GraphQL vs. REST

D� uma olhada r�pida nas diferen�as entre GraphQL e REST:

 - Ao contr�rio do REST, que pode precisar de v�rias chamadas de API para obter os dados desejados, o GraphQL exp�e apenas um endpoint que voc� pode usar para obter as informa��es necess�rias.
 - REST s� funciona com HTTP, enquanto o GraphQL n�o precisa de HTTP.
 - Ao contr�rio do REST, que permite usar qualquer verbo HTTP, o GraphQL permite que voc� use apenas o verbo HTTP POST.
 - No REST, a API especifica a solicita��o e a resposta. Pelo contr�rio, no GraphQL, a API define os recursos acess�veis, e os clientes ou consumidores podem solicitar exatamente os dados que precisam da API.
 - Ao trabalhar com REST, o servidor determina o tamanho do recurso. Pelo contr�rio, com o GraphQL, a API especifica os recursos acess�veis e o cliente solicita exatamente o que precisa.
 - REST e GraphQL s�o plataforma e linguagem neutra, e ambos podem retornar dados JSON.

# Objetivos do GraphQL: qual problema ele resolve?

Existem v�rias desvantagens do REST:

 - Busca excessiva � isso implica que sua API REST envia mais dados do que voc� precisa
 - Busca insuficiente � isso implica que sua API REST envia menos dados do que voc� precisa
 - V�rias solicita��es � exigindo v�rias solicita��es para obter os dados de que voc� precisa
 - V�rias viagens de ida e volta � v�rias solicita��es necess�rias para concluir uma execu��o antes que voc� possa prosseguir

A busca excessiva e a busca insuficiente s�o dois dos problemas comuns que voc� encontraria com frequ�ncia ao trabalhar com APIs REST. Isso � explicado com mais detalhes na pr�xima se��o.

# Explica��o do problema da sub-busca e da sobre-busca

Aqui est� um exemplo t�pico de endpoints REST para um aplicativo t�pico que gerencia postagens de blog.

- GET /blogposts
- GET /blogposts/{blogPostId}
- GET /authors
- GET /authors/{authorId}

Para agregar os dados, voc� ter� que fazer v�rias chamadas para os endpoints mostrados aqui. Observe que uma solicita��o para o ponto de extremidade /blogposts buscaria a lista de postagens do blog junto com authorId, mas n�o retornaria dados do autor. Voc� precisa fazer uma chamada para /authors/{authorId} v�rias vezes para obter detalhes do autor dos autores. Esse problema � conhecido como busca insuficiente, pois a carga �til da API cont�m menos dados do que voc� precisa. Voc� pode aproveitar o Backend for Frontend ou o padr�o Gateway Aggregation para resolver esse problema. Ainda assim, em ambos os casos, voc� precisar� de v�rias chamadas para os endpoints da API.

Pelo contr�rio, sua carga �til da API tamb�m pode ser muito detalhada. Por exemplo, voc� pode querer saber apenas os detalhes das postagens do blog chamando o ponto de extremidade /blogposts, mas sua carga tamb�m conter� authorId. Esse problema � conhecido como over-fetching, o que implica que a carga �til da API cont�m mais dados do que voc� precisa, consumindo mais largura de banda da rede. � aqui que o GraphQL vem em socorro.