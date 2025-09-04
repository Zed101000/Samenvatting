# 📚 Software Design Patterns Course Overview

This course provides an overview of the main categories of design patterns in software engineering, their purpose, and typical applications.

---
## Module 0: How to read UML

![Legende](Puml/legend.png)



## Module 1: 🏗️ Creational Patterns
**Goal:** Simplify and structure object creation.

### Lessons:

1. **Singleton**
   - **Purpose:** Ensure only one instance of a class exists.
   - **Applications:** Configuration management, logging, database connections.
   
   ![Singleton UML](Puml/Creational/Singleton.png)


2. **Factory Method**
   - **Purpose:** Let subclasses decide which object to instantiate.
   - **Applications:** UI components, file format parsers.
   
   ![Factory Method UML](Puml/Creational/FactoryMethod.png)


3. **Abstract Factory**
   - **Purpose:** Create families of related objects without specifying concrete classes.
   - **Applications:** GUI toolkits, cross-platform applications.
   
   ![Abstract Factory UML](Puml/Creational/AbstractFactory.png)


4. **Builder**
   - **Purpose:** Separate the construction of a complex object from its representation.
   - **Applications:** Document generation, HTML/XML builders.
   
   ![Builder UML](Puml/Creational/Builder.png)

---

## Module 2: 🤝 Behavioral Patterns
**Goal:** Manage object behavior and communication.

### Lessons:

1. **Observer**
   - **Purpose:** Allow objects to react automatically to changes in another object.
   - **Applications:** Event systems, GUI buttons, notifications.
   
   ![Observer UML](Puml/Behavioral/Observer.png)


2. **Strategy**
   - **Purpose:** Define a family of algorithms and make them interchangeable.
   - **Applications:** Sorting algorithms, payment methods.
   
   ![Strategy UML](Puml/Behavioral/Strategy.png)


3. **Command**
   - **Purpose:** Encapsulate a request as an object.
   - **Applications:** Undo/redo functionality, macro recording.
   
   ![Command UML](Puml/Behavioral/Command.png)


4. **State**
   - **Purpose:** Change an object's behavior depending on its internal state.
   - **Applications:** Game player states, workflow systems.
   
   ![State UML](Puml/Behavioral/State.png)


5. **Template Method**
   - **Purpose:** Define the structure of an algorithm but let subclasses override steps.
   - **Applications:** Document processing, report generation.
   
   ![Template Method UML](Puml/Behavioral/TemplateMethod.png)


6. **Iterator**
   - **Purpose:** Provide a way to traverse a collection.
   - **Applications:** Collections, data structures.
   
   ![Iterator UML](Puml/Behavioral/Iterator.png)

---

## Module 3: 🧩 Structural Patterns
**Goal:** Flexibly combine objects and classes.

### Lessons:

1. **Adapter**
   - **Purpose:** Make interfaces compatible between otherwise incompatible classes.
   - **Applications:** Legacy code integration, API conversion.
   
   ![Adapter UML](Puml/Structural/Adapter.png)


2. **Decorator**
   - **Purpose:** Dynamically add behavior to an object.
   - **Applications:** UI components (scrollbars, borders), logging.
   
   ![Decorator UML](Puml/Structural/Decorator.png)


3. **Facade**
   - **Purpose:** Provide a simplified interface to a complex subsystem.
   - **Applications:** Libraries, system modules.
   
   ![Facade UML](Puml/Structural/Facade.png)


4. **Composite**
   - **Purpose:** Treat hierarchical objects uniformly.
   - **Applications:** Tree structures, UI layouts.
   
   ![Composite UML](Puml/Structural/Composite.png)


5. **Proxy**
   - **Purpose:** Control access to an object.
   - **Applications:** Lazy loading, security, caching.
   
   ![Proxy UML](Puml/Structural/Proxy.png)

---
