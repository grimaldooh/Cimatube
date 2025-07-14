# 🎥 Cimatube - Educational Video Platform

A comprehensive educational video platform built with ASP.NET Web Forms, designed for academic institutions to manage and share educational content.

## 📋 Table of Contents
- [Features](#features)
- [Technologies](#technologies)
- [Architecture](#architecture)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [Contributing](#contributing)
- [License](#license)

## ✨ Features

### 🎯 Core Features
- **Video Management**: Upload, organize, and manage educational videos
- **User Authentication**: Secure login system for students and instructors
- **Author Management**: Content creator profiles and permissions
- **Subject Organization**: Videos categorized by academic subjects and careers
- **Video Player**: Custom video player with educational features
- **Comment System**: Interactive commenting system for educational discussions
- **Responsive Design**: Mobile-friendly interface using Bootstrap

### 👥 User Roles
- **Students**: View videos, leave comments, and track progress
- **Authors/Instructors**: Upload and manage educational content
- **Administrators**: Full platform management capabilities

## 🛠️ Technologies

### Backend
- **Framework**: ASP.NET Web Forms (.NET Framework 4.7.2)
- **Language**: C#
- **Database**: SQL Server
- **Data Access**: ADO.NET with SqlClient

### Frontend
- **UI Framework**: Bootstrap 5.0.2
- **Styling**: Custom CSS with responsive design
- **JavaScript**: Custom scripts for video player functionality
- **Icons & Assets**: Custom educational theme

### Development Tools
- **IDE**: Visual Studio 2019/2022
- **Version Control**: Git
- **Package Manager**: NuGet

## 🏗️ Architecture

The project follows a **3-Layer Architecture** pattern:

```
┌─────────────────┐
│   Presentation  │  ← ASP.NET Web Forms (UI Layer)
├─────────────────┤
│    Business     │  ← Business Logic Layer
├─────────────────┤
│   Data Access   │  ← Data Access Layer
├─────────────────┤
│    Entities     │  ← Data Models/Entities
└─────────────────┘
```

### Layer Responsibilities

1. **Presentation Layer** (`Presentacion/`)
   - ASP.NET Web Forms pages
   - User controls and validation
   - CSS styling and responsive design
   - Client-side JavaScript functionality

2. **Business Layer** (`Negocios/`)
   - Business logic implementation
   - Data validation and processing
   - Communication between Presentation and Data layers

3. **Data Access Layer** (`Datos/`)
   - Database connection management
   - SQL queries and stored procedures
   - Data retrieval and manipulation

4. **Entities Layer** (`Entidades/`)
   - Data models and entity classes
   - Data transfer objects (DTOs)

## 🚀 Installation

### Prerequisites
- Visual Studio 2019 or later
- SQL Server 2017 or later
- .NET Framework 4.7.2
- IIS (for deployment)

### Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/grimaldooh/Cimatube.git
   cd Cimatube
   ```

2. **Database Setup**
   - Create a SQL Server database named `Cimatube`
   - Update connection strings in `Web.config`
   - Run database scripts to create tables:
     - `Usuarios` (Users)
     - `Autores` (Authors)
     - `Carreras` (Careers)
     - `Materias` (Subjects)
     - `Videos` (Videos)
     - `Comentarios` (Comments)

3. **Build the Solution**
   ```bash
   # Open in Visual Studio
   # Build → Build Solution (Ctrl+Shift+B)
   ```

4. **Configure IIS** (for local deployment)
   - Set up IIS application pointing to `Presentacion/` folder
   - Ensure ASP.NET 4.7.2 is installed

5. **Run the Application**
   - Press F5 in Visual Studio for debugging
   - Or deploy to IIS for production

## 📱 Usage

### For Students
1. **Browse Videos**: Navigate through educational content by subject
2. **Watch Videos**: Use the custom video player with educational features
3. **Engage**: Leave comments and participate in discussions
4. **Search**: Find specific content using the search functionality

### For Instructors/Authors
1. **Content Upload**: Upload educational videos with metadata
2. **Organization**: Categorize content by subject and career
3. **Management**: Edit video information and manage content
4. **Analytics**: Track video views and engagement

### For Administrators
1. **User Management**: Manage student and instructor accounts
2. **Content Moderation**: Review and approve educational content
3. **System Configuration**: Configure platform settings and permissions

## 📁 Project Structure

```
Cimatube/
├── 📁 Presentacion/          # Presentation Layer
│   ├── 📄 Inicio.aspx        # Home page
│   ├── 📄 Login.aspx         # Authentication
│   ├── 📄 VideoPlayer.aspx   # Video player
│   ├── 📄 DatosCarreras.aspx # Career management
│   ├── 📄 DatosMaterias.aspx # Subject management
│   ├── 📁 Controles/         # User controls
│   ├── 📁 CSS/               # Stylesheets
│   ├── 📁 javascript/        # Client scripts
│   ├── 📁 Imagenes/          # Images and assets
│   └── 📄 Web.config         # Configuration
├── 📁 Negocios/              # Business Logic Layer
│   ├── 📄 GestionUsuarios.cs
│   ├── 📄 GestionVideos.cs
│   ├── 📄 GestionAutores.cs
│   ├── 📄 GestionCarreras.cs
│   ├── 📄 GestionMaterias.cs
│   └── 📄 GestionComentarios.cs
├── 📁 Datos/                 # Data Access Layer
│   ├── 📄 GestionUsuarios.cs
│   ├── 📄 GestionVideos.cs
│   ├── 📄 GestionAutores.cs
│   ├── 📄 GestionCarreras.cs
│   ├── 📄 GestionMaterias.cs
│   └── 📄 GestionComentarios.cs
├── 📁 Entidades/             # Entity Models
│   ├── 📄 GestionUsuarios.cs
│   ├── 📄 GestionVideos.cs
│   ├── 📄 GestionAutores.cs
│   ├── 📄 GestionCarreras.cs
│   ├── 📄 GestionMaterias.cs
│   └── 📄 GestionComentarios.cs
├── 📁 packages/              # NuGet packages
├── 📄 YouTubeDos.sln         # Solution file
└── 📄 README.md              # This file
```

## 🗄️ Database Schema

### Core Tables

#### Users (`Usuarios`)
- User authentication and profile information
- Role-based access control

#### Authors (`Autores`)
- Content creator profiles
- Linked to user accounts

#### Careers (`Carreras`)
- Academic programs and specializations
- Organizational structure

#### Subjects (`Materias`)
- Academic subjects within careers
- Content categorization

#### Videos (`Videos`)
- Video metadata and file information
- View tracking and analytics

#### Comments (`Comentarios`)
- User feedback and discussions
- Moderation capabilities

## 🤝 Contributing

We welcome contributions to Cimatube! Here's how you can help:

### Getting Started
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Commit your changes (`git commit -m 'Add amazing feature'`)
5. Push to the branch (`git push origin feature/amazing-feature`)
6. Open a Pull Request

### Development Guidelines
- Follow C# coding conventions
- Write meaningful commit messages
- Test your changes thoroughly
- Update documentation as needed
- Ensure responsive design compliance

### Code Style
- Use meaningful variable and method names
- Follow the existing project structure
- Add comments for complex business logic
- Implement proper error handling

## 📋 Development Roadmap

### Phase 1: Core Platform ✅
- [x] Basic video upload and playback
- [x] User authentication system
- [x] Subject and career organization
- [x] Comment system

### Phase 2: Enhanced Features 🚧
- [ ] Advanced search functionality
- [ ] Video analytics dashboard
- [ ] Mobile app development
- [ ] API development for third-party integrations

### Phase 3: Advanced Features 📋
- [ ] AI-powered content recommendations
- [ ] Live streaming capabilities
- [ ] Interactive quizzes and assessments
- [ ] Multi-language support

## 🐛 Known Issues

- Video upload size limitations
- Browser compatibility with older versions
- Mobile responsiveness needs improvement in some areas

## 📞 Support

For support and questions:
- Create an issue in this repository
- Contact the development team
- Check the documentation wiki

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **Development Team** - Initial work and ongoing development
- **Contributors** - See [CONTRIBUTORS.md](CONTRIBUTORS.md) for the list of contributors

## 🙏 Acknowledgments

- Educational institutions for requirements and feedback
- Open source community for tools and libraries
- Bootstrap team for the responsive framework
- Microsoft for the .NET Framework

---

**Cimatube** - Empowering education through technology 🎓

[![Built with ASP.NET](https://img.shields.io/badge/Built%20with-ASP.NET-blue)](https://dotnet.microsoft.com/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.0.2-purple)](https://getbootstrap.com/)
[![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)](https://www.microsoft.com/sql-server/)
