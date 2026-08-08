# Shop & Life Systems

A collection of gameplay systems developed for a mobile game prototype, focused on creating a modular in-game character shop and a configurable player life management system.
The systems were designed as reusable gameplay modules that can be integrated into different projects and gameplay loops.

## Used Technologies:

- Unity / C#
- Unity UI Toolkit
- GitHub

## My Contributions:

### Shop System

- Designed an in-game shop with character purchasing and selection.
- Created a data-driven character system using **Scriptable Objects**, allowing new skins to be added and configured without modifying the core shop logic.
- Implemented character states:
  - Locked
  - Unlocked
  - Selected
- Created a prototype save system for persisting:
  - player currency,
  - unlocked characters,
  - currently selected character.
- Built the Shop UI using **Unity UI Toolkit**.
- Implemented dynamic generation of character shop cells based on the available character data.

### Life System

- Designed a configurable life management system.
- Implemented health loss and life restoration.
- Used an **event-driven approach** to communicate health changes between gameplay and UI systems.
- Created a dynamically generated heart UI based on the configured number of lives.
- Implemented a Game Over flow with:
  - Retry
  - Watch Video / +1 Life
  - Main Menu
- Added gameplay pausing when all lives are lost.

## What I Learned:

- Working with **Unity UI Toolkit** and dynamically generated UI.
- Working with **Sprite Library and Sprite Resolver** for reusable 2D character animations.
- Strengthening my understanding of **data-driven programming** using Scriptable Objects.
- Strengthening my understanding of **event-driven programming** and reducing dependencies between systems.
- Improving my skills in **gameplay system architecture and system design**.
- Working with additive scene loading and independent scene modules.
