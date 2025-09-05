# Contributing to PlayerMMO Design Patterns

Thank you for your interest in contributing to the PlayerMMO Design Patterns project! This document provides guidelines and information for contributors.

## 🎯 Project Goals

This project aims to provide:
- **Educational Resources** - High-quality design pattern documentation
- **Practical Examples** - Real C# implementations in game context
- **Modern Presentation** - Professional web interface
- **Learning Support** - Comprehensive guides and visual aids

## 🤝 How to Contribute

### 📝 Documentation Improvements
- Fix typos or grammatical errors
- Improve explanations or add examples
- Update outdated information
- Add missing details or clarifications

### 💻 Code Enhancements
- Improve C# implementations
- Add better error handling
- Optimize performance
- Add unit tests

### 🎨 Website Improvements
- Enhance user interface
- Fix responsive design issues
- Improve accessibility
- Add new features

### 📊 UML Diagrams
- Create additional diagrams
- Improve existing diagrams
- Add diagram explanations
- Fix diagram errors

## 🚀 Getting Started

### 1. Fork the Repository
```bash
# Click the "Fork" button on GitHub
# Clone your fork
git clone https://github.com/YOUR-USERNAME/Samenvatting.git
cd Samenvatting
```

### 2. Set Up Development Environment
```bash
# Install dependencies (if needed)
# For C# development
dotnet --version

# For Python tools
python --version
pip install markdown weasyprint

# For local web development
python -m http.server 8000
```

### 3. Create a Feature Branch
```bash
git checkout -b feature/your-feature-name
# or
git checkout -b fix/issue-description
```

### 4. Make Your Changes
- Edit source files in appropriate directories
- Test your changes locally
- Follow project conventions

### 5. Test Your Changes
```bash
# Test C# code
cd PlayerMMO/[PatternName]
dotnet build
dotnet run

# Test documentation generation
python tools/generate_pdfs_simple.py

# Test website locally
python -m http.server 8000
```

### 6. Commit and Push
```bash
git add .
git commit -m "Description of your changes"
git push origin feature/your-feature-name
```

### 7. Create Pull Request
- Go to GitHub and create a pull request
- Provide clear description of changes
- Reference any related issues

## 📁 Project Structure

### Source Code
- **`PlayerMMO/`** - C# pattern implementations
- **`Puml/`** - PlantUML diagram sources

### Documentation
- **`docs-source/`** - Original markdown files
- **`docs/`** - Generated HTML files (don't edit directly)

### Website
- **`index.html`** - Main website
- **`assets/`** - CSS, JavaScript, images

### Tools
- **`tools/`** - Build and generation scripts

## 📋 Style Guidelines

### C# Code
- Follow standard C# conventions
- Use meaningful variable names
- Add XML documentation comments
- Include error handling where appropriate

### Documentation
- Use clear, concise language
- Include code examples
- Add proper markdown formatting
- Reference UML diagrams when relevant

### Commit Messages
- Use present tense ("Add feature" not "Added feature")
- Keep first line under 50 characters
- Include detailed description if needed

## 🐛 Reporting Issues

### Before Submitting
1. Check existing issues
2. Test with latest version
3. Gather relevant information

### Issue Template
```
**Description**: Brief description of the issue

**Steps to Reproduce**:
1. Step one
2. Step two
3. Step three

**Expected Behavior**: What should happen

**Actual Behavior**: What actually happens

**Environment**:
- OS: [Windows/macOS/Linux]
- Browser: [if web-related]
- .NET Version: [if code-related]

**Additional Context**: Any other relevant information
```

## ✅ Review Process

### Automated Checks
- GitHub Actions will run automatically
- Website deployment will be tested
- Basic validation will be performed

### Manual Review
- Maintainers will review pull requests
- Feedback will be provided if needed
- Changes may be requested

### Merge Criteria
- Code compiles and runs correctly
- Documentation is accurate and clear
- Changes align with project goals
- No breaking changes to existing functionality

## 🎓 Learning Resources

### Design Patterns
- [Gang of Four Book](https://en.wikipedia.org/wiki/Design_Patterns)
- [Refactoring Guru](https://refactoring.guru/design-patterns)
- [Microsoft Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)

### UML
- [UML Specification](https://www.uml.org/)
- [PlantUML Documentation](https://plantuml.com/)

### Web Development
- [MDN Web Docs](https://developer.mozilla.org/)
- [GitHub Pages Documentation](https://pages.github.com/)

## 📧 Contact

- **Issues**: Use GitHub Issues for bug reports and feature requests
- **Discussions**: Use GitHub Discussions for questions and ideas
- **Email**: Contact maintainers for private matters

## 📄 License

By contributing, you agree that your contributions will be licensed under the MIT License.

---

Thank you for helping make this project better! 🎉
