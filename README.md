# Api do Sistema Curativo Vital

Esta documentação descreve as funcionalidades da API responsável por gerir o sistema Curativo Vital.
O sistema faz acompanhamento de lesões a partir de curativos e avaliações.

- A api tem como objetivo ser apresentada como projeto final de pós graduação.
- Front-end: [https://github.com/alessandravgs/ProjetoFinal](https://github.com/alessandravgs/curativos-vue)

## Informações de Contato

- **Nome:** Alessandra Gonçalves
- **Email:** alessandravgs0@gmail.com
- **GitHub:** [GitHub](https://github.com/alessandravgs)

## Como executar o projeto

- Baixar o código
- Abrir no visual studio
- Clicar em executar

## Tecnologias usadas

- C#
- Asp Net Core
- Entity Framework
- Banco de dados Sql Server


## Enpoints de Cobertura

### 1. Registrar Cobertura
- **Endpoint**: `/cobertura/register`
- **Método**: `POST`
- **Tags**: `Cobertura`
- **Descrição**: Registra uma nova cobertura.

#### Request Body
- **Content-Type**: `application/json`, `text/json`, `application/*+json`
- **Schema**: 
  - `RegisterCobertura`

#### Respostas
- **200 OK**: A cobertura foi registrada com sucesso.

---

### 2. Atualizar Cobertura
- **Endpoint**: `/cobertura/update`
- **Método**: `POST`
- **Tags**: `Cobertura`
- **Descrição**: Atualiza os dados de uma cobertura existente.

#### Request Body
- **Content-Type**: `application/json`, `text/json`, `application/*+json`
- **Schema**: 
  - `CoberturaUpdateRequest`

#### Respostas
- **200 OK**: A cobertura foi atualizada com sucesso.

---

### 3. Listar Coberturas Paginado
- **Endpoint**: `/cobertura/paginado`
- **Método**: `GET`
- **Tags**: `Cobertura`
- **Descrição**: Retorna uma lista de coberturas paginadas.

#### Parâmetros de Consulta
- `pageNumber` (integer): Número da página (default: 1)
- `pageSize` (integer): Tamanho da página (default: 10)

#### Respostas
- **200 OK**: Lista de coberturas paginadas retornada com sucesso.

---

### 4. Pesquisar Coberturas
- **Endpoint**: `/cobertura/search`
- **Método**: `GET`
- **Tags**: `Cobertura`
- **Descrição**: Pesquisa por coberturas com base em um parâmetro.

#### Parâmetros de Consulta
- `parametro` (string): O parâmetro a ser pesquisado.
- `pageNumber` (integer): Número da página (default: 1)
- `pageSize` (integer): Tamanho da página (default: 10)

#### Respostas
- **200 OK**: Resultados da pesquisa retornados com sucesso.

---

## Enpoints de Curativo

### 1. Registrar Curativo
- **Endpoint**: `/curativo/register`
- **Método**: `POST`
- **Tags**: `Curativo`
- **Descrição**: Registra um novo curativo.

#### Request Body
- **Content-Type**: `application/json`, `text/json`, `application/*+json`
- **Schema**: 
  - `RegisterCurativoRequest`

#### Respostas
- **200 OK**: O curativo foi registrado com sucesso.

---

### 2. Atualizar Curativo
- **Endpoint**: `/curativo/update`
- **Método**: `POST`
- **Tags**: `Curativo`
- **Descrição**: Atualiza os dados de um curativo existente.

#### Request Body
- **Content-Type**: `application/json`, `text/json`, `application/*+json`
- **Schema**: 
  - `UpdateCurativoRequest`

#### Respostas
- **200 OK**: O curativo foi atualizado com sucesso.

---

### 3. Obter Curativo por ID
- **Endpoint**: `/curativo/id`
- **Método**: `GET`
- **Tags**: `Curativo`
- **Descrição**: Retorna um curativo específico baseado no ID.

#### Parâmetros de Consulta
- `parametro` (integer): ID do curativo.

#### Respostas
- **200 OK**: Curativo retornado com sucesso.

---

### 4. Obter Últimos Curativos
- **Endpoint**: `/curativo/ultimos`
- **Método**: `GET`
- **Tags**: `Curativo`
- **Descrição**: Retorna os últimos curativos registrados.

#### Respostas
- **200 OK**: Últimos curativos retornados com sucesso.

---

### 5. Listar Curativos Paginado
- **Endpoint**: `/curativo/paginado`
- **Método**: `GET`
- **Tags**: `Curativo`
- **Descrição**: Retorna uma lista de curativos paginados.

#### Parâmetros de Consulta
- `pageNumber` (integer): Número da página (default: 1)
- `pageSize` (integer): Tamanho da página (default: 10)

#### Respostas
- **200 OK**: Lista de curativos paginadas retornada com sucesso.

---

### 6. Pesquisar Curativos
- **Endpoint**: `/curativo/search`
- **Método**: `GET`
- **Tags**: `Curativo`
- **Descrição**: Pesquisa por curativos com base em um parâmetro.

#### Parâmetros de Consulta
- `parametro` (string): O parâmetro a ser pesquisado.
- `pageNumber` (integer): Número da página (default: 1)
- `pageSize` (integer): Tamanho da página (default: 10)

#### Respostas
- **200 OK**: Resultados da pesquisa retornados com sucesso.

## Enpoints de Lesão

### 1. Registrar Lesão
- **Endpoint**: `/lesao/register`
- **Método**: `POST`
- **Tags**: `Lesao`
- **Descrição**: Registra uma nova lesão.

#### Request Body
- **Content-Type**: `application/json`, `text/json`, `application/*+json`
- **Schema**: 
  - `RegisterLesaoRequest`

#### Respostas
- **200 OK**: A lesão foi registrada com sucesso.

---

### 2. Atualizar Lesão
- **Endpoint**: `/lesao/update`
- **Método**: `POST`
- **Tags**: `Lesao`
- **Descrição**: Atualiza os dados de uma lesão existente.

#### Request Body
- **Content-Type**: `application/json`, `text/json`, `application/*+json`
- **Schema**: 
  - `LesaoUpdateRequest`

#### Respostas
- **200 OK**: A lesão foi atualizada com sucesso.

---

### 3. Obter Lesão por ID
- **Endpoint**: `/lesao/id`
- **Método**: `GET`
- **Tags**: `Lesao`
- **Descrição**: Retorna uma lesão específica baseada no ID.

#### Parâmetros de Consulta
- `parametro` (integer): ID da lesão.

#### Respostas
- **200 OK**: Lesão retornada com sucesso.

---

### 4. Listar Lesões Paginado
- **Endpoint**: `/lesao/paginado`
- **Método**: `GET`
- **Tags**: `Lesao`
- **Descrição**: Retorna uma lista de lesões paginadas.

#### Parâmetros de Consulta
- `pageNumber` (integer): Número da página (default: 1)
- `pageSize` (integer): Tamanho da página (default: 10)

#### Respostas
- **200 OK**: Lista de lesões paginadas retornada com sucesso.

---

### 5. Pesquisar Lesões
- **Endpoint**: `/lesao/search`
- **Método**: `GET`
- **Tags**: `Lesao`
- **Descrição**: Pesquisa por lesões com base em um parâmetro.

#### Parâmetros de Consulta
- `parametro` (string): O parâmetro a ser pesquisado.
- `pageNumber` (integer): Número da página (default: 1)
- `pageSize` (integer): Tamanho da página (default: 10)

#### Respostas
- **200 OK**: Resultados da pesquisa retornados com sucesso.

---

### 6. Listar Lesões por Paciente
- **Endpoint**: `/lesao/paciente`
- **Método**: `GET`
- **Tags**: `Lesao`
- **Descrição**: Retorna lesões associadas a um paciente.

#### Parâmetros de Consulta
- `parametro` (integer): ID do paciente.
- `pageNumber` (integer): Número da página (default: 1)
- `pageSize` (integer): Tamanho da página (default: 10)

#### Respostas
- **200 OK**: Lesões do paciente retornadas com sucesso.

---

## Enpoints de Paciente

### 1. Registrar Paciente
- **Endpoint**: `/paciente/register`
- **Método**: `POST`
- **Tags**: `Paciente`
- **Descrição**: Registra um novo paciente.

#### Request Body
- **Content-Type**: `application/json`, `text/json`, `application/*+json`
- **Schema**: 
  - `RegisterPacienteRequest`

#### Respostas
- **200 OK**: O paciente foi registrado com sucesso.

---

### 2. Atualizar Paciente
- **Endpoint**: `/paciente/update`
- **Método**: `POST`
- **Tags**: `Paciente`
- **Descrição**: Atualiza os dados de um paciente existente.

#### Request Body
- **Content-Type**: `application/json`, `text/json`, `application/*+json`
- **Schema**: 
  - `UpdatePacienteRequest`

#### Respostas
- **200 OK**: O paciente foi atualizado com sucesso.

---

### 3. Buscar Paciente
- **Endpoint**: `/paciente/buscar`
- **Método**: `GET`
- **Tags**: `Paciente`
- **Descrição**: Busca por pacientes com base em um parâmetro.

#### Parâmetros de Consulta
- `parametro` (string): O parâmetro a ser pesquisado.

#### Respostas
- **200 OK**: Pacientes encontrados retornados com sucesso.

---

### 4. Obter Paciente por ID
- **Endpoint**: `/paciente/id`
- **Método**: `GET`
- **Tags**: `Paciente`
- **Descrição**: Retorna um paciente específico baseado no ID.

#### Parâmetros de Consulta
- `parametro` (integer): ID do paciente.

#### Respostas
- **200 OK**: Paciente retornado com sucesso.

---

### 5. Listar Pacientes Paginado
- **Endpoint**: `/paciente/paginado`
- **Método**: `GET`
- **Tags**: `Paciente`
- **Descrição**: Retorna uma lista de pacientes paginados.

#### Parâmetros de Consulta
- `pageNumber` (integer): Número da página (default: 1)
- `pageSize` (integer): Tamanho da página (default: 10)

#### Respostas
- **200 OK**: Lista de pacientes paginadas retornada com sucesso.

---

### 6. Pesquisar Pacientes
- **Endpoint**: `/paciente/search`
- **Método**: `GET`
- **Tags**: `Paciente`
- **Descrição**: Pesquisa por pacientes com base em um parâmetro.

#### Parâmetros de Consulta
- `parametro` (string): O parâmetro a ser pesquisado.
- `pageNumber` (integer): Número da página (default: 1)
- `pageSize` (integer): Tamanho da página (default: 10)

#### Respostas
- **200 OK**: Resultados da pesquisa retornados com sucesso.

---

### 7. Obter Alergias dos Pacientes
- **Endpoint**: `/paciente/alergias`
- **Método**: `GET`
- **Tags**: `Paciente`
- **Descrição**: Retorna uma lista de alergias.

#### Respostas
- **200 OK**: Lista de alergias retornada com sucesso.

---

### 8. Obter Comorbidades dos Pacientes
- **Endpoint**: `/paciente/comorbidades`
- **Método**: `GET`
- **Tags**: `Paciente`
- **Descrição**: Retorna uma lista de comorbidades.

#### Respostas
- **200 OK**: Lista de comorbidades retornada com sucesso.


### Enpoints de Profissional

- **Registrar um Novo Profissional**
  - `POST /profissional/register`
  - **Request Body**: 
    - `application/json`: `{ "request": { ... } }` (Referência: `#/components/schemas/RegisterProfissionalRequest`)
  - **Resposta**:
    - `200 OK`

- **Login do Profissional**
  - `POST /profissional/login`
  - **Request Body**: 
    - `application/json`: `{ "request": { ... } }` (Referência: `#/components/schemas/LoginModel`)
  - **Resposta**:
    - `200 OK`

- **Ping Serviço do Profissional**
  - `GET /profissional/ping`
  - **Resposta**:
    - `200 OK`

- **Obter Lista de Pacientes para o Profissional**
  - `GET /profissional/pacientes`
  - **Resposta**:
    - `200 OK`

- **Obter Lista de Curativos para o Profissional**
  - `GET /profissional/curativos`
  - **Resposta**:
    - `200 OK`

- **Obter Dados do Profissional**
  - `GET /profissional/dados`
  - **Resposta**:
    - `200 OK`

- **Atualizar Profissional**
  - `POST /profissional/update`
  - **Request Body**: 
    - `application/json`: `{ "request": { ... } }` (Referência: `#/components/schemas/ProfissionalDto`)
  - **Resposta**:
    - `200 OK`

### Enpoints de Relatório

- **Obter Total de Relatório por Paciente**
  - `GET /relatorio/total/paciente`
  - **Parâmetros**:
    - `idPaciente` (query, tipo: `integer`)
  - **Resposta**:
    - `200 OK`

- **Obter Relatório por Período para Paciente**
  - `GET /relatorio/periodo/paciente`
  - **Parâmetros**:
    - `idPaciente` (query, tipo: `integer`)
    - `dataInicial` (query, tipo: `string`, formato: `date-time`)
    - `dataFinal` (query, tipo: `string`, formato: `date-time`)
  - **Resposta**:
    - `200 OK`

- **Obter Relatório por Período para Profissional**
  - `GET /relatorio/periodo/profissional`
  - **Parâmetros**:
    - `dataInicial` (query, tipo: `string`, formato: `date-time`)
    - `dataFinal` (query, tipo: `string`, formato: `date-time`)
  - **Resposta**:
    - `200 OK`

- **Obter Relatório de Lesão**
  - `GET /relatorio/lesao`
  - **Parâmetros**:
    - `lesaoId` (query, tipo: `integer`)
  - **Resposta**:
    - `200 OK`
