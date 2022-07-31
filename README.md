# Receita
Esse projeto tem como finalidade a criação de uma portal de receitas para treinamento de novas tecnologias lançadas, sempre tentaremos atualizar o sistema com alguma nova 
tecnologia ou afins no nosso projeto.

<b>O que temos até o momento no nosso projeto :</b>

<br> > .Net 5 (Será feito update para .net 7 mais a frente).
<br> > Web Api como nosso serviço de back end.
<br> > Test (Até o momento está cobrindo o básico da web api, será adicionado o test de unidade da api nos próximos passos).
<br> > FluentValidation para validação básica de dados. 
<br> > Middleware básico para autenticação com jwt.
<br> > Swagger.
<br> > Docker.
 
 
<b>Proximos passos :</b>
 <br>> Implementar a camada de domain para conter as regras de negocio.
 <br>> Inclusão de EventBus com RabbitMq ou Azure ServiceBus para permitir o cadastro de receitas assicronamente.
 <br>> Inclusão de unit of work para melhor gereciamento e garantia de nossas transações sincronas.
 <br>> Inclusão de cache redis para melhor leitura das receitas.
 <br>> Inclusão de Polly para nos ajudar na implementação do circuit breaker.
 <br>> Avaliar a implementação de GraphQL. 
 <br>> Incluir log serilog (analisar o melhor sink para o nosso cenário).
 <br>> Ao final migrar a arquitetura para um formato distribuido (microserviços), assim implementar.
 <br>> Incluir api Gateway (Ocelot ou Kong Gateway).
 <br>> Avaliar a implementação de CQRS após distribuido.
 <br>> Ao processo de migração implementar a observabilidade (Tracing(Elastic apm), Logging(Elastic) e metricas(Kibana ou prometheus etc)).


