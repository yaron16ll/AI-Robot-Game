## Description
The project demonstrates **intelligent behavior (AI)** of computer-controlled characters within a **maze environment** containing rooms, corridors, ammo depots, health packs, and obstacles used as cover.  

Two teams compete against each other, each consisting of two fighters and a support carrier (who does not fight but provides ammunition and medical supplies).  

Each character has health points (HP) and an ammo inventory, and makes decisions based on its current state using a **Finite State Machine (FSM)**. Depending on the situation, characters can search for and engage enemies, retreat to survive, or request assistance from the support carrier.  

Characters are assigned random personalities (e.g., aggressive or cautious) which creates variety in behavior and team strategies.  

The combat system includes bullet shooting and grenade throwing (without friendly fire).  

Navigation within the maze is handled by the **A*** **pathfinding algorithm**, which adapts to a **dynamic safety map** that changes during battles.  

![Image](https://github.com/user-attachments/assets/9148a0fd-45b6-4a97-b001-c940e5e8dbd8)

## Demo Video 
**Top Down View** 
[Watch Video](https://github.com/yaron16ll/AI-Robot-Game/releases/download/top/Up.mp4)

**Regular View**
[Watch Video](https://github.com/yaron16ll/AI-Robot-Game/releases/download/top/Down.mp4)
