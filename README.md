# 📄 DocFlow – Document Management System MVP

**DocFlow** is a lightweight, scalable Document Management System (DMS) built with a microservices architecture using .NET and React. The system allows users to upload, manage, and retrieve documents efficiently in a secure cloud-based environment powered by Azure and MongoDB.

---

## 🏗️ Architecture Overview

- **Frontend**: React SPA
- **Backend**: .NET 6 Microservices
- **Storage**: Azure Blob Storage
- **Database**: MongoDB Atlas
- **API Gateway**: Ocelot
- **Authentication**: JWT-based Auth Service
- **Deployment**: Docker Compose (Dev)

---

## 📦 Project Structure
DocFlow/ ├── src/ │ 
├── Gateway/ │ 
├── Services/ │ │ ├── AuthService/ │ │ ├── UserService/ │ │ ├── DocumentService/ │ │ └── SearchService/ │
└── Frontend/ │ └── docflow-frontend/ 
├── tests/ 
├── infrastructure/ └── docker-compose.yml


---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [Node.js + npm](https://nodejs.org/)
- [MongoDB Atlas](https://www.mongodb.com/cloud/atlas)
- [Azure Storage Account](https://azure.microsoft.com/en-us/services/storage/)
- [Docker](https://www.docker.com/)

### Setup

1. **Clone the repository**  
   ```bash
   git clone https://github.com/your-username/DocFlow.git
   cd DocFlow

