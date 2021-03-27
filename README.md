# Cabother-Exceptions

Biblioteca de apoio ao uso de exceptions customizadas

## Nuget
```
https://www.nuget.org/packages/Cabother.Exceptions/
```
## Lista de Exceptions

| Nome da Exception                   | Descrição                                               | Mensagem do Usuário                                      |
| ----------------------------------- | ------------------------------------------------------- | -------------------------------------------------------- |
| ConfigurationNotFoundException      | Solicitado uma configuração, e esta não é encontrada    | Configuration key '{configurationKey}' not found         |
| EnvironmentVariableInvalidException | Solicitado o valor de uma ENV, e esta não é encontrada  | Environment variable '{variableName}' don't parametrized |
| EntityNotFoundException             | Entidade não encontrada no banco de dados               | {personalErrorCode} - {personalMessage}                  |
| MySqlDatabaseException              | Exceção interna em banco de dados do tipo MySql         | {personalMessage}                                        |
| OracleDatabaseException             | Exceção interna em banco de dados do tipo Oracle        | {personalMessage}                                        |
| RepositoryNotFoundException         | Repositório não é encontrado no banco de dados          | Not found {entity}'s repository                          |
| BadGatewayException                 | Servidor recebe uma resposta ruim de outro              | {personalMessage}                                        |
| BadRequestException                 | Servidor não pode ou não irá processar a requisição     | {personalMessage}                                        |
| ConflictException                   | Servidor já recebeu a mesma requisição                  | {personalMessage}                                        |
| ForbiddenException                  | Servidor entendeu o pedido, mas se recusa a autorizá-lo | {personalMessage}                                        |
| GatewayTimeoutException             | Quando não é possível completar a solicitação           | {personalMessage}                                        |
| InternalServerErrorException        | Quando houver error interno no processamento da request | {personalMessage}                                        |
| PreconditionFailedException         | Condição definida no cabeçalho da request não atendida  | {personalMessage}                                        |
| UnexpectedResponseException         | Condição não atendida para processar regra de negócio   | {personalMessage}                                        |
| WebServiceException                 | Erro no processamento de chamadas para web services     | {personalMessage}                                        |

