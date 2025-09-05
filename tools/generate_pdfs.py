#!/usr/bin/env python3
"""
PDF Generator for PlayerMMO Design Patterns and Modelling Summaries
Converts all markdown documentation to professional PDF format
"""

import os
import sys
import subprocess
from pathlib import Path
from datetime import datetime

def check_dependencies():
    """Check if required dependencies are installed"""
    required_packages = ['markdown', 'weasyprint', 'pygments']
    missing_packages = []
    
    for package in required_packages:
        try:
            __import__(package.replace('-', '_'))
        except ImportError:
            missing_packages.append(package)
    
    if missing_packages:
        print("Missing required packages. Installing...")
        for package in missing_packages:
            subprocess.run([sys.executable, '-m', 'pip', 'install', package], check=True)
        print("Dependencies installed successfully!")

def setup_css_styles():
    """Create CSS styles for PDF generation"""
    css_content = """
/* Professional PDF Styling for PlayerMMO Documentation */

@page {
    size: A4;
    margin: 2cm 1.5cm;
    @top-center {
        content: "PlayerMMO Design Patterns Documentation";
        font-family: 'Arial', sans-serif;
        font-size: 10pt;
        color: #666;
        border-bottom: 1px solid #ddd;
        padding-bottom: 5px;
    }
    @bottom-center {
        content: "Page " counter(page) " of " counter(pages);
        font-family: 'Arial', sans-serif;
        font-size: 9pt;
        color: #666;
    }
}

body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    line-height: 1.6;
    color: #333;
    font-size: 11pt;
}

/* Headings */
h1 {
    color: #2c3e50;
    font-size: 24pt;
    font-weight: bold;
    margin-top: 0;
    margin-bottom: 20pt;
    padding-bottom: 10pt;
    border-bottom: 3px solid #3498db;
    page-break-before: avoid;
}

h2 {
    color: #34495e;
    font-size: 18pt;
    font-weight: bold;
    margin-top: 25pt;
    margin-bottom: 12pt;
    page-break-after: avoid;
}

h3 {
    color: #2c3e50;
    font-size: 14pt;
    font-weight: bold;
    margin-top: 20pt;
    margin-bottom: 10pt;
    page-break-after: avoid;
}

h4 {
    color: #34495e;
    font-size: 12pt;
    font-weight: bold;
    margin-top: 15pt;
    margin-bottom: 8pt;
}

/* Paragraphs and text */
p {
    margin-bottom: 10pt;
    text-align: justify;
}

/* Lists */
ul, ol {
    margin-bottom: 12pt;
    padding-left: 20pt;
}

li {
    margin-bottom: 4pt;
}

/* Code blocks */
pre {
    background-color: #f8f9fa;
    border: 1px solid #e9ecef;
    border-radius: 4px;
    padding: 12pt;
    margin: 12pt 0;
    font-family: 'Consolas', 'Monaco', 'Courier New', monospace;
    font-size: 9pt;
    line-height: 1.4;
    overflow-x: auto;
    page-break-inside: avoid;
}

code {
    background-color: #f1f3f4;
    padding: 2pt 4pt;
    border-radius: 3px;
    font-family: 'Consolas', 'Monaco', 'Courier New', monospace;
    font-size: 9pt;
}

/* Tables */
table {
    border-collapse: collapse;
    width: 100%;
    margin: 12pt 0;
    page-break-inside: avoid;
}

th, td {
    border: 1px solid #ddd;
    padding: 8pt;
    text-align: left;
    font-size: 10pt;
}

th {
    background-color: #f2f2f2;
    font-weight: bold;
    color: #2c3e50;
}

/* Blockquotes */
blockquote {
    border-left: 4px solid #3498db;
    margin: 12pt 0;
    padding-left: 12pt;
    font-style: italic;
    color: #555;
    background-color: #f8f9fa;
    padding: 12pt;
    border-radius: 0 4px 4px 0;
}

/* Images */
img {
    max-width: 100%;
    height: auto;
    margin: 12pt 0;
    page-break-inside: avoid;
}

/* Links */
a {
    color: #3498db;
    text-decoration: none;
}

a:hover {
    text-decoration: underline;
}

/* Special formatting */
.emoji {
    font-size: 12pt;
}

/* Pattern-specific styling */
.pattern-overview {
    background-color: #f8f9fa;
    border: 1px solid #dee2e6;
    border-radius: 6px;
    padding: 15pt;
    margin: 15pt 0;
}

.code-example {
    background-color: #f8f9fa;
    border-left: 4px solid #28a745;
    padding: 12pt;
    margin: 12pt 0;
}

/* Page breaks */
.page-break {
    page-break-before: always;
}

/* Table of contents styling */
.toc {
    background-color: #f8f9fa;
    border: 1px solid #dee2e6;
    padding: 15pt;
    margin-bottom: 25pt;
}

.toc ul {
    list-style-type: none;
    padding-left: 0;
}

.toc li {
    margin-bottom: 6pt;
}

/* Ensure proper spacing around sections */
section {
    margin-bottom: 20pt;
}

/* Status badges */
.status-badge {
    display: inline-block;
    padding: 2pt 6pt;
    border-radius: 3px;
    font-size: 8pt;
    font-weight: bold;
    color: white;
}

.status-complete {
    background-color: #28a745;
}

.status-inprogress {
    background-color: #ffc107;
    color: #333;
}

/* Highlight boxes */
.highlight-box {
    background-color: #e3f2fd;
    border: 1px solid #2196f3;
    border-radius: 4px;
    padding: 12pt;
    margin: 12pt 0;
}

.warning-box {
    background-color: #fff3cd;
    border: 1px solid #ffc107;
    border-radius: 4px;
    padding: 12pt;
    margin: 12pt 0;
}

.success-box {
    background-color: #d4edda;
    border: 1px solid #28a745;
    border-radius: 4px;
    padding: 12pt;
    margin: 12pt 0;
}
"""
    
    css_path = Path("pdf_styles.css")
    with open(css_path, 'w', encoding='utf-8') as f:
        f.write(css_content)
    
    return css_path

def convert_markdown_to_html(md_file_path, output_dir):
    """Convert markdown file to HTML with proper formatting"""
    import markdown
    from markdown.extensions import codehilite, tables, toc
    
    # Read markdown content
    with open(md_file_path, 'r', encoding='utf-8') as f:
        md_content = f.read()
    
    # Configure markdown processor
    md = markdown.Markdown(extensions=[
        'codehilite',
        'tables',
        'toc',
        'fenced_code',
        'attr_list',
        'def_list',
        'footnotes',
        'md_in_html'
    ])
    
    # Convert to HTML
    html_content = md.convert(md_content)
    
    # Create complete HTML document
    file_name = Path(md_file_path).stem
    html_template = f"""<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>{file_name} - PlayerMMO Documentation</title>
    <link rel="stylesheet" href="pdf_styles.css">
</head>
<body>
    <div class="document-header">
        <h1>PlayerMMO Design Patterns</h1>
        <p><strong>Document:</strong> {file_name}</p>
        <p><strong>Generated:</strong> {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}</p>
        <hr/>
    </div>
    
    <div class="content">
        {html_content}
    </div>
    
    <div class="document-footer">
        <hr/>
        <p><em>Generated from PlayerMMO Design Patterns Documentation</em></p>
    </div>
</body>
</html>"""
    
    # Save HTML file
    html_file_path = output_dir / f"{file_name}.html"
    with open(html_file_path, 'w', encoding='utf-8') as f:
        f.write(html_template)
    
    return html_file_path

def convert_html_to_pdf(html_file_path, pdf_file_path, css_file_path):
    """Convert HTML file to PDF using WeasyPrint"""
    try:
        from weasyprint import HTML, CSS
        
        print(f"Converting {html_file_path.name} to PDF...")
        
        # Configure WeasyPrint
        html_doc = HTML(filename=str(html_file_path))
        css_doc = CSS(filename=str(css_file_path))
        
        # Generate PDF
        html_doc.write_pdf(
            str(pdf_file_path),
            stylesheets=[css_doc],
            optimize_images=True
        )
        
        print(f"✓ Generated: {pdf_file_path}")
        return True
        
    except Exception as e:
        print(f"✗ Error converting {html_file_path.name}: {str(e)}")
        return False

def generate_pdfs_for_directory(source_dir, output_dir, css_file_path):
    """Generate PDFs for all markdown files in a directory"""
    source_path = Path(source_dir)
    output_path = Path(output_dir)
    
    # Create output directory if it doesn't exist
    output_path.mkdir(parents=True, exist_ok=True)
    
    # Find all markdown files
    md_files = list(source_path.glob("*.md"))
    
    if not md_files:
        print(f"No markdown files found in {source_dir}")
        return []
    
    generated_pdfs = []
    
    for md_file in md_files:
        try:
            # Convert markdown to HTML
            html_file = convert_markdown_to_html(md_file, output_path)
            
            # Convert HTML to PDF
            pdf_file = output_path / f"{md_file.stem}.pdf"
            
            if convert_html_to_pdf(html_file, pdf_file, css_file_path):
                generated_pdfs.append(pdf_file)
            
            # Clean up HTML file
            html_file.unlink()
            
        except Exception as e:
            print(f"✗ Error processing {md_file.name}: {str(e)}")
    
    return generated_pdfs

def main():
    """Main function to generate all PDFs"""
    print("🔄 PlayerMMO Documentation PDF Generator")
    print("=" * 50)
    
    # Check and install dependencies
    print("📦 Checking dependencies...")
    check_dependencies()
    
    # Setup CSS styles
    print("🎨 Setting up PDF styles...")
    css_file_path = setup_css_styles()
    
    # Define source and output directories
    base_dir = Path(".")
    pdf_output_dir = base_dir / "PDFs"
    
    # Create main PDF output directory
    pdf_output_dir.mkdir(exist_ok=True)
    
    # Generate PDFs for different sections
    sections = [
        {
            "name": "Design Patterns Summaries",
            "source": "PlayerMMO/Summaries",
            "output": pdf_output_dir / "DesignPatterns"
        },
        {
            "name": "Modelling Documentation", 
            "source": "Modelling",
            "output": pdf_output_dir / "Modelling"
        },
        {
            "name": "Main Documentation",
            "source": ".",
            "output": pdf_output_dir / "Main"
        }
    ]
    
    all_generated_pdfs = []
    
    for section in sections:
        print(f"\n📄 Generating PDFs for {section['name']}...")
        print("-" * 40)
        
        # Check if source directory exists
        if not Path(section["source"]).exists():
            print(f"⚠️  Source directory {section['source']} not found, skipping...")
            continue
        
        generated = generate_pdfs_for_directory(
            section["source"],
            section["output"], 
            css_file_path
        )
        
        all_generated_pdfs.extend(generated)
        print(f"✓ Generated {len(generated)} PDFs for {section['name']}")
    
    # Generate summary report
    print(f"\n📊 PDF Generation Summary")
    print("=" * 50)
    print(f"Total PDFs generated: {len(all_generated_pdfs)}")
    print(f"Output directory: {pdf_output_dir.absolute()}")
    
    if all_generated_pdfs:
        print("\n📁 Generated files:")
        for pdf_file in sorted(all_generated_pdfs):
            relative_path = pdf_file.relative_to(pdf_output_dir)
            print(f"  • {relative_path}")
    
    # Cleanup temporary files
    if css_file_path.exists():
        css_file_path.unlink()
    
    print(f"\n🎉 PDF generation complete!")
    print(f"All PDFs saved to: {pdf_output_dir.absolute()}")

if __name__ == "__main__":
    main()
