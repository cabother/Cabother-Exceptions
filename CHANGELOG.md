# Changelog

Todas as mudanças deste projeto serão documentadas neste arquivo.

O formato é baseado no [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
e o projeto está aderente ao [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [v1.1.0]("https://github.com/cabother/Cabother-Exceptions/releases/tag/v1.1.0")
- `feat: suporte multi-target para netstandard2.0, net8.0 e net10.0 (mantém compatibilidade com projetos net5.0+ e .NET Framework 4.6.1+)`
- `feat: adicionadas exceções de requisição NotFoundException (404), RequestTimeoutException (408), UnprocessableEntityException (422), TooManyRequestsException (429, com RetryAfter) e ServiceUnavailableException (503)`
- `feat: adicionada ValidationException com erros agrupados por campo`
- `feat: adicionada BusinessRuleException para violações de regra de negócio`
- `feat: adicionadas EntityAlreadyExistsException e ConcurrencyException para cenários de banco de dados`
- `feat: adicionada InvalidConfigurationException para configurações com valor inválido`
- `feat: geração da documentação XML no pacote NuGet`
- `chore: atualizados pacotes dos projetos de teste e testes para as novas exceções`
- `fix: corrigida referência na documentação do UnauthorizedException`
- `docs: README atualizado com compatibilidade, novas exceções e exemplos de uso`

## [v1.0.4]("https://github.com/cabother/Cabother-Exceptions/releases/tag/v1.0.4")
- `feat: removido método duplicado de conversão de exceptions`
  
## [v1.0.3]("https://github.com/cabother/Cabother-Exceptions/releases/tag/v1.0.3")
- `feat: extensões para facilitar a conversão`
- `feat: adicionado arquivo CHANGELOG.md`
- `feat: criação e uso da classe base para as exceções`