<h1 align="center">SP2 Tool</h1>

<p align="center">A tool for extracting DirectDraw Surface textures and DirectX Shader Bytecode from Team Sonic Racing GPU.SP2 files.</p>

# Features
### DirectDraw Surface Extracting
- This tool allows for extracting DDS files from the `GPU.SP2` 'archives' in Team Sonic Racing.

### DirectX Shader Bytecode Extracting
- This tool also allows for extracting DXBC portions from the `GPU.SP2` 'archives,' these are output as O files, respective to the original file type used for DXBC.

# Project Goals
### SP2 Repacking
- This tool does allow for repacking `GPU.SP2` files, however, the method used is incomplete and is simply based off the `copy /b` command, which can produce undesirable results and may not work correctly with Team Sonic Racing. The offsets for where DirectDraw Surface textures and DirectX Shader Bytecode sections are may be hard coded.
