import os
from plantuml import PlantUML

# Path to your plantuml.jar (update if needed)
PLANTUML_JAR = os.path.expanduser('~/plantuml.jar')
# Or set to the path where you downloaded plantuml.jar

# Root directory containing all .puml files
ROOT = os.path.join(os.path.dirname(__file__), '.')

# Extensions and output format
PUML_EXT = '.puml'
IMG_EXT = '.png'

# Create PlantUML server instance (local jar)
server = PlantUML(url='http://www.plantuml.com/plantuml/img/')

# Walk through all subfolders and convert .puml to .png with same basename
for dirpath, _, filenames in os.walk(ROOT):
    for fname in filenames:
        if fname.endswith(PUML_EXT):
            puml_path = os.path.join(dirpath, fname)
            img_path = os.path.splitext(puml_path)[0] + IMG_EXT
            try:
                server.processes_file(puml_path, outfile=img_path)
                print(f"Generated: {img_path}")
            except Exception as e:
                print(f"Error processing {puml_path}: {e}")
                continue
