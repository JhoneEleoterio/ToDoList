Projeto ToDoList com Docker
Este projeto consiste em uma aplicação WebAPI que utiliza um banco de dados MongoDB para gerenciar tarefas. O ambiente é configurado e executado usando Docker Compose.

Pré-requisitos
Antes de começar, certifique-se de que você tem o seguinte instalado em sua máquina:

Docker: Instale o Docker
Docker Compose: Instale o Docker Compose

Estrutura do Projeto
O projeto é composto por dois serviços:

WebAPI: Aplicação .NET que expõe endpoints REST.
MongoDB: Banco de dados MongoDB para armazenamento de dados.

Como Executar o Projeto
Siga os passos abaixo para configurar e executar o projeto:

1. Clone o Repositório
Clone o repositório do projeto para sua máquina local:
git clone https://github.com/JhoneEleoterio/ToDoList.git
cd ToDoList

3. Execute o Docker Compose
No diretório raiz do projeto, execute o seguinte comando para iniciar os containers:
docker-compose up -d

Isso fará o seguinte:
  Construirá a imagem da WebAPI com base no Dockerfile.
  Iniciará o container do MongoDB.
  Iniciará o container da WebAPI.

3. Valide o Deploy
Após os containers serem iniciados, você pode validar se a aplicação está funcionando corretamente.

Acesse a API:
HTTP: http://localhost:5000
HTTPS: https://localhost:5001

*Url com swagger*: 
HTTP: http://localhost:5000/swagger
HTTPS: https://localhost:5001/swagger

Teste os Endpoints: 
Na aplicação foi disponibilizado o swagger, mas você pode utilizar outras opções como: Postman ou Insomnia

4. Parar e Remover os Containers
Para parar e remover os containers, execute:
docker-compose down

Isso removerá os containers, mas manterá o volume do MongoDB (mongo_data) para persistência dos dados.

Solução de Problemas
1. Portas já em uso
Se as portas 5000, 5001 ou 27017 já estiverem em uso, altere as configurações de portas no docker-compose.yml.

Contribuindo
Se você deseja contribuir para este projeto, siga estas etapas:

Faça um fork do repositório.
Crie uma branch para sua feature (git checkout -b feature/nova-feature).
Commit suas alterações (git commit -m 'Adicionando nova feature').
Push para a branch (git push origin feature/nova-feature).
Abra um Pull Request.

Licença
Este projeto está licenciado sob a licença MIT. Consulte o arquivo LICENSE para mais detalhes.
