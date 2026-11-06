# Cabother Exceptions

Biblioteca de apoio ao uso de exceptions customizadas

## Nuget
```
https://www.nuget.org/packages/Cabother.Exceptions/
```

```bash
dotnet add package Cabother.Exceptions
```

## Compatibilidade

O pacote é publicado com múltiplos targets, e cada projeto recebe automaticamente a versão mais adequada:

| Target           | Atende                                                  |
| ---------------- | ------------------------------------------------------- |
| `net10.0`        | .NET 10+                                                |
| `net8.0`         | .NET 8 e .NET 9                                         |
| `netstandard2.0` | .NET 5, 6 e 7, .NET Core 2.0+ e .NET Framework 4.6.1+   |

## Formato da mensagem

Todas as exceptions (exceto `WebServiceException`) herdam de `BaseException` e expõem a propriedade `ErrorCode`. A mensagem final segue o formato:

| Construtor utilizado                    | Mensagem gerada                                  |
| --------------------------------------- | ------------------------------------------------ |
| `(message)`                             | `{message}`                                      |
| `(message, errorCode)`                  | `{errorCode} - {message}`                        |
| `(message, innerException)`             | `{message}: {innerMessage}`                      |
| `(message, errorCode, innerException)`  | `{errorCode} - {message}: {innerMessage}`        |

## Lista de Exceptions

### Requests (`Cabother.Exceptions.Requests`)

| Nome da Exception            | HTTP | Descrição                                                  |
| ---------------------------- | ---- | ---------------------------------------------------------- |
| BadRequestException          | 400  | Servidor não pode ou não irá processar a requisição        |
| UnauthorizedException        | 401  | Requisição http não autorizada                             |
| ForbiddenException           | 403  | Servidor entendeu o pedido, mas se recusa a autorizá-lo    |
| NotFoundException            | 404  | Recurso solicitado não existe                              |
| RequestTimeoutException      | 408  | Requisição excedeu o tempo limite                          |
| ConflictException            | 409  | Requisição conflita com o estado atual do recurso          |
| PreconditionFailedException  | 412  | Condição definida no cabeçalho da request não atendida     |
| UnprocessableEntityException | 422  | Requisição válida, mas que não pode ser processada         |
| TooManyRequestsException     | 429  | Limite de requisições excedido (propriedade `RetryAfter`)  |
| InternalServerErrorException | 500  | Erro interno no processamento da request                   |
| BadGatewayException          | 502  | Servidor recebe uma resposta ruim de outro                 |
| ServiceUnavailableException  | 503  | Serviço temporariamente indisponível                       |
| GatewayTimeoutException      | 504  | Servidor upstream não respondeu a tempo                    |
| UnexpectedResponseException  | -    | Valor de uma resposta não é o esperado                     |

### Validações e domínio

| Nome da Exception     | Namespace                         | Descrição                                                   |
| --------------------- | --------------------------------- | ----------------------------------------------------------- |
| ValidationException   | `Cabother.Exceptions.Validations` | Dados de entrada inválidos, com erros por campo (`Errors`)  |
| BusinessRuleException | `Cabother.Exceptions.Domains`     | Violação de regra de negócio                                |

### Banco de dados (`Cabother.Exceptions.Databases`)

| Nome da Exception            | Descrição                                      | Mensagem padrão                          |
| ---------------------------- | ---------------------------------------------- | ---------------------------------------- |
| EntityNotFoundException      | Entidade não encontrada no banco de dados      | {entity} not found                       |
| EntityAlreadyExistsException | Entidade já existe (ex.: chave duplicada)      | {entity} already exists                  |
| ConcurrencyException         | Entidade alterada por outro processo           | {entity} was modified by another process |
| RepositoryNotFoundException  | Repositório da entidade não encontrado         | {entity}'s repository not found          |

### Configurações e ambiente

| Nome da Exception                  | Namespace                            | Mensagem padrão                                              |
| ---------------------------------- | ------------------------------------ | ------------------------------------------------------------ |
| ConfigurationNotFoundException     | `Cabother.Exceptions.Configurations` | Configuration key '{configurationKey}' not found.            |
| InvalidConfigurationException      | `Cabother.Exceptions.Configurations` | Configuration key '{configurationKey}' has an invalid value. |
| InvalidEnvironmentVariableException | `Cabother.Exceptions.Environments`  | Environment variable '{VARIABLENAME}' don't parametrized.    |

### Web services (`Cabother.Exceptions.WebServices`)

| Nome da Exception   | Descrição                                                                 |
| ------------------- | ------------------------------------------------------------------------- |
| WebServiceException | Erro em chamadas para web services (propriedades `Method` e `ErrorCode`)  |

## Exemplos de uso

```csharp
using Cabother.Exceptions.Databases;
using Cabother.Exceptions.Requests;
using Cabother.Exceptions.Validations;

// Mensagem com código de erro: "ORD-404 - Order 123 not found"
throw new NotFoundException("Order 123 not found", "ORD-404");

// Erros de validação agrupados por campo
throw new ValidationException(new Dictionary<string, string[]>
{
    ["Email"] = new[] { "Email is invalid" },
    ["Name"] = new[] { "Name is required" }
}, "VAL-001");

// Limite de requisições com tempo sugerido para nova tentativa
throw new TooManyRequestsException("Rate limit exceeded", "RL-001", TimeSpan.FromSeconds(30));

// Chave duplicada: "DB-001 - Customer already exists: {mensagem do erro original}"
catch (DbUpdateException ex)
{
    throw new EntityAlreadyExistsException("Customer", "DB-001", ex);
}
```

### Extensões

O namespace `Cabother.Exceptions.Extensions` oferece métodos para converter e enriquecer exceções:

```csharp
using Cabother.Exceptions.Extensions;

catch (Exception ex)
{
    ex.AddErrorCode("ERR-001");
    var code = ex.GetErrorCode();

    throw ex.ToInternalServerErrorException("ERR-500", "Failed to process order");
    // ou: ex.ToEntityNotFoundException("Order") / ex.ToConflictException("Order already processed")
}
```

<a href="https://www.buymeacoffee.com/cabother" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a> 
