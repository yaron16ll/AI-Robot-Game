## Description
The project demonstrates **intelligent behavior (AI)** of computer-controlled characters within a **maze environment** containing rooms, corridors, ammo depots, health packs, and obstacles used as cover.  

Two teams compete against each other, each consisting of two fighters and a support carrier (who does not fight but provides ammunition and medical supplies).  

Each character has health points (HP) and an ammo inventory, and makes decisions based on its current state using a **Finite State Machine (FSM)**. Depending on the situation, characters can search for and engage enemies, retreat to survive, or request assistance from the support carrier.  

Characters are assigned random personalities (e.g., aggressive or cautious) which creates variety in behavior and team strategies.  

The combat system includes bullet shooting and grenade throwing (without friendly fire).  

Navigation within the maze is handled by the **A*** **pathfinding algorithm**, which adapts to a **dynamic safety map** that changes during battles.  

## Demo Video 
**Top Down View** 
[![Watch on Drive](https://img.shields.io/badge/Watch-Video-blue?logo=google-drive)](https://drive.google.com/file/d/1elboNYjhBmRCh4iJN6ciqsgSBRRw9t2S/view?usp=drive_link)

**Regular View**
[Watch Video](https://drive.google.com/file/d/1elboNYjhBmRCh4iJN6ciqsgSBRRw9t2S/view?usp=drive_link)
