# 🛍️ Product Manager - Gestão de Produtos

## 📌 Sobre o Projeto

Aplicação fullstack desenvolvida para gerenciamento de produtos de uma loja, permitindo realizar operações de cadastro, listagem, edição e exclusão.

---

## 🚀 Tecnologias Utilizadas

### 🔹 Back-end

* C#
* ASP.NET Core Web API (.NET 6+)
* Entity Framework Core
* SQLite

### 🔹 Front-end

* Angular (Standalone Components)
* Angular Material

---

## ▶️ Como Executar o Projeto
### Primeiro o Back-end

1. Acesse a pasta do projeto:

```bash
cd backend
```

2. Instale dependências:

```bash
dotnet restore
```

3. Execute migrations:

```bash
dotnet ef database update
```

4. Rode a API:

```bash
dotnet run
```

### Agora o Front-end. 

1. Abra outro terminal

2. Acesse a pasta:

```bash
cd frontend
```

3. Instale dependências:

```bash
npm install
```

4. Execute:

```bash
ng serve
```

5. Acesse:

```
http://localhost:4200
```

## ⚙️ Funcionalidades

### 📦 Produtos

* ✅ Listar produtos com paginação
* ✅ Criar produto
* ✅ Editar produto
* ✅ Excluir produto
* ✅ Visualizar detalhes

### 🎯 Regras de Negócio

* ❌ Não permite estoque negativo
* ❌ Produtos da categoria **Eletrônicos** devem ter preço mínimo de R$ 50,00
* ❌ SKU único (não permite duplicidade)

---

## 🧠 Diferenciais

* Uso de **DTOs** para separar entidade e API
* Implementação de **logs** no back-end
* Interface com **Angular Material**
* Uso de **modais** para criação e edição
* Validação no **front-end e back-end**

---

## 🗂️ Estrutura do Projeto

```
ProductManager/
│
├── backend/
│   ├── Controllers
│   ├── Application
│   ├── Domain
│   ├── Infrastructure
│
├── frontend/
│   ├── src/app
│   ├── components
│   ├── services
```

---

---

## 📡 Endpoints Principais

| Método | Endpoint           | Descrição         |
| ------ | ------------------ | ----------------- |
| GET    | /api/produtos      | Listar produtos   |
| GET    | /api/produtos/{id} | Obter produto     |
| POST   | /api/produtos      | Criar produto     |
| PUT    | /api/produtos/{id} | Atualizar produto |
| DELETE | /api/produtos/{id} | Remover produto   |

---

## 🧪 Observações

* O projeto utiliza SQLite para facilitar a execução local.
* A API retorna respostas adequadas para erros de validação.
* O front-end consome a API via HTTP e trata erros exibindo mensagens ao usuário.

---

## 👩‍💻 Autor

Desenvolvido por **Lais Rangel**
🔗 GitHub: https://github.com/lais-telles

---

## 📌 Considerações Finais

Este projeto foi desenvolvido como parte de um processo seletivo, buscando demonstrar boas práticas de desenvolvimento, organização e clareza na implementação.
