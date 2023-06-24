# SchoolManager

### Objetivo: 
Projeto de Gerenciamento Escolar básico, aonde é possivel cadastrar alunos e turmas, e relaciona-los entre si.

## Como rodar:

Primeiro será necessário a criação do Banco de Dados:

CREATE DATABASE school_manager


Após isso, entre no banco de dados criado e rode o comando para a criação das tabelas


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

