# ToDoList

## 📋 About
A ToDoList WebAPI project using Docker and MongoDB. This application provides a containerized environment for managing tasks through a REST API.

## 🚀 Technologies
- .NET WebAPI
- MongoDB
- Docker
- Docker Compose

## ⚙️ Prerequisites
Make sure you have the following installed:
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

## 🏗️ Project Structure
The project consists of two main services:
- **WebAPI**: .NET application exposing REST endpoints
- **MongoDB**: Database for data persistence

## 🛠️ Setup and Installation

### 1. Clone the Repository
```bash
git clone https://github.com/JhoneEleoterio/ToDoList.git
cd ToDoList
```

### 2. Start the Application
Run the following command in the project root directory:
```bash
docker-compose up --build
```

This command will:
- Build the WebAPI image using the Dockerfile
- Build the Tests image using the Dockerfile
- Start the MongoDB container
- Start the WebAPI container

### 3. Access the Application
The application will be available at:

- **HTTP**: http://localhost:5000
- **HTTPS**: https://localhost:5001

#### Swagger Documentation
- **HTTP**: http://localhost:5000/swagger
- **HTTPS**: https://localhost:5001/swagger

You can test the endpoints using:
- Swagger UI
- Postman
- Insomnia

### 4. Stop the Application
To stop and remove the containers:
```bash
docker-compose down -v
```

*Note: This will preserve the MongoDB volume (mongo_data) for data persistence.*

## 🔧 Troubleshooting

### Port Conflicts
If ports 5000, 5001, or 27017 are already in use:
1. Open `docker-compose.yml`
2. Modify the port mappings as needed
3. Restart the containers

## 👥 Contributing
1. Fork the repository
2. Create a feature branch
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Commit your changes
   ```bash
   git commit -m 'Add some feature'
   ```
4. Push to the branch
   ```bash
   git push origin feature/your-feature-name
   ```
5. Open a Pull Request

## 📄 License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Support
If you encounter any issues or have questions, please open an issue in the GitHub repository.
