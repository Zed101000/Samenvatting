#!/usr/bin/env python3
"""
Simple PDF Generator using Python built-in libraries
Creates PDFs from markdown files without external dependencies
"""

import os
import sys
import re
from pathlib import Path
from datetime import datetime
from html import escape

def install_required_packages():
    """Install required packages using pip"""
    packages = ['markdown', 'weasyprint']
    
    for package in packages:
        try:
            __import__(package.replace('-', '_'))
            print(f"✓ {package} already installed")
        except ImportError:
            print(f"📦 Installing {package}...")
            try:
                import subprocess
                subprocess.check_call([sys.executable, '-m', 'pip', 'install', package])
                print(f"✓ {package} installed successfully")
            except subprocess.CalledProcessError as e:
                print(f"❌ Failed to install {package}: {e}")
                return False
    
    return True

def create_simple_html_converter():
    """Create a simple markdown to HTML converter without external dependencies"""
    
    def convert_markdown_to_html(md_content, title="Document"):
        """Simple markdown to HTML conversion"""
        
        # Basic markdown patterns
        patterns = [
            # Headers
            (r'^# (.+)$', r'<h1>\1</h1>'),
            (r'^## (.+)$', r'<h2>\1</h2>'),
            (r'^### (.+)$', r'<h3>\1</h3>'),
            (r'^#### (.+)$', r'<h4>\1</h4>'),
            
            # Bold and italic
            (r'\*\*(.+?)\*\*', r'<strong>\1</strong>'),
            (r'\*(.+?)\*', r'<em>\1</em>'),
            
            # Code blocks (simple)
            (r'```(\w+)?\n(.*?)\n```', r'<pre><code>\2</code></pre>'),
            (r'`(.+?)`', r'<code>\1</code>'),
            
            # Links
            (r'\[(.+?)\]\((.+?)\)', r'<a href="\2">\1</a>'),
            
            # Images
            (r'!\[(.+?)\]\((.+?)\)', r'<img src="\2" alt="\1" style="max-width:100%;">'),
            
            # Lists (simple)
            (r'^\- (.+)$', r'<li>\1</li>'),
            (r'^\* (.+)$', r'<li>\1</li>'),
        ]
        
        # Split into lines for processing
        lines = md_content.split('\n')
        html_lines = []
        in_list = False
        in_code_block = False
        code_buffer = []
        
        for line in lines:
            # Handle code blocks
            if line.strip().startswith('```'):
                if in_code_block:
                    # End code block
                    html_lines.append('<pre><code>')
                    html_lines.extend(escape(l) for l in code_buffer)
                    html_lines.append('</code></pre>')
                    code_buffer = []
                    in_code_block = False
                else:
                    # Start code block
                    in_code_block = True
                continue
            
            if in_code_block:
                code_buffer.append(line)
                continue
            
            # Handle lists
            if line.strip().startswith(('- ', '* ')):
                if not in_list:
                    html_lines.append('<ul>')
                    in_list = True
                
                # Apply basic patterns to line
                processed_line = line
                for pattern, replacement in patterns:
                    processed_line = re.sub(pattern, replacement, processed_line, flags=re.MULTILINE)
                html_lines.append(processed_line)
            else:
                if in_list:
                    html_lines.append('</ul>')
                    in_list = False
                
                # Apply patterns to line
                processed_line = line
                for pattern, replacement in patterns:
                    processed_line = re.sub(pattern, replacement, processed_line, flags=re.MULTILINE)
                
                # Add paragraph tags for non-empty, non-header lines
                if processed_line.strip() and not processed_line.strip().startswith('<h'):
                    if not processed_line.strip().startswith('<'):
                        processed_line = f'<p>{processed_line}</p>'
                
                html_lines.append(processed_line)
        
        # Close any open list
        if in_list:
            html_lines.append('</ul>')
        
        return '\n'.join(html_lines)
    
    return convert_markdown_to_html

def create_css_styles():
    """Create CSS styles for PDF"""
    return """
    <style>
        @page {
            size: A4;
            margin: 2cm;
        }
        
        body {
            font-family: 'Segoe UI', Arial, sans-serif;
            line-height: 1.6;
            color: #333;
            max-width: 800px;
            margin: 0 auto;
        }
        
        h1 {
            color: #2c3e50;
            font-size: 24px;
            border-bottom: 3px solid #3498db;
            padding-bottom: 10px;
            margin-bottom: 20px;
        }
        
        h2 {
            color: #34495e;
            font-size: 20px;
            margin-top: 30px;
            margin-bottom: 15px;
        }
        
        h3 {
            color: #2c3e50;
            font-size: 16px;
            margin-top: 25px;
            margin-bottom: 10px;
        }
        
        h4 {
            color: #34495e;
            font-size: 14px;
            margin-top: 20px;
            margin-bottom: 8px;
        }
        
        p {
            margin-bottom: 12px;
            text-align: justify;
        }
        
        code {
            background-color: #f1f3f4;
            padding: 2px 4px;
            border-radius: 3px;
            font-family: 'Consolas', 'Monaco', monospace;
            font-size: 90%;
        }
        
        pre {
            background-color: #f8f9fa;
            border: 1px solid #e9ecef;
            border-radius: 4px;
            padding: 15px;
            overflow-x: auto;
            margin: 15px 0;
        }
        
        pre code {
            background: none;
            padding: 0;
            font-family: 'Consolas', 'Monaco', monospace;
            font-size: 12px;
        }
        
        ul, ol {
            margin-bottom: 15px;
            padding-left: 25px;
        }
        
        li {
            margin-bottom: 5px;
        }
        
        a {
            color: #3498db;
            text-decoration: none;
        }
        
        a:hover {
            text-decoration: underline;
        }
        
        img {
            max-width: 100%;
            height: auto;
            margin: 15px 0;
            border: 1px solid #ddd;
            border-radius: 4px;
        }
        
        table {
            border-collapse: collapse;
            width: 100%;
            margin: 15px 0;
        }
        
        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        
        th {
            background-color: #f2f2f2;
            font-weight: bold;
        }
        
        blockquote {
            border-left: 4px solid #3498db;
            margin: 15px 0;
            padding-left: 15px;
            font-style: italic;
            background-color: #f8f9fa;
            padding: 15px;
        }
        
        .document-header {
            text-align: center;
            margin-bottom: 40px;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 8px;
        }
        
        .document-footer {
            margin-top: 40px;
            padding-top: 20px;
            border-top: 1px solid #ddd;
            text-align: center;
            font-size: 12px;
            color: #666;
        }
        
        .toc {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 6px;
            margin-bottom: 30px;
        }
        
        .page-break {
            page-break-before: always;
        }
    </style>
    """

def convert_markdown_to_html_file(md_file_path, output_dir):
    """Convert markdown file to standalone HTML"""
    
    # Read markdown content
    with open(md_file_path, 'r', encoding='utf-8') as f:
        md_content = f.read()
    
    # Get converter
    md_to_html = create_simple_html_converter()
    
    # Convert content
    html_content = md_to_html(md_content)
    
    # Create complete HTML document
    file_name = Path(md_file_path).stem
    title = file_name.replace('_', ' ').replace('-', ' ').title()
    
    html_document = f"""<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>{title} - PlayerMMO Documentation</title>
    {create_css_styles()}
</head>
<body>
    <div class="document-header">
        <h1>PlayerMMO Design Patterns</h1>
        <h2>{title}</h2>
        <p><strong>Generated:</strong> {datetime.now().strftime('%B %d, %Y at %H:%M:%S')}</p>
    </div>
    
    <div class="content">
        {html_content}
    </div>
    
    <div class="document-footer">
        <p><em>Generated from PlayerMMO Design Patterns Documentation</em></p>
        <p>© 2025 PlayerMMO Project</p>
    </div>
</body>
</html>"""
    
    # Save HTML file
    output_path = Path(output_dir)
    output_path.mkdir(parents=True, exist_ok=True)
    
    html_file_path = output_path / f"{file_name}.html"
    with open(html_file_path, 'w', encoding='utf-8') as f:
        f.write(html_document)
    
    return html_file_path

def convert_html_to_pdf_with_weasyprint(html_file_path, pdf_file_path):
    """Convert HTML to PDF using WeasyPrint if available"""
    try:
        from weasyprint import HTML
        
        print(f"  Converting {html_file_path.name} to PDF...")
        html_doc = HTML(filename=str(html_file_path))
        html_doc.write_pdf(str(pdf_file_path))
        
        return True
        
    except ImportError:
        print("  WeasyPrint not available, HTML file created instead")
        return False
    except Exception as e:
        print(f"  Error with WeasyPrint: {e}")
        return False

def generate_pdfs_simple():
    """Simple PDF generation without complex dependencies"""
    
    print("🔄 PlayerMMO Simple PDF Generator")
    print("=" * 40)
    
    # Try to install packages
    print("📦 Checking/installing packages...")
    weasyprint_available = install_required_packages()
    
    # Define source directories and files
    base_dir = Path(".")
    output_dir = base_dir / "PDFs"
    
    # Create output directory
    output_dir.mkdir(exist_ok=True)
    
    # Files to convert
    files_to_convert = [
        {
            "path": "README.md",
            "output": output_dir / "Main",
            "name": "Project Overview"
        },
        {
            "path": "PlayerMMO/README.md", 
            "output": output_dir / "PlayerMMO",
            "name": "PlayerMMO Overview"
        },
        {
            "path": "Modelling/summary_modelling.md",
            "output": output_dir / "Modelling", 
            "name": "UML Modelling Guide"
        }
    ]
    
    # Add all pattern summaries
    summaries_dir = Path("PlayerMMO/Summaries")
    if summaries_dir.exists():
        for md_file in summaries_dir.glob("*.md"):
            files_to_convert.append({
                "path": str(md_file),
                "output": output_dir / "DesignPatterns",
                "name": md_file.stem.replace('_', ' ').title()
            })
    
    # Convert files
    converted_files = []
    html_files = []
    
    print(f"\n📄 Converting {len(files_to_convert)} files...")
    print("-" * 40)
    
    for file_info in files_to_convert:
        file_path = Path(file_info["path"])
        
        if not file_path.exists():
            print(f"⚠️  {file_path} not found, skipping...")
            continue
        
        print(f"📝 Processing: {file_info['name']}")
        
        try:
            # Convert to HTML
            html_file = convert_markdown_to_html_file(file_path, file_info["output"])
            html_files.append(html_file)
            
            # Try to convert to PDF if WeasyPrint is available
            if weasyprint_available:
                pdf_file = file_info["output"] / f"{file_path.stem}.pdf"
                if convert_html_to_pdf_with_weasyprint(html_file, pdf_file):
                    converted_files.append(pdf_file)
                    # Remove HTML file if PDF was created successfully
                    html_file.unlink()
                else:
                    print(f"  ✓ HTML created: {html_file}")
            else:
                print(f"  ✓ HTML created: {html_file}")
                
        except Exception as e:
            print(f"  ❌ Error processing {file_path}: {e}")
    
    # Generate summary
    print(f"\n📊 Conversion Summary")
    print("=" * 40)
    
    if weasyprint_available and converted_files:
        print(f"✓ PDFs generated: {len(converted_files)}")
        print(f"📁 PDF location: {output_dir.absolute()}")
        
        for pdf_file in sorted(converted_files):
            try:
                relative_path = pdf_file.relative_to(output_dir)
                size_kb = pdf_file.stat().st_size / 1024
                print(f"  • {relative_path} ({size_kb:.1f} KB)")
            except Exception:
                print(f"  • {pdf_file.name}")
    
    if html_files:
        print(f"✓ HTML files created: {len(html_files)}")
        print("💡 Open HTML files in your browser and use 'Print to PDF' to convert them")
    
    print(f"\n📂 All files saved to: {output_dir.absolute()}")
    
    # Create instructions file
    instructions_file = output_dir / "README.txt"
    with open(instructions_file, 'w') as f:
        f.write(f"""PlayerMMO Documentation Files
Generated: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}

This folder contains the generated documentation files for the PlayerMMO project.

Files Generated:
- PDFs: Professional formatted documents (if WeasyPrint was available)
- HTML: Web-formatted documents that can be viewed in any browser

To convert HTML to PDF manually:
1. Open the HTML file in your web browser
2. Press Ctrl+P (or Cmd+P on Mac) to print
3. Choose "Save as PDF" as the destination
4. Adjust settings as needed and save

Folder Structure:
- Main/: Project overview and main documentation
- PlayerMMO/: PlayerMMO system overview
- DesignPatterns/: Individual design pattern guides  
- Modelling/: UML modeling documentation

For the latest version, visit the source repository.
""")
    
    print("🎉 Documentation generation complete!")
    print(f"📖 Instructions saved to: {instructions_file}")

def main():
    """Main entry point"""
    try:
        generate_pdfs_simple()
    except KeyboardInterrupt:
        print("\n\n❌ Generation cancelled by user")
    except Exception as e:
        print(f"\n❌ Error during generation: {e}")
        print("Please check the error and try again")

if __name__ == "__main__":
    main()
