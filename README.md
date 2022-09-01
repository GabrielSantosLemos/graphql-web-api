# Por que você precisa do GraphQL?

Menos viagens de ida e volta ao servidor – O GraphQL requer menos viagens de ida e volta, ou seja, menos chamadas de ida e volta para o servidor para obter todos os dados de que você precisa.

Sem over-fetching ou under-fetching – Ao contrário do REST, você nunca terá poucos ou muitos dados ao usar o GraphQL, pois pode especificar todas as informações necessárias da API antecipadamente.

Sem problemas de versionamento – O GraphQL não precisa de versionamento e, se você não remover os campos dos tipos, os clientes ou consumidores da API não serão interrompidos.

Largura de banda reduzida – o GraphQL geralmente requer menos solicitações e menos largura de banda. Você pode obter todos os dados necessários usando uma única chamada de API para o endpoint da API. Como você pode especificar os dados necessários, em vez de recuperar todos os campos de um tipo, você pode recuperar apenas os necessários, reduzindo assim a largura de banda e o uso de recursos.

Documentação – O GraphQL é adepto da criação de documentação de endpoints GraphQL, assim como o Swagger faz para endpoints REST.

Apesar de todas as vantagens que o GraphQL tem a oferecer, também existem algumas desvantagens. O GraphQL é complexo e é difícil implementar o cache ou a limitação de taxa no GraphQL do que no REST.

# Como funciona uma consulta GraphQL?

Cada consulta do GraphQL passa por três fases: análise, validação e execução. Na fase de análise, a consulta do GraphQL é tokenizada e analisada em uma representação conhecida como árvore de sintaxe abstrata. Na fase de validação, a consulta gráfica é validada em relação ao esquema.

![Graphql Execution Engine](./documents/graphql-execution-engine.png =600x)

Por fim, na fase de execução, o runtime do GraphQL percorre a árvore de sintaxe abstrata da raiz da árvore, recupera e agrega os resultados e envia os dados de volta ao cliente GraphQL como JSON.

# GraphQL vs. REST

Dê uma olhada rápida nas diferenças entre GraphQL e REST:

 - Ao contrário do REST, que pode precisar de várias chamadas de API para obter os dados desejados, o GraphQL expõe apenas um endpoint que você pode usar para obter as informações necessárias.
 - REST só funciona com HTTP, enquanto o GraphQL não precisa de HTTP.
 - Ao contrário do REST, que permite usar qualquer verbo HTTP, o GraphQL permite que você use apenas o verbo HTTP POST.
 - No REST, a API especifica a solicitação e a resposta. Pelo contrário, no GraphQL, a API define os recursos acessíveis, e os clientes ou consumidores podem solicitar exatamente os dados que precisam da API.
 - Ao trabalhar com REST, o servidor determina o tamanho do recurso. Pelo contrário, com o GraphQL, a API especifica os recursos acessíveis e o cliente solicita exatamente o que precisa.
 - REST e GraphQL são plataforma e linguagem neutra, e ambos podem retornar dados JSON.

# Objetivos do GraphQL: qual problema ele resolve?

Existem várias desvantagens do REST:

 - Busca excessiva – isso implica que sua API REST envia mais dados do que você precisa
 - Busca insuficiente – isso implica que sua API REST envia menos dados do que você precisa
 - Várias solicitações – exigindo várias solicitações para obter os dados de que você precisa
 - Várias viagens de ida e volta – várias solicitações necessárias para concluir uma execução antes que você possa prosseguir

A busca excessiva e a busca insuficiente são dois dos problemas comuns que você encontraria com frequência ao trabalhar com APIs REST. Isso é explicado com mais detalhes na próxima seção.

# Explicação do problema da sub-busca e da sobre-busca

Aqui está um exemplo típico de endpoints REST para um aplicativo típico que gerencia postagens de blog.

- GET /blogposts
- GET /blogposts/{blogPostId}
- GET /authors
- GET /authors/{authorId}

Para agregar os dados, você terá que fazer várias chamadas para os endpoints mostrados aqui. Observe que uma solicitação para o ponto de extremidade /blogposts buscaria a lista de postagens do blog junto com authorId, mas não retornaria dados do autor. Você precisa fazer uma chamada para /authors/{authorId} várias vezes para obter detalhes do autor dos autores. Esse problema é conhecido como busca insuficiente, pois a carga útil da API contém menos dados do que você precisa. Você pode aproveitar o Backend for Frontend ou o padrão Gateway Aggregation para resolver esse problema. Ainda assim, em ambos os casos, você precisará de várias chamadas para os endpoints da API.

Pelo contrário, sua carga útil da API também pode ser muito detalhada. Por exemplo, você pode querer saber apenas os detalhes das postagens do blog chamando o ponto de extremidade /blogposts, mas sua carga também conterá authorId. Esse problema é conhecido como over-fetching, o que implica que a carga útil da API contém mais dados do que você precisa, consumindo mais largura de banda da rede. É aqui que o GraphQL vem em socorro.