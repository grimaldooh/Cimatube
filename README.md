# 📺 CimaTube - Educational Video Platform

A YouTube-style video platform specialized in institutional educational content, designed for universities and academic institutions to centralize learning resources.

## ✨ Features

- **🎥 Video Management** - Upload, organize, and manage educational content
- **🔍 Advanced Search** - Specialized filters for academic categories and topics
- **👥 User Roles** - Separate interfaces for professors, students, and administrators
- **📚 Academic Categories** - University-specific topic organization
- **📊 Analytics Dashboard** - View counts, engagement metrics, and learning analytics
- **💬 Comments & Interaction** - Student-professor communication tools
- **🎯 Content Curation** - Quality control and content approval workflows

## 🛠️ Technologies

- **C#** - Backend programming language
- **.NET Framework** - Application framework
- **Bootstrap** - Responsive frontend framework
- **HTML5/CSS3** - Modern web standards
- **JavaScript** - Interactive frontend functionality
- **SQL Server** - Database management
- **Layered Architecture** - Clean code organization

## 🚀 Getting Started

### Prerequisites
- .NET Framework 4.7.2+
- SQL Server 2017+
- Visual Studio 2019+
- IIS Express (for development)

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/grimaldooh/Cimatube.git
cd Cimatube
```

2. **Database Setup**
```sql
-- Create database in SQL Server
CREATE DATABASE CimaTubeDB;

-- Run migration scripts
-- Execute scripts in /Database/Migrations/ folder
```

3. **Configure Connection String**
```xml
<!-- Update Web.config -->
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Server=localhost;Database=CimaTubeDB;Trusted_Connection=true;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

4. **Build and Run**
```bash
# Open in Visual Studio
# Build Solution (Ctrl + Shift + B)
# Run with IIS Express (F5)
```

## 🏗️ Architecture

```
CimaTube/
├── Controllers/               # MVC Controllers
├── Models/                   # Data models and entities
├── Views/                    # Razor views and templates
├── Services/                 # Business logic layer
├── Data/                     # Data access layer
├── wwwroot/                  # Static files (CSS, JS, images)
└── Database/
    ├── Migrations/           # Database schema updates
    └── Scripts/              # SQL scripts and procedures
```

## 🎯 Key Features

### Video Management System
- **Upload Interface** - Drag-and-drop video uploads with progress tracking
- **Metadata Management** - Title, description, tags, and category assignment
- **Quality Control** - Automatic video processing and optimization
- **Storage Management** - Efficient file organization and CDN integration

### Academic Integration
- **Course Mapping** - Link videos to specific courses and curricula
- **Semester Organization** - Organize content by academic periods
- **Professor Tools** - Specialized interface for educators
- **Student Dashboard** - Personalized learning experience

### Search & Discovery
- **Intelligent Search** - Full-text search with academic relevance
- **Filter Options** - By professor, course, semester, topic
- **Recommendation Engine** - Suggest related educational content
- **Playlist Creation** - Organize videos into learning sequences

## 👥 User Roles

### Students
- Browse and watch educational videos
- Create personal playlists
- Comment and engage with content
- Track learning progress

### Professors
- Upload and manage course videos
- Monitor student engagement
- Moderate comments and discussions
- Access analytics and insights

### Administrators
- Manage user accounts and permissions
- Oversee content quality and compliance
- Generate institutional reports
- Configure system settings

## 📊 Analytics & Reporting

- **View Analytics** - Detailed video performance metrics
- **User Engagement** - Comment and interaction tracking
- **Learning Insights** - Student progress and completion rates
- **Institutional Reports** - Usage statistics and trends

## 🔐 Security Features

- **Authentication** - Secure login with institutional credentials
- **Authorization** - Role-based access control
- **Content Protection** - Video streaming security
- **Data Privacy** - Compliance with educational privacy standards

## 📱 Responsive Design

- **Mobile Optimized** - Works seamlessly on all devices
- **Bootstrap Framework** - Consistent and modern UI
- **Progressive Enhancement** - Graceful degradation for older browsers
- **Accessibility** - WCAG compliance for inclusive education

## 🧪 Testing

```bash
# Run unit tests
dotnet test CimaTube.Tests/

# Integration tests
dotnet test CimaTube.IntegrationTests/
```

## 📚 Documentation

- [User Guide](docs/user-guide.md)
- [Administrator Manual](docs/admin-guide.md)
- [API Documentation](docs/api.md)
- [Database Schema](docs/database-schema.md)

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/NewFeature`)
3. Commit your changes (`git commit -m 'Add NewFeature'`)
4. Push to the branch (`git push origin feature/NewFeature`)
5. Create a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Angel Grimaldo** - [GitHub](https://github.com/grimaldooh)

## 🎓 Educational Impact

CimaTube facilitates knowledge sharing in academic environments by:
- Centralizing educational content delivery
- Improving accessibility to learning resources
- Enhancing student-professor communication
- Supporting remote and hybrid learning models
