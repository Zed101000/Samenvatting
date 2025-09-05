#!/usr/bin/env python3
"""
Alternative PDF Generator using Pandoc
Simpler approach using pandoc for markdown to PDF conversion
"""

import os
import sys
import subprocess
from pathlib import Path
from datetime import datetime

def check_pandoc():
    """Check if pandoc is installed"""
    try:
        result = subprocess.run(['pandoc', '--version'], 
                              capture_output=True, text=True, check=True)
        print("✓ Pandoc found:", result.stdout.split('\n')[0])
        return True
    except (subprocess.CalledProcessError, FileNotFoundError):
        print("❌ Pandoc not found. Please install pandoc:")
        print("   Windows: choco install pandoc (with Chocolatey)")
        print("   Or download from: https://pandoc.org/installing.html")
        return False

def create_pandoc_template():
    """Create a custom LaTeX template for better PDF formatting"""
    template_content = r"""
\documentclass[11pt,a4paper]{article}
\usepackage[utf8]{inputenc}
\usepackage[T1]{fontenc}
\usepackage{lmodern}
\usepackage{microtype}
\usepackage{geometry}
\usepackage{fancyhdr}
\usepackage{graphicx}
\usepackage{longtable,booktabs}
\usepackage{listings}
\usepackage{xcolor}
\usepackage{hyperref}
\usepackage{tocloft}

% Page setup
\geometry{
    top=2.5cm,
    bottom=2.5cm,
    left=2cm,
    right=2cm
}

% Headers and footers
\pagestyle{fancy}
\fancyhf{}
\fancyhead[C]{\textbf{PlayerMMO Design Patterns Documentation}}
\fancyfoot[C]{\thepage}
\renewcommand{\headrulewidth}{0.5pt}

% Hyperlink setup
\hypersetup{
    colorlinks=true,
    linkcolor=blue,
    filecolor=magenta,      
    urlcolor=blue,
    pdftitle={PlayerMMO Design Patterns},
    pdfauthor={PlayerMMO Documentation}
}

% Code styling
\definecolor{codegray}{rgb}{0.5,0.5,0.5}
\definecolor{codepurple}{rgb}{0.58,0,0.82}
\definecolor{backcolour}{rgb}{0.95,0.95,0.92}

\lstdefinestyle{mystyle}{
    backgroundcolor=\color{backcolour},   
    commentstyle=\color{codegray},
    keywordstyle=\color{magenta},
    numberstyle=\tiny\color{codegray},
    stringstyle=\color{codepurple},
    basicstyle=\ttfamily\footnotesize,
    breakatwhitespace=false,         
    breaklines=true,                 
    captionpos=b,                    
    keepspaces=true,                 
    numbers=left,                    
    numbersep=5pt,                  
    showspaces=false,                
    showstringspaces=false,
    showtabs=false,                  
    tabsize=2
}

\lstset{style=mystyle}

% Custom title formatting
\makeatletter
\def\@maketitle{%
  \newpage
  \null
  \vskip 2em%
  \begin{center}%
  \let \footnote \thanks
    {\LARGE \@title \par}%
    \vskip 1.5em%
    {\large
      \lineskip .5em%
      \begin{tabular}[t]{c}%
        \@author
      \end{tabular}\par}%
    \vskip 1em%
    {\large \@date}%
  \end{center}%
  \par
  \vskip 1.5em}
\makeatother

\begin{document}

$if(title)$
\title{$title$}
$endif$

$if(author)$
\author{$author$}
$endif$

$if(date)$
\date{$date$}
$else$
\date{\today}
$endif$

$if(title)$
\maketitle
$endif$

$if(toc)$
\tableofcontents
\newpage
$endif$

$body$

\end{document}
"""
    
    template_path = Path("pandoc_template.latex")
    with open(template_path, 'w', encoding='utf-8') as f:
        f.write(template_content)
    
    return template_path

def convert_markdown_to_pdf_pandoc(md_file_path, output_dir, template_path):
    """Convert markdown to PDF using pandoc"""
    md_path = Path(md_file_path)
    output_path = Path(output_dir)
    
    # Create output directory if it doesn't exist
    output_path.mkdir(parents=True, exist_ok=True)
    
    # Define output PDF path
    pdf_path = output_path / f"{md_path.stem}.pdf"
    
    # Prepare pandoc command
    pandoc_cmd = [
        'pandoc',
        str(md_path),
        '-o', str(pdf_path),
        '--template', str(template_path),
        '--pdf-engine=xelatex',
        '--toc',
        '--toc-depth=3',
        '--number-sections',
        '--highlight-style=tango',
        '--variable', 'geometry:margin=2cm',
        '--variable', 'fontsize=11pt',
        '--variable', 'documentclass=article',
        '--variable', 'classoption=onecolumn',
        '--variable', 'linestretch=1.2'
    ]
    
    try:
        print(f"Converting {md_path.name} to PDF...")
        result = subprocess.run(pandoc_cmd, capture_output=True, text=True, check=True)
        print(f"✓ Generated: {pdf_path}")
        return pdf_path
        
    except subprocess.CalledProcessError as e:
        print(f"✗ Error converting {md_path.name}:")
        print(f"   Command: {' '.join(pandoc_cmd)}")
        print(f"   Error: {e.stderr}")
        return None

def generate_batch_file():
    """Generate a Windows batch file for easier PDF generation"""
    batch_content = """@echo off
echo PlayerMMO PDF Generator
echo ========================

echo Checking for Python...
python --version >nul 2>&1
if errorlevel 1 (
    echo Error: Python not found. Please install Python first.
    pause
    exit /b 1
)

echo Checking for Pandoc...
pandoc --version >nul 2>&1
if errorlevel 1 (
    echo Error: Pandoc not found. 
    echo Please install Pandoc from https://pandoc.org/installing.html
    echo Or use Chocolatey: choco install pandoc
    pause
    exit /b 1
)

echo Generating PDFs...
python generate_pdfs_pandoc.py

echo.
echo PDF generation complete!
echo Check the PDFs folder for generated files.
pause
"""
    
    with open("generate_pdfs.bat", 'w') as f:
        f.write(batch_content)
    
    print("✓ Created generate_pdfs.bat for easy execution")

def main():
    """Main function"""
    print("🔄 PlayerMMO Documentation PDF Generator (Pandoc)")
    print("=" * 55)
    
    # Check for pandoc
    if not check_pandoc():
        return
    
    # Create template
    print("📄 Creating LaTeX template...")
    template_path = create_pandoc_template()
    
    # Define directories
    base_dir = Path(".")
    pdf_output_dir = base_dir / "PDFs"
    
    # Create main output directory
    pdf_output_dir.mkdir(exist_ok=True)
    
    # Define sections to process
    sections = [
        {
            "name": "Main Documentation",
            "source": ".",
            "output": pdf_output_dir / "Main",
            "files": ["README.md"]
        },
        {
            "name": "PlayerMMO Overview",
            "source": "PlayerMMO",
            "output": pdf_output_dir / "PlayerMMO",
            "files": ["README.md"]
        },
        {
            "name": "Design Pattern Summaries",
            "source": "PlayerMMO/Summaries",
            "output": pdf_output_dir / "DesignPatterns",
            "files": "all"  # Process all .md files
        },
        {
            "name": "UML Modelling Guide",
            "source": "Modelling", 
            "output": pdf_output_dir / "Modelling",
            "files": ["summary_modelling.md"]
        }
    ]
    
    all_generated_pdfs = []
    
    for section in sections:
        print(f"\n📚 Processing {section['name']}...")
        print("-" * 40)
        
        source_path = Path(section["source"])
        
        if not source_path.exists():
            print(f"⚠️  Source directory {source_path} not found, skipping...")
            continue
        
        # Determine which files to process
        if section["files"] == "all":
            md_files = list(source_path.glob("*.md"))
        else:
            md_files = [source_path / filename for filename in section["files"] 
                       if (source_path / filename).exists()]
        
        if not md_files:
            print(f"⚠️  No markdown files found in {source_path}")
            continue
        
        # Process each file
        for md_file in md_files:
            pdf_path = convert_markdown_to_pdf_pandoc(
                md_file, 
                section["output"], 
                template_path
            )
            
            if pdf_path:
                all_generated_pdfs.append(pdf_path)
    
    # Generate summary
    print(f"\n📊 PDF Generation Summary")
    print("=" * 50)
    print(f"Total PDFs generated: {len(all_generated_pdfs)}")
    print(f"Output directory: {pdf_output_dir.absolute()}")
    
    if all_generated_pdfs:
        print("\n📁 Generated files:")
        for pdf_file in sorted(all_generated_pdfs):
            try:
                relative_path = pdf_file.relative_to(pdf_output_dir)
                size_mb = pdf_file.stat().st_size / (1024 * 1024)
                print(f"  • {relative_path} ({size_mb:.1f} MB)")
            except Exception:
                print(f"  • {pdf_file.name}")
    
    # Cleanup
    if template_path.exists():
        template_path.unlink()
    
    # Generate batch file for future use
    generate_batch_file()
    
    print(f"\n🎉 PDF generation complete!")
    print(f"📁 All PDFs saved to: {pdf_output_dir.absolute()}")
    print(f"🚀 Next time, you can run: generate_pdfs.bat")

if __name__ == "__main__":
    main()
