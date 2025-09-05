# Development Tools

This directory contains scripts and utilities for building, generating, and maintaining the PlayerMMO Design Patterns project.

## 📁 Scripts Overview

### 🖼️ UML Generation
- **`generate_all_puml_images.py`** - Generates PNG images from PlantUML files
  ```bash
  python tools/generate_all_puml_images.py
  ```

### 📄 PDF Generation
- **`generate_pdfs_simple.py`** - Converts markdown to HTML/PDF (recommended)
- **`generate_pdfs.py`** - Advanced PDF generation with WeasyPrint
- **`generate_pdfs_pandoc.py`** - PDF generation using Pandoc

### 🌐 GitHub Pages Setup
- **`setup-github-pages.bat`** - Windows batch script for GitHub Pages setup
- **`setup-github-pages.sh`** - Unix shell script for GitHub Pages setup

## 🚀 Usage

### Generate UML Diagrams
```bash
cd tools/
python generate_all_puml_images.py
```

### Generate PDF Documentation
```bash
cd tools/
python generate_pdfs_simple.py
```

### Setup GitHub Pages
```bash
# Windows
tools/setup-github-pages.bat

# Unix/Linux/Mac
chmod +x tools/setup-github-pages.sh
./tools/setup-github-pages.sh
```

## 📋 Requirements

### Python Scripts
- Python 3.7+
- Required packages (auto-installed):
  - `markdown`
  - `weasyprint` (for PDF generation)

### PlantUML
- Java Runtime Environment
- PlantUML JAR file (downloaded automatically)

### GitHub Pages
- Git repository with GitHub remote
- GitHub account with Pages enabled

## 🔧 Development

These tools are designed to be:
- **Self-contained** - Install dependencies automatically
- **Cross-platform** - Work on Windows, macOS, and Linux
- **Error-resistant** - Handle missing dependencies gracefully
- **User-friendly** - Provide clear feedback and instructions
