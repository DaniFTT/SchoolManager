# SchoolManager

### Objetivo: 
Projeto de Gerenciamento Escolar básico, aonde é possivel cadastrar alunos e turmas, e relaciona-los entre si.

### Requisitos para rodar o projeto:

- Visual Studio 2022;
- SDK do .NET 6 e .NET 7 instaladas;
- SQL Server.

### Como rodar:

**1 - Primeiro será necessário a criação do Banco de Dados:**

```
CREATE DATABASE school_manager
```


Após isso, entre no banco de dados criado e rode o comando para a criação das tabelas

```
USE school_manager

CREATE TABLE aluno (
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(255) NOT NULL,
    usuario VARCHAR(45) NOT NULL,
    senha CHAR(60) NOT NULL
);

CREATE TABLE turma (
    id INT  PRIMARY KEY IDENTITY(1,1),
    curso_id int NOT NULL,
    turma VARCHAR(45) UNIQUE NOT NULL,
    ano int NOT NULL
);

CREATE TABLE aluno_turma (
    aluno_id INT,
    turma_id INT,
    CONSTRAINT aluno_id FOREIGN KEY (aluno_id) REFERENCES aluno(id) ON DELETE CASCADE,
    CONSTRAINT turma_id FOREIGN KEY (turma_id) REFERENCES turma(id) ON DELETE CASCADE
);
```

**2 -  Feito isso basta clonar o projeto em uma pasta de sua preferência, com o seguinte comando:**

```
git clone https://github.com/DaniFTT/SchoolManager.git
```

**3 - Abra a pasta onde voce realizou o clone, e abra Solution do projeto "SchoolManager.sln": **


![image](https://github.com/DaniFTT/SchoolManager/assets/64164438/46f15034-3c77-438a-addc-8b1d24dce22d)

**4 - Com o projeto aberto no seu VS2022, entre na camada "2 - API" e acesse o Arquivo "appsettings.Development.Json"**

![image](https://github.com/DaniFTT/SchoolManager/assets/64164438/a3e9858a-8839-4dd3-ab87-888e7e351c5e)

Nesse arquivo você deverá configurar sua string de conexão para do SQL Server que você usou para a criação do Banco de Dados.

Exemplo:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "SqlServer": "Server=localhost;Database=school_manager;User Id=sa;Password={YourPassword}"
  }
}
```

Substituindo o {YourPassword}, pela sua senha do usuário "sa";

**5 - Agora para rodar o projeto, será necessário colocar ambos os projetos **SchoolManager.WebUI** , quando o **SchoolManager.WebApi** para executarem juntos, para que tanto a Api quanto o Front funcionem simultaneamente:**

![image](https://github.com/DaniFTT/SchoolManager/assets/64164438/056151b7-2f81-4826-b46f-b28e139a5a02)

![image](https://github.com/DaniFTT/SchoolManager/assets/64164438/6c963c97-65ad-4e16-9430-e8193648e416)

**6 - Após isso, basta clicar em **Start** para rodar os dois projetos, veja como no video a seguir:**


https://github.com/DaniFTT/SchoolManager/assets/64164438/36311d98-20ad-4f75-a0ce-7264bc1a50a6



### Prévia do projeto:

Veja uma prévia do projeto no video a seguir:



https://github.com/DaniFTT/SchoolManager/assets/64164438/895532df-6f1b-4397-8148-5f63670dbd59

