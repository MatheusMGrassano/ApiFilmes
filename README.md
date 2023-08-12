# Api Filmes 

### Tópicos 

[Descrição do projeto](#descrição-do-projeto)

[Recursos](#recursos)

[Pré-requisitos](#pré-requisitos)

[Como rodar a aplicação](#como-rodar-a-aplicação)

[Como rodar os testes](#como-rodar-os-testes)

[Bibliotecas e ferramentas](#bibliotecas-e-ferramentas)


## Descrição do projeto 

Projeto prático da criação de uma API RESTful em C# para interação com banco de dados SQL Server que armazena dados de filmes, como: título, data de lançamento etc.

O objetivo do projeto é criar uma API simples para consultar, criar, atualizar e deletar dados utilizando o formato JSON, através de requisições HTTP.


## Recursos

| Método | Rota            | Corpo da Requisição | Retorno     | Ação                    |
| ------ | --------------- | ------------------- | ----------- | ----------------------- |
| GET    | /api/Filme      |                     | Objeto JSON | Retorna todos os filmes |
| GET    | /api/Filme/{id} |                     | Objeto JSON | Retorna um filme        |
| POST   | /api/Filme      | Objeto JSON         | Objeto JSON | Registra um filme       |
| PUT    | /api/Filme      | Objeto JSON         | Objeto JSON | Altera um filme         |
| DELETE | /api/Filme      | Objeto JSON         | Objeto JSON | Exclui um filme         |

### Exemplo de Request Body
```
{
  "id": 0,
  "titulo": "string",
  "bilheteria": 0,
  "dataLancamento": "0001-01-01",
  "genero": "Acao"
}
```

### Exemplo de Response Body
```
{
  "data": {
    "id": 0,
    "titulo": "string",
    "bilheteria": 0,
    "dataLancamento": "0001-01-01",
    "genero": "Acao"
  },
  "message": "Mensagem de sucesso"
}
```


## Pré-requisitos

Para rodar a aplicação, é necessário possuir instaladas as seguintes ferramentas:

- [.NET 6.0](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0)
- [Microsoft SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)


## Como rodar a aplicação

No terminal, clone o projeto: 

```
git clone https://github.com/MatheusMGrassano/ApiFilmes
```

### Configurando a String de Conexão

Altere as credenciais de conexão com o banco de dados através do arquivo appsettings.json

Altere as configurações "Data Source" para o nome do servidor conectado no SQL Server e "Database" para um nome à sua escolha para o banco de dados que será criado.

**Exemplo de ConnectionString:**
```
  "ConnectionStrings": {
    "Default": "Data Source=NomeDoServidor;Database=NomeDoBancoDeDados;Trusted_connection=true;Encrypt=false;TrustServerCertificate=true"
  }
```

### Criando a migração de geração do Banco de Dados

No terminal, acesse a pasta raiz do projeto e digite os seguintes comandos:
```
dotnet tool install --global dotnet-ef
```

Crie a migração de geração do banco de dados:
```
dotnet ef migrations add DataBaseCreation
```

Aplique a migração criada no banco de dados:
```
dotnet ef database update
```

### Rodando a aplicação

No terminal, acesse a pasta do projeto e digite o comando: 
```
dotnet watch run
```

Após isso, automaticamente uma aba do navegador abrirá com a interface do Swagger UI, exibindo todas as opções de requisições disponíveis.


## Como rodar os testes

Os testes podem ser realizados da forma que for mais conveniente, utilizando aplicações externas como Postman ou Insomnia, mas, integrado ao projeto, já é disponibilizado uma ferramenta para testes das requisições.

A interface do Swagger UI será a aba do navegador que abrirá automaticamente ao rodar o projeto, contendo todos os recursos já disponíveis para testar, juntamente com exemplos dos Request Body e Response Body, além dos Schemas dos tipos utilizados na API. 


## Bibliotecas e ferramentas

- [Entity Framework Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/)
- [Entity Framework Core SQL Server](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)
- [Entity Framework Core Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)
- [Entity Framework Core Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design)
- [Swagger UI](https://swagger.io/tools/swagger-ui/)