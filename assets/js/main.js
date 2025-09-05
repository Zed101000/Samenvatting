// PlayerMMO Design Patterns Website JavaScript

document.addEventListener('DOMContentLoaded', function() {
    // Mobile Navigation Toggle
    const navToggle = document.getElementById('nav-toggle');
    const navMenu = document.querySelector('.nav-menu');
    
    if (navToggle && navMenu) {
        navToggle.addEventListener('click', function() {
            navMenu.classList.toggle('active');
            
            // Animate hamburger menu
            const spans = navToggle.querySelectorAll('span');
            navToggle.classList.toggle('active');
            
            if (navToggle.classList.contains('active')) {
                spans[0].style.transform = 'rotate(45deg) translate(5px, 5px)';
                spans[1].style.opacity = '0';
                spans[2].style.transform = 'rotate(-45deg) translate(7px, -6px)';
            } else {
                spans[0].style.transform = '';
                spans[1].style.opacity = '';
                spans[2].style.transform = '';
            }
        });
        
        // Close mobile menu when clicking on a link
        const navLinks = navMenu.querySelectorAll('a');
        navLinks.forEach(link => {
            link.addEventListener('click', () => {
                navMenu.classList.remove('active');
                navToggle.classList.remove('active');
                
                const spans = navToggle.querySelectorAll('span');
                spans[0].style.transform = '';
                spans[1].style.opacity = '';
                spans[2].style.transform = '';
            });
        });
    }
    
    // Smooth scrolling for anchor links
    const anchorLinks = document.querySelectorAll('a[href^="#"]');
    anchorLinks.forEach(link => {
        link.addEventListener('click', function(e) {
            const href = this.getAttribute('href');
            
            if (href === '#') return;
            
            e.preventDefault();
            
            const target = document.querySelector(href);
            if (target) {
                const navHeight = document.querySelector('.main-nav').offsetHeight;
                const targetPosition = target.offsetTop - navHeight - 20;
                
                window.scrollTo({
                    top: targetPosition,
                    behavior: 'smooth'
                });
            }
        });
    });
    
    // Intersection Observer for fade-in animations
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };
    
    const observer = new IntersectionObserver(function(entries) {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('visible');
            }
        });
    }, observerOptions);
    
    // Observe elements for animation
    const animatedElements = document.querySelectorAll('.doc-card, .category-card, .pattern-tile, .download-card, .feature-item');
    animatedElements.forEach(el => {
        el.classList.add('fade-in');
        observer.observe(el);
    });
    
    // Active navigation highlighting
    const sections = document.querySelectorAll('section[id]');
    const navLinks = document.querySelectorAll('.nav-menu a[href^="#"]');
    
    function highlightNavigation() {
        const scrollPosition = window.scrollY + 100;
        
        sections.forEach(section => {
            const sectionTop = section.offsetTop;
            const sectionHeight = section.offsetHeight;
            const sectionId = section.getAttribute('id');
            
            if (scrollPosition >= sectionTop && scrollPosition < sectionTop + sectionHeight) {
                navLinks.forEach(link => {
                    link.classList.remove('active');
                    if (link.getAttribute('href') === `#${sectionId}`) {
                        link.classList.add('active');
                    }
                });
            }
        });
    }
    
    // Pattern search functionality
    function createPatternSearch() {
        const searchInput = document.createElement('input');
        searchInput.type = 'text';
        searchInput.placeholder = 'Search patterns...';
        searchInput.className = 'pattern-search';
        
        const patternsSection = document.getElementById('patterns');
        if (patternsSection) {
            const title = patternsSection.querySelector('.section-title');
            if (title) {
                title.parentNode.insertBefore(searchInput, title.nextSibling);
            }
        }
        
        searchInput.addEventListener('input', function() {
            const searchTerm = this.value.toLowerCase();
            const patternTiles = document.querySelectorAll('.pattern-tile');
            const categoryCards = document.querySelectorAll('.category-card');
            
            patternTiles.forEach(tile => {
                const patternName = tile.querySelector('.pattern-name').textContent.toLowerCase();
                const patternCategory = tile.querySelector('.pattern-category').textContent.toLowerCase();
                
                if (patternName.includes(searchTerm) || patternCategory.includes(searchTerm)) {
                    tile.style.display = 'flex';
                } else {
                    tile.style.display = searchTerm === '' ? 'flex' : 'none';
                }
            });
            
            // Also filter category cards
            if (searchTerm) {
                categoryCards.forEach(card => {
                    const categoryName = card.querySelector('h3').textContent.toLowerCase();
                    const patternLinks = card.querySelectorAll('.pattern-link');
                    let hasMatchingPattern = false;
                    
                    patternLinks.forEach(link => {
                        if (link.textContent.toLowerCase().includes(searchTerm)) {
                            hasMatchingPattern = true;
                        }
                    });
                    
                    if (categoryName.includes(searchTerm) || hasMatchingPattern) {
                        card.style.display = 'block';
                    } else {
                        card.style.display = 'none';
                    }
                });
            } else {
                categoryCards.forEach(card => {
                    card.style.display = 'block';
                });
            }
        });
    }
    
    // Theme toggle functionality
    function createThemeToggle() {
        const themeToggle = document.createElement('button');
        themeToggle.className = 'theme-toggle';
        themeToggle.innerHTML = '🌙';
        themeToggle.setAttribute('aria-label', 'Toggle dark mode');
        
        const nav = document.querySelector('.nav-content');
        if (nav) {
            nav.appendChild(themeToggle);
        }
        
        // Check for saved theme preference
        const savedTheme = localStorage.getItem('theme');
        if (savedTheme === 'dark') {
            document.body.classList.add('dark-theme');
            themeToggle.innerHTML = '☀️';
        }
        
        themeToggle.addEventListener('click', function() {
            document.body.classList.toggle('dark-theme');
            
            if (document.body.classList.contains('dark-theme')) {
                themeToggle.innerHTML = '☀️';
                localStorage.setItem('theme', 'dark');
            } else {
                themeToggle.innerHTML = '🌙';
                localStorage.setItem('theme', 'light');
            }
        });
    }
    
    // Tooltip functionality for pattern tiles
    function initializeTooltips() {
        const patternTiles = document.querySelectorAll('.pattern-tile');
        
        patternTiles.forEach(tile => {
            const patternName = tile.querySelector('.pattern-name').textContent;
            const descriptions = {
                'Abstract Factory': 'Provides an interface for creating families of related objects',
                'Builder': 'Constructs complex objects step by step',
                'Factory Method': 'Creates objects without specifying their concrete classes',
                'Singleton': 'Ensures a class has only one instance',
                'Command': 'Encapsulates a request as an object',
                'Iterator': 'Provides sequential access to elements of a collection',
                'Observer': 'Defines a one-to-many dependency between objects',
                'State': 'Allows an object to alter its behavior when its state changes',
                'Strategy': 'Defines a family of algorithms and makes them interchangeable',
                'Template Method': 'Defines the skeleton of an algorithm in a base class',
                'Adapter': 'Allows incompatible interfaces to work together',
                'Composite': 'Composes objects into tree structures',
                'Decorator': 'Adds behavior to objects dynamically',
                'Facade': 'Provides a simplified interface to a complex subsystem',
                'Proxy': 'Provides a placeholder or surrogate for another object'
            };
            
            tile.setAttribute('title', descriptions[patternName] || '');
        });
    }
    
    // Back to top button
    function createBackToTopButton() {
        const backToTop = document.createElement('button');
        backToTop.className = 'back-to-top';
        backToTop.innerHTML = '↑';
        backToTop.setAttribute('aria-label', 'Back to top');
        document.body.appendChild(backToTop);
        
        window.addEventListener('scroll', function() {
            if (window.scrollY > 300) {
                backToTop.classList.add('visible');
            } else {
                backToTop.classList.remove('visible');
            }
        });
        
        backToTop.addEventListener('click', function() {
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        });
    }
    
    // Progress indicator
    function createProgressIndicator() {
        const progress = document.createElement('div');
        progress.className = 'progress-indicator';
        document.body.appendChild(progress);
        
        window.addEventListener('scroll', function() {
            const windowHeight = document.documentElement.scrollHeight - window.innerHeight;
            const scrolled = (window.scrollY / windowHeight) * 100;
            progress.style.width = scrolled + '%';
        });
    }
    
    // Lazy loading for images (if any)
    function initializeLazyLoading() {
        const images = document.querySelectorAll('img[data-src]');
        
        const imageObserver = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const img = entry.target;
                    img.src = img.dataset.src;
                    img.classList.remove('lazy');
                    imageObserver.unobserve(img);
                }
            });
        });
        
        images.forEach(img => imageObserver.observe(img));
    }
    
    // Pattern statistics
    function displayPatternStatistics() {
        const stats = {
            creational: document.querySelectorAll('.creational-tile').length,
            behavioral: document.querySelectorAll('.behavioral-tile').length,
            structural: document.querySelectorAll('.structural-tile').length
        };
        
        // Update pattern counts in category cards
        const categoryCards = document.querySelectorAll('.category-card');
        categoryCards.forEach(card => {
            const countElement = card.querySelector('.pattern-count');
            if (countElement) {
                const categoryType = card.classList.contains('creational') ? 'creational' :
                                   card.classList.contains('behavioral') ? 'behavioral' : 'structural';
                countElement.textContent = `${stats[categoryType]} Pattern${stats[categoryType] !== 1 ? 's' : ''}`;
            }
        });
    }
    
    // Initialize all features
    window.addEventListener('scroll', highlightNavigation);
    
    // Initialize optional features
    createPatternSearch();
    createThemeToggle();
    initializeTooltips();
    createBackToTopButton();
    createProgressIndicator();
    initializeLazyLoading();
    displayPatternStatistics();
    
    // Keyboard navigation
    document.addEventListener('keydown', function(e) {
        // ESC key closes mobile menu
        if (e.key === 'Escape' && navMenu && navMenu.classList.contains('active')) {
            navMenu.classList.remove('active');
            navToggle.classList.remove('active');
        }
        
        // Alt + number keys for quick navigation
        if (e.altKey && !isNaN(e.key)) {
            const num = parseInt(e.key);
            const navItems = document.querySelectorAll('.nav-menu a');
            if (navItems[num - 1]) {
                navItems[num - 1].click();
            }
        }
    });
    
    // Performance monitoring
    if ('performance' in window) {
        window.addEventListener('load', function() {
            setTimeout(() => {
                const perfData = performance.getEntriesByType('navigation')[0];
                console.log('Page load time:', perfData.loadEventEnd - perfData.loadEventStart, 'ms');
            }, 0);
        });
    }
    
    // Error handling for missing elements
    window.addEventListener('error', function(e) {
        console.warn('Non-critical error:', e.message);
    });
    
    console.log('PlayerMMO Design Patterns website initialized successfully!');
});

// Additional styles for new components
const additionalStyles = `
    .pattern-search {
        width: 100%;
        max-width: 400px;
        margin: 0 auto 2rem;
        padding: 12px 16px;
        border: 2px solid var(--border-color);
        border-radius: var(--border-radius);
        font-size: 1rem;
        transition: var(--transition);
        display: block;
    }
    
    .pattern-search:focus {
        outline: none;
        border-color: var(--secondary-color);
        box-shadow: 0 0 0 3px rgba(52, 152, 219, 0.1);
    }
    
    .theme-toggle {
        background: none;
        border: none;
        font-size: 1.5rem;
        cursor: pointer;
        padding: 0.5rem;
        border-radius: 50%;
        transition: var(--transition);
    }
    
    .theme-toggle:hover {
        background-color: var(--bg-light);
    }
    
    .back-to-top {
        position: fixed;
        bottom: 20px;
        right: 20px;
        width: 50px;
        height: 50px;
        background-color: var(--secondary-color);
        color: white;
        border: none;
        border-radius: 50%;
        font-size: 1.5rem;
        cursor: pointer;
        opacity: 0;
        visibility: hidden;
        transition: var(--transition);
        z-index: 1000;
    }
    
    .back-to-top.visible {
        opacity: 1;
        visibility: visible;
    }
    
    .back-to-top:hover {
        background-color: var(--primary-color);
        transform: translateY(-2px);
    }
    
    .progress-indicator {
        position: fixed;
        top: 0;
        left: 0;
        height: 3px;
        background-color: var(--secondary-color);
        z-index: 1001;
        transition: width 0.3s ease;
    }
    
    .nav-menu a.active {
        background-color: var(--secondary-color);
        color: white;
    }
    
    .dark-theme {
        --bg-color: #1a1a1a;
        --bg-light: #2d2d2d;
        --bg-dark: #0f0f0f;
        --text-color: #e0e0e0;
        --text-light: #b0b0b0;
        --border-color: #404040;
    }
    
    .lazy {
        opacity: 0;
        transition: opacity 0.3s;
    }
    
    @media (max-width: 768px) {
        .pattern-search {
            margin: 1rem auto;
        }
        
        .theme-toggle {
            order: -1;
            margin-right: 1rem;
        }
    }
`;

// Inject additional styles
const styleSheet = document.createElement('style');
styleSheet.textContent = additionalStyles;
document.head.appendChild(styleSheet);
