# Passo a Passo para configuração de uma API em C#

## Requisitos

- Ter instalado em sua máquina um editor de código (VSCode ou Visual Studio Code)
- Ter instalado em sua máquina o pacote de desenvolvimento <a href="https://dotnet.microsoft.com/en-us/download" target="_blank">.NET</a>
- Ter instalado em sua máquina um banco de dados (SQL Server, PostgreSQL, MySQL)
- **Obs.:** Usados nesse projeto:
  - <a href="https://code.visualstudio.com/download" target="_blank">VSCode</a>
  - <a href="https://www.microsoft.com/pt-br/sql-server/sql-server-downloads" target="_blank">SQL Sever</a>

## Preparação do ambiente

- **Passo 1**: Inicie a aplicação dotnet com o seguinte comando `dotnet new webapi`
- **Passo 2:** Para visualizar o projeto em seu navegador, com o Swagger, use o seguinte comando `dotnet watch run`
- **Passo 3:** Instale de forma global o Entity Framework com o seguinte comando `dotnet tool install --global dotnet-ef`
- **Passo 4:** Inicie o Entity Framework no seu projeto com o comando `dotnet add package Microsoft.EntityFrameworkCore.{seuservidor}`
- **Passo 5:** Inicie também o pacote Design do Entity Framework `dotnet add package Microsoft.EntityFrameworkCore.Design`

## Preparando o banco de dados

- **Passo 1:** Crie suas models na pasta model de acordo com os dados que você usará no DataBase(DB).
- **Passo 2:** Crie sua pasta Context, onde ficarão seus códigos construtores do DB
- **Passo 3:** No arquivo _appsettings.Development.json_ configure o comando para iniciar suas migrations: 
    ```
    "ConnectionStrings": {
        "ConexaoPadrao": "Server=localhost\\sqlexpress; Initial Catalog={seucontext}Mvc; Integrated Security=True"
    }        
    ```
- **Passo 4:** No arquivo _Program.cs_ abaixo do comentário _Add services to the container._ configure o seguinte comando:
    ```
    builder.Services.AddDbContext<{seucontext}>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
    ```
- **Passo 5:** Crie agora suas migrations de acordo com a model que você criou. Use o comando `dotnet ef migrations add {nomeDaMigration}`
- **Passo 6:** Com a pasta migration criada agora crie os dados no seu DB com o seguinte comando `dotnet ef database update`

## Resumo da programação

- **Passo 1:** Crie sua **CONTROLLER** para gerenciar seu CRUD
- **Passo 2:** A cada método http criado, teste seu funcionamento no Swagger
- **Passo 3:** Repetir os passos acima de acordo com o CRUD necessário para sua API

Para conhecer um projeto MVC em .NET <a href="https://github.com/PkMs7/introducao-MVC-CSharp" target="_blank">clique aqui</a>.