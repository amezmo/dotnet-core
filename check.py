import xml.etree.ElementTree as ET
import sys
try:
    root = ET.parse('dotnet-core.csproj')
    version = root.findall('PropertyGroup/TargetFramework')[0].text
    if version:
        sys.stdout.write(version)
        sys.exit(0)
    sys.exit(1)
except Exception as e:
    sys.stdout.write(str(e))
    sys.exit(1)