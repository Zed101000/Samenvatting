#!/bin/bash
# GitHub Pages Setup Script for PlayerMMO Design Patterns

echo "🚀 PlayerMMO Design Patterns - GitHub Pages Setup"
echo "=================================================="

# Check if we're in a git repository
if [ ! -d ".git" ]; then
    echo "❌ Not in a git repository. Please run this from the repository root."
    exit 1
fi

echo "📋 Checking repository status..."

# Check current branch
current_branch=$(git branch --show-current)
echo "Current branch: $current_branch"

# Check for uncommitted changes
if [[ -n $(git status --porcelain) ]]; then
    echo "⚠️  You have uncommitted changes. Please commit them first."
    echo ""
    echo "📝 To commit your changes:"
    echo "   git add ."
    echo "   git commit -m \"Add GitHub Pages website\""
    echo "   git push origin main"
    echo ""
    read -p "Continue anyway? (y/N): " confirm
    if [[ $confirm != [yY] ]]; then
        exit 1
    fi
fi

echo ""
echo "🔧 GitHub Pages Configuration"
echo "=============================="

# Check if GitHub Pages is already configured
echo "To enable GitHub Pages for your repository:"
echo ""
echo "1. Go to your repository on GitHub:"
echo "   https://github.com/Zed101000/Samenvatting"
echo ""
echo "2. Click on 'Settings' tab"
echo ""
echo "3. Scroll down to 'Pages' section in the left sidebar"
echo ""
echo "4. Under 'Source', select 'GitHub Actions'"
echo ""
echo "5. The workflow will automatically deploy your site to:"
echo "   https://zed101000.github.io/Samenvatting"
echo ""

echo "📦 Files created for GitHub Pages:"
echo "=================================="
echo "✅ index.html              - Main website homepage"
echo "✅ docs/                   - Documentation pages"
echo "✅ assets/css/style.css    - Website styling"
echo "✅ assets/js/main.js       - Interactive functionality"
echo "✅ _config.yml             - GitHub Pages configuration"
echo "✅ .github/workflows/      - GitHub Actions deployment"
echo "✅ 404.html                - Custom error page"
echo "✅ sitemap.xml             - SEO sitemap"
echo "✅ robots.txt              - Search engine instructions"
echo ""

echo "🌐 Website Features:"
echo "==================="
echo "• Responsive design for all devices"
echo "• Dark/light theme toggle"
echo "• Interactive pattern search"
echo "• Smooth scrolling navigation"
echo "• SEO optimized"
echo "• Progressive enhancement"
echo ""

echo "📱 Testing Locally:"
echo "=================="
echo "To test the website locally before deploying:"
echo ""
echo "Option 1 - Python:"
echo "   python -m http.server 8000"
echo "   # Then visit http://localhost:8000"
echo ""
echo "Option 2 - Node.js:"
echo "   npx serve ."
echo "   # Then visit http://localhost:3000"
echo ""
echo "Option 3 - PHP:"
echo "   php -S localhost:8000"
echo "   # Then visit http://localhost:8000"
echo ""

echo "🚀 Deployment Steps:"
echo "==================="
echo "1. Commit and push your changes:"
echo "   git add ."
echo "   git commit -m \"Add GitHub Pages website\""
echo "   git push origin main"
echo ""
echo "2. Enable GitHub Pages in repository settings"
echo ""
echo "3. Wait for deployment (usually 2-5 minutes)"
echo ""
echo "4. Visit your live site:"
echo "   https://zed101000.github.io/Samenvatting"
echo ""

echo "📧 Next Steps:"
echo "=============="
echo "• Customize the website content if needed"
echo "• Update repository description and topics"
echo "• Add a custom domain (optional)"
echo "• Set up Google Analytics (optional)"
echo ""

echo "✨ Your PlayerMMO Design Patterns website is ready!"
echo "Check the live site at: https://zed101000.github.io/Samenvatting"
