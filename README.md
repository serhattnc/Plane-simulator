# Endless Flight 🛩️
<img width="666" height="382" alt="Screenshot 2026-10-09 220226" src="https://github.com/user-attachments/assets/fbfcc56f-4fe0-41c3-b0dd-fd4ed326481a" />
<img width="667" height="371" alt="Screenshot 2026-10-09 220201" src="https://github.com/user-attachments/assets/983dbdaa-ef0f-4434-8aa6-f0fe474a9bc7" />

A simple 3D endless runner I built in Unity. You basically fly a plane, dodge whatever gets in your way, and collect as many coins as possible before you crash. 

## What's in it?
- **Infinite Map:** The ground generates dynamically as you fly forward and destroys the old parts behind you so the game doesn't lag.
- **Coin Rush:** Coins spawn randomly. Grab them to bump up your score.
- **Simple Controls:** Straightforward and smooth flight mechanics. 

## Controls
- **W / S** or **Up / Down Arrows:** Pitch up and down
- **A / D** or **Left / Right Arrows:** Steer left and right

## How to run it
1. Clone this repo to your PC:
   `git clone https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git`
2. Open the project using **Unity Hub**.
3. Navigate to the `Scenes` folder in the project window.
4. Double-click the main scene and hit the Play button.

## Project Layout
Trying to keep things somewhat organized:
- `Scripts/` - All the C# logic (Plane controller, map spawner, coin pickup).
- `Prefabs/` - Reusable game objects like the map tiles, coins, and the plane itself.
- `Models/` & `Materials/` - 3D stuff and colors.
