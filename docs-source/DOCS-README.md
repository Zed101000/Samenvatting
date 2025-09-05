# Documentation Source Files

This directory contains the original markdown documentation files that are used to generate the HTML documentation in the `/docs` directory.

## 📁 Structure

```
docs-source/
├── README.md                    # PlayerMMO system overview (original)
├── summary_modelling.md         # UML modeling guide (original)
└── patterns/                    # Individual pattern documentation
    ├── AbstractFactory.md
    ├── Adapter.md
    ├── BehavioralPatterns.md
    ├── Builder.md
    ├── Command.md
    ├── Composite.md
    ├── CreationalPatterns.md
    ├── Decorator.md
    ├── Facade.md
    ├── FactoryMethod.md
    ├── Iterator.md
    ├── Observer.md
    ├── Proxy.md
    ├── README.md                # Patterns overview
    ├── Singleton.md
    ├── State.md
    ├── Strategy.md
    ├── StructuralPatterns.md
    └── TemplateMethod.md
```

## 🔄 Workflow

1. **Edit Source**: Modify markdown files in this directory
2. **Generate HTML**: Use tools to convert markdown to HTML
3. **Deploy**: HTML files in `/docs` are automatically deployed to GitHub Pages

## 📝 Editing Guidelines

### Markdown Standards
- Use standard Markdown syntax
- Include proper headings hierarchy (h1 → h2 → h3)
- Add code blocks with language specification
- Use relative links for internal references

### Pattern Documentation Structure
Each pattern should include:
1. **Overview** - Brief description and purpose
2. **Problem** - What problem does it solve?
3. **Solution** - How does the pattern work?
4. **Implementation** - C# code examples
5. **UML Diagrams** - Visual representation
6. **Use Cases** - When to use the pattern
7. **Best Practices** - Tips and recommendations

### UML Documentation
- Include diagram descriptions
- Explain notation and symbols
- Provide practical examples
- Reference relevant standards

## 🛠️ Generation

To convert these markdown files to HTML:

```bash
# Using the simple PDF generator (also creates HTML)
python tools/generate_pdfs_simple.py

# Manual conversion (if needed)
# Use any markdown to HTML converter
```

## ✅ Quality Checklist

Before committing changes:
- [ ] Spell check completed
- [ ] Code examples tested
- [ ] Links verified
- [ ] Proper markdown formatting
- [ ] UML diagrams referenced correctly
- [ ] Cross-references updated
